using System.Dynamic;

namespace Contracts.DTOs.StoreItems.Orders
{
    public class PostOrderDto
    {
        public int? UserId { get; set; }
        public required List<PostOrderItemDto> Items { get; set; } = new();
    }
}
