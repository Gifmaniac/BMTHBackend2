using BusinessLayer.Exceptions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DataLayer.Context;
using DataLayer.Repositories.Store.Orders;
using BusinessLayer.Services.Store.Orders;
using Contracts.Enums.Store;
using Contracts.DTOs.StoreItems.Orders;
using Contracts.Enums.User;
using DataLayer.Models.Store.Orders;
using DataLayer.Models.User;


namespace Test.Integration;

public class OrderServiceIntegrationTests
{
    private StoreDbContext CreateTestDb()
    {
        var options = new DbContextOptionsBuilder<StoreDbContext>()
            .UseSqlite("Filename=:memory:")
            .Options;

        var db = new StoreDbContext(options);
        db.Database.OpenConnection();
        db.Database.EnsureCreated();
        return db;
    }

    // Helper to stop SQLite FK failure
    private void AddUser(StoreDbContext db, int id)
    {
        var user = new UserModel
        {
            UserId = id,
            Email = "test@example.com",
            Password = "hash",
            FirstName = "Test",
            LastName = "Test",
            CreatedAt = DateTime.UtcNow,
            Orders = new List<OrderModel>(),
            Role = Roles.User
        };

        db.Users.Add(user);
        db.SaveChanges();
    }

    // TEST 1 — Success
    [Fact]
    public async Task PostUserOrder_SavesOrder_AndReturnsOrderId()
    {
        // Arrange
        var db = CreateTestDb();
        AddUser(db, 10);

        var repo = new OrderRepository(db);
        var service = new OrderService(repo);

        var dto = new PostOrderDto
        {
            UserId = 10,
            Items = new List<PostOrderItemDto>
            {
                new PostOrderItemDto
                {
                    ProductId = 1,
                    VariantId = 101,
                    Quantity = 2,
                    Color = Color.Black.ToString(),
                    Size = Sizes.L.ToString(),
                }
            }
        };

        // Act
        var orderId = await service.PostUserOrder(dto);

        // Assert
        Assert.True(orderId > 0);

        var saved = db.Orders
            .Include(o => o.Items)
            .First(o => o.OrderId == orderId);

        Assert.Equal(10, saved.UserId);
        Assert.Equal(OrderStatus.Pending, saved.Status);
        Assert.Single(saved.Items);

        db.Database.CloseConnection();
    }

    // TEST 2 — Empty items should throw
    [Fact]
    public async Task PostUserOrder_Throws_WhenItemsEmpty()
    {
        // Arrange
        var db = CreateTestDb();
        AddUser(db, 5);

        var repo = new OrderRepository(db);
        var service = new OrderService(repo);

        var dto = new PostOrderDto
        {
            UserId = 5,
            Items = new List<PostOrderItemDto>() // invalid
        };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => service.PostUserOrder(dto));

        db.Database.CloseConnection();
    }

    // TEST 3 — Invalid quantity should throw
    [Fact]
    public async Task PostUserOrder_Throws_WhenQuantityInvalid()
    {
        // Arrange
        var db = CreateTestDb();
        AddUser(db, 7);

        var repo = new OrderRepository(db);
        var service = new OrderService(repo);

        var dto = new PostOrderDto
        {
            UserId = 7,
            Items = new List<PostOrderItemDto>()
            {
                new PostOrderItemDto
                {
                    ProductId = 2,
                    VariantId = 202,
                    Quantity = 0, // invalid
                    Color = Color.Red.ToString(),
                    Size = Sizes.S.ToString()
                }
            }
        };

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => service.PostUserOrder(dto));

        db.Database.CloseConnection();
    }
}
