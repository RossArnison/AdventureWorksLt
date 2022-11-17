using AdventureWorksLt.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Contexts;

public class SalesContext : DbContext, Interfaces.ISalesContext
{
    public SalesContext(DbContextOptions<SalesContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductDescription> ProductDescriptions { get; set; }
    public DbSet<ProductModel> ProductModels { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(Product.Setup);
        modelBuilder.Entity<ProductCategory>(ProductCategory.Setup);
        modelBuilder.Entity<ProductModelDescription>(ProductModelDescription.Setup);
    }
}