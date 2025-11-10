using Contracts.DTOs.StoreItems.Orders;
using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Orders
{
    public class CreatedOrders
    {
        public required int OrderId { get; set; }
        public required int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Created;
        public List<CreateOrder> Orders { get; set; } = [];
    }
}
