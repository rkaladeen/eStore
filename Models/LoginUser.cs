using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models {
  public class LoginUser
  {
    [Required]
    [EmailAddress]
    public string Email {get; set;}
    
    [Required]
    public string Password { get; set; }
  }
}