using MyStore.Application.DTOs;
using MyStore.Domain.Entities;

namespace MyStore.Application.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product?> GetProductByID(int id);
        public Task<Product> AddProduct(Product p);
        public Task UpdateProduct(Product p, ProductDto newProduct);
        public Task DeleteProduct(Product p);
    }
}