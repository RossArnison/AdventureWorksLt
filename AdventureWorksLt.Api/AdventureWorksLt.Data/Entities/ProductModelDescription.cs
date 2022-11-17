using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorksLt.Data.Constants;

namespace AdventureWorksLt.Data.Entities;


[Table("ProductModelProductDescription", Schema = Schemas.SalesLt)]
public partial class ProductModelDescription : Base.SalesLt
{
    public int ProductModelId { get; set; }
    
    public int ProductDescriptionId { get; set; }
    
    public string Culture { get; set; }

    public virtual ProductDescription ProductDescription { get; set; }

    public virtual ProductModel ProductModel { get; set; }
}