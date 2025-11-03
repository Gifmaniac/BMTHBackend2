using Contracts.Enums.Store;
using DataLayer.Models.Store.Common;
using DataLayer.Models.Store.Products;

namespace DataLayer.Interfaces
{
    public interface ITShirtRepository
    {
        public List<StoreOverviewModel> GetTShirtOverviewByGender(Genders gender);

        public ProductsModel? GetById(int? id);
    }
}
