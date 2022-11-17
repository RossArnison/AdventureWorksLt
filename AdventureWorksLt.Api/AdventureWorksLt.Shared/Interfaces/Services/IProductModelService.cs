using AdventureWorksLt.Shared.Dtos.ProductModel;

namespace AdventureWorksLt.Shared.Interfaces.Services;

public interface IProductModelService
{
    Task<ProductModelDto[]> GetProductModelsAsync();
    Task<ProductModelDto?> GetProductModelAsync(int id);
    Task<bool> CreateProductModelAsync(ProductModelDto dto);
    Task<bool> UpdateProductModelAsync(int id, ProductModelDto dto);
    Task<bool> DeleteProductModelAsync(int id);
}