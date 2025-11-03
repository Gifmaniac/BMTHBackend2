using DataLayer.Models.Store.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configurations.Store
{
    public class ProductsConfiguration : IEntityTypeConfiguration<ProductsModel>
    {
        public void Configure(EntityTypeBuilder<ProductsModel> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Gender)
                .HasConversion<string>();

            builder.Property(p => p.Category)
                .HasConversion<string>();

            builder.Property(t => t.Material)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(t => t.Variants)
                .WithOne()
                .HasForeignKey(v => v.ProductModelId);
        }
    }
}
