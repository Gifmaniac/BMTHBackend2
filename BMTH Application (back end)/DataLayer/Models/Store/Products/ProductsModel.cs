using Contracts.Enums.Store;
using DataLayer.Models.Store.Common;

namespace DataLayer.Models.Store.Products
{
    public class ProductsModel : MerchandiseModel
    {
        public Genders Gender { get; set; }
        public required string Material { get; set; }
        public List<ProductsVariantsModel> Variants { get; set; } = [];
    }
}
