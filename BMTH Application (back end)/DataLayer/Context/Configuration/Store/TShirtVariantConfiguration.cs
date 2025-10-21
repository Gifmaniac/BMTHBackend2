using DataLayer.Models.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configuration.Store
{
    class TShirtVariantConfiguration : IEntityTypeConfiguration<TShirtVariantModel>
    {
        public void Configure(EntityTypeBuilder<TShirtVariantModel> builder)
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

            builder.Property(v => v.TShirtModelId)
                .IsRequired();


            builder.HasOne<TShirtModel>()
                .WithMany(t => t.Variants)
                .HasForeignKey(v => v.TShirtModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
