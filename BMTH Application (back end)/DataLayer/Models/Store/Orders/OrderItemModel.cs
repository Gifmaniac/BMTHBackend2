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

        public OrderModel Order { get; set; }  // Navigation

        public int ProductId { get; set; }     // FK to Product

        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public Color Color { get; set; }
        public Sizes Size { get; set; }
    }
}

