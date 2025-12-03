using System.Dynamic;

namespace Contracts.DTOs.StoreItems.Orders
{
    public class PostOrderDto
    {
        public int? UserId { get; set; }
        public List<PostOrderItemDto> Items { get; set; } = [];
    }
}
