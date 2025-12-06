using Xunit;
using Microsoft.Extensions.Configuration;
using BusinessLayer.Services.Store.Common;
using Xunit.Abstractions;

namespace Test.Unit
{
    public class ImageServiceTest
    {
        private readonly ITestOutputHelper _output;

        public ImageServiceTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void BuildImageUrl_ShouldReturnValidCloudinaryUrl()
        {
            // Arrange
            var inMemorySettings = new Dictionary<string, string?>
            {
                {"Cloudinary:CloudName", "demo"},
                {"Cloudinary:ApiKey", "1234567890"},
                {"Cloudinary:ApiSecret", "abcdefg"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var imageService = new ImageService(configuration);

            // Act
            var result = imageService.BuildImageUrl(
                "BMTHTShirtGlitch1",
                "TShirts",
                "Men",
                "BMTHTShirtGlitch1"
            );

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Store/TShirts/Men/BMTHTShirtGlitch1/BMTHTShirtGlitch1", result);
            _output.WriteLine("Generated Cloudinary URL: " + result);
        }
    }
}
