using APIContracts.DTOs.StoreItems.Common;
using Contracts.Enums.Store;

namespace APIContracts.DTOs.StoreItems.Shirts
{
    public class TShirtDetailsDto : StoreItemDto
    {
        public TShirtDetailsDto(int id, string name, decimal price, int quantity, Genders gender) : base(id, StoreCategoryType.TShirts, name, price, quantity)
        {
            Gender = gender;
        }
        public Genders Gender { get; set; }
        public List<TShirtVariantDto> Variants { get; set; } = new();
    }
}
