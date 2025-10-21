using BusinessLayer.Interfaces.Store.TShirts;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Models.Store.TShirts;
using Moq;

namespace Test.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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

            var service = new ITShirtService(repo);

            // Act
            var result = service.GetTShirtsByGender(Genders.Men);

            // Assert
            Assert.Single(result);
            Assert.Equal("Unit Test Shirt", result[0].Name);
        }
    }
}