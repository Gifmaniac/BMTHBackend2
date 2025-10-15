using Contracts.Enums.Store;
using DataLayer.Models.Store.Common;

namespace DataLayer.Models.Store.TShirts
{
    public class TShirtModel : MerchandiseModel
    {
        public Genders Gender { get; set; }
        public required string Material { get; set; }
        public List<TShirtVariantModel> Variants { get; set; } = new();
    }
}
