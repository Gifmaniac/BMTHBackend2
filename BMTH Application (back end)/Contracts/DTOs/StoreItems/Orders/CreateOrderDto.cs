namespace Contracts.DTOs.StoreItems.Orders
{
    public class CreateOrderDto
    {
        public required int ProductId { get; set; }
        public required int VariantId { get; set; }


    }
}
