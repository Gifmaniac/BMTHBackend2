using Contracts.Enums.Store;
using Domain.Domains.Store.TShirts;

namespace BusinessLayer.Interfaces.Store.TShirts
{
    public interface ITShirtService
    {
        public List<TShirt> GetTShirtsByGender(Genders? gender = null);
    }
}
