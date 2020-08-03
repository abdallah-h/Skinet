using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class StoreContext : DbContext {
        public StoreContext (DbContextOptions<StoreContext> options) : base (options) { }

        // query database using DbContext and product entity
        public DbSet<Product> Products { get; set; }
    }

}