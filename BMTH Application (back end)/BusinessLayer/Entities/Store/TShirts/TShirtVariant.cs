using Contracts.Enums.Store;

namespace BusinessLayer.Entities.Store.TShirts
{
    public class TShirtVariant
    {
        public int VariantId { get; }
        public int TShirtId { get; }
        public string Color { get; }
        public Sizes Size { get; }
        public int Quantity { get; private set; }

        public TShirtVariant(int variantid, int tShirtId, string color, Sizes size, int quantity)
        {
            VariantId = variantid;
            TShirtId = tShirtId;
            Color = color;
            Size = size;
            Quantity = quantity;
        }
    }
}
