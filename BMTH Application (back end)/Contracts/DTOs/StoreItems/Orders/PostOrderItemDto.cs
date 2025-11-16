namespace Contracts.DTOs.StoreItems.Orders
{
    public class PostOrderItemDto
    {
        public required int ProductId { get; set; }
        public required int VariantId { get; set; }
        public required int Quantity { get; set; }
        public required string Color { get; set; }
        public required string Size { get; set; }

    }
}
