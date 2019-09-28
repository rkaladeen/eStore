using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
    [ValidateAntiForgeryToken]
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
        NewProduct.Status = "Available";
        dbContext.Products.Add(NewProduct);
        dbContext.SaveChanges();
        return Redirect("/Store");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
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
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.AllProducts = dbContext.Products
                              .ToList()
                              .Where(i => i.Status == "Available");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
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
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
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
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
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
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      return View();
    }

    public IActionResult Cart()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return Redirect("/LogIn");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");

      ViewBag.UserCart = dbContext.Carts
        .Include(p => p.Products)
        .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
      return View();
    }

    public IActionResult AddtoCart(int id)
    {
      Product itemToAdd = dbContext.Products.FirstOrDefault(p => p.Id == id);
      if(itemToAdd.Status != "Available")
      {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
        ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
        ViewBag.AllProducts = dbContext.Products
                              .ToList()
                              .Where(i => i.Status == "Available");
        ViewBag.AllCategories = dbContext.Categories.ToList();
        ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
        return View("Store");
      }
      int? UserId = HttpContext.Session.GetInt32("UserId");
      Cart userCart = dbContext.Carts
            .Include(p => p.Products)
            .FirstOrDefault(u => u.UserId == UserId && u.isCheckedOut == false);
      if(userCart == null)
      {
        Cart newCart = new Cart()
        {
          UserId = (int)UserId
        };
        newCart.Products.Add(itemToAdd);
        dbContext.Carts.Add(newCart);
        dbContext.SaveChanges();
      }
      else
      {
        userCart.Products.Add(itemToAdd);
        dbContext.SaveChanges();
      }
      itemToAdd.Status = "inCart";
      dbContext.SaveChanges();


      HttpContext.Session.SetInt32("Cart", userCart.Products.Count);
      return RedirectToAction("Store");
    }

    public IActionResult RemoveFromCart(int id)
    {
      Product itemToRemove = dbContext.Products.FirstOrDefault(p => p.Id == id);
      if(itemToRemove.Status != "inCart")
      {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
        ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
        ViewBag.AllProducts = dbContext.Products
                              .ToList()
                              .Where(i => i.Status == "Available");
        ViewBag.AllCategories = dbContext.Categories.ToList();
        ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
        return View("Store");
      }
      int? UserId = HttpContext.Session.GetInt32("UserId");
      
      Cart userCart = dbContext.Carts.FirstOrDefault(c => c.UserId == UserId && c.isCheckedOut == false);
      userCart.Products.Remove(itemToRemove);
      dbContext.SaveChanges();
      itemToRemove.Status = "Available";
      dbContext.SaveChanges();
      HttpContext.Session.SetInt32("Cart", userCart.Products.Count);
      return RedirectToAction("Store");
    }

    public IActionResult Bid(int id)
    {
      Bid NewBid = new Bid()
      {
        Id = id,
        UserId = (int)HttpContext.Session.GetInt32("UserId")
      };
      dbContext.Bids.Add(NewBid);
      dbContext.SaveChanges();
      return RedirectToAction("Store");
    //Need to add price to bid model
    }

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