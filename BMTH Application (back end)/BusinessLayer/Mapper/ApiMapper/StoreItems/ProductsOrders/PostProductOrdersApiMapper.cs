using BusinessLayer.Domain.Store.Orders;
using Contracts.DTOs.StoreItems.Orders;
using Contracts.Enums.Store;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.ProductsOrders
{
    public class PostProductOrdersApiMapper
    {
        public static Order ToDomain(PostOrderDto dto)
        {
            return new Order()
            {
                UserId = dto.UserId,
                Items = dto.Items.Select(o => new OrderItem
                {
                    ProductId = o.ProductId,
                    VariantId = o.VariantId,
                    Color = Enum.Parse<Color>(o.Color),
                    Size = Enum.Parse<Sizes>(o.Size),
                    Quantity = o.Quantity
                }).ToList()
            };
        }

    }
}
