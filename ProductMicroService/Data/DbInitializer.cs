using ProductMicroService.Models;

namespace ProductMicroService.Data
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context) //Seed data 
        {
            if (context.Products.Any()) return; // Already seeded

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Description = "Dell XPS 15", Quantity = 5 },
                new Product { Name = "Mouse", Description = "Wireless Logitech", Quantity = 20 },
                new Product { Name = "Monitor", Description = "27 inch 4K", Quantity = 7 }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
