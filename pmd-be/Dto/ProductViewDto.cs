namespace pmd_be.Dto
{
    public class ProductViewDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required string Code { get; set; }
        public required decimal Price { get; set; }
        public required string SKU { get; set; }
        public required int StockQuantity { get; set; } 
        public DateTimeOffset DateAdded { get; set; }
    }
}
