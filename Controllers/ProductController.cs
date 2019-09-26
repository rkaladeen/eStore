using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace eStore.Controllers
{
  public class ProductController : Controller
  {
    private MyContext dbContext;
    public ProductController(MyContext context)
    {
      dbContext = context;
    }

    [HttpPost("/NewProduct")]
    public IActionResult NewProduct(Product product)
    {
      if(ModelState.IsValid)
      {
        dbContext.Add(product);
        dbContext.SaveChanges();
      }
      return Redirect("/");
    }

    public void UploadImages(List<ProductImage> images)
    {
      if(ModelState.IsValid)
      {
        foreach(var image in images)
        {
          dbContext.Add(image);
          dbContext.SaveChanges();
        }
      }
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