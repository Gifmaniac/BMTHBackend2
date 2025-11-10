using Contracts.Enums.Store;

namespace DataLayer.Models.Store.Orders
{
    public class CreatedOrderModel
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


    }
}
