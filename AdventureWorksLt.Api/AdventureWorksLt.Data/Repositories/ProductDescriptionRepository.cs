using AdventureWorksLt.Data.Contexts.Interfaces;
using AdventureWorksLt.Data.Entities;
using AdventureWorksLt.Shared.Dtos.ProductDescription;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Repositories;

public class ProductDescriptionRepository : IProductDescriptionRepository
{
    private readonly ISalesContext _context;

    public ProductDescriptionRepository(ISalesContext context)
    {
        _context = context;
    }
    
    public Task<ProductDescriptionDto[]> GetAsync()
    {
        return _context.ProductDescriptions
            .OrderBy(description => description.Id)
            .Select(description => ProductDescriptionToDto(description))
            .ToArrayAsync();
    }

    public Task<ProductDescriptionDto?> GetAsync(int productDescriptionId)
    {
        return _context.ProductDescriptions
            .Where(description => description.Id == productDescriptionId)
            .Select(description => ProductDescriptionToDto(description))
            .SingleOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(ProductDescriptionDto dto)
    {
        var description = DtoToProductDescription(dto);

        _context.ProductDescriptions.Add(description);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateAsync(int productDescriptionId, ProductDescriptionDto dto)
    {
        var description = await GetProductDescriptionEntityAsync(productDescriptionId);

        if (description == null) return false;

        DtoToProductDescription(dto, description);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteAsync(int productDescriptionId)
    {
        var description = await GetProductDescriptionEntityAsync(productDescriptionId);

        if (description == null) return false;

        _context.ProductDescriptions.Remove(description);

        return await _context.SaveChangesAsync() == 1;
    }

    private Task<ProductDescription?> GetProductDescriptionEntityAsync(int productDescriptionId)
    {
        return _context.ProductDescriptions.SingleOrDefaultAsync(description => description.Id == productDescriptionId);
    }

    private static ProductDescription DtoToProductDescription(ProductDescriptionDto dto, ProductDescription? description = null)
    {
        description ??= new ProductDescription();

        description.Description = dto.Description;

        return description;
    }

    private static ProductDescriptionDto ProductDescriptionToDto(ProductDescription description) => new()
    {
        Id = description.Id,
        Description = description.Description
    };
}