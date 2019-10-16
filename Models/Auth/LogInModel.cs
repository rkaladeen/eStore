using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models {
  public class LogInModel
  {
    [Required(ErrorMessage="{0} is required")]
    [EmailAddress(ErrorMessage="Please enter a valid {0}")]
    public string Email {get; set;}
    
    [Required(ErrorMessage="{0} is required")]
    public string Password { get; set; }
  }
}