using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorksLt.Data.Entities;

public partial class ProductCategory
{
    public static void Setup(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasOne(category => category.Parent)
               .WithMany(category => category.Children)
               .HasForeignKey(category => category.ParentId);
    }
}