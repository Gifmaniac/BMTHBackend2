using BusinessLayer.Domain.Store.Common;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Services.Store.Common;
using Contracts.DTOs.StoreItems.Common;
using Contracts.Enums.Store;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.Common
{
    public class StoreItemOverviewApiMapper(IImageService imageService)
    {
        private readonly IImageService _imageService = imageService;


        public static StoreItemOverviewDto ToOverviewDto(StoreItemOverview model, IImageService imageService)
        {
            return new StoreItemOverviewDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock,
                Category = model.Category.ToString(),
                Gender = model.Gender.ToString(),
                ImageUrl = imageService.BuildImageUrl(
                    $"{model.Name}.png",
                    model.Category.ToString(),
                    model.Gender.ToString(),
                    model.Name
                )
            };
        }

        public static List<StoreItemOverviewDto> ToOverViewDtoList(List<StoreItemOverview> models, IImageService imageService)
        {
            return models
                .Select(model => ToOverviewDto(model, imageService))
                .ToList();
        }

        public static StoreItemOverview ToOverviewDomain(StoreItemOverviewDto overview)
        {
            return new StoreItemOverview
            {
                Id = overview.Id,
                Name = overview.Name,
                Price = overview.Price,
                InStock = overview.InStock,
                Category = Enum.Parse<StoreCategoryType>(overview.Category),
                Gender = Enum.Parse<Genders>(overview.Gender)
            };
        }

        public static List<StoreItemOverview> ToOverviewDomainList(List<StoreItemOverviewDto> overviews)
        {
            return overviews.Select(ToOverviewDomain).ToList();
        }
    }
}
