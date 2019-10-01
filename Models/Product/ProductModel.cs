using System;
using System.ComponentModel.DataAnnotations;

namespace eStore.Models 
{
  public class Product : BaseModel
  {
    [Key]
    public int Id {get; set;}

    [Required]
    public int SellerId {get; set;}
    public User Seller {get; set;}

    [Required] 
    public string Status {get; set;}
    
    [Required(ErrorMessage="{0} is required")]
    [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Title {get; set;}

    public string ImagePath { get; set; }

    public int CategoryId {get; set;}
    public ProductCategory Category {get; set;}
    public string Condition {get; set;}
    public string Model { get; set; }
    public string Brand { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(1000, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Description {get; set;}

    public bool isAuction { get; set; }
    [Range(1, 10000000000000)]
    [Display(Name="Starting Bid")]
    public double? BidStartPrice { get; set; }
    [Range(1, 10)]
    [Display(Name = "Auction Duration")]
    public int AuctionDuration { get; set; }

    public bool isSale { get; set; }
    [Range(1, 10000000000000)]
    public double? Price { get; set; }
    [Range(1, 30)]
    [Display(Name = "Sale Duration")]
    public int SaleDuration { get; set; }

    public DateTime EndDate { get; set; }
    public Product()
    {
      if(isAuction)
      {
        EndDate = CreatedAt.AddDays(AuctionDuration);
      }else if(isSale)
      {
        EndDate = CreatedAt.AddDays(SaleDuration);
      }
    }
  }
    
}