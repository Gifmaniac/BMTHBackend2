using DataLayer.Models.Store.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Context.Configurations.Store
{
    public class CreatedOrdersConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.Status)
                .HasConversion<string>();
        }
    }
}
