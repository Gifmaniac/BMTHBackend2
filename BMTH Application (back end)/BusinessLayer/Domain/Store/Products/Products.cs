using BusinessLayer.Domain.Store.Common;
using Contracts.Enums.Store;

namespace BusinessLayer.Domain.Store.Products
{
    public class Products : Merchandise
    {
        public Genders Gender { get; set; }
        public required string Material { get; set; }
        public List<ProductsVariants> Variants { get; set; } = [];
    }
}
