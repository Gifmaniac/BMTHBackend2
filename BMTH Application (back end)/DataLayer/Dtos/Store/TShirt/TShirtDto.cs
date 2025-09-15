using Contracts.Enums.Store;
using DataLayer.Dtos.Store.Common;

namespace DataLayer.Dtos.Store.TShirt
{
    public class TShirtDto : MerchandiseDto
    {
        public Genders Gender { get; set; }
        public string Material { get; set; }
        public int TotalQuantity { get; set; }

        public List<TShirtVariantDto> Variants { get; set; } = new();
    }
}
