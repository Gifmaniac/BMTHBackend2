using DataLayer.Models.Store.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configurations.Store
{
    public class ProductsVariantsConfiguration : IEntityTypeConfiguration<ProductsVariantsModel>
    {
        public void Configure(EntityTypeBuilder<ProductsVariantsModel> builder)
        {
            builder.HasKey(v => v.VariantId);

            builder.Property(v => v.Color)
                .HasConversion<string>();

            builder.Property(v => v.Color)
                .HasConversion<string>();
            
            builder.Property(v => v.Size)
                .HasConversion<string>();
        }
    }
}
