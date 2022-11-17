using AdventureWorksLt.Shared.Dtos.ProductCategory;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using AdventureWorksLt.Shared.Interfaces.Services;

namespace AdventureWorksLt.Domain.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public Task<ProductCategoryDto[]> GetProductCategoriesAsync() =>
        _productCategoryRepository.GetAsync();

    public Task<ProductCategoryDto?> GetProductCategoryAsync(int id) =>
        _productCategoryRepository.GetAsync(id);

    public Task<bool> CreateProductCategoryAsync(ProductCategoryDto dto) =>
        _productCategoryRepository.CreateAsync(dto);

    public Task<bool> UpdateProductCategoryAsync(int id, ProductCategoryDto dto) =>
        _productCategoryRepository.UpdateAsync(id, dto);

    public Task<bool> DeleteProductCategoryAsync(int id) =>
        _productCategoryRepository.DeleteAsync(id);
}