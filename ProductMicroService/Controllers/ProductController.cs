using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Data;
using ProductMicroService.Models;

namespace ProductMicroService.Controllers
{
        [ApiController]
        [Route("products")]
        public class ProductsController : ControllerBase
        {
            private readonly ProductRepository _repo;

            public ProductsController(ProductRepository repo)
            {
                _repo = repo;
            }
        // Retrieves all products from the database and returns them with HTTP 200 OK.
        [HttpGet]
            public async Task<IActionResult> GetAll()
                => Ok(await _repo.GetAllAsync());
        // Retrieves a single product by its ID. Returns 404 Not Found if it doesn't exist.

        [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _repo.GetByIdAsync(id);
                return product == null ? NotFound() : Ok(product);
            }
        // Creates a new product and returns HTTP 201 Created with the new product's data.
        [HttpPost]
            public async Task<IActionResult> Create(Product product)
            {
                var newProduct = await _repo.AddAsync(product);
                return Created($"products/{newProduct.Id}", newProduct);
            }
        // Updates an existing product. Returns 404 Not Found if product doesn't exist,
        // otherwise updates it and returns 204 No Content.
        [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Product product)
            {
                var existing = await _repo.GetByIdAsync(id);
                if (existing == null) return NotFound();

                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Quantity = product.Quantity;

                await _repo.UpdateAsync(existing);

                return NoContent();
            }
        // Deletes a product by ID. Returns 204 No Content if deleted, 404 Not Found if not found.
        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _repo.DeleteAsync(id);
                return deleted ? NoContent() : NotFound();
            }
        }
}
