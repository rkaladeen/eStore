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
  public class HomeController : Controller
  {
    private MyContext dbContext;
    public HomeController(MyContext context)
    {
      dbContext = context;
    } 
    public IActionResult Index()
    {
      if(HttpContext.Session.GetString("UserName") != null)
      {
        
        // ViewBag.AllActivities = dbContext.Activities
        //     .Include(c => c.Coordinator)
        //     .Include(p => p.RSVPed)
        //       .ThenInclude(u2 => u2.User)
        //     .Include(p => p.RSVPed)            
        //       .ThenInclude(a => a.Activity)
        //     .Where(t => t.StartDateTime > DateTime.Now)
        //     .ToList()
        //     .OrderBy(u => u.StartDateTime);
        ViewBag.user_name = HttpContext.Session.GetString("UserName");
        ViewBag.UserId = HttpContext.Session.GetInt32("User_Id");

        return View("Index");
      }
      else
      {
        return RedirectToAction("LogIn", "User");
      }
    }

    // public IActionResult RSVP(int id)
    // {
    //   if (HttpContext.Session.GetString("UserName") == null ){
    //     return RedirectToAction("LogIn", "User");
    //   }
    //   RSVPModel NewRSVP = new RSVPModel()
    //   {
    //     Activity_Id = id,
    //     User_Id = (int)HttpContext.Session.GetInt32("User_Id")
    //   };
    //   dbContext.RSVPs.Add(NewRSVP);
    //   dbContext.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public IActionResult cancelActivity(int id)
    // {
    //   if (HttpContext.Session.GetString("UserName") == null ){
    //     return RedirectToAction("LogIn", "User");
    //   }
    //   ActivityModel oneActivity = dbContext.Activities.FirstOrDefault(a => a.Activity_Id == id);
    //   dbContext.Activities.Remove(oneActivity);
    //   dbContext.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public IActionResult leaveActivity(int id)
    // {
    //   if (HttpContext.Session.GetString("UserName") == null ){
    //     return RedirectToAction("LogIn", "User");
    //   }
    //   int? UserId = HttpContext.Session.GetInt32("User_Id");
    //   RSVPModel rsvp = dbContext.RSVPs
    //       .Where(r => r.Activity_Id == id && r.User_Id == UserId)
    //       .FirstOrDefault();

    //   dbContext.RSVPs.Remove(rsvp);
    //   dbContext.SaveChanges();
    //   return RedirectToAction("Index");
    // }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
