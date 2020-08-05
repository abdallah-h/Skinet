using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class StoreContext : DbContext {
        public StoreContext (DbContextOptions<StoreContext> options) : base (options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        /* Used to add config to database 
        and apply defines the shape of your entities, 
        the relationships between them, and how they map to the database. */
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly (Assembly.GetExecutingAssembly ());
        }
    }

}