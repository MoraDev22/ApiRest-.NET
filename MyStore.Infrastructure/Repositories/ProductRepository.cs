using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;

namespace MyStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task<Product?> GetProductByID(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<Product> AddProduct(Product p)
        {
            _context.Products.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task UpdateProduct(Product p, Product newProduct)
        {
            p.Name = newProduct.Name;
            p.Description = newProduct.Description;
            p.Price = newProduct.Price;
            p.Stock = newProduct.Stock;
            p.Marca = newProduct.Marca;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product p)
        {
            _context.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}