namespace Contracts.DTOs.StoreItems.Common
{
    public class StoreItemOverviewDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required bool InStock { get; set; }
        public required string Category { get; set; }
        public required string ImageUrl { get; set; }
        public required string Gender { get; set; }

    }
}
