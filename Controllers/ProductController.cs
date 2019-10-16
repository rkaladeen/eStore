using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

    public IActionResult Search(SearchModel input)
    {
      if(input.SearchValue == null && input.CategoryId == 0)
      {
        ViewBag.AllProducts = dbContext.Products.Where(i => i.Status == "Available").DefaultIfEmpty().ToList();
      }
      else if(input.SearchValue != null && input.CategoryId == 0)
      {
        ViewBag.AllProducts = dbContext.Products.Where(p => p.Title.Contains(input.SearchValue) && p.Status == "Available").DefaultIfEmpty().ToList();
      }
      else if(input.SearchValue == null && input.CategoryId != 0)
      {
        ViewBag.AllProducts = dbContext.Products.Where(c => c.CategoryId == input.CategoryId && c.Status == "Available").DefaultIfEmpty().ToList();
      }
      else if(input.SearchValue != null && input.CategoryId != 0) 
      {
        ViewBag.AllProducts = dbContext.Products.Where(c => c.CategoryId == input.CategoryId && c.Title.Contains(input.SearchValue) && c.Status == "Available").DefaultIfEmpty().ToList();
      }
      Console.WriteLine(ViewBag.AllProducts);
      
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      return View("Store");
    }

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
        if(NewProduct.isAuction){
          Bid InitialBid = new Bid(){
            UserId = (int)NewProduct.SellerId,
            ProductId = NewProduct.Id,
            BidAmount = (double)NewProduct.BidStartPrice
          };
          dbContext.Bids.Add(InitialBid);
          dbContext.SaveChanges();
        }
        return RedirectToAction("Store");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      return View("Sell");
    }

    public IActionResult Store()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return RedirectToAction("LogIn", "Auth");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.AllProducts = dbContext.Products.ToList().Where(i => i.Status == "Available");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      return View();
    }

    public IActionResult Sell()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return RedirectToAction("LogIn", "Auth");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      return View();
    }

    public IActionResult Orders()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return RedirectToAction("LogIn", "Auth");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      return View();
    }

    public IActionResult Bids()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return RedirectToAction("LogIn", "Auth");
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
        return RedirectToAction("LogIn", "Auth");
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
        ViewBag.AllProducts = dbContext.Products.ToList().Where(i => i.Status == "Available");
        ViewBag.AllCategories = dbContext.Categories.ToList();
        ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
        return View("Store");
      }
      int? UserId = HttpContext.Session.GetInt32("UserId");
      Cart userCart = dbContext.Carts.Include(p => p.Products)
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
        userCart = newCart;
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
        ViewBag.AllProducts = dbContext.Products.ToList().Where(i => i.Status == "Available");
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
      return RedirectToAction("Cart");
    }

    public IActionResult Details(int id)
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return RedirectToAction("LogIn", "Auth");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      ViewBag.AllCategories = dbContext.Categories.ToList();

      var Product = dbContext.Products.Include(s => s.Seller)
                                      .Include(c => c.Category)
                                      .FirstOrDefault(p => p.Id == id);
      ViewBag.Product = Product;

      var HighestBid = dbContext.Bids.OrderByDescending(b => b.BidAmount)
                                     .Include(u => u.Bidder)
                                     .FirstOrDefault(p => p.ProductId == id);
      if(HighestBid == null)
      {
        ViewBag.HighestBid = Product.BidStartPrice;
      }
      else
      {
        ViewBag.HighestBid = HighestBid.BidAmount;
        ViewBag.HighestBidder = HighestBid;
      }
      return View();
    }

    public IActionResult Bid(Bid model)
    {
      var HighestBid = dbContext.Bids.OrderByDescending(b => b.BidAmount).FirstOrDefault(p => p.ProductId == model.ProductId);
      if(ModelState.IsValid && model.BidAmount > HighestBid.BidAmount)
      {
        dbContext.Bids.Add(model);
        dbContext.SaveChanges();
        return RedirectToAction("Store");
      }
      if(model.BidAmount <= HighestBid.BidAmount)
      {
        ModelState.AddModelError("BidAmount", "Please bid $1.00 higher than current bid");
      }
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      ViewBag.AllCategories = dbContext.Categories.ToList();
      var Product = dbContext.Products.Include(s => s.Seller)
                                      .Include(c => c.Category)
                                      .FirstOrDefault(p => p.Id == model.ProductId);
      ViewBag.Product = Product;
      if(HighestBid == null)
      {
        ViewBag.HighestBid = Product.BidStartPrice;
      }
      else
      {
        ViewBag.HighestBid = HighestBid.BidAmount;
      }
      return View("Details");
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

    [HttpGet]
    public IActionResult Checkout()
    {
      if (HttpContext.Session.GetString("UserName") == null)
      {
        return RedirectToAction("LogIn", "Auth");
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
    [HttpPost]
    public IActionResult Checkout(int CartId)
    {
      return RedirectToAction("Index", "Home");
    }

  }
}