using Contracts.DTOs.StoreItems.Common;

namespace Contracts.DTOs.StoreItems.Shirts
{
    public class TShirtDetailsDto : StoreItemDetailDto
    {
        public string Gender { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public List<TShirtVariantDto> Variants { get; set; } = new();
    }
}
