using Contracts.Enums.Store;

namespace Contracts.Interfaces
{
    public interface ITShirtRepository
    {
        List<TShirt> GetShirtsByGender(Genders? gender = null);
    }
}
