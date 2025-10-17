using DataLayer.Models.Store.TShirts;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<TShirtModel> TShirts { get; set; }
        public DbSet<TShirtVariantModel> TShirtVariants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }

}
