using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eStore.Models;

namespace eStore.Controllers
{
  public class AdminController : Controller
  {
    private MyContext dbContext;
    public AdminController(MyContext context)
    {
      dbContext = context;
    } 
    
    [HttpGet("Admin")]
    public IActionResult Admin()
    {
      if(HttpContext.Session.GetString("UserName") == null || HttpContext.Session.GetInt32("isAdmin") == 0)
      {
        return Redirect("/LogIn");
      }
      else if(HttpContext.Session.GetInt32("isAdmin") == 1)
      {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
        ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
        ViewBag.AllCategories = dbContext.Categories.ToList();
        ViewBag.AllUsers = dbContext.Users.ToList();
        return View("Admin");
      }
      return Redirect("/LogIn");
    }

    [HttpPost("/AddCategory")]
    [ValidateAntiForgeryToken]
    public IActionResult AddCategory(ProductCategory model)
    {
      if(ModelState.IsValid)
      {
        if(dbContext.Categories.Any(c => c.Name == model.Name))
        {
          ModelState.AddModelError("Name", "Category already exists!");
          ViewBag.UserName = HttpContext.Session.GetString("UserName");
          ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
          ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
          ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
          ViewBag.AllCategories = dbContext.Categories.ToList();
          ViewBag.AllUsers = dbContext.Users.ToList();
          return View("Admin");
        }

        dbContext.Categories.Add(model);
        dbContext.SaveChanges();
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
        ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
        ViewBag.AllCategories = dbContext.Categories.ToList();
        ViewBag.AllUsers = dbContext.Users.ToList();
        return View("Admin");
      }
      return RedirectToAction("Admin");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
