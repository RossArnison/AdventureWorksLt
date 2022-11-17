namespace AdventureWorksLt.Shared.Dtos.Product;

public class ProductTableDto : ProductDto
{
    public byte[]? ThumbnailPhoto { get; set; }
    public string? ThumbnailPhotoFileName { get; set; }
}