using Microsoft.EntityFrameworkCore;
using ONYX.RAIN.Domain.Catalog;

namespace ONYX.RAIN.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DbInitializer.Initialize(modelBuilder);  // Call the initializer to seed data
        }
    }
}