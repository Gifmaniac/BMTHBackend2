using Contracts.Enums.Store;
using DataLayer.Repositories;
using Domain.Domains.Store.TShirts;

namespace BusinessLayer.Services
{
    public class TShirtService
    {
        private readonly TShirtRepository _repo;

        public TShirtService(TShirtRepository repo)
        {
            _repo = repo;
        }

        public List<TShirt> GetShirtsByGender(Genders? gender = null)
        {
            return _repo.GetShirtsByGender(gender);
        }
    }
}
