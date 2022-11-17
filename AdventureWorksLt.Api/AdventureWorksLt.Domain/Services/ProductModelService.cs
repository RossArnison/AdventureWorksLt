using AdventureWorksLt.Shared.Dtos.ProductModel;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using AdventureWorksLt.Shared.Interfaces.Services;

namespace AdventureWorksLt.Domain.Services;

public class ProductModelService : IProductModelService
{
    private readonly IProductModelRepository _productModelRepository;

    public ProductModelService(IProductModelRepository productModelRepository)
    {
        _productModelRepository = productModelRepository;
    }

    public Task<ProductModelDto[]> GetProductModelsAsync() =>
        _productModelRepository.GetAsync();

    public Task<ProductModelDto?> GetProductModelAsync(int id) =>
        _productModelRepository.GetAsync(id);

    public Task<bool> CreateProductModelAsync(ProductModelDto dto) =>
        _productModelRepository.CreateAsync(dto);

    public Task<bool> UpdateProductModelAsync(int id, ProductModelDto dto) =>
        _productModelRepository.UpdateAsync(id, dto);

    public Task<bool> DeleteProductModelAsync(int id) =>
        _productModelRepository.DeleteAsync(id);
}