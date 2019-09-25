using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models 
{
  public class ProductDetails
  {
    public string Condition {get; set;}

  }

  public class Product : BaseModel
  {
    [Key]
    public int Id {get; set;}

    [Required]
    [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Title {get; set;}

    [Required]
    [Display(Name="Image URL")]
    public string ImageURL {get; set;}

    [Required]
    [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Description {get; set;}

    [Required]
    public int CategoryId {get; set;}
    public ProductCategory Category {get; set;}

    [Required]
    public int SellerId {get; set;}
    public User Seller {get; set;}
  }



}