using AdventureWorksLt.Shared.Dtos.Product;

namespace AdventureWorksLt.Shared.Interfaces.Services;

public interface IProductService
{
    Task<ProductDto[]> GetProductsAsync();
    Task<ProductDetailsDto?> GetProductAsync(int productId);
    Task<bool> CreateProductAsync(ProductDetailsDto requestDto);
    Task<bool> UpdateProductAsync(int productId, ProductDetailsDto requestDto);
    Task<bool> DeleteProductAsync(int productId);
}