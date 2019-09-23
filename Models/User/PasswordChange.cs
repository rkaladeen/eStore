using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models {
  public class PasswordChange
  { 
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Current Password")]
    public string CurrentPassword {get; set;}
    
    [Required]
    [MinLength(8, ErrorMessage="Password must be Between 6 and 18 characters in length")]
    [RegularExpression(@"^.*(?=.{6,18})(?=.*\d)(?=.*[A-Za-z])(?=.*[!%&#]{1,}).*$", ErrorMessage = "Password doesn't meet the requirements")]
    [DataType(DataType.Password)]
    [Display(Name = "New Password")]
    public string NewPassword {get; set;}

    [NotMapped]
    [Compare("NewPassword", ErrorMessage="Password does not match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string Confirm {get;set;}
  }
}