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
  public class AuthController : Controller
  {
    private readonly IHostingEnvironment hostingEnvironment;
    private readonly MyContext dbContext;
    
    public AuthController(MyContext dbContext, IHostingEnvironment hostingEnvironment)
    {
      this.dbContext = dbContext;
      this.hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    public IActionResult Register()
    { return View(); }
    
    [HttpGet]
    public IActionResult LogIn()
    { return View(); }
    
    [HttpGet]
    public IActionResult LogOut()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("LogIn");
    }
    
    [HttpGet]
    public IActionResult Account()
    {
      if (HttpContext.Session.GetInt32("UserId") == null )
      { return RedirectToAction("LogIn", "User"); }

      ViewBag.UserName = HttpContext.Session.GetString("UserName");
      ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
      ViewBag.isAdmin = HttpContext.Session.GetInt32("isAdmin");
      ViewBag.Avatar = HttpContext.Session.GetString("Avatar");
      ViewBag.Cart = HttpContext.Session.GetInt32("Cart");
      int? id = HttpContext.Session.GetInt32("UserId");
      User oneUser = dbContext.Users.FirstOrDefault(a => a.UserId == id);
      ViewBag.CurrentUser = oneUser;

      return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterModel model)
    {
      if(!ModelState.IsValid)
      { return View(); }

      if(dbContext.Users.Any(u => u.Email == model.User.Email))
      {
        ModelState.AddModelError("Email", "Email already in use!");
        return View();
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
      HttpContext.Session.SetInt32("Cart", getCartCount(model.User.UserId));
      HttpContext.Session.SetInt32("isAdmin", isAdmin(model.User.isAdmin));
      HttpContext.Session.SetString("Avatar", model.User.AvatarPath);

      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult LogIn(LogInModel model)
    {
      if(!ModelState.IsValid)
      { return View(); }

      var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == model.Email);
      if(userInDb == null)
      {
        ModelState.AddModelError("Password", "Invalid Email/Password");
        return View();
      }
      var hasher = new PasswordHasher<LogInModel>();
      var result = hasher.VerifyHashedPassword(model, userInDb.Password, model.Password);
      if(result == 0)
      {
        ModelState.AddModelError("Password", "Invalid Email/Password");
        return View();
      }
      HttpContext.Session.SetString("UserName", userInDb.FirstName);
      HttpContext.Session.SetInt32("UserId", userInDb.UserId);
      HttpContext.Session.SetInt32("Cart", getCartCount(userInDb.UserId));
      HttpContext.Session.SetInt32("isAdmin", isAdmin(userInDb.isAdmin));
      HttpContext.Session.SetString("Avatar", userInDb.AvatarPath);

      return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public IActionResult ChangePassword(PasswordChange userSubmission)
    {
      if(!ModelState.IsValid)
      {
        return View("Account");
      }
      int? id = HttpContext.Session.GetInt32("UserId");
      User oneUser = dbContext.Users.FirstOrDefault(a => a.UserId == id);

      var hasher = new PasswordHasher<PasswordChange>();
      var result = hasher.VerifyHashedPassword(userSubmission, oneUser.Password, userSubmission.CurrentPassword);
      
      if(result == 0)
      {
        ModelState.AddModelError("CurrentPassword", "Invalid Password");
        return View("Account");
      }
      PasswordHasher<PasswordChange> Hasher = new PasswordHasher<PasswordChange>();
      userSubmission.NewPassword = Hasher.HashPassword(userSubmission, userSubmission.NewPassword);
      oneUser.Password = userSubmission.NewPassword;
      dbContext.SaveChanges();
      ModelState.AddModelError("Success", "Password updated!");
      return View("Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public int getCartCount(int id)
    {
      Cart userCart = dbContext.Carts
            .Include(p => p.Products)
            .FirstOrDefault(u => u.UserId == id && u.isCheckedOut == false);

      if (userCart != null)
      {
        return userCart.Products.Count;
      }
      else
      {
        return 0;
      }
    }

    public int isAdmin(bool Role)
    {
      int isAdmin = 0;
      if (Role)
      {
        isAdmin = 1;
      }
      return isAdmin;
    }
  }
}
