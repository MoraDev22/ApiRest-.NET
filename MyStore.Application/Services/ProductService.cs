using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Application.Methods;
using MyStore.Application.DTOs;

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

        public async Task<ProductCreateDto> AddProduct(ProductDto productDto)
        {
           
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Marca = productDto.Marca
            };
            Product newProduct = await _repository.AddProduct(product);

            //SI TODO SALIO BIEN
            return new ProductCreateDto
            (
                newProduct.ProductID,
                newProduct.Name,
                newProduct.Description,
                newProduct.Price,
                newProduct.Stock,
                newProduct.Marca
            );

        }

        public async Task<ProductDto?> UpdateProduct(ProductDto newProduct, int id)
        {
            return await ProductMethod.ValidateProductOperations(_repository, id, "update", newProduct);
        }

        public async Task<ProductDto?> DeleteProduct(int id)
        {
            return await ProductMethod.ValidateProductOperations(_repository, id, "delete");
        }
    }
}