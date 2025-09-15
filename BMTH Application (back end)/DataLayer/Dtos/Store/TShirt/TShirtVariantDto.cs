using Contracts.Enums.Store;

namespace DataLayer.Dtos.Store.TShirt
{
    public class TShirtVariantDto
    {
        public int VariantId { get; set; }
        public int TShirtId { get; set; }
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
    }
}
