using Contracts.Enums.Store;
using DataLayer.Dtos.Store.TShirt;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class TShirtRepository : ITShirtRepository
    {
        public List<TShirtDto> MakeShirts()
        {
            return new List<TShirtDto>
            {
                new TShirtDto
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Gender = Genders.Unisex,
                    Material = "Cotton",
                    Price = 19.99m,
                    TotalQuantity = 30,
                    Variants = new List<TShirtVariantDto>
                    {
                        new TShirtVariantDto { VariantId = 1, TShirtId = 1, Color = "Black", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariantDto { VariantId = 2, TShirtId = 1, Color = "Black", Size = Sizes.L, Quantity = 5 },
                        new TShirtVariantDto { VariantId = 3, TShirtId = 1, Color = "White", Size = Sizes.M, Quantity = 15 },
                    }
                },
                new TShirtDto
                {
                    Id = 2,
                    Name = "Vintage Logo Shirt",
                    Gender = Genders.Men,
                    Material = "Organic Cotton",
                    Price = 24.99m,
                    TotalQuantity = 20,
                    Variants = new List<TShirtVariantDto>
                    {
                        new TShirtVariantDto { VariantId = 4, TShirtId = 2, Color = "Navy", Size = Sizes.S, Quantity = 5 },
                        new TShirtVariantDto { VariantId = 5, TShirtId = 2, Color = "Navy", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariantDto { VariantId = 6, TShirtId = 2, Color = "Gray", Size = Sizes.L, Quantity = 5 },
                    }
                },
                new TShirtDto
                {
                    Id = 3,
                    Name = "SportFit Shirt",
                    Gender = Genders.Women,
                    Material = "Polyester",
                    Price = 29.99m,
                    TotalQuantity = 18,
                    Variants = new List<TShirtVariantDto>
                    {
                        new TShirtVariantDto { VariantId = 7, TShirtId = 3, Color = "Red", Size = Sizes.M, Quantity = 6 },
                        new TShirtVariantDto { VariantId = 8, TShirtId = 3, Color = "Red", Size = Sizes.L, Quantity = 6 },
                        new TShirtVariantDto { VariantId = 9, TShirtId = 3, Color = "Blue", Size = Sizes.M, Quantity = 6 },
                    }
                }
            };
        }
    }
}
