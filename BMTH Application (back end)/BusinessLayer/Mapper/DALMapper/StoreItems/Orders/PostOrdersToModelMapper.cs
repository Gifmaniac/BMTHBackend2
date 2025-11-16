using BusinessLayer.Domain.Store.Orders;
using Contracts.Enums.Store;
using DataLayer.Models.Store.Orders;

namespace BusinessLayer.Mapper.DALMapper.StoreItems.Orders
{
    public class PostOrdersToModelMapper
    {
        public static OrderModel ToModel(Order domain)
        {
            return new OrderModel()
            {
                UserId = domain.UserId,
                CreatedAt = domain.CreatedAt,
                UpdatedAt = domain.UpdatedAt,
                Status = domain.Status,
                Items = domain.Items.Select(o => new OrderItemModel()
                {
                    OrderItemId = o.ProductId,
                    VariantId = o.VariantId,
                    Color = o.Color,
                    Size = o.Size,
                    Quantity = o.Quantity
                }).ToList()
            };
        }
    }
}
