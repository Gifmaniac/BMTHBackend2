namespace Contracts.DTOs.StoreItems.Product
{
    public class ProductVariantsDto
    {
        public required int VariantId { get; set; }
        public required int ProductModelId { get; set; }
        public required string Color { get; set; }
        public required string Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
        public List<string> ImageUrlsList { get; set; } = new List<string>();
    }
}
