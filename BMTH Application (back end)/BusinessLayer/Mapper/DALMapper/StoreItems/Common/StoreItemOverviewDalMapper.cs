using BusinessLayer.Domain.Store.Common;
using DataLayer.Models.Store.Common;

namespace BusinessLayer.Mapper.DALMapper.StoreItems.Common
{
    public class StoreItemOverviewDalMapper
    {
        public static StoreItemOverview ToOverviewDomain(StoreOverviewModel model)
        {
            return new StoreItemOverview
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock,
                Category = model.Category
            };
        }
        public static List<StoreItemOverview> ToOverviewDomainList(List<StoreOverviewModel> models)
        {
            return models.Select(ToOverviewDomain).ToList();
        }

        public static StoreOverviewModel ToOverviewModel(StoreItemOverview domain)
        {
            return new StoreOverviewModel
            {
                Id = domain.Id,
                Name = domain.Name,
                Price = domain.Price,
                InStock = domain.InStock,
                Category = domain.Category
            };
        }

        public static List<StoreOverviewModel> ToOverviewModelList(List<StoreItemOverview> domains)
        {
            return domains.Select(ToOverviewModel).ToList();
        }
    }
}
