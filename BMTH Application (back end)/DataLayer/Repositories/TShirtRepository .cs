using Contracts.Enums.Store;
using DataLayer.Dtos;

namespace DataLayer.Repositories
{
    public class TShirtRepository
    {
        public List<TShirtDto> MakeShirts()
        {
            return new List<TShirtDto>
            {
                new TShirtDto
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Material = "Cotton",
                    Price = 19.99m,
                    TotalQuantity = 30,
                    Variants = new List<TShirtVariantDto>
                    {
                        new TShirtVariantDto { Id = 1, TShirtId = 1, Color = "Black", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariantDto { Id = 2, TShirtId = 1, Color = "Black", Size = Sizes.L, Quantity = 5 },
                        new TShirtVariantDto { Id = 3, TShirtId = 1, Color = "White", Size = Sizes.M, Quantity = 15 },
                    }
                },
                new TShirtDto
                {
                    Id = 2,
                    Name = "Vintage Logo Shirt",
                    Material = "Organic Cotton",
                    Price = 24.99m,
                    TotalQuantity = 20,
                    Variants = new List<TShirtVariantDto>
                    {
                        new TShirtVariantDto { Id = 4, TShirtId = 2, Color = "Navy", Size = Sizes.S, Quantity = 5 },
                        new TShirtVariantDto { Id = 5, TShirtId = 2, Color = "Navy", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariantDto { Id = 6, TShirtId = 2, Color = "Gray", Size = Sizes.L, Quantity = 5 },
                    }
                },
                new TShirtDto
                {
                    Id = 3,
                    Name = "SportFit Shirt",
                    Material = "Polyester",
                    Price = 29.99m,
                    TotalQuantity = 18,
                    Variants = new List<TShirtVariantDto>
                    {
                        new TShirtVariantDto { Id = 7, TShirtId = 3, Color = "Red", Size = Sizes.M, Quantity = 6 },
                        new TShirtVariantDto { Id = 8, TShirtId = 3, Color = "Red", Size = Sizes.L, Quantity = 6 },
                        new TShirtVariantDto { Id = 9, TShirtId = 3, Color = "Blue", Size = Sizes.M, Quantity = 6 },
                    }
                }
            };
        }
    }
}
