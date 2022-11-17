using AdventureWorksLt.Data.Constants;
using AdventureWorksLt.Data.Contexts.Interfaces;
using AdventureWorksLt.Data.Entities;
using AdventureWorksLt.Shared.Dtos.Product;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ISalesContext _salesContext;

    public ProductRepository(ISalesContext salesContext)
    {
        _salesContext = salesContext;
    }

    public Task<ProductTableDto[]> GetAsync()
    {
        return _salesContext.Products
            .OrderBy(product => product.Id)
            .Select(product =>  new ProductTableDto
            {
                Id = product.Id,
                Name = product.Name,
                ListPrice = product.ListPrice,
                ThumbnailPhoto = product.ThumbnailPhoto,
                Category = product.Category.Name,
                Model = product.Model.Name,
                Description = product.Model.ProductModelDescriptions
                    .Where(pmd => pmd.Culture == Culture.Current)
                    .Select(pmd => pmd.ProductDescription.Description)
                    .FirstOrDefault()
            })
            .ToArrayAsync();
    }

    public Task<ProductDetailsDto?> GetAsync(int productId)
    {
        return _salesContext.Products
            .Where(product => product.Id == productId)
            .Select(product => new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                Color = product.Color,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
                Size = product.Size,
                Weight = product.Weight,
                SellStartDate = product.SellStartDate,
                SellEndDate = product.SellEndDate,
                DiscontinuedDate = product.DiscontinuedDate,
                ThumbnailPhoto = product.ThumbnailPhoto,
                CategoryId = product.ProductCategoryId,
                ModelId = product.ProductModelId
            })
            .SingleOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(ProductDetailsDto requestDto)
    {
        var product = DetailDtoToProduct(requestDto);
        
        _salesContext.Products.Add(product);
        
        return await _salesContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateAsync(int productId, ProductDetailsDto requestDto)
    {
        var product = await GetProductEntityAsync(productId);

        if (product == null) return false;

        DetailDtoToProduct(requestDto, product);

        return await _salesContext.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteAsync(int productId)
    {
        var product = await GetProductEntityAsync(productId);

        if (product == null) return false;

        _salesContext.Products.Remove(product);
        
        return await _salesContext.SaveChangesAsync() == 1;
    }

    private Task<Product?> GetProductEntityAsync(int productId)
    {
        return _salesContext.Products.SingleOrDefaultAsync(product => product.Id == productId);
    }

    private static Product DetailDtoToProduct(ProductDetailsDto dto, Product? product = null)
    {
        product ??= new Product();

        product.Name = dto.Name;
        product.ProductNumber = dto.ProductNumber;
        product.Color = dto.Color;
        product.StandardCost = dto.StandardCost;
        product.ListPrice = dto.ListPrice;
        product.Size = dto.Size;
        product.Weight = dto.Weight;
        product.SellStartDate = dto.SellStartDate;
        product.SellEndDate = dto.SellEndDate;
        product.DiscontinuedDate = dto.DiscontinuedDate;
        product.ProductCategoryId = dto.CategoryId;
        product.ProductModelId = dto.ModelId;

        return product;
    }
}