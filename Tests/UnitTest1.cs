using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ProductMicroService.Data;
using ProductMicroService.Models;

namespace Tests
{
    public class UnitTest1
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddAsync_Should_Add_Product()
        {
            var context = GetDbContext();
            var repo = new ProductRepository(context);

            var product = new Product
            {
                Name = "Test Product",
                Description = "Test Description",
                Quantity = 10
            };

            var result = await repo.AddAsync(product);

            result.Id.Should().BeGreaterThan(0);
            context.Products.Count().Should().Be(1);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Product()
        {
            var context = GetDbContext();
            var repo = new ProductRepository(context);

            var p = await repo.AddAsync(new Product
            {
                Name = "Item",
                Description = "Test",
                Quantity = 5
            });

            var result = await repo.GetByIdAsync(p.Id);

            result.Should().NotBeNull();
            result!.Name.Should().Be("Item");
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Product()
        {
            var context = GetDbContext();
            var repo = new ProductRepository(context);

            var p = await repo.AddAsync(new Product
            {
                Name = "DeleteMe",
                Quantity = 1
            });

            var deleted = await repo.DeleteAsync(p.Id);

            deleted.Should().BeTrue();
            context.Products.Count().Should().Be(0);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Product()
        {
            var context = GetDbContext();
            var repo = new ProductRepository(context);

            var p = await repo.AddAsync(new Product
            {
                Name = "OldName",
                Quantity = 2
            });

            p.Name = "NewName";
            await repo.UpdateAsync(p);

            var updated = await repo.GetByIdAsync(p.Id);
            updated!.Name.Should().Be("NewName");
        }
    }
}