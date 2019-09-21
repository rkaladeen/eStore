using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models 
{
  public class ProductPost : BaseModel
  {
    [Key]
    public int Id {get; set;}

    public int ProductId {get; set;}
    public Product Product {get; set;}

    public int SellerId {get; set;}
    public User Seller {get; set;} 

    

  }

}