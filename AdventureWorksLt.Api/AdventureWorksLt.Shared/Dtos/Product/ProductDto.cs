namespace AdventureWorksLt.Shared.Dtos.Product;

public class ProductDto
{
    public int? Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public string? Model { get; init; }
    public decimal ListPrice { get; init; }
    public string? Category { get; init; }
    public string Image { get; set; }
}