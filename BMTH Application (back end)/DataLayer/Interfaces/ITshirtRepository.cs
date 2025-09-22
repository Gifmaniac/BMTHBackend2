using Contracts.Enums.Store;
using Domain.Domains.Store.TShirts;

namespace Contracts.Interfaces
{
    public interface ITShirtRepository
    {
        List<TShirt> GetShirtsByGender(Genders? gender = null);
    }
}
