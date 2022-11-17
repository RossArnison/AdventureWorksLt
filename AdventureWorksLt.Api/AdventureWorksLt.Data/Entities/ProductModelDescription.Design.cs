using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorksLt.Data.Entities;

public partial class ProductModelDescription
{
    
    public static void Setup(EntityTypeBuilder<ProductModelDescription> builder)
    {
        builder.HasKey(e => new
        {
            e.ProductModelId, 
            e.ProductDescriptionId, 
            e.Culture
        });

        builder.HasOne(pmd => pmd.ProductDescription)
               .WithMany(description => description.ProductModelDescriptions)
               .HasForeignKey(pmd => pmd.ProductDescriptionId);

        builder.HasOne(pmd => pmd.ProductModel)
               .WithMany(model => model.ProductModelDescriptions)
               .HasForeignKey(d => d.ProductModelId);
    }
}