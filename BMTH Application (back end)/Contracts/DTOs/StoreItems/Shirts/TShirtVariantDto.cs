namespace Contracts.DTOs.StoreItems.Shirts
{
    public class TShirtVariantDto
    {
        public string Color { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
    }
}
