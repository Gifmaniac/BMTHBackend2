using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using Contracts.Enums.Store;
using DataLayer.Models.User;
using Microsoft.Identity.Client;

namespace DataLayer.Models.Store.Orders
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }  // PK

        public int? UserId { get; set; }   // FK
        public UserModel? User { get; set; }  // navigation
        public required OrderStatus Status { get; set; }

        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }

        // Order has many items
        public List<OrderItemModel> Items { get; set; } = new();

    }
}
