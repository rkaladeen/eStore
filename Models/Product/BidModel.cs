using System.ComponentModel.DataAnnotations;

namespace eStore.Models
{
  public class Bid : BaseModel
  {
    [Key]
    public int Id {get; set;}

    public int UserId {get; set;}
    public User Bidder {get; set;}

    public int ProductId {get; set;}
    public Product Products {get; set;}
  }
}