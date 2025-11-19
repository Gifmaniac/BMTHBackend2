using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Products;
using BusinessLayer.Exceptions;
using BusinessLayer.Helper.Store;
using BusinessLayer.Interfaces.Store.TShirts;
using BusinessLayer.Mapper.DALMapper.StoreItems.Common;
using BusinessLayer.Mapper.DALMapper.StoreItems.Product;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Products;

namespace BusinessLayer.Services.Store.Product
{
    public class ProductService : ITShirtService
    {
        private readonly IProductsRepository _tShirtRepository;

        public ProductService(IProductsRepository repo)
        {
            _tShirtRepository = repo;
        }

        public List<StoreItemOverview> GetTShirtsByGender(string? gender)
        {
            var validatedGender = MerchandiseValidator.ValidateGender(gender);
            var models = _tShirtRepository.GetTShirtOverviewByGender(validatedGender);

            return StoreItemOverviewDalMapper.ToOverviewDomainList(models);
        }

        public Products? GetShirtById(int? id)
        {
            ProductsModel? tShirtId = _tShirtRepository.GetById(id);

            if (tShirtId == null)
            {
                throw new NotFoundException($"No T-shirt found with ID {id}.");
            }
            return ProductDalMapper.ToDomain(tShirtId);
        }
    }
}
