using Contracts.Enums.Store;
using DataLayer.Entity.Store.Common;

namespace DataLayer.Entity.Store.TShirt
{
    public class TShirtEntity : MerchandiseEntity
    {
        public Genders Gender { get; set; }
        public string Material { get; set; }
        public int TotalQuantity { get; set; }

        public List<TShirtVariantEntity> Variants { get; set; } = new();
    }
}
