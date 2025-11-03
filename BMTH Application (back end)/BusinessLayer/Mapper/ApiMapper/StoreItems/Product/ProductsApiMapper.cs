using Contracts.Enums.Store;
using BusinessLayer.Helper;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Domain.Store.Products;
using Contracts.DTOs.StoreItems.Product;


namespace BusinessLayer.Mapper.ApiMapper.StoreItems.Product
{
    public static class ProductsApiMapper
    {
        public static ProductDetailDto ToDetailsDto(Products model, IImageService imageService)
        {
            return new ProductDetailDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Category = model.Category.ToString(),
                InStock = model.InStock,
                Material = model.Material,
                Gender = model.Gender.ToString(),
                Variants = model.Variants.Select(v => new ProductVariantsDto
                {
                    ProductModelId = v.ProductModelId,
                    VariantId = v.VariantId,
                    Color = v.Color.ToString(),
                    Size = v.Size.ToString(),
                    Quantity = v.Quantity,
                    ImageUrlsList = imageService.GetVariantImageUrls(
                        category: model.Category.ToString(),
                        gender: model.Gender.ToString(),
                        productName: model.Name,
                        color: v.Color.ToString(),
                        variantId: v.VariantId)
                }).ToList()
            };
        }

        public static Products ToDetailsDomain(ProductDetailDto dto)
        {
            return new Products()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Category = Enum.Parse<StoreCategoryType>(dto.Category, true),
                InStock = dto.InStock,
                Material = dto.Material,
                Gender = Enum.Parse<Genders>(dto.Gender, true),
                Variants = dto.Variants.Select(v => new ProductsVariants()
                {
                    ProductModelId = v.ProductModelId,
                    VariantId = v.VariantId,
                    Color = Enum.Parse<Color>(v.Color, true),
                    Size = Enum.Parse<Sizes>(v.Size, true),
                    Quantity = v.Quantity,
                }).ToList()
            };
        }
    }
}
