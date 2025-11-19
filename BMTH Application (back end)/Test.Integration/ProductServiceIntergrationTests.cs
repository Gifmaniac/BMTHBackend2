using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using DataLayer.Context;
using DataLayer.Repositories.Store.Products;
using BusinessLayer.Services.Store.Product;
using BusinessLayer.Exceptions;
using Contracts.Enums.Store;
using DataLayer.Models.Store.Products;

namespace Test.Integration;

public class ProductServiceIntegrationTests
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

    // TEST 1 — GetShirtById: SUCCESS
    [Fact]
    public void GetShirtById_ReturnsProduct_WhenExists()
    {
        // Arrange
        var db = CreateTestDb();

        var product = new ProductsModel
        {
            Id = 1,
            Name = "BMTH Shirt",
            Price = 50,
            Category = StoreCategoryType.TShirts,
            Gender = Genders.Men,
            Material = "Cotton",
            Variants = new List<ProductsVariantsModel>
            {
                new ProductsVariantsModel
                {
                    VariantId = 100,
                    ProductModelId = 1,
                    Color = Color.Black,
                    Size = Sizes.L,
                    Quantity = 10
                }
            }
        };

        db.Products.Add(product);
        db.SaveChanges();

        var loggerRepo = Mock.Of<ILogger<ProductsRepository>>();
        var repo = new ProductsRepository(db, loggerRepo);

        var service = new ProductService(repo);

        // Act
        var result = service.GetShirtById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("BMTH Shirt", result.Name);
        Assert.Equal("Cotton", result.Material);

        Assert.Single(result.Variants);
        Assert.Equal(Color.Black, result.Variants.First().Color);
        Assert.Equal(Sizes.L, result.Variants.First().Size);
        Assert.True(result.Variants.First().InStock);

        db.Database.CloseConnection();
    }

    // TEST 2 — GetShirtById: NOT FOUND
    [Fact]
    public void GetShirtById_ThrowsNotFound_WhenMissing()
    {
        // Arrange
        var db = CreateTestDb();

        var loggerRepo = Mock.Of<ILogger<ProductsRepository>>();
        var repo = new ProductsRepository(db, loggerRepo);


        var service = new ProductService(repo);

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.GetShirtById(777));

        db.Database.CloseConnection();
    }

    // TEST 3 — GetTShirtsByGender: RETURNS LIST
    [Fact]
    public void GetTShirtsByGender_ReturnsCorrectList()
    {
        // Arrange
        var db = CreateTestDb();

        var maleShirt = new ProductsModel
        {
            Id = 1,
            Name = "Male Shirt",
            Price = 30,
            Category = StoreCategoryType.TShirts,
            Gender = Genders.Men,
            Material = "Cotton",
            Variants = new List<ProductsVariantsModel>
            {
                new ProductsVariantsModel
                {
                    VariantId = 10,
                    ProductModelId = 1,
                    Color = Color.White,
                    Size = Sizes.M,
                    Quantity = 3
                }
            }
        };

        var femaleShirt = new ProductsModel
        {
            Id = 2,
            Name = "Female Shirt",
            Price = 30,
            Category = StoreCategoryType.TShirts,
            Gender = Genders.Female,
            Material = "Cotton",
            Variants = new List<ProductsVariantsModel>
            {
                new ProductsVariantsModel
                {
                    VariantId = 20,
                    ProductModelId = 2,
                    Color = Color.Red,
                    Size = Sizes.S,
                    Quantity = 3
                }
            }
        };

        db.Products.AddRange(maleShirt, femaleShirt);
        db.SaveChanges();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act
        var result = service.GetTShirtsByGender("Men");


        // Assert
        Assert.Single(result);
        Assert.Equal("Male Shirt", result[0].Name);
        Assert.True(result[0].InStock);

        db.Database.CloseConnection();
    }


    // TEST 4 — GetTShirtsByGender: THROWS WHEN EMPTY
    [Fact]
    public void GetTShirtsByGender_ThrowsNotFound_WhenEmpty()
    {
        // Arrange
        var db = CreateTestDb();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act & Assert
        Assert.Throws<ValidationException>(() => service.GetTShirtsByGender("Women"));

        db.Database.CloseConnection();
    }

    // TEST 5 — GetTShirtsByGender: INVALID GENDER
    [Fact]
    public void GetTShirtsByGender_Throws_ValidationError_OnInvalidGender()
    {
        // Arrange
        var db = CreateTestDb();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act & Assert
        Assert.Throws<ValidationException>(() => service.GetTShirtsByGender("Alain"));

        db.Database.CloseConnection();
    }
}