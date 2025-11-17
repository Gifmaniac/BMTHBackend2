using Contracts.Enums.Store;
using System.ComponentModel.DataAnnotations;


namespace DataLayer.Models.Store.Orders
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set; }  // PK
        public int OrderId { get; set; }    // FK
        public OrderModel? Order { get; set; }  // Navigation

        public required int VariantId { get; set; }
        public required int Quantity { get; set; }
        public required Color Color { get; set; }
        public required Sizes Size { get; set; }
    }
}
