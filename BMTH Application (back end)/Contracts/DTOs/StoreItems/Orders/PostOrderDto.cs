using System.Dynamic;

namespace Contracts.DTOs.StoreItems.Orders
{
    public class PostOrderDto
    {
        public required int UserId { get; set; } = 1;
        public List<PostOrderItemDto> Items { get; set; } = [];
    }
}
