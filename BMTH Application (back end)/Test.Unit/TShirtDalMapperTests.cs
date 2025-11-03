using BusinessLayer.Domain.Store.Products;
using BusinessLayer.Mapper.DALMapper.StoreItems.Product;
using Contracts.Enums.Store;
using DataLayer.Models.Store.Products;


namespace Test.Unit
{
    public class TShirtDalMapperTests
    {
        [Fact]
        public void ToDomain_Should_Map_All_Properties_Correctly()
        {
            // Arrange
            var models = new List<ProductsModel>
            {
                new ProductsModel
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Price = 19.99m,
                    InStock = true,
                    Gender = Genders.Men,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<ProductsVariantsModel>
                    {
                        new ProductsVariantsModel()
                            { VariantId = 101, ProductModelId = 1, Color = "Black", Size = Sizes.M, Quantity = 4 },
                        new ProductsVariantsModel
                            () { VariantId = 102, ProductModelId = 1, Color = "Red", Size = Sizes.L, Quantity = 0 }
                    }
                },

                new ProductsModel
                {
                    Id = 2,
                    Name = "Retro Tee",
                    Price = 24.99m,
                    InStock = true,
                    Gender = Genders.Female,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<ProductsVariantsModel>
                    {
                        new ProductsVariantsModel
                            () { VariantId = 103, ProductModelId = 2, Color = "Orange", Size = Sizes.S, Quantity = 3 },
                        new ProductsVariantsModel
                            () { VariantId = 104, ProductModelId = 2, Color = "White", Size = Sizes.XL, Quantity = 2 },
                    }
                }

            };

            // Act
            var result = ProductDalMapper.ToDomainList(models);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Classic Tee", result[0].Name);
            Assert.Equal(24.99m, result[1].Price);
            Assert.Equal(Genders.Female, result[1].Gender);
            Assert.All(result, shirt => Assert.Equal(StoreCategoryType.TShirts, shirt.Category));
            Assert.Equal("Cotton", result[0].Material);

            Assert.Equal(2, result[0].Variants.Count);
            Assert.Equal(2, result[1].Variants.Count);
            Assert.Equal("White", result[1].Variants[1].Color);
            Assert.Equal(Sizes.L, result[0].Variants[1].Size);
            Assert.False(result[0].Variants[1].InStock);
        }


        [Fact]
        public void ToEntityList_Should_Map_All_Properties_Correctly()
        {
            // Arrange
            var domain = new List<Products>
            {
                new Products
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Price = 19.99m,
                    InStock = true,
                    Gender = Genders.Men,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<ProductsVariants>
                    {
                        new ProductsVariants
                            { VariantId = 101, ProductModelId = 1, Color = "Black", Size = Sizes.XXL, Quantity = 6 },
                        new ProductsVariants
                            { VariantId = 102, ProductModelId = 1, Color = "Green", Size = Sizes.L, Quantity = 2 }
                    }
                },

                new Products
                {
                    Id = 2,
                    Name = "Retro Tee",
                    Price = 24.99m,
                    InStock = true,
                    Gender = Genders.Female,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<ProductsVariants>
                    {
                        new ProductsVariants
                            { VariantId = 103, ProductModelId = 2, Color = "Purple", Size = Sizes.S, Quantity = 0 },
                        new ProductsVariants
                            { VariantId = 104, ProductModelId = 2, Color = "Blue", Size = Sizes.XL, Quantity = 1 }
                    }
                }
            };

            // Act
            var result = ProductDalMapper.ToEntityList(domain);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Classic Tee", result[0].Name);
            Assert.Equal(24.99m, result[1].Price);
            Assert.Equal(Genders.Female, result[1].Gender);
            Assert.All(result, shirt => Assert.Equal(StoreCategoryType.TShirts, shirt.Category));
            Assert.Equal("Cotton", result[0].Material);
            Assert.Equal(2, result[0].Variants.Count);
            Assert.Equal(2, result[1].Variants.Count);
            Assert.Equal("Blue", result[1].Variants[1].Color);
            Assert.Equal(Sizes.L, result[0].Variants[1].Size);
            Assert.Equal(0, result[1].Variants[0].Quantity);
        }
    }
}
