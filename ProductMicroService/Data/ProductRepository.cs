using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;

namespace ProductMicroService.Data
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        { 
            _context = context; // _context is used to access the Products table in the database.
        }
        // Retrieves all products from the database asynchronously.
        public async Task<List<Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();

        // Retrieves a single product by its Id asynchronously. Returns null if not found.
        public async Task<Product?> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);

        // Adds a new product to the database and saves changes asynchronously.
        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Updates an existing product in the database and saves changes asynchronously.
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        // Deletes a product by Id. Returns true if deletion was successful, false if product not found.
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
