using Contracts.Enums.Store;

namespace DataLayer.Entity.Store.TShirt
{
    public class TShirtVariantEntity
    {
        public int VariantId { get; set; }
        public int TShirtId { get; set; }
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
