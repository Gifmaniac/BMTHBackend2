using Contracts.Enums.Store;

namespace Contracts.Entities
{
    public class TShirt : Merchandise
    {
        public Sizes Size { get; set; }
        public string Color { get; set; }
        public string Material { get; }

        public TShirt(int id, string name, decimal price, bool inStock, string color, Sizes size, string material)
            : base(id, name, price, inStock)
        {
            Material = material;
            Size = size;
            Color = color;
        }

    }
}
