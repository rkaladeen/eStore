using eStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace eStore
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<MyContext>(options => 
        options.UseMySql(Configuration["DBInfo:ConnectionString"]));
      services.AddSession(); 
      services.AddMvc();

    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseSession();
      app.UseStaticFiles();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          "Default", // Route name
          "{controller}/{action}/{id?}", // URL with parameters
          new { controller = "Auth", action = "LogIn" }); // Parameter defaults
      });
    }
  }
}
