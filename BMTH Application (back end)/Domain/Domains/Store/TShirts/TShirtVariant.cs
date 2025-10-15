using Contracts.Enums.Store;

namespace Domain.Domains.Store.TShirts
{
    public class TShirtVariant
    {
        public int VariantId { get; set; }      // PK
        public required int TShirtId { get; set; }       // FK
        public required string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
    }
}
