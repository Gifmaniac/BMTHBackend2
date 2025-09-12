namespace Repositories
{
    public class TShirtRepository
    {
        private static readonly List<TShirtDetailsDto> _tShirts = new()
        {
            new TShirtDetailsDto(1, "Limited Edition Tee", 29.99m, 30)
            {
                Variants = new List<TShirtVariantDto>
                {
                    new TShirtVariantDto { Color = "Black", Size = Sizes.S, Quantity = 5 },
                    new TShirtVariantDto { Color = "Black", Size = Sizes.M, Quantity = 8 },
                    new TShirtVariantDto { Color = "White", Size = Sizes.M, Quantity = 10 },
                    new TShirtVariantDto { Color = "White", Size = Sizes.L, Quantity = 7 }
                }
            }
        };

    }
}
