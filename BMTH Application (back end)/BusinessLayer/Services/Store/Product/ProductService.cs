using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Products;
using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Store;
using BusinessLayer.Mapper.DALMapper.StoreItems.Common;
using BusinessLayer.Mapper.DALMapper.StoreItems.Product;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Products;


namespace BusinessLayer.Services.Store.Product
{
    public class ProductService(IProductsRepository productsRepository) : IProductService
    {
        private readonly IProductsRepository _productsRepository = productsRepository;

        public List<StoreItemOverview> GetProductByGender(Genders gender)
        {

            var models = productsRepository.GetProductOverviewByGender(gender);

            if (models == null || models.Count == 0)
            {
                throw new NotFoundException($"No products found for gender: {gender}");
            }

            return StoreItemOverviewDalMapper.ToOverviewDomainList(models);
        }

        public Products GetProductById(int productId)
        {
            ProductsModel? productById = productsRepository.GetById(productId);

            if (productById == null)
            {
                throw new NotFoundException($"No product found with ID {productId}.");
            }
            return ProductDalMapper.ToDomain(productById);
        }

        public Products? UpdateStock(int productId, int variantId, int amount)
        {
            ProductsModel? productById = productsRepository.GetById(productId);

            if (productById == null)
            {
                throw new NotFoundException($"No product found with ID {productId}.");
            }

            Products productDomain = ProductDalMapper.ToDomain(productById);

            var variant = productDomain.Variants.FirstOrDefault(v => v.VariantId == variantId);

            if (variant == null)
            {
                throw new NotFoundException($"No variant was found with ID {variantId}");
            }

            int newQuantity = variant.Quantity + amount;
            if (newQuantity < 0)
            {
                throw new ValidationException(
                    $"Updating stock for variant {variantId} would result in negative quantity.");
            }

            variant.Quantity += amount;

            var updatedProductModel = ProductDalMapper.ToDetailEntity(productDomain);

            productsRepository.UpdateStock(updatedProductModel);

            return productDomain;
        }

    }
}
