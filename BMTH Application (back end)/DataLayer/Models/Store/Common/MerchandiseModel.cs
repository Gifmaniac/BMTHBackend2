using Contracts.Enums.Store;

namespace DataLayer.Models.Store.Common
{
    public abstract class MerchandiseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public StoreCategoryType Category { get; set; } 
    }
}
