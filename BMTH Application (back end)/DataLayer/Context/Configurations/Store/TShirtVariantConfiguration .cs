using DataLayer.Models.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configurations.Store
{
    public class TShirtVariantConfiguration : IEntityTypeConfiguration<TShirtVariantModel>
    {
        public void Configure(EntityTypeBuilder<TShirtVariantModel> builder)
        {
            builder.HasKey(v => v.VariantId);

            builder.Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(v => v.ImageUrl)
                .HasMaxLength(255);
        }
    }
}
