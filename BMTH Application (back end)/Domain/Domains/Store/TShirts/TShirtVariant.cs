using Contracts.Enums.Store;

namespace Domain.Domains.Store.TShirts
{
    public class TShirtVariant
    {
        public int VariantId { get; set; }
        public int TShirtId { get; set; }
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
