﻿using System;
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
  public class HomeController : Controller
  {
    private MyContext dbContext;
    public HomeController(MyContext context)
    {
      dbContext = context;
    } 
    
    public IActionResult Index()
    {
      if(HttpContext.Session.GetString("UserName") == null)
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
