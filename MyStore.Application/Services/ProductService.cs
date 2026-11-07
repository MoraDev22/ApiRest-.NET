using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;

namespace MyStore.Application.Services
{
    public class ProductService
    {
        public readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repository.GetAll();
        }

        public async Task<Product?> GetProductByID(int id)
        {
            return await _repository.GetProductByID(id);
        }

        public async Task<Product?> AddProduct(Product p)
        {
            return await _repository.AddProduct(p);
        }

        public async Task<Product?> UpdateProduct(Product newProduct, int id)
        {
            Product? productObtained = await _repository.GetProductByID(id);
            if (productObtained == null) return null;

            await _repository.UpdateProduct(productObtained, newProduct);
            return productObtained;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            Product? productObtained = await _repository.GetProductByID(id);
            if (productObtained == null) return null;

            await _repository.DeleteProduct(productObtained);
            return productObtained;
        }
    }
}