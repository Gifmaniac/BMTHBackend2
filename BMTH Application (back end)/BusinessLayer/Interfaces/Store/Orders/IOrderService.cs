using BusinessLayer.Domain.Store.Orders;
using Contracts.DTOs.StoreItems.Orders;

namespace BusinessLayer.Interfaces.Store.Orders
{
    public interface IOrderService
    {
        Task<int> PostUserOrder(PostOrderDto order);
    }
}
