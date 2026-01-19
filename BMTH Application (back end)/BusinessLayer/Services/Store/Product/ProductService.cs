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
        public Products GetProductById(int id)
        {
            ProductsModel? productById = _productsRepository.GetById(id);

            if (productById == null)
            {
                throw new NotFoundException($"No product found with ID {id}.");
            }
            return ProductDalMapper.ToDomain(productById);
        }

        private static ProductsVariants GetVariants(Products product, int variantId)
        {
            var variants = product.Variants.FirstOrDefault(v => v.VariantId == variantId);

            if (variants == null)
            {
                throw new NotFoundException($"No variant were found for {product.Name}.");
            }

            return variants;
        }
        public List<StoreItemOverview> GetProductByGender(Genders gender)
        {
            var models = _productsRepository.GetProductOverviewByGender(gender);

            if (models == null || models.Count == 0)
            {
                throw new NotFoundException($"No products found for gender: {gender}.");
            }

            return StoreItemOverviewDalMapper.ToOverviewDomainList(models);
        }

        public Products UpdateStock(int productId, int variantId, int amount)
        {
            Products productDomain = GetProductById(productId);

            var variant = GetVariants(productDomain, variantId);

            if (variant.Quantity + amount < 0)
            {
                throw new ValidationException($"Decreasing the stock for {productDomain.Name} ({variant.Color}, {variant.Size}) would result in negative quantity.");
            }

            variant.Quantity += amount;

            var updatedProductModel = ProductDalMapper.ToDetailModel(productDomain);

            _productsRepository.UpdateStock(updatedProductModel);

            return productDomain;
        }

        public void DeleteProduct(int productId)
        {
            Products productDomain = GetProductById(productId);

            var DeletedProduct = _productsRepository.DeleteProduct(productId);

            if (!DeletedProduct)
            {
                throw new ValidationException("Product could not be deleted.");
            }
        }

        public void DeleteVariants(int productId, int variantId)
        {
            Products productDomain = GetProductById(productId);

            var DeletedVariant = _productsRepository.DeleteProductVariant(productId, variantId);

            if (!DeletedVariant)
            {
                throw new ValidationException("Product variant could not be deleted.");
            }
        }

    }
}
