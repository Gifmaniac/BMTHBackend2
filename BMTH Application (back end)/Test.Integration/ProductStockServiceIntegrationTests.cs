//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using DataLayer.Context;
//using DataLayer.Repositories.Store.Products;
//using BusinessLayer.Services.Store.Products;
//using DataLayer.Models.Store.Products;
//using Contracts.Enums.Store;
//using BusinessLayer.Exceptions;

//namespace Test.Integration;

//public class ProductStockServiceIntegrationTests
//{
//    private StoreDbContext CreateTestDb()
//    {
//        var options = new DbContextOptionsBuilder<StoreDbContext>()
//            .UseSqlite("Filename=:memory:")
//            .Options;

//        var db = new StoreDbContext(options);
//        db.Database.OpenConnection();
//        db.Database.EnsureCreated();
//        return db;
//    }

//    private ProductsModel AddProductWithVariant(StoreDbContext db, int productId, int variantId, int quantity = 5)
//    {
//        var product = new ProductsModel
//        {
//            Id = productId,
//            Name = "Test Shirt",
//            Material = "Cotton",
//            Gender = Genders.Men,
//            Variants = new List<ProductsVariantsModel>
//            {
//                new ProductsVariantsModel
//                {
//                    VariantId = variantId,
//                    ProductModelId = productId,
//                    Color = Color.Black,
//                    Size = Sizes.M,
//                    Quantity = quantity
//                }
//            }
//        };

//        db.Products.Add(product);
//        db.SaveChanges();
//        return product;
//    }

//    // TEST 1 — Success: stock increments correctly
//    [Fact]
//    public void AddStock_UpdatesQuantity_WhenValid()
//    {
//        // Arrange
//        var db = CreateTestDb();
//        AddProductWithVariant(db, 1, 100, quantity: 5);

//        var repo = new ProductsRepository(db);
//        var service = new ProductsService(repo);

//        // Act
//        var result = service.UpdateStock(productId: 1, variantId: 100, amount: 3);

//        // Assert
//        Assert.NotNull(result);

//        var updated = db.Products
//            .Include(p => p.Variants)
//            .First(p => p.Id == 1);

//        Assert.Equal(8, updated.Variants.First().Quantity);

//        db.Database.CloseConnection();
//    }

//    // TEST 2 — Product not found should throw NotFoundException
//    [Fact]
//    public void AddStock_Throws_WhenProductNotFound()
//    {
//        // Arrange
//        var db = CreateTestDb();

//        var repo = new ProductsRepository(db);
//        var service = new ProductsService(repo);

//        // Act & Assert
//        Assert.Throws<NotFoundException>(() =>
//            service.UpdateStock(productId: 999, variantId: 1, amount: 1)
//        );

//        db.Database.CloseConnection();
//    }

//    // TEST 3 — Variant not found should throw NotFoundException
//    [Fact]
//    public void AddStock_Throws_WhenVariantNotFound()
//    {
//        // Arrange
//        var db = CreateTestDb();
//        AddProductWithVariant(db, 1, 100, quantity: 5);

//        var repo = new ProductsRepository(db);
//        var service = new ProductsService(repo);

//        // Act & Assert
//        Assert.Throws<NotFoundException>(() =>
//            service.UpdateStock(productId: 1, variantId: 999, amount: 1)
//        );

//        db.Database.CloseConnection();
//    }
//}
