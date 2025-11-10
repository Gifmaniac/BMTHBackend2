using BusinessLayer.Domain.Store.Orders;
using BusinessLayer.Interfaces.Store.Orders;
using DataLayer.Interfaces;
using DataLayer.Repositories.Store.Orders;

namespace BusinessLayer.Services.Store.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _ordersRepository;

        public OrderService(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        //public List<CreatedOrders> PostUserOrder(int orderId)
        //{
        //    var order = _ordersRepository.PostOrderById(orderId);

        //}
    }
}
