using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdventureWorksLt.Data.Constants;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksLt.Data.Entities;

[Table("Product", Schema = Schemas.SalesLt)]
public partial class Product : Base.SalesLt
{
    [Key]
    [Column("ProductId")]
    public int? Id { get; set; }
    
    [Required, StringLength(50)]
    public string Name { get; set; }
    
    [Required, StringLength(25)]
    public string ProductNumber { get; set; }
    
    [StringLength(15)]
    public string? Color { get; set; }
    
    [Required, Column("StandardCost", TypeName = "money")]
    public decimal StandardCost { get; set; }
    
    [Required, Column("ListPrice", TypeName = "money")]
    public decimal ListPrice { get; set; }
    
    [StringLength(5)]
    public string? Size { get; set; }
    
    [Precision(8, 2)]
    public decimal? Weight { get; set; }

    [Required]
    public DateTime SellStartDate { get; set; }
    
    public DateTime? SellEndDate { get; set; }
    
    public DateTime? DiscontinuedDate { get; set; }
    
    public byte[]? ThumbnailPhoto { get; set; }
    
    [StringLength(50)]
    public string? ThumbnailPhotoFileName { get; set; }
    
    public int? ProductCategoryId { get; set; }
    
    public int? ProductModelId { get; set; }
    
    public virtual ProductCategory Category { get; set; }
    public virtual ProductModel Model { get; set; }
}