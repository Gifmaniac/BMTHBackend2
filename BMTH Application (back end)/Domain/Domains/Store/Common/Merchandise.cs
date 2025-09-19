using Contracts.Enums.Store;


namespace Domain.Domains.Store.Common
{
    public abstract class Merchandise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public Genders Gender { get; set; }
        public StoreCategoryType Category { get; set; }
    }
}
