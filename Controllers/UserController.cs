using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace eStore.Controllers
{
  public class UserController : Controller
  {
    private MyContext dbContext;
    public UserController(MyContext context)
    {
      dbContext = context;
    }
    public IActionResult NewUser()
    {
      return View();
    }
    public IActionResult LogIn()
    {
      return View();
    }
    public IActionResult LogOut()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("LogIn");
    }
    public IActionResult CreateUser(User User)
    {
      if(ModelState.IsValid)
      {
        if(dbContext.Users.Any(u => u.Email == User.Email))
        {
          ModelState.AddModelError("Email", "Email already in use!");
          return View("NewUser");
        }
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        User.Password = Hasher.HashPassword(User, User.Password);
        dbContext.Users.Add(User);
        dbContext.SaveChanges();
        HttpContext.Session.SetString("UserName", User.FirstName);
        HttpContext.Session.SetInt32("User_Id", User.UserId);
        return RedirectToAction("Index", "Home");
      }
      return View("NewUser");
    }

    public IActionResult LoginUser(LoginUser userSubmission)
    {
      if(ModelState.IsValid)
      {
        var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
        if(userInDb == null)
        {
          ModelState.AddModelError("Email", "Invalid Email/Password");
          return View("LogIn");
        }
        var hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
        
        if(result == 0)
        {
          ModelState.AddModelError("Email", "Invalid Email/Password");
          return View("LogIn");
        }
        else
        {
          HttpContext.Session.SetString("UserName", userInDb.FirstName);
          HttpContext.Session.SetInt32("UserId", userInDb.UserId);
          // ViewBag.UserName = HttpContext.Session.GetString("UserName");
          // ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
          return RedirectToAction("Index", "Home");
        }
      }
      else 
      {
        return View("LogIn");
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
