using Microsoft.EntityFrameworkCore;
 
namespace eStore.Models
{
  public class MyContext : DbContext
  {
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users {get;set;}
    public DbSet<ProductCategory> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }

  }

}