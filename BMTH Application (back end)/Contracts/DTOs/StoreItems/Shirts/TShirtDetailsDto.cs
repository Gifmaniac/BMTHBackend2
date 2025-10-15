using Contracts.DTOs.StoreItems.Common;

namespace Contracts.DTOs.StoreItems.Shirts
{
    public class TShirtDetailsDto : MerchandiseDetailDto
    {
        public required string Gender { get; set; }
        public required string Material { get; set; }
        public List<TShirtVariantDto> Variants { get; set; } = new();
    }
}
