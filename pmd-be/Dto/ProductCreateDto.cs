namespace pmd_be.Dto
{
    public class ProductCreateDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required decimal Price { get; set; }
        public required string SKU { get; set; }
        public required int Category { get; set; }
        public required int StockQuantity { get; set; }
    }
}
