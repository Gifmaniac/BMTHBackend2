using DataLayer.Models.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configurations.Store
{
    public class TShirtConfiguration : IEntityTypeConfiguration<TShirtModel>
    {
        public void Configure(EntityTypeBuilder<TShirtModel> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Material)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(t => t.Variants)
                .WithOne()
                .HasForeignKey(v => v.TShirtModelId);
        }
    }
}
