namespace DataLayer.Dtos
{
    public class TShirtDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public int TotalQuantity { get; set; }

        public List<TShirtVariantDto> Variants { get; set; } = new();
    }
}
