using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Mapper.ApiMapper.StoreItems.Common;
using BusinessLayer.Services.Store.Product;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Common;
using Moq;



namespace Test.Unit
{
    public class TShirtOverviewServiceTests
    {
        [Fact]
        public void GetTShirtOverviewByGender_ShouldReturnOverviewDtos_WhenTShirtsExist()
        {
            // Arrange
            var mockRepo = new Mock<IProductsRepository>();
            var dbModels = new List<StoreOverviewModel>
            {
                new StoreOverviewModel
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Price = 19.99m,
                    InStock = true,
                    Category = StoreCategoryType.TShirts,
                    Gender = Genders.Female
                },
                new StoreOverviewModel
                {
                    Id = 2,
                    Name = "Logo Tee",
                    Price = 24.99m,
                    InStock = false,
                    Category = StoreCategoryType.TShirts,
                    Gender = Genders.Men
                }
            };

            mockRepo.Setup(r => r.GetTShirtOverviewByGender(Genders.Men))
                    .Returns(dbModels);

            var service = new ProductService(mockRepo.Object);

            // Act
            var result = service.GetTShirtsByGender("Men");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Classic Tee", result[0].Name);
            Assert.True(result[0].InStock);
            Assert.Equal(StoreCategoryType.TShirts, result[0].Category);
        }

        [Fact]
        public void GetTShirtOverviewByGender_ShouldThrowNotFoundException_WhenNoTShirtsFound()
        {
            // Arrange
            var mockRepo = new Mock<IProductsRepository>();
            mockRepo.Setup(r => r.GetTShirtOverviewByGender(Genders.Female))
                    .Returns(new List<StoreOverviewModel>());

            var service = new ProductService(mockRepo.Object);

            // Act
            Action act = () => service.GetTShirtsByGender("Male");

            // Assert
            Assert.Throws<ValidationException>(act);
        }

        [Fact]
        public void ToOverviewDto_MapsPropertiesCorrectly_AndBuildsImageUrl()
        {
            // Arrange
            var model = new StoreItemOverview
            {
                Id = 1,
                Name = "BMTH Hoodie",
                Price = 99.99m,
                InStock = true,
                Category = StoreCategoryType.Hoodies,
                Gender = Genders.Men
            };

            var expectedUrl = "https://cdn.example.com/Hats/Male/GoldenCap.png";

            var mockImageService = new Mock<IImageService>();
            mockImageService
                .Setup(x => x.BuildImageUrl(
                    "BMTH Hoodie.png",
                    "Hoodies",
                    "Men",
                    "BMTH Hoodie"))
                .Returns(expectedUrl);

            // Act
            var dto = StoreItemOverviewApiMapper.ToOverviewDto(model, mockImageService.Object);

            // Assert
            Assert.Equal(model.Id, dto.Id);
            Assert.Equal(model.Name, dto.Name);
            Assert.Equal(model.Price, dto.Price);
            Assert.Equal(model.InStock, dto.InStock);
            Assert.Equal("Hoodies", dto.Category);
            Assert.Equal("Men", dto.Gender);
            Assert.Equal(expectedUrl, dto.ImageUrl);

            mockImageService.Verify(x => x.BuildImageUrl(
                "BMTH Hoodie.png",
                "Hoodies",
                "Men",
                "BMTH Hoodie"
            ), Times.Once);
        }
    }
}
