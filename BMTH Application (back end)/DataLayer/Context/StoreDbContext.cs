using Domain.Domains.Store.TShirts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base (options)
        {

        }

        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<TShirtVariant> TShirtVariants { get; set; }

    }
}
