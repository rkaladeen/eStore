using Microsoft.AspNetCore.Http;

namespace eStore.Models
{
  public class RegisterViewModel
  {
    public User User { get; set; }
    public IFormFile Image { get; set; }
  }
}