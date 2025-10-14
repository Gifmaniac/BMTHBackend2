using Contracts.Enums.Store;
using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;

namespace Contracts.Interfaces
{
    public interface ITShirtRepository
    {
        public List<TShirtModel> GetTShirtByGender(Genders? gender = null);
    }
}
