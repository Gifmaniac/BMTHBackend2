using Contracts.DTOs.StoreItems.Common;

namespace Contracts.DTOs.StoreItems.Product
{
    public class ProductDetailDto : MerchandiseDetailDto
    {
        public required string Gender { get; set; }
        public required string Material { get; set; }
        public List<ProductVariantsDto> Variants { get; set; } = [];
    }
}
