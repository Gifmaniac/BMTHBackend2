using APIContracts.DTOs.StoreItems.Common;
using Contracts.Enums.Store;

namespace APIContracts.DTOs.StoreItems.Shirts
{
    public class TShirtDetailsDto : StoreItemDto
    {
        public TShirtDetailsDto(
            int id, string category, string name, decimal price, int quantity, string gender) : base(id, category, name, price, quantity)
        {
            Gender = gender;
        }

        public string Gender { get; set; }
        public List<TShirtVariantDto> Variants { get; set; } = new();
    }
}
