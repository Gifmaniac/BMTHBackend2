using BusinessLayer.Mapper.DALMapper.StoreItems.TShirts;
using Contracts.Enums.Store;
using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;


namespace Test.Unit
{
    public class TShirtDalMapperTests
    {
        [Fact]
        public void ToDomain_Should_Map_All_Properties_Correctly()
        {
            // Arrange
            var models = new List<TShirtModel>
            {
                new TShirtModel
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Price = 19.99m,
                    InStock = true,
                    Gender = Genders.Men,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<TShirtVariantModel>
                    {
                        new TShirtVariantModel 
                            { VariantId = 101, Color = "Black", Size = Sizes.M, Quantity = 4 },
                        new TShirtVariantModel 
                            { VariantId = 102, Color = "Red", Size = Sizes.L, Quantity = 0 }
                    }
                },

                new TShirtModel
                {
                    Id = 2,
                    Name = "Retro Tee",
                    Price = 24.99m,
                    InStock = true,
                    Gender = Genders.Women,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<TShirtVariantModel>
                    {
                        new TShirtVariantModel 
                            { VariantId = 103, Color = "Orange", Size = Sizes.S, Quantity = 3 },
                        new TShirtVariantModel 
                            { VariantId = 104, Color = "White", Size = Sizes.XL, Quantity = 2 },
                    }
                }
                
            };

            // Act
            var result = TShirtDalMapper.ToDomainList(models);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Classic Tee", result[0].Name);
            Assert.Equal(24.99m, result[1].Price);
            Assert.Equal(Genders.Women, result[1].Gender);
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
            var domain = new List<TShirt>
            {
                new TShirt
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Price = 19.99m,
                    InStock = true,
                    Gender = Genders.Men,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<TShirtVariant>
                    {
                        new TShirtVariant 
                            { VariantId = 101, TShirtId = 1, Color = "Black", Size = Sizes.XXL, Quantity = 6 },
                        new TShirtVariant 
                            { VariantId = 102, TShirtId = 1, Color = "Green", Size = Sizes.L, Quantity = 2 }
                    }
                },

                new TShirt
                {
                    Id = 2,
                    Name = "Retro Tee",
                    Price = 24.99m,
                    InStock = true,
                    Gender = Genders.Women,
                    Category = StoreCategoryType.TShirts,
                    Material = "Cotton",
                    Variants = new List<TShirtVariant>
                    {
                        new TShirtVariant
                            { VariantId = 103, TShirtId = 2, Color = "Purple", Size = Sizes.S, Quantity = 0 },
                        new TShirtVariant
                            { VariantId = 104, TShirtId = 2, Color = "Blue", Size = Sizes.XL, Quantity = 1 }
                    }
                }
            };

            // Act
            var result = TShirtDalMapper.ToEntityList(domain);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal("Classic Tee", result[0].Name);
            Assert.Equal(24.99m, result[1].Price);
            Assert.Equal(Genders.Women, result[1].Gender);
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
