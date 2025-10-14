using Contracts.Enums.Store;

namespace DataLayer.Models.Store.Common
{
    abstract public class MerchandiseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public Genders Gender { get; set; }
        public StoreCategoryType Category { get; set; }
    }
}
