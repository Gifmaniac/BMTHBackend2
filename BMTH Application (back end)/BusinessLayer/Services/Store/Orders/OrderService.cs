using BusinessLayer.Domain.Store.Orders;
using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Store.Orders;
using BusinessLayer.Mapper.ApiMapper.StoreItems.ProductsOrders;
using BusinessLayer.Mapper.DALMapper.StoreItems.Orders;
using Contracts.DTOs.StoreItems.Orders;
using Contracts.Enums.Store;
using DataLayer.Interfaces;
using DataLayer.Repositories.Store.Orders;

namespace BusinessLayer.Services.Store.Orders
{
    public class OrderService(IOrderRepository orderRepository): IOrderService
    {
        private readonly IOrderRepository _ordersRepository = orderRepository;

        public async Task<int> PostUserOrder(PostOrderDto order)
        {
            if (order.Items == null || !order.Items.Any())
            {
                throw new ValidationException("Order must include at least one order item.");
            }

            if (order.Items.Any(i => i.Quantity <= 0))
            {
                throw new ValidationException("Order item quantity must be greater than zero.");
            }

            if (order.UserId == 0)
            {
                order.UserId = null;
            }

            var domain = PostProductOrdersApiMapper.ToDomain(order);

            domain.Status = OrderStatus.Pending;
            domain.CreatedAt = DateTime.UtcNow;
            domain.UpdatedAt = DateTime.UtcNow;

            var model = PostOrdersToModelMapper.ToModel(domain);

            return await _ordersRepository.PostOrder(model);

        }
    }
}
