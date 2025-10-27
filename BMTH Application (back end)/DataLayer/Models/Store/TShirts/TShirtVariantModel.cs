using System.ComponentModel.DataAnnotations;
using Contracts.Enums.Store;

namespace DataLayer.Models.Store.TShirts
{
    public class TShirtVariantModel
    {
        [Key]
        public int VariantId { get; set; }// PK
        public required int TShirtModelId { get; set; } // FK
        public required string Color { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public bool InStock  => Quantity > 0;
    }
}
