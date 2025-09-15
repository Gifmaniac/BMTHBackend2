using BusinessLayer.Entities.Store.Common;
using Contracts.Enums.Store;
using System.Reflection;

namespace BusinessLayer.Entities.Store.TShirts
{
    public class TShirt : Merchandise
    {
        public Genders Gender { get; }
        public string Material { get; }
        public List<TShirtVariant> Variants { get; }

        public TShirt(int id, string name, decimal price, bool inStock, Genders gender, string material, List<TShirtVariant> variants) : base(id, name, price, inStock)
        {
            Gender = gender;
            Material = material;
            Variants = variants;
        }

    }
}
