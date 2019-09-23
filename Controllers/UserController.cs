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

    [HttpGet("User/Register")]
    public IActionResult NewUser()
    {
      return View();
    }

    [HttpGet("Login")]
    public IActionResult LogIn()
    {
      return View();
    }

    [HttpGet("User/Account")]
    public IActionResult Account()
    {
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      if (HttpContext.Session.GetInt32("UserId") == null ){
        return RedirectToAction("LogIn", "User");
      }
      int? id = HttpContext.Session.GetInt32("UserId");
      User oneUser = dbContext.Users.FirstOrDefault(a => a.UserId == id);
      ViewBag.CurrentUser = oneUser;
      return View();
    }

    [HttpGet("Logout")]
    public IActionResult LogOut()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("LogIn");
    }

    [HttpPost("User/Create")]
    [ValidateAntiForgeryToken]
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
        return Redirect("");
      }
      return View("NewUser");
    }

    [HttpPost("LoginPOST")]
    [ValidateAntiForgeryToken]
    public IActionResult LoginPOST(LoginUser userSubmission)
    {
      if(ModelState.IsValid)
      {
        var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
        if(userInDb == null)
        {
          ModelState.AddModelError("Password", "Invalid Email/Password");
          return View("LogIn");
        }
        var hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
        
        if(result == 0)
        {
          ModelState.AddModelError("Password", "Invalid Email/Password");
          return View("LogIn");
        }
        else
        {
          HttpContext.Session.SetString("UserName", userInDb.FirstName);
          HttpContext.Session.SetInt32("UserId", userInDb.UserId);
          return Redirect("/");
        }
      }
      else 
      {
        return View("LogIn");
      }
    }

    [HttpPost("ChangePassword")]
    [ValidateAntiForgeryToken]
    public IActionResult ChangePassword(PasswordChange userSubmission)
    {
      if(ModelState.IsValid)
      {
        int? id = HttpContext.Session.GetInt32("UserId");
        User oneUser = dbContext.Users.FirstOrDefault(a => a.UserId == id);

        var hasher = new PasswordHasher<PasswordChange>();
        var result = hasher.VerifyHashedPassword(userSubmission, oneUser.Password, userSubmission.CurrentPassword);
        
        if(result == 0)
        {
          ModelState.AddModelError("CurrentPassword", "Invalid Password");
          return View("Account");
        }
        else
        {
          PasswordHasher<PasswordChange> Hasher = new PasswordHasher<PasswordChange>();
          userSubmission.NewPassword = Hasher.HashPassword(userSubmission, userSubmission.NewPassword);
          oneUser.Password = userSubmission.NewPassword;
          dbContext.SaveChanges();
          ModelState.AddModelError("Success", "Password updated!");
          return View("Account");
        }
      }
      else 
      {
        return View("Account");
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
