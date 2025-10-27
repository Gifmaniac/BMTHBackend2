using Contracts.Enums.Store;

namespace BusinessLayer.Interfaces.Store.Common
{
    public interface IImageService
    {
        public string BuildImageUrl(string imageName, string category, string gender, string productName);
    }
}
