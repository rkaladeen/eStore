using Microsoft.AspNetCore.Http;

namespace eStore.Models
{
  public class RegisterModel
  {
    public User User { get; set; }
    public IFormFile Image { get; set; }
  }
}