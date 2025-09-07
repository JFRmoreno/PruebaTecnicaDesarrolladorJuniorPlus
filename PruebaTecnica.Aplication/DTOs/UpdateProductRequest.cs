namespace PruebaTecnica.Aplication.DTOs
{
    public class UpdateProductRequest
    {
        public int IdProduct { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
