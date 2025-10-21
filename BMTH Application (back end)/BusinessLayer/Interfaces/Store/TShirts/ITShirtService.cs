using BusinessLayer.Domain.Store.Shirts;
using Contracts.Enums.Store;

namespace BusinessLayer.Interfaces.Store.TShirts
{
    public interface ITShirtService
    {
        public List<TShirt> GetTShirtsByGender(Genders? gender = null);
    }
}
