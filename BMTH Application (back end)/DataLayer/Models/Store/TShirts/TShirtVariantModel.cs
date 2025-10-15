using Contracts.Enums.Store;

namespace DataLayer.Models.Store.TShirts
{
    public class TShirtVariantModel
    {
        public int VariantId { get; set; }      // PK
        public int TShirtId { get; set; }       // FK
        public string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock  => Quantity > 0;
    }
}
