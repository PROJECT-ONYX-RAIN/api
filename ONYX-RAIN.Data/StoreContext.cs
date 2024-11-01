using Microsoft.EntityFrameworkCore;
using ONYX.RAIN.Domain.Catalog;
using ONYX.RAIN.Domain.Orders;

namespace ONYX.RAIN.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DbInitializer.Initialize(modelBuilder);  // Call the initializer to seed data
        }
    }
}