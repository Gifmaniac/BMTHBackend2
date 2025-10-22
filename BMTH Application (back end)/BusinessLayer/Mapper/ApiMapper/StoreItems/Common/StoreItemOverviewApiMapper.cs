using APIContracts.DTOs.StoreItems.Common;
using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Domain.Store.Shirts;
using Contracts.Enums.Store;
using DataLayer.Models.Store.Common;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.Common
{
    public class StoreItemOverviewApiMapper
    {
        public static StoreItemOverviewDto ToOverviewDto(StoreItemOverview model)
        {
            return new StoreItemOverviewDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock,
                Category = model.Category.ToString()
            };
        }

        public static List<StoreItemOverviewDto> ToOverViewDtoList(List<StoreItemOverview> models)
        {
            return models.Select(ToOverviewDto).ToList();
        }

        public static StoreItemOverview ToOverviewDomain(StoreItemOverviewDto overview)
        {
            return new StoreItemOverview()
            {
                Id = overview.Id,
                Name = overview.Name,
                Price = overview.Price,
                InStock = overview.InStock,
                Category = Enum.Parse<StoreCategoryType>(overview.Category)
            };
        }

        public static List<StoreItemOverview> ToOverviewDomainList(List<StoreItemOverviewDto> overviews)
        {
            return overviews.Select(ToOverviewDomain).ToList();
        }
    }
}
