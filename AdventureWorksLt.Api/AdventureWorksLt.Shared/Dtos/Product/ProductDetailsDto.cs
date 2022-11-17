namespace AdventureWorksLt.Shared.Dtos.Product;

public class ProductDetailsDto : ProductTableDto
{
    public string ProductNumber { get; init; }
    public string? Color { get; init; }
    public decimal StandardCost { get; init; }
    public string? Size { get; init; }
    public decimal? Weight { get; init; }
    
    public DateTime SellStartDate { get; init; }
    public DateTime? SellEndDate { get; init; }
    public DateTime? DiscontinuedDate { get; init; }
    
    public int? CategoryId { get; init; }
    public int? ModelId { get; init; }
}