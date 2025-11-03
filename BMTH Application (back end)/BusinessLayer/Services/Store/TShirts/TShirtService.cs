using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Shirts;
using BusinessLayer.Exceptions;
using BusinessLayer.Helper.Validator.Store;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.DALMapper.StoreItems.Common;
using BusinessLayer.Mapper.DALMapper.StoreItems.Products;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Products;

namespace BusinessLayer.Services.Store.TShirts
{
    public class TShirtService : ITShirtService
    {
        private readonly ITShirtRepository _tShirtRepository;

        public TShirtService(ITShirtRepository repo)
        {
            _tShirtRepository = repo;
        }

        public List<StoreItemOverview> GetTShirtsByGender(string? gender)
        {
            var validatedGender = MerchandiseValidator.ValidateGender(gender);
            var models = _tShirtRepository.GetTShirtOverviewByGender(validatedGender);

            if (models == null)
            {
                throw new NotFoundException("No T-Shirts have been found for the selected gender");
            }

            return StoreItemOverviewDalMapper.ToOverviewDomainList(models);
        }

        public TShirt? GetShirtById(int? id)
        {
            ProductsModel? tShirtId = _tShirtRepository.GetById(id);

            if (tShirtId == null)
            {
                throw new NotFoundException($"No T-shirt found with ID {id}.");
            }
            return ProductsDalMapper.ToDomain(tShirtId);
        }
    }
}
