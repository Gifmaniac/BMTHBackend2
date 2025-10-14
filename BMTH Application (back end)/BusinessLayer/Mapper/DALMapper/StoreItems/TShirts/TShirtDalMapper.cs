using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;

namespace BusinessLayer.Mapper.DALMapper.StoreItems.TShirts
{
    public static class TShirtDalMapper
    {
        public static TShirtModel ToEntity(TShirt Model)
        {
            return new TShirtModel
            {
                Id = Model.Id,
                Name = Model.Name,
                Price = Model.Price,
                InStock = Model.InStock,
                Gender = Model.Gender,
                Category = Model.Category,
                Material = Model.Material,
                Variants = Model.Variants.Select(v => new TShirtVariantModel()
                {
                    VariantId = v.VariantId,
                    TShirtId = v.TShirtId,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }

        public static TShirt ToDomain(TShirtModel entity)
        {
            return new TShirt
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                InStock = entity.InStock,
                Gender = entity.Gender,
                Category = entity.Category,
                Material = entity.Material,
                Variants = entity.Variants.Select(v => new TShirtVariant
                {
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }
    }
}
}
