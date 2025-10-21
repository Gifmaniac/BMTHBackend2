using BusinessLayer.Domain.Store.Common;
using Contracts.Enums.Store;
using DataLayer.Models.Store.TShirts;

namespace BusinessLayer.Domain.Store.Shirts
{
    public class TShirt : Merchandise
    {
        public Genders Gender { get; set; }
        public required string Material { get; set; }
        public List<TShirtVariant> Variants { get; set; } = new();
    }
}
