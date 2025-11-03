using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Products
{
    public class ProductsVariants
    {
        public required int VariantId { get; set; }
        public required int ProductModelId { get; set; }
        public required Color Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock => Quantity > 0;
    }
}
