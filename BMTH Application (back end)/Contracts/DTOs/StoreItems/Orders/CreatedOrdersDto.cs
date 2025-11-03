namespace Contracts.DTOs.StoreItems.Orders
{
    public class CreatedOrdersDto
    {
        public required int UserId = 1;
        public List<CreateOrderDto> Orders = [];
    }
}
