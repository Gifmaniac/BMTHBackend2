using Contracts.Enums.Store;

namespace DataLayer.Dtos
{
    public class TShirtVariantDto
    {
        public int Id { get; set; }
        public int TShirtId { get; set; }
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
