using AdventureWorksLt.Shared.Dtos.ProductCategory;

namespace AdventureWorksLt.Shared.Interfaces.Services;

public interface IProductCategoryService
{
    Task<ProductCategoryDto[]> GetProductCategoriesAsync();
    Task<ProductCategoryDto?> GetProductCategoryAsync(int id);
    Task<bool> CreateProductCategoryAsync(ProductCategoryDto dto);
    Task<bool> UpdateProductCategoryAsync(int id, ProductCategoryDto dto);
    Task<bool> DeleteProductCategoryAsync(int id);
}