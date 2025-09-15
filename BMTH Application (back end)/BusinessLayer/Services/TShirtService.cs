using BusinessLayer.Entities.Store.TShirts;
using BusinessLayer.Mappers.Store;
using Contracts.Enums.Store;
using DataLayer.Repositories;

namespace BusinessLayer.Services
{
    public class TShirtService
    {
        private readonly TShirtRepository _repo;

        public TShirtService(TShirtRepository repo)
        {
            _repo = repo;
        }

        public List<TShirt> GetAllTShirts(Genders? gender = null)
        {
            var shirtDtos = _repo.MakeShirts();

            var entities = shirtDtos.Select(TShirtMapper.ToEntity);

            if (gender.HasValue)
                entities = entities.Where(s => s.Gender == gender.Value || s.Gender == Genders.Unisex);

            return entities.ToList();
        }

    }
}
