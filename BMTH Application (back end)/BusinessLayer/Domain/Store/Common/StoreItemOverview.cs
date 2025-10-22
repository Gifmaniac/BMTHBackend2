using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Common
{
    public class StoreItemOverview
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public StoreCategoryType Category { get; set; }
    }
}
