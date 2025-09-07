namespace PruebaTecnica.Aplication.DTOs
{
    public class CreateProductsRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
