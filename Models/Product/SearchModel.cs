using System.ComponentModel.DataAnnotations;

namespace eStore.Models
{
  public class SearchModel
  {
    public string SearchValue {get; set;}
    public int CategoryId {get; set;} 
  }
}