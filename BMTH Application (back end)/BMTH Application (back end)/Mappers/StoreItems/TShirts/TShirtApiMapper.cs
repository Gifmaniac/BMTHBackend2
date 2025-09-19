using APIContracts.DTOs.StoreItems.Common;
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
                Category = StoreCategoryType.TShirts,
                Gender = entity.Gender
            };
        }
    }
}
