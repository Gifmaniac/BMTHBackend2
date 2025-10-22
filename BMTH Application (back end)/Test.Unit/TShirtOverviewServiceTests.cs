using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Exceptions;
using BusinessLayer.Services;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Common;
using Moq;
using Xunit;



namespace Test.Unit
{
    public class TShirtOverviewServiceTests
    {
        [Fact]
        public void GetTShirtOverviewByGender_ShouldReturnOverviewDtos_WhenTShirtsExist()
        {
            // Arrange
            var mockRepo = new Mock<ITShirtRepository>();
            var dbModels = new List<StoreOverviewModel>
            {
                new StoreOverviewModel
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Price = 19.99m,
                    InStock = true,
                    Category = StoreCategoryType.TShirts
                },
                new StoreOverviewModel
                {
                    Id = 2,
                    Name = "Logo Tee",
                    Price = 24.99m,
                    InStock = false,
                    Category = StoreCategoryType.TShirts
                }
            };

            mockRepo.Setup(r => r.GetTShirtOverviewByGender(Genders.Men))
                    .Returns(dbModels);

            var service = new TShirtService(mockRepo.Object, null!);

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
            var mockRepo = new Mock<ITShirtRepository>();
            mockRepo.Setup(r => r.GetTShirtOverviewByGender(Genders.Men))
                    .Returns(new List<StoreOverviewModel>());

            var service = new TShirtService(mockRepo.Object, null!);

            // Act
            Action act = () => service.GetTShirtsByGender("Men");

            // Assert
            Assert.Throws<NotFoundException>(act);
        }
    }
}
