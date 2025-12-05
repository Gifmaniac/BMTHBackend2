using Contracts.Enums.Store;

namespace DataLayer.Models.Store.Common
{
    public class StoreOverviewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required bool InStock { get; set; }
        public required StoreCategoryType Category { get; set; }
        public required Genders Gender { get; set; }
    }
}
