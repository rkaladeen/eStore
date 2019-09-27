using System.ComponentModel.DataAnnotations;

namespace eStore.Models 
{
  public class ProductCategory : BaseModel
  {
    [Key]
    public int Id {get; set;}

    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
    public string Name {get; set;}

  }

}