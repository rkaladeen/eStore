
using Microsoft.AspNetCore.Http;

namespace eStore.Models
{
  public class ProductViewModel
  {
    public Product newProduct { get; set; }
    public IFormFile Image { get; set; }
  }
}