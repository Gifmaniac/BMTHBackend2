using Contracts.Enums.Store;
using DataLayer.Models.Store.Common;
using DataLayer.Models.Store.Products;

namespace DataLayer.Interfaces
{
    public interface IProductsRepository
    {
        public List<StoreOverviewModel> GetTShirtOverviewByGender(Genders gender);

        public ProductsModel? GetById(int? id);
    }
}
