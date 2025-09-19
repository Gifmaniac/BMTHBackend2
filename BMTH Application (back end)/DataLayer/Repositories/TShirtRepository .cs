using Contracts.Enums.Store;
using DataLayer.Entity.Store.TShirt;


namespace DataLayer.Repositories
{
    public class TShirtRepository
    {
        public List<TShirtEntity> GetMaleShirts()
        {
            return new List<TShirtEntity>
            {
                new TShirtEntity
                {
                    Id = 2,
                    Name = "Vintage Logo Shirt",
                    Gender = Genders.Men,
                    Material = "Organic Cotton",
                    Price = 24.99m,
                    TotalQuantity = 20,
                    Variants = new List<TShirtVariantEntity>
                    {
                        new TShirtVariantEntity
                            { VariantId = 4, TShirtId = 2, Color = "Navy", Size = Sizes.S, Quantity = 5 },
                        new TShirtVariantEntity
                            { VariantId = 5, TShirtId = 2, Color = "Navy", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariantEntity
                            { VariantId = 6, TShirtId = 2, Color = "Gray", Size = Sizes.L, Quantity = 5 },
                    }
                }
            };

        }

        public List<TShirtEntity> GetWomenShirtsEntities()
        {
            return new List<TShirtEntity>
            {
                new TShirtEntity
                {
                    Id = 3,
                    Name = "SportFit Shirt",
                    Gender = Genders.Women,
                    Material = "Polyester",
                    Price = 29.99m,
                    TotalQuantity = 18,
                    Variants = new List<TShirtVariantEntity>
                    {
                        new TShirtVariantEntity
                            { VariantId = 7, TShirtId = 3, Color = "Red", Size = Sizes.M, Quantity = 6 },
                        new TShirtVariantEntity
                            { VariantId = 8, TShirtId = 3, Color = "Red", Size = Sizes.L, Quantity = 6 },
                        new TShirtVariantEntity
                            { VariantId = 9, TShirtId = 3, Color = "Blue", Size = Sizes.M, Quantity = 6 },
                    }
                }
            };
        }

        public List<TShirtEntity> GetUnisexShirtsEntities()
        {
            return new List<TShirtEntity>
            {
                new TShirtEntity()
                {
                    Id = 1,
                    Name = "Classic Tee",
                    Gender = Genders.Unisex,
                    Material = "Cotton",
                    Price = 19.99m,
                    TotalQuantity = 30,
                    Variants = new List<TShirtVariantEntity>
                    {
                        new TShirtVariantEntity
                            { VariantId = 1, TShirtId = 1, Color = "Black", Size = Sizes.M, Quantity = 10 },
                        new TShirtVariantEntity
                            { VariantId = 2, TShirtId = 1, Color = "Black", Size = Sizes.L, Quantity = 5 },
                        new TShirtVariantEntity
                            { VariantId = 3, TShirtId = 1, Color = "White", Size = Sizes.M, Quantity = 15 },
                    }
                }
            };
        }
    }
}
