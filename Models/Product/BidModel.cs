using System.ComponentModel.DataAnnotations;

namespace eStore.Models
{
  public class Bid : BaseModel
  {
    [Key]
    public int Id {get; set;}
    
    [Required]
    public int UserId {get; set;}
    public User Bidder {get; set;}
    
    [Required]
    public int ProductId {get; set;}
    public Product Products {get; set;}

    [Required(ErrorMessage="Please enter a bid")]
    [Display(Name="Bid")]
    public double BidAmount {get; set;}
  }
}