using AdventureWorksLt.Shared.Dtos.ProductDescription;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using AdventureWorksLt.Shared.Interfaces.Services;

namespace AdventureWorksLt.Domain.Services;

public class ProductDescriptionService : IProductDescriptionService
{
    private readonly IProductDescriptionRepository _productDescriptionRepository;

    public ProductDescriptionService(IProductDescriptionRepository productDescriptionRepository)
    {
        _productDescriptionRepository = productDescriptionRepository;
    }

    public Task<ProductDescriptionDto[]> GetProductDescriptionsAsync() =>
        _productDescriptionRepository.GetAsync();

    public Task<ProductDescriptionDto?> GetProductDescriptionAsync(int id) =>
        _productDescriptionRepository.GetAsync(id);

    public Task<bool> CreateProductDescriptionAsync(ProductDescriptionDto dto) =>
        _productDescriptionRepository.CreateAsync(dto);

    public Task<bool> UpdateProductDescriptionAsync(int id, ProductDescriptionDto dto) =>
        _productDescriptionRepository.UpdateAsync(id, dto);

    public Task<bool> DeleteProductDescriptionAsync(int id) =>
        _productDescriptionRepository.DeleteAsync(id);
}