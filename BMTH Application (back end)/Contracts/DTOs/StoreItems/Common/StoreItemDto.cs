namespace Contracts.DTOs.StoreItems.Common
{
    public class StoreItemDto
    {
        public StoreItemDto(int id, string category, string name, decimal price, int quantity)
        {
            Id = id;
            Category = category;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Category { get; set; }
        public bool InStock { get; set; } = false;
    }
}
