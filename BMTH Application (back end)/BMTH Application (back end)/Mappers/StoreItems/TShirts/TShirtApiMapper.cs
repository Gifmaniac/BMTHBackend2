using APIContracts.DTOs.StoreItems.Common;
using APIContracts.DTOs.StoreItems.Shirts;
using Contracts.Enums.Store;
using Domain.Domains.Store.TShirts;

namespace BMTH_Application__back_end_.Mappers.StoreItems.TShirts
{
    public static class TShirtApiMapper
    {
        public static StoreItemOverviewDto ToOverviewDto(TShirt entity)
        {
            return new StoreItemOverviewDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Category = entity.Category.ToString(),
                Gender = entity.Gender.ToString()
            };
        }

        public static StoreItemDetailDto ToDetailDto(TShirt entity)
        {
            var total = entity.Variants.Sum(variant => variant.Quantity);

            return new StoreItemDetailDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Gender = entity.Gender.ToString(),
                Material = entity.Material,
                TotalQuantity = total,
                InStock = total > 0,
                Variants = entity.Variants.Select(variant => new TShirtVariantDto
                {
                    Color = variant.Color,
                    Size = variant.Size.ToString(),
                    Quantity = variant.Quantity
                }).ToList()
            };
        }
    }
}
