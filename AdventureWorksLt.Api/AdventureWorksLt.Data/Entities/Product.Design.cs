using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorksLt.Data.Entities;

public partial class Product
{
    public static void Setup(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne(product => product.Category)
               .WithMany(category => category.Products)
               .HasForeignKey(product => product.ProductCategoryId);

        builder.HasOne(product => product.Model)
               .WithMany(model => model.Products)
               .HasForeignKey(product => product.ProductModelId);
    }
}