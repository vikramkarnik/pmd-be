namespace pmd_be.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required decimal Price { get; set; }
    public required string SKU { get; set; }
    public required int Category { get; set; }
    public required int StockQuantity { get; set; }
    public DateTimeOffset DateAdded { get; set; }


}
