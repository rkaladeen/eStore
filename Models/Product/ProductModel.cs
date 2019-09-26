using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models 
{
  public class ProductImage : BaseModel
  {
    [Key]
    public int ImageId {get; set;}
    public string ImageURL { get; set; }
    public int ProductId { get; set; }
    public Product product { get; set; }
  }

  public class Product : BaseModel
  {
    [Key]
    public int Id {get; set;}

    [Required]
    public int SellerId {get; set;}
    public User Seller {get; set;}
    
    [Required(ErrorMessage="{0} is required")]
    [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Title {get; set;}

    public List<ProductImage> ImageURLs { get; set; }
    public Product()
    {
      ImageURLs = new List<ProductImage>();
    }

    public int CategoryId {get; set;}
    public ProductCategory Category {get; set;}
    public string Condition {get; set;}
    public string Model { get; set; }
    public string Brand { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Description {get; set;}

    public bool isAuction { get; set; }
    [Range(1, 10000000000000)]
    [Display(Name="Starting Bid")]
    public double BidStartPrice { get; set; }
    [Range(1, 10)]
    [Display(Name = "Auction Duration")]
    public string AuctionDuration { get; set; }

    public bool isSale { get; set; }
    [Range(1, 10000000000000)]
    public double Price { get; set; }
    [Range(1, 30)]
    [Display(Name = "Sale Duration")]
    public string SaleDuration { get; set; }
  }
    
}