using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;

namespace ProductMicroService.Data
{ 
        public class AppDbContext : DbContext //Database instance
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Product> Products { get; set; } //Maps to the Product table in the database; allows adding, updating, deleting, and querying products.
    }
    

}
