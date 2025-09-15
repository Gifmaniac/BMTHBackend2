using BusinessLayer.Entities.Store.TShirts;
using DataLayer.Dtos.Store.TShirt;

namespace BusinessLayer.Mappers.Store
{
    public class TShirtMapper
    {
        public static TShirt ToEntity(TShirtDto dto)
        {
            var variants = dto.Variants.Select(v => new TShirtVariant(
                v.VariantId,
                v.TShirtId,
                v.Color,
                v.Size,
                v.Quantity
            )).ToList();

            return new TShirt(
                dto.Id,
                dto.Name,
                dto.Price,
                dto.InStock,
                dto.Gender,
                dto.Material,
                variants
            );
        }

        public static TShirtDto ToDto(TShirt entity)
        {
            return new TShirtDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                InStock = entity.InStock,
                Gender = entity.Gender,
                Material = entity.Material,
                Variants = entity.Variants.Select(v => new TShirtVariantDto
                {
                    VariantId = v.VariantId,
                    TShirtId = entity.Id,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }
    }
}
