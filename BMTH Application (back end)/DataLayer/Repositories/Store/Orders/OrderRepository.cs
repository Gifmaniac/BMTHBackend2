using Contracts.Enums.Store;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models.Store.Orders;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Store.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;

        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task PostOrderById(int orderId)
        {
            CreatedOrderModel order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                throw new Exception("Order Id has not been found");
            }

            order.Status = OrderStatus.Processing;
        }

    }
}
