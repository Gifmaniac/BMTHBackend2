using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Shirts
{
    public class TShirtVariant
    {
        public required int VariantId { get; set; }
        public required int TShirtModelId { get; set; }
        public required string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
