using InventoryManagement.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Web.Contexts
{
    public class InventoryDbContext : DbContext, IInventoryDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InventoryDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
    }
}
