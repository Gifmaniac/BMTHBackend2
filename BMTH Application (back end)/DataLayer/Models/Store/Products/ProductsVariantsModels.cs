using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Enums.Store;

namespace DataLayer.Models.Store.Products
{
    public class ProductsVariantsModel
    {
        [Key]
        public int VariantId { get; set; }// PK
        public required int ProductModelId { get; set; } // FK
        public required Color Color { get; set; } 
        public Sizes Size { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public bool InStock => Quantity > 0;
    }
}
