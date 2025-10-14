using Contracts.Enums.Store;

namespace Contracts.DTOs.StoreItems.Shirts
{
    public class TShirtCreateDto
    {
        public Sizes Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

