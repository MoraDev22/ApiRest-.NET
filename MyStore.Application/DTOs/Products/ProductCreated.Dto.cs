namespace MyStore.Application.DTOs
{
    public record ProductCreateDto
    (
        int ProductID,
        string Name,
        string Description,
        decimal Price,
        int Stock,
        string Marca
    );
}