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
      ViewBag.user_name = null;
      HttpContext.Session.Clear();
      return RedirectToAction("LogIn");
    }
    public IActionResult CreateUser(UserModel User)
    {
      if(ModelState.IsValid)
      {
        if(dbContext.Users.Any(u => u.Email == User.Email))
        {
          ModelState.AddModelError("Email", "Email already in use!");
          return View("NewUser");
        }
        PasswordHasher<UserModel> Hasher = new PasswordHasher<UserModel>();
        User.Password = Hasher.HashPassword(User, User.Password);
        dbContext.Users.Add(User);
        dbContext.SaveChanges();
        HttpContext.Session.SetString("UserName", User.FirstName);
        HttpContext.Session.SetInt32("User_Id", User.User_Id);
        ViewBag.user_id = HttpContext.Session.GetInt32("User_Id");
        ViewBag.user_name = HttpContext.Session.GetString("UserName");
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View("NewUser");
      }
    }

    public IActionResult LoginUser(LoginUser userSubmission)
    {
      if(ModelState.IsValid)
      {
        // If inital ModelState is valid, query for a user with provided email
        var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
        // If no user exists with provided email
        if(userInDb == null)
        {
          // Add an error to ModelState and return to View!
          ModelState.AddModelError("Email", "Invalid Email/Password");
          return View("LogIn");
        }
        
        // Initialize hasher object
        var hasher = new PasswordHasher<LoginUser>();
        
        // verify provided password against hash stored in db
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
        
        // result can be compared to 0 for failure
        if(result == 0)
        {
          // handle failure (this should be similar to how "existing email" is handled)
          ModelState.AddModelError("Email", "Invalid Email/Password");
          return View("LogIn");
        }
        else
        {
          HttpContext.Session.SetString("UserName", userInDb.FirstName);
          HttpContext.Session.SetInt32("User_Id", userInDb.User_Id);
          ViewBag.user_name = HttpContext.Session.GetString("UserName");
          ViewBag.UserId = HttpContext.Session.GetInt32("User_Id");

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
