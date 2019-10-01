using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using eStore.Models;

namespace eStore.Controllers
{
  public class UserController : Controller
  {
    private readonly IHostingEnvironment hostingEnvironment;
    private readonly MyContext dbContext;
    public UserController(MyContext dbContext, IHostingEnvironment hostingEnvironment)
    {
      this.dbContext = dbContext;
      this.hostingEnvironment = hostingEnvironment;
    }

    public IActionResult NewUser()
    {
      return View();
    }

    public IActionResult LogIn()
    {
      return View();
    }

    public IActionResult Account()
    {
      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");

      if (HttpContext.Session.GetInt32("UserId") == null ){
        return RedirectToAction("LogIn", "User");
      }
      int? id = HttpContext.Session.GetInt32("UserId");
      User oneUser = dbContext.Users.FirstOrDefault(a => a.UserId == id);
      ViewBag.CurrentUser = oneUser;
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      return View();
    }

    public IActionResult LogOut()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("LogIn");
    }

    [ValidateAntiForgeryToken]
    public IActionResult CreateUser(RegisterViewModel model)
    {
      if(ModelState.IsValid)
      {

        if(dbContext.Users.Any(u => u.Email == model.User.Email))
        {
          ModelState.AddModelError("Email", "Email already in use!");
          return View("NewUser");
        }

        string uniqueFileName = null;
        if (model.Image != null)
        {
          string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
          uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
          string filePath = Path.Combine(uploadsFolder, uniqueFileName);
          model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
        }
        User NewUser = model.User;
        NewUser.AvatarPath = uniqueFileName;
        NewUser.isActive = true;
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        model.User.Password = Hasher.HashPassword(model.User, model.User.Password);
        dbContext.Users.Add(NewUser);
        dbContext.SaveChanges();

        HttpContext.Session.SetString("UserName", model.User.FirstName);
        HttpContext.Session.SetInt32("UserId", model.User.UserId);
        int Admin = 0;
        if(model.User.isAdmin)
        {
          Admin = 1;
        }
        HttpContext.Session.SetInt32("isAdmin", Admin);
        HttpContext.Session.SetString("Avatar", model.User.AvatarPath);
        return Redirect("/");
      }
      return View("NewUser");
    }

    [ValidateAntiForgeryToken]
    public IActionResult LoginPOST(LoginUser userSubmission)
    {
      if(ModelState.IsValid)
      {
        var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
        Cart userCart = dbContext.Carts
            .Include(p => p.Products)
            .FirstOrDefault(u => u.UserId == userInDb.UserId && u.isCheckedOut == false);

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
          int Admin = 0;
          if(userInDb.isAdmin)
          {
            Admin = 1;
          }
          HttpContext.Session.SetInt32("isAdmin", Admin);
          HttpContext.Session.SetString("Avatar", userInDb.AvatarPath);
          HttpContext.Session.SetInt32("Cart", userCart.Products.Count);
          // HttpContext.Session.SetInt32("Messages", );
          return RedirectToAction("Index", "Home");
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
