using System.Net.Http.Headers;
using BusinessLayer.Domain.Store.Shirts;
using Contracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;
using BusinessLayer.Helper;
using BusinessLayer.Interfaces.Store.Common;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts
{
    public static class TShirtApiMapper
    {
        public static TShirtDetailsDto ToDetailsDto(TShirt model, IImageService imageService)
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
                    TShirtModelId = v.TShirtModelId,
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

        public static TShirt ToDetailsDomain(TShirtDetailsDto dto)
        {
            return new TShirt()
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                Category = EnumHelper.ParseEnum(dto.Category, StoreCategoryType.TShirts),
                InStock = dto.InStock,
                Material = dto.Material,
                Gender = EnumHelper.ParseEnum(dto.Gender, Genders.Unisex),
                Variants = dto.Variants.Select(v => new TShirtVariant()
                {
                    TShirtModelId = v.TShirtModelId,
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = Enum.Parse<Sizes>(v.Size, true),
                    Quantity = v.Quantity,
                }).ToList()
            };
        }
    }
}
