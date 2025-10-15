using Contracts.DTOs.StoreItems.Shirts;

namespace Contracts.DTOs.StoreItems.Common
{
    public class MerchandiseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool InStock { get; set; } 
        public int TotalQuantity { get; set; }

    }

}
