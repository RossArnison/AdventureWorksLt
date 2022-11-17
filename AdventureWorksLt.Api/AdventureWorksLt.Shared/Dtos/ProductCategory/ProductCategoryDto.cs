namespace AdventureWorksLt.Shared.Dtos.ProductCategory;

public class ProductCategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    
    public int? ParentId { get; init; }
    
    public int  ChildCount { get; init; }
    
    public ProductCategoryDto? Parent { get; init; }
    public IEnumerable<ProductCategoryDto?>? Children { get; init; }
}