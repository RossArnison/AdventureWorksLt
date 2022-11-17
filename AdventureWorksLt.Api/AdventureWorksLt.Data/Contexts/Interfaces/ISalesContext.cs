using AdventureWorksLt.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Contexts.Interfaces;

public interface ISalesContext
{

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<Product> Products { get; set; }
    DbSet<ProductCategory> ProductCategories { get; set; }
    DbSet<ProductDescription> ProductDescriptions { get; set; }
    DbSet<ProductModel> ProductModels { get; set; }
}