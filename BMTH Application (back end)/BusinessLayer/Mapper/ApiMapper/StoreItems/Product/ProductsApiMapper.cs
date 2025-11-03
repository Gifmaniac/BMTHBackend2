using Contracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;
using BusinessLayer.Helper;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Domain.Store.Products;


namespace BusinessLayer.Mapper.ApiMapper.StoreItems.Product
{
    public static class ProductsApiMapper
    {
        public static TShirtDetailsDto ToDetailsDto(Products model, IImageService imageService)
        {
            return new TShirtDetailsDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Category = model.Category.ToString(),
                InStock = model.InStock,
                Material = model.Material,
                Gender = model.Gender.ToString(),
                Variants = model.Variants.Select(v => new TShirtVariantDto
                {
                    TShirtModelId = v.ProductModelId,
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = v.Size.ToString(),
                    Quantity = v.Quantity,
                    ImageUrlsList = imageService.GetVariantImageUrls(
                        category: model.Category.ToString(),
                        gender: model.Gender.ToString(),
                        productName: model.Name,
                        color: v.Color,
                        variantId: v.VariantId)
                }).ToList()
            };
        }

        public static Products ToDetailsDomain(TShirtDetailsDto dto)
        {
            return new Products()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Category = EnumHelper.ParseEnum(dto.Category, StoreCategoryType.TShirts),
                InStock = dto.InStock,
                Material = dto.Material,
                Gender = EnumHelper.ParseEnum(dto.Gender, Genders.Unisex),
                Variants = dto.Variants.Select(v => new ProductsVariants()
                {
                    ProductModelId = v.TShirtModelId,
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = Enum.Parse<Sizes>(v.Size, true),
                    Quantity = v.Quantity,
                }).ToList()
            };
        }
    }
}
