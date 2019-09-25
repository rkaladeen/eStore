using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eStore.Models
{
  public class Cart : BaseModel
  {
    [Key]
    public int CartId {get; set;}

    public bool isCheckedOut {get; set;} = false;

    [Required]
    public int UserId {get; set;}
    public User Shopper {get; set;}

    public List<Product> Products {get; set;}
  }
}