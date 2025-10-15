
namespace APIContracts.DTOs.StoreItems.Common
{
    public class StoreItemOverviewDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public required string Gender { get; set; }
    }
}
