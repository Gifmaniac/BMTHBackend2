namespace Contracts.DTOs.StoreItems.Shirts
{
    public class TShirtVariantDto
    {
        public required int VariantId { get; set; }
        public required int TShirtModelId { get; set; }
        public required string Color { get; set; }
        public required string Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
    }
}
