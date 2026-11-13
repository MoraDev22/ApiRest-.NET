namespace MyStore.Application.DTOs
{
    public record ProductDto
    (
        int ProductID,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Marca
    );
}