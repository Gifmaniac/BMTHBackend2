using Domain.Domains.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configuration.Store
{
    class TShirtVariantConfiguration : IEntityTypeConfiguration<TShirtVariant>
    {
        public void Configure(EntityTypeBuilder<TShirtVariant> builder)
        {
            builder.ToTable("TShirtVariants");

            builder.HasKey(v => v.VariantId);

            builder.Property(v => v.Color)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.ImageUrl)
                .HasMaxLength(500);

            builder.Property(v => v.Quantity)
                .IsRequired();

            builder.Property(v => v.Size)
                .IsRequired();

            builder.Property(v => v.TShirtId)
                .IsRequired();


            builder.HasOne<TShirt>()
                .WithMany(t => t.Variants)
                .HasForeignKey(v => v.TShirtId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
