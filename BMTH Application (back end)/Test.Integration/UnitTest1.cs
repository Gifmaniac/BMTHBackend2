using BusinessLayer.Services;
using Contracts.Enums.Store;
using Contracts.Interfaces;
using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;
using Moq;

namespace Test.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var repo = new Mock<ITShirtRepository>();

            repo.Setup(r => r.GetTShirtByGender(It.IsAny<Genders?>()))
                .Returns(new List<TShirtModel>
                {
                    new TShirtModel()
                    {
                        Name = "Unit Test Shirt",
                        Gender = Genders.Men
                    }
                });

            var service = new TShirtService(repo.Object);
            var result = service.GetShirtsByGender(Genders.Men);

            Assert.Single(result);
        }
    }
}