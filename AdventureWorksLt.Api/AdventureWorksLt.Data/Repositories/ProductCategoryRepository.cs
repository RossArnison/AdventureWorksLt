using AdventureWorksLt.Data.Contexts.Interfaces;
using AdventureWorksLt.Data.Entities;
using AdventureWorksLt.Shared.Dtos.ProductCategory;
using AdventureWorksLt.Shared.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly ISalesContext _context;

    public ProductCategoryRepository(ISalesContext context)
    {
        _context = context;
    }
    
    public Task<ProductCategoryDto[]> GetAsync()
    {
        return _context.ProductCategories
            .Where(category => category.ParentId == null)
            .OrderBy(category => category.Id)
            .Select(category => new ProductCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Children = category.Children.Select(child => ProductCategoryToDto(child))
            })
            .ToArrayAsync();
    }

    public Task<ProductCategoryDto?> GetAsync(int categoryId)
    {
        return _context.ProductCategories
            .Where(category => category.Id == categoryId)
            .Select(category => new ProductCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Parent = ProductCategoryToDto(category.Parent),
                Children = category.Children.Select(ProductCategoryToDto)
            }).SingleOrDefaultAsync();
    }

    public async Task<bool> CreateAsync(ProductCategoryDto dto)
    {
        var category = DtoToProductCategory(dto);

        _context.ProductCategories.Add(category);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> UpdateAsync(int categoryId, ProductCategoryDto dto)
    {
        var category = await GetProductCategoryEntityAsync(categoryId);

        if (category == null) return false;

        DtoToProductCategory(dto, category);

        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> DeleteAsync(int categoryId)
    {
        var category = await GetProductCategoryEntityAsync(categoryId);

        if (category == null) return false;

        _context.ProductCategories.Remove(category);

        return await _context.SaveChangesAsync() == 1;
    }

    private Task<ProductCategory?> GetProductCategoryEntityAsync(int categoryId)
    {
        return _context.ProductCategories.SingleOrDefaultAsync(category => category.Id == categoryId);
    }

    private static ProductCategory DtoToProductCategory(ProductCategoryDto dto, ProductCategory? category = null)
    {
        category ??= new ProductCategory();

        category.Id = dto.Id;
        category.Name = dto.Name;
        category.ParentId = dto.Parent?.Id;

        return category;
    }

    private static ProductCategoryDto? ProductCategoryToDto(ProductCategory? category)
    {
        return category == null 
            ? null 
            : new ProductCategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
    }
}