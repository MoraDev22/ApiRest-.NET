using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.Entities
{
    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; } = string.Empty;
    }
}