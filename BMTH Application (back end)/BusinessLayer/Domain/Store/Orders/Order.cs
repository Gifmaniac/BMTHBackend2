using System;
using System.Collections.Generic;
using Contracts.DTOs.StoreItems.Orders;
using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Orders
{
    public class Order
    {
        public int? UserId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<OrderItem> Items { get; set; } = [];
    }
}
