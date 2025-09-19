using Contracts.Enums.Store;
using DataLayer.Mapper;
using Domain.Domains.Store.TShirts;


namespace DataLayer.Repositories
{
    public class TShirtRepository
    {
        private readonly List<TShirt> _tShirts;

        public List<TShirt> GetShirtsByGender(Genders? gender = null)
        {
            IEnumerable<TShirt> getTShirts = _tShirts;

            if (gender.HasValue)
            {
                getTShirts = getTShirts
                    .Where(tShirt => tShirt.Gender == gender.Value || tShirt.Gender == Genders.Unisex);
            }

            return getTShirts.ToList();
        }

        public TShirtRepository()
        {
            _tShirts = new List<TShirt>
            {
                new TShirt
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Gender = Genders.Unisex,
                    Material = "Cotton",
                    Price = 19.99m,
                    TotalQuantity = 30,
                    Variants = new List<TShirtVariant>
                    {
                        new TShirtVariant
                            { VariantId = 1, TShirtId = 1, Color = "Black", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariant
                            { VariantId = 2, TShirtId = 1, Color = "Black", Size = Sizes.L, Quantity = 5 },
                        new TShirtVariant
                            { VariantId = 3, TShirtId = 1, Color = "White", Size = Sizes.M, Quantity = 15 },
                    }
                },
                new TShirt
                {
                    Id = 2,
                    Name = "Vintage Logo Shirt",
                    Gender = Genders.Men,
                    Material = "Organic Cotton",
                    Price = 24.99m,
                    TotalQuantity = 20,
                    Variants = new List<TShirtVariant>
                    {
                        new TShirtVariant { VariantId = 4, TShirtId = 2, Color = "Navy", Size = Sizes.S, Quantity = 5 },
                        new TShirtVariant
                            { VariantId = 5, TShirtId = 2, Color = "Navy", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariant { VariantId = 6, TShirtId = 2, Color = "Gray", Size = Sizes.L, Quantity = 5 },
                    }
                },
                new TShirt
                {
                    Id = 3,
                    Name = "SportFit Shirt",
                    Gender = Genders.Women,
                    Material = "Polyester",
                    Price = 29.99m,
                    TotalQuantity = 18,
                    Variants = new List<TShirtVariant>
                    {
                        new TShirtVariant { VariantId = 7, TShirtId = 3, Color = "Red", Size = Sizes.M, Quantity = 6 },
                        new TShirtVariant { VariantId = 8, TShirtId = 3, Color = "Red", Size = Sizes.L, Quantity = 6 },
                        new TShirtVariant { VariantId = 9, TShirtId = 3, Color = "Blue", Size = Sizes.M, Quantity = 6 },
                    }
                }
            };
        }
    }
}
