using BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts;
using Contracts.Enums.Store;
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

        public List<TShirt> GetShirtsByGender(Genders? gender = null)
        {
            var entities = _tShirtRepository.GetShirtsByGender(gender);

            var domainModels = entities.Select(TShirtMapper.ToDetailsDto(tshirt));

        }
    }
}
