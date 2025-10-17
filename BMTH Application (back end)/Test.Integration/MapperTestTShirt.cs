using BusinessLayer.Services;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Models.Store.TShirts;
using Moq;

namespace Test.Integration
{
    public class MapperTestTShirt
    {
        [Fact]
        public void Should_Map_From_Model_To_Domain()
        {
            // Arrange
            var repo = new Mock<ITShirtRepository>();

            repo.Setup(r => r.GetTShirtByGender(It.IsAny<Genders?>()))
                .Returns(new List<TShirtModel>
                {
                    new TShirtModel()
                    {
                        Name = "Unit Test Shirt",
                        Gender = Genders.Men,
                        Material = "Leather"
                    }
                });

            
            var service = new TShirtService(repo.Object);

            // Act
            var result = service.GetTShirtsByGender(Genders.Men);

            // Assert
            Assert.Single(result);
            Assert.Equal("Unit Test Shirt", result[0].Name);
        }
    }
}