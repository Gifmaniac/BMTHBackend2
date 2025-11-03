using DataLayer.Models.Store.Products;
using BusinessLayer.Domain.Store.Products;

namespace BusinessLayer.Mapper.DALMapper.StoreItems.Product
{
    public static class ProductDalMapper
    {
        public static ProductsModel ToDetailEntity(Products domain)
        {
            return new ProductsModel
            {
                Id = domain.Id,
                Name = domain.Name,
                Price = domain.Price,
                InStock = domain.InStock,
                Gender = domain.Gender,
                Category = domain.Category,
                Material = domain.Material,
                Variants = domain.Variants.Select(v => new ProductsVariantsModel()
                {
                    VariantId = v.VariantId,
                    ProductModelId = v.ProductModelId,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }

        public static List<ProductsModel> ToEntityList(List<Products> domain)
        {
            return domain.Select(ToDetailEntity).ToList();
        }

        public static Products ToDomain(ProductsModel model)
        {
            return new Products
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                InStock = model.InStock,
                Gender = model.Gender,
                Category = model.Category,
                Material = model.Material,
                Variants = model.Variants.Select(v => new ProductsVariants
                {
                    ProductModelId = v.ProductModelId,
                    VariantId = v.VariantId,
                    Color = v.Color,
                    Size = v.Size,
                    Quantity = v.Quantity
                }).ToList()
            };
        }

        public static List<Products> ToDomainList(List<ProductsModel> models)
        {
            return models.Select(ToDomain).ToList();
        }
    }
}

