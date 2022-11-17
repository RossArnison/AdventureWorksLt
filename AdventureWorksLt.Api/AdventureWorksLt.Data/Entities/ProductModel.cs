using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorksLt.Data.Constants;

namespace AdventureWorksLt.Data.Entities;

[Table("ProductModel", Schema = Schemas.SalesLt)]
public partial class ProductModel : Base.SalesLt
{
    [Key, Column("ProductModelID")]
    public int Id { get; set; }
    
    [Required, StringLength(50)]
    public string Name { get; set; }
    
    public string? CatalogDescription { get; set; }
    
    public virtual ICollection<Product> Products { get; set; }
    
    public virtual ICollection<ProductModelDescription> ProductModelDescriptions { get; set; }
}