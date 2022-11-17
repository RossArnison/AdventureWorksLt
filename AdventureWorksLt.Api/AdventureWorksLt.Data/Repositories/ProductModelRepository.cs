using AdventureWorksLt.Data.Contexts.Interfaces;
using AdventureWorksLt.Data.Entities;
using AdventureWorksLt.Shared.Dtos.ProductModel;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Repositories;

public class ProductModelRepository : IProductModelRepository
{
    private readonly ISalesContext _context;

    public ProductModelRepository(ISalesContext context)
    {
        _context = context;
    }
    
    public Task<ProductModelDto[]> GetAsync()
    {
        return _context.ProductModels
            .OrderBy(model => model.Id)
            .Select(model => ProductModelToDto(model))
            .ToArrayAsync();
    }

    public Task<ProductModelDto?> GetAsync(int productModelId)
    {
        return _context.ProductModels
            .Where(model => model.Id == productModelId)
            .Select(model => ProductModelToDto(model))
            .SingleOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(ProductModelDto dto)
    {
        var productModel = DtoToProductModel(dto);

        _context.ProductModels.Add(productModel);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateAsync(int productModelId, ProductModelDto dto)
    {
        var productModel = await GetProductModelEntityAsync(productModelId);

        if (productModel == null) return false;

        DtoToProductModel(dto, productModel);

        return await _context.SaveChangesAsync() == 1;
    }
    
    public async Task<bool> DeleteAsync(int productModelId)
    {
        var productModel = await GetProductModelEntityAsync(productModelId);

        if (productModel == null) return false;

        _context.ProductModels.Remove(productModel);

        return await _context.SaveChangesAsync() == 1;
    }

    private Task<ProductModel?> GetProductModelEntityAsync(int productModelId)
    {
        return _context.ProductModels.SingleOrDefaultAsync(model => model.Id == productModelId);
    }

    private static ProductModel DtoToProductModel(ProductModelDto dto, ProductModel? productModel = null)
    {
        productModel ??= new ProductModel();

        productModel.Id = dto.Id;
        productModel.Name = dto.Name;
        productModel.CatalogDescription = dto.CatalogDescription;

        return productModel;
    }

    private static ProductModelDto ProductModelToDto(ProductModel productModel) => new()
    {
        Id = productModel.Id,
        Name = productModel.Name,
        CatalogDescription = productModel.CatalogDescription
    };
}