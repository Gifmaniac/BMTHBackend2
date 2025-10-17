using DataLayer.Models.Store.TShirts;
using Domain.Domains.Store.TShirts;

namespace BusinessLayer.Mapper.DALMapper.StoreItems.TShirts
{
    public static class TShirtDalMapper
    {
        public static TShirtModel ToEntity(TShirt domain)
        {
            return new TShirtModel
            {
                Id = domain.Id,
                Name = domain.Name,
                Price = domain.Price,
                InStock = domain.InStock,
                Gender = domain.Gender,
                Category = domain.Category,
                Material = domain.Material,
                Variants = domain.Variants.Select(v => new TShirtVariantModel()
                {
                    VariantId = v.VariantId,
                    TShirtModelId = v.TShirtId,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }

        public static List<TShirtModel> ToEntityList(List<TShirt> domain)
        {
            return domain.Select(ToEntity).ToList();
        }

        public static TShirt ToDomain(TShirtModel model)
        {
            return new TShirt
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock,
                Gender = model.Gender,
                Category = model.Category,
                Material = model.Material,
                Variants = model.Variants.Select(v => new TShirtVariant
                {
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }

        public static List<TShirt> ToDomainList(List<TShirtModel> models)
        {
            return models.Select(ToDomain).ToList();
        }

    }
}

