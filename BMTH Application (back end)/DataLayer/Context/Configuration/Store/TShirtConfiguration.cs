using DataLayer.Models.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataLayer.Context.Configuration.Store
{
    class TShirtConfiguration : IEntityTypeConfiguration<TShirtModel>
    {
        public void Configure(EntityTypeBuilder<TShirtModel> builder)
        {
            builder.ToTable("TShirts");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Material)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Price)
                .HasColumnType("decimal(10,2)");

            builder.HasMany(t => t.Variants)
                .WithOne()                             
                .HasForeignKey(v => v.TShirtModelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
