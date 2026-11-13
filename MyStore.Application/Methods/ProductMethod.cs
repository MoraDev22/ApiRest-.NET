using MyStore.Application.Interfaces;
using MyStore.Domain.Entities;
using MyStore.Application.DTOs;
namespace MyStore.Application.Methods
{  
    public static class ProductMethod
    {
        public static async Task<ProductDto?> ValidateProductOperations(IProductRepository repository, int id, string operation, ProductDto? newProduct = null)
        {
            Product? productObtained = await repository.GetProductByID(id);
            if (productObtained == null) return null;

            if (operation == "delete" && newProduct == null) await repository.DeleteProduct(productObtained);

            if (operation == "update") await repository.UpdateProduct(productObtained, newProduct!);
            
            return new ProductDto(
                productObtained.ProductID,
                productObtained.Name,
                productObtained.Description,
                productObtained.Price,
                productObtained.Stock,
                productObtained.Marca
            );
        }
    }
}
