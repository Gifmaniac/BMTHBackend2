using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Products;
using Contracts.Enums.Store;
using DataLayer.Models.Store.Products;

namespace BusinessLayer.Interfaces.Store
{
    public interface IProductService
    {
        public List<StoreItemOverview> GetProductByGender(Genders gender);
        public Products GetProductById(int id);
        public Products UpdateStock(int productId, int variantId, int amount);

        public void DeleteProduct(int productId);
        public void DeleteVariants(int productId, int variantId);

    }
}
