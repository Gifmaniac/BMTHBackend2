using BusinessLayer.Domain.Store.Shirts;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.DALMapper.StoreItems.TShirts;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Models.Store.TShirts;

namespace BusinessLayer.Services
{
    public class TShirtService : ITShirtService
    {
        private readonly ITShirtRepository _tShirtRepository;

        public TShirtService(ITShirtRepository repo)
        {
            _tShirtRepository = repo;
        }

        public List<TShirt> GetTShirtsByGender(Genders? gender = null)
        {
            List<TShirtModel> models = _tShirtRepository.GetTShirtByGender(gender);

            return TShirtDalMapper.ToDomainList(models);
        }

        public TShirt GetShirtById(int id)
        {
            TShirtModel tShirtId = _tShirtRepository.GetById(id);

            return TShirtDalMapper.ToDomain(tShirtId);
        }
    }
}
