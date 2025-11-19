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

        public int UserId { get; set; }   // FK
        public UserModel? User { get; set; }  // navigation

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Order has many items
        public List<OrderItemModel> Items { get; set; } = new();

    }
}
