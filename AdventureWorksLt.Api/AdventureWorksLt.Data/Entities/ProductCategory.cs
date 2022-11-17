using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorksLt.Data.Constants;

namespace AdventureWorksLt.Data.Entities;

[Table("ProductCategory", Schema = Schemas.SalesLt)]
public partial class ProductCategory : Base.SalesLt
{
    [Key, Column("ProductCategoryId")]
    public int Id { get; set; }
    
    [Required, StringLength(50)]
    public string Name { get; set; }
    
    [Column("ParentProductCategoryID")]
    public int? ParentId { get; set; }
    
    public virtual ProductCategory? Parent { get; set; }
    public virtual ICollection<ProductCategory>? Children { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}