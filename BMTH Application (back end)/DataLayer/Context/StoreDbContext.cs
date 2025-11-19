using DataLayer.Models.Common;
using DataLayer.Models.Store.Orders;
using DataLayer.Models.Store.Products;
using DataLayer.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<ProductsVariantsModel> ProductsVariants { get; set; }  
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserRegisterModel> UserRegister { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }
    }
}
