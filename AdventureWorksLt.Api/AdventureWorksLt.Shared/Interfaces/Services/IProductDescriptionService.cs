using AdventureWorksLt.Shared.Dtos.ProductDescription;

namespace AdventureWorksLt.Shared.Interfaces.Services;

public interface IProductDescriptionService
{
    Task<ProductDescriptionDto[]> GetProductDescriptionsAsync();
    Task<ProductDescriptionDto?> GetProductDescriptionAsync(int id);
    Task<bool> CreateProductDescriptionAsync(ProductDescriptionDto dto);
    Task<bool> UpdateProductDescriptionAsync(int id, ProductDescriptionDto dto);
    Task<bool> DeleteProductDescriptionAsync(int id);
}