using Contracts.Enums.Store;
using Domain.Domains.Store.Common;

namespace Domain.Domains.Store.TShirts
{
    public class TShirt : Merchandise
    {
        public Genders Gender { get; set; }
        public string Material { get; set; }

        public List<TShirtVariant> Variants { get; set; } = new();
    }
}