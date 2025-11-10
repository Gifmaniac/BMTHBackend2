using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Orders
{
    public class CreateOrder
    {  
        public required int ProductId { get; set; }
        public required int VariantId { get; set; }
        public required int Quantity { get; set; }
        public required Color Color { get; set; }
        public required Sizes Size { get; set; }
    }
}
