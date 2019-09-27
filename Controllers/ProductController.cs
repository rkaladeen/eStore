using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using eStore.Models;

namespace eStore.Controllers
{
  public class ProductController : Controller
  {
    private readonly IHostingEnvironment hostingEnvironment;
    private readonly MyContext dbContext;
    public ProductController(MyContext dbContext, IHostingEnvironment hostingEnvironment)
    {
      this.dbContext = dbContext;
      this.hostingEnvironment = hostingEnvironment;
    }

    [HttpPost("/NewProduct")]
    public IActionResult NewProduct(ProductViewModel model)
    {
      if(ModelState.IsValid)
      {
        string uniqueFileName = null;
        if (model.Image != null)
        {
          string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
          uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
          string filePath = Path.Combine(uploadsFolder, uniqueFileName);
          model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
        }
        Product NewProduct = model.newProduct;
        NewProduct.ImagePath = uniqueFileName;

        dbContext.Products.Add(NewProduct);
        dbContext.SaveChanges();
        return Redirect("/Store");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      return View("Sell");
    }

    [HttpGet("/Store")]
    public IActionResult Store()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return Redirect("/LogIn");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.AllProducts = dbContext.Products.ToList();
      ViewBag.AllCategories = dbContext.Categories.ToList();
      return View();
    }

    [HttpGet("/Sell")]
    public IActionResult Sell()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return Redirect("/LogIn");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      return View();
    }

    [HttpGet("/Orders")]
    public IActionResult Orders()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return Redirect("/LogIn");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      return View();
    }

    [HttpGet("/Bids")]
    public IActionResult Bids()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return Redirect("/LogIn");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      return View();
    }

// public IActionResult Bid(int id)
    // {
    //   if (HttpContext.Session.GetString("UserName") == null ){
    //     return RedirectToAction("LogIn", "User");
    //   }
    //   Bid NewBid = new Bid()
    //   {
    //     PostId = id,
    //     UserId = (int)HttpContext.Session.GetInt32("UserId")
    //   };
    //   dbContext.Bids.Add(NewBid);
    //   dbContext.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public IActionResult cancelBid(int id)
    // {
    //   if (HttpContext.Session.GetString("UserName") == null ){
    //     return RedirectToAction("LogIn", "User");
    //   }
    //   Post onePost = dbContext.Posts.FirstOrDefault(a => a.PostId == id);
    //   dbContext.Posts.Remove(onePost);
    //   dbContext.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public IActionResult modifyBid(int id)
    // {
    //   if (HttpContext.Session.GetString("UserName") == null ){
    //     return RedirectToAction("LogIn", "User");
    //   }
    //   int? UserId = HttpContext.Session.GetInt32("UserId");
    //   Bid NewBid = dbContext.Bids
    //       .Where(r => r.PostId == id && r.UserId == UserId)
    //       .FirstOrDefault();

    //   dbContext.Bids.Update(NewBid);
    //   dbContext.SaveChanges();
    //   return RedirectToAction("Index");
    // }

  }
}