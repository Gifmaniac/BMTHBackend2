using Contracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;
using Domain.Domains.Store.TShirts;
using System.Reflection;
using BusinessLayer.Helper;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.TShirts
{
    public static class TShirtMapper
    {
        public static TShirtDetailsDto ToDetailsDto(TShirt model)
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
                    Color = v.Color,
                    Size = v.Size.ToString(),
                    Quantity = v.Quantity
                }).ToList()
            };
        }

        public static TShirt ToDetailsDomain(TShirtDetailsDto Dto)
        {
            return new TShirt()
            {
                Id = Dto.Id,
                Name = Dto.Name,
                Price = Dto.Price,
                Category = EnumHelper.ParseEnum(Dto.Category, StoreCategoryType.TShirts),
                InStock = Dto.InStock,
                Gender = EnumHelper.ParseEnum(Dto.Gender, Genders.Unisex),
                Variants = Dto.Variants.Select(v => new TShirtVariant()
                {
                    Color = v.Color,
                    Size = EnumHelper.ParseEnum()
                }
            }
        }
    }
}
