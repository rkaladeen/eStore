#pragma checksum "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c491c2d1268455016de83cb0477ecf2aaabeba36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin__AllUsers), @"mvc.1.0.view", @"/Views/Admin/_AllUsers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/_AllUsers.cshtml", typeof(AspNetCore.Views_Admin__AllUsers))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\rkala\Dropbox\Projects\estore\Views\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#line 2 "C:\Users\rkala\Dropbox\Projects\estore\Views\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c491c2d1268455016de83cb0477ecf2aaabeba36", @"/Views/Admin/_AllUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a7cd37460f953b9787e736e6c4fe42df2fc1ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin__AllUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 365, true);
            WriteLiteral(@"<div class=""jumbotron shadow border mb-0 bg-light"">
  <h4>Registered Users</h4>

  <table class=""table"">
  <thead>
    <tr>
      <th scope=""col"">#</th>
      <th scope=""col"">First</th>
      <th scope=""col"">Last</th>
      <th scope=""col"">Email</th>
      <th scope=""col"">Status</th>
      <th scope=""col"">Action</th>
    </tr>
  </thead>
  <tbody>
");
            EndContext();
#line 16 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
      
      foreach(var user in ViewBag.AllUsers)
      {

#line default
#line hidden
            BeginContext(427, 36, true);
            WriteLiteral("      <tr>\r\n        <th scope=\"row\">");
            EndContext();
            BeginContext(464, 11, false);
#line 20 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
                   Write(user.UserId);

#line default
#line hidden
            EndContext();
            BeginContext(475, 19, true);
            WriteLiteral("</th>\r\n        <td>");
            EndContext();
            BeginContext(495, 14, false);
#line 21 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
       Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(509, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(529, 13, false);
#line 22 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
       Write(user.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(542, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(562, 10, false);
#line 23 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
       Write(user.Email);

#line default
#line hidden
            EndContext();
            BeginContext(572, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 24 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
         if(user.isAdmin)
        {

#line default
#line hidden
            BeginContext(617, 82, true);
            WriteLiteral("        <td>\r\n          <span class=\"badge badge-danger badge-pill\">Admin</span>\r\n");
            EndContext();
#line 28 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
           if(user.isActive)
          {

#line default
#line hidden
            BeginContext(742, 72, true);
            WriteLiteral("            <span class=\"badge badge-success badge-pill\">Active</span>\r\n");
            EndContext();
#line 31 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
          }
          else
          {

#line default
#line hidden
            BeginContext(856, 76, true);
            WriteLiteral("            <span class=\"badge badge-secondary badge-pill\">Inactive</span>\r\n");
            EndContext();
#line 35 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
          }

#line default
#line hidden
            BeginContext(945, 13, true);
            WriteLiteral("        </td>");
            EndContext();
#line 36 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
             ;
        }
        else
        {
          

#line default
#line hidden
#line 40 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
           if(user.isActive)
          {

#line default
#line hidden
            BeginContext(1040, 81, true);
            WriteLiteral("            <td><span class=\"badge badge-success badge-pill\">Active</span></td>\r\n");
            EndContext();
#line 43 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
          }
          else
          {

#line default
#line hidden
            BeginContext(1163, 85, true);
            WriteLiteral("            <td><span class=\"badge badge-secondary badge-pill\">Inactive</span></td>\r\n");
            EndContext();
#line 47 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
          }

#line default
#line hidden
#line 47 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
           
        }

#line default
#line hidden
            BeginContext(1272, 14, true);
            WriteLiteral("        <td>\r\n");
            EndContext();
#line 50 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
           if(user.UserId != ViewBag.UserId)
          {

#line default
#line hidden
            BeginContext(1345, 222, true);
            WriteLiteral("            <a href=\"#\" class=\"far fa-eye btn btn-sm nav-link btn-link text-secondary px-1\" title=\"Audit\"></a>\r\n            <a href=\"#\" class=\"far fa-edit btn btn-sm nav-link btn-link text-warning px-1\" title=\"Edit\"></a>\r\n");
            EndContext();
#line 55 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
             if(user.isActive)
            {

#line default
#line hidden
            BeginContext(1616, 120, true);
            WriteLiteral("              <a href=\"#\" class=\"fas fa-user-minus btn btn-sm nav-link btn-link text-black px-1\" title=\"Inactive\"></a>\r\n");
            EndContext();
#line 58 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
            }
            else{

#line default
#line hidden
            BeginContext(1770, 119, true);
            WriteLiteral("              <a href=\"#\" class=\"fas fa-user-plus btn btn-sm nav-link btn-link text-success px-1\" title=\"Active\"></a>\r\n");
            EndContext();
#line 61 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
            }

#line default
#line hidden
            BeginContext(1932, 117, true);
            WriteLiteral("            <a href=\"#\" class=\"fas fa-user-times btn btn-sm nav-link btn-link text-danger px-1\" title=\"Delete\"></a>\r\n");
            EndContext();
#line 65 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
            
          }

#line default
#line hidden
            BeginContext(2076, 26, true);
            WriteLiteral("        </td>\r\n      </tr>");
            EndContext();
#line 68 "C:\Users\rkala\Dropbox\Projects\estore\Views\Admin\_AllUsers.cshtml"
           ;
      }
    

#line default
#line hidden
            BeginContext(2121, 30, true);
            WriteLiteral("  </tbody>\r\n</table>\r\n\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
