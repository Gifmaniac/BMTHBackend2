using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer.Context.Configurations.Store
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=BMTH_Test;Trusted_Connection=True;TrustServerCertificate=True");

            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}
