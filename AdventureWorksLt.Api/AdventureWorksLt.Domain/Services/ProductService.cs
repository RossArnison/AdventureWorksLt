using AdventureWorksLt.Shared.Dtos.Product;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using AdventureWorksLt.Shared.Interfaces.Services;

namespace AdventureWorksLt.Domain.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto[]> GetProductsAsync()
    {
        var products = await _productRepository.GetAsync();
        return products.Select(PopulateThumbnail).ToArray();
    }

    public async Task<ProductDetailsDto?> GetProductAsync(int productId)
    {
        var product = await _productRepository.GetAsync(productId);

        if (product == null) return null;
        
        return PopulateThumbnail(product) as ProductDetailsDto;
    }

    public Task<bool> CreateProductAsync(ProductDetailsDto requestDto) =>
        _productRepository.CreateAsync(requestDto);

    public Task<bool> UpdateProductAsync(int productId, ProductDetailsDto requestDto) =>
        _productRepository.UpdateAsync(productId, requestDto);

    public Task<bool> DeleteProductAsync(int productId) =>
        _productRepository.DeleteAsync(productId);

    private static ProductDto PopulateThumbnail(ProductTableDto product)
    {
        try
        {
            if (product.ThumbnailPhoto != null)
                product.Image = $"data:image/png;base64, {Convert.ToBase64String(product.ThumbnailPhoto)}";

            return product;
        }
        finally
        {
            product.ThumbnailPhoto = null;
        }
    }
}