using BusinessLayer.Mapper.DALMapper.StoreItems.TShirts;
using Contracts.Enums.Store;
using DataLayer.Models.Store.TShirts;
using DataLayer.Repositories;
using Domain.Domains.Store.TShirts;

namespace BusinessLayer.Services
{
    public class TShirtService
    {
        private readonly TShirtRepository _tShirtRepository;

        public TShirtService(TShirtRepository repo)
        {
            _tShirtRepository = repo;
        }
        private static List<TShirt> MapToDomain(List<TShirtModel> models)
        {
            return models.Select(TShirtDalMapper.ToDomain).ToList();
        }


        public List<TShirt> GetTShirtsByGender(Genders? gender = null)
        {
            List<TShirtModel> models = _tShirtRepository.GetTShirtByGender(gender);

            return TShirtDalMapper.ToDomainList(models);
        }
    }
}
