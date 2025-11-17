using Contracts.Enums.Store;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Orders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Store.Orders
{
    public class OrderRepository(StoreDbContext context) : IOrderRepository
    {
        private readonly StoreDbContext _context = context;

        public async Task<int> PostOrder(OrderModel order)
        {
            foreach (var item in order.Items)
            {
                item.OrderItemId = 0;

                item.Order = null;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.OrderId;
        }

    }
}
