using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Services;
using MyStore.Domain.Entities;

namespace MyStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> productList = await _service.GetAllProducts();
            if (!productList.Any()) return NotFound("No existen productos");

            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product? productObtained = await _service.GetProductByID(id);
            if (productObtained == null) return NotFound($"No se encontro el producto con ID: {id}");

            return Ok(productObtained);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            Product? productCreated = await _service.AddProduct(product);
            if (productCreated == null) return BadRequest("Los datos enviados no son válidos");
            return Ok(productCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product newProduct, int id)
        {
            Product? productUpdated = await _service.UpdateProduct(newProduct, id);

            if (productUpdated == null) return NotFound(
                "El producto que deseas modificar no se encuentra registrado en la Base de Datos"
            );

            return Ok(productUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product? productDeleted = await _service.DeleteProduct(id);

            if (productDeleted == null) return NotFound(
                "El producto que deseas eliminar no se encuentra registrado en la Base de Datos"
            );

            return Ok(productDeleted);
        }
    }
}