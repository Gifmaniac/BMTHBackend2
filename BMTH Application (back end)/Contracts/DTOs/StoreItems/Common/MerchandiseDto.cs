namespace Contracts.DTOs.StoreItems.Common
{
    public class MerchandiseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public required string Category { get; set; }
        public bool InStock { get; set; }
    }
}
