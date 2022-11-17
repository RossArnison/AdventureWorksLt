using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorksLt.Data.Constants;

namespace AdventureWorksLt.Data.Entities;

[Table("ProductDescription", Schema = Schemas.SalesLt)]
public partial class ProductDescription : Base.SalesLt
{
    [Key, Column("ProductDescriptionID")]
    public int Id { get; set; }
    
    [Required, StringLength(400)]
    public string Description { get; set; }
    
    public virtual ICollection<ProductModelDescription> ProductModelDescriptions { get; set; }
}