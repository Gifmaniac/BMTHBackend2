using Contracts.Enums.Store;

namespace Contracts.DTOs.StoreItems.Product
{
    public class TShirtCreateDto
    {
        public Sizes Size { get; set; }
        public required string Color { get; set; }
        public required string Material { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

