using APIContracts.DTOs.StoreItems.Shirts;


namespace APIContracts.DTOs.StoreItems.Common
{
    public class StoreItemDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Gender { get; set; }
        public string Material { get; set; }
        public int TotalQuantity { get; set; }
        public bool InStock { get; set; }
        public List<TShirtVariantDto> Variants { get; set; }
    }

}
