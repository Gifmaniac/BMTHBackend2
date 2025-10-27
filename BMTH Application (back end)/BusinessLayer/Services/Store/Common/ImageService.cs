using BusinessLayer.Helper;
using BusinessLayer.Interfaces.Store.Common;
using CloudinaryDotNet;
using Contracts.Enums.Store;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Services.Store.Common
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public ImageService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }
        public string BuildImageUrl(string imageName, string category, string gender, string productName)
        {
            var categoryFolder = SwitchCaseHelper.SetStoreCategoryType(category);
            var genderFolder = SwitchCaseHelper.SetGender(gender);
            var folderPath = $"Store/{categoryFolder}/{genderFolder}/{productName}";

            return _cloudinary.Api.UrlImgUp
                .Transform(new Transformation()
                    .Quality("auto")
                    .FetchFormat("auto")
                    .Effect("sharpen"))
                .BuildUrl($"{folderPath}/{imageName}");
        }

        //TODO: Make the user able to upload a image.

        //TODO: Make the user able to update/ remove images.

    }
}
