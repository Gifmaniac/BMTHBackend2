using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataLayer.Context;
using DataLayer.Repositories.Store.Products;
using BusinessLayer.Services.Store.Product;
using BusinessLayer.Exceptions;
using Contracts.Enums.Store;
using DataLayer.Models.Store.Products;
using Moq;
using Contracts.DTOs.Responses;

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

    // TEST 1 — GetProductById: SUCCESS
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
            InStock = true,
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
        var result = service.GetProductById(1);

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

    // TEST 2 — GetProductById: NOT FOUND
    [Fact]
    public void GetShirtById_ThrowsNotFound_WhenMissing()
    {
        // Arrange
        var db = CreateTestDb();

        var loggerRepo = Mock.Of<ILogger<ProductsRepository>>();
        var repo = new ProductsRepository(db, loggerRepo);


        var service = new ProductService(repo);

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.GetProductById(777));

        db.Database.CloseConnection();
    }

    // TEST 3 — GetProductByGender: RETURNS LIST
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
            InStock = true,
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
            InStock = true,
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
        var result = service.GetProductByGender(Genders.Men);


        // Assert
        Assert.Single(result);
        Assert.Equal("Male Shirt", result[0].Name);
        Assert.True(result[0].InStock);

        db.Database.CloseConnection();
    }


    // TEST 4 — GetProductByGender: THROWS WHEN EMPTY
    [Fact]
    public void GetTShirtsByGender_ThrowsNotFound_WhenEmpty()
    {
        // Arrange
        var db = CreateTestDb();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act + Assert
        Assert.Throws<NotFoundException>(() => service.GetProductByGender(Genders.Men));

        db.Database.CloseConnection();
    }

    // TEST 5 — UpdateStock: PRODUCT NOT FOUND
    [Fact]
    public void AddStock_ThrowsNotFound_WhenProductMissing()
    {
        // Arrange
        var db = CreateTestDb();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.UpdateStock(productId: 999, variantId: 1, amount: 5));

        db.Database.CloseConnection();
    }

    // TEST 6 — UpdateStock: VARIANT NOT FOUND
    [Fact]
    public void AddStock_ThrowsNotFound_WhenVariantMissing()
    {
        // Arrange
        var db = CreateTestDb();

        var product = new ProductsModel
        {
            Id = 1,
            Name = "Test Shirt",
            Price = 40,
            Category = StoreCategoryType.TShirts,
            Gender = Genders.Men,
            Material = "Cotton",
            InStock = true,
            Variants = new List<ProductsVariantsModel>() // no variants
        };

        db.Products.Add(product);
        db.SaveChanges();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.UpdateStock(productId: 1, variantId: 555, amount: 2));

        db.Database.CloseConnection();
    }

    // TEST 7— UpdateStock: SUCCESS
    [Fact]
    public void AddStock_UpdatesVariantQuantity_WhenValid()
    {
        // Arrange
        var db = CreateTestDb();

        var product = new ProductsModel
        {
            Id = 1,
            Name = "Stock Test Shirt",
            Price = 40,
            Category = StoreCategoryType.TShirts,
            Gender = Genders.Men,
            Material = "Cotton",
            InStock = true,
            Variants = new List<ProductsVariantsModel>
            {
                new ProductsVariantsModel
                {
                    VariantId = 10,
                    ProductModelId = 1,
                    Color = Color.Black,
                    Size = Sizes.L,
                    Quantity = 5
                }
            }
        };

        db.Products.Add(product);
        db.SaveChanges();

        var repo = new ProductsRepository(db, Mock.Of<ILogger<ProductsRepository>>());
        var service = new ProductService(repo);

        // Act
        var updated = service.UpdateStock(productId: 1, variantId: 10, amount: 4);

        // Assert (domain object)
        Assert.NotNull(updated);
        Assert.Single(updated.Variants);
        Assert.Equal(9, updated.Variants.First().Quantity);

        // Assert (database)
        var dbVariant = db.Products
            .Include(p => p.Variants)
            .First(p => p.Id == 1)
            .Variants.First(v => v.VariantId == 10);

        Assert.Equal(9, dbVariant.Quantity);

        db.Database.CloseConnection();
    }
}