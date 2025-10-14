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

            List<TShirt> domainModels = MapToDomain(models);

            foreach (TShirt shirt in domainModels)
            {  
                if (shirt.Variants.Sum(v => v.Quantity) == 0)
                    shirt.InStock = false;
            }
            return domainModels;
        }
    }
}
