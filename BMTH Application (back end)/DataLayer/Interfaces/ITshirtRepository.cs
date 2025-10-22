using Contracts.Enums.Store;
using DataLayer.Models.Store.Common;
using DataLayer.Models.Store.TShirts;

namespace DataLayer.Interfaces
{
    public interface ITShirtRepository
    {
        public List<StoreOverviewModel> GetTShirtOverviewByGender(Genders gender);

        public TShirtModel? GetById(int? id);
    }
}
