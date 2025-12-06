using Contracts.Enums.Store;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer.Models.Store.Orders
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set; }   // PK

        [ForeignKey("Order")]
        public int OrderId { get; set; }       // FK to Orders

        public OrderModel Order { get; set; } = null!;  // Navigation

        public int ProductId { get; set; }     // FK to Product

        public required int VariantId { get; set; }
        public required int Quantity { get; set; }
        public required Color Color { get; set; }
        public required Sizes Size { get; set; }
    }
}

