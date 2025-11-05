using System.Dynamic;

namespace Contracts.DTOs.StoreItems.Orders
{
    public class CreatedOrdersDto
    {
        public required int OrderId { get; set; }
        public required int UserId { get; set; } = 1;
        public string Status { get; set; } = "Created";
        public List<CreateOrderDto> Orders { get; set; } = [];
    }
}
