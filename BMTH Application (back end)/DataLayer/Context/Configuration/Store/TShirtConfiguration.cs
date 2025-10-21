using Domain.Domains.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataLayer.Context.Configuration.Store
{
    class TShirtConfiguration : IEntityTypeConfiguration<TShirt>
    {
        public void Configure(EntityTypeBuilder<TShirt> builder)
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
                .HasForeignKey(v => v.TShirtId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
