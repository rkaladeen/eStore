#pragma checksum "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be569ef890ae005dd88898c37872ab7d9bd66294"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Store), @"mvc.1.0.view", @"/Views/Product/Store.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Store.cshtml", typeof(AspNetCore.Views_Product_Store))]
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
#line 1 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#line 2 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be569ef890ae005dd88898c37872ab7d9bd66294", @"/Views/Product/Store.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a7cd37460f953b9787e736e6c4fe42df2fc1ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Store : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-11 col-md-6 mx-auto shadow-lg px-0 rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
  
  ViewData["Title"] = "Store";

#line default
#line hidden
            BeginContext(39, 149, true);
            WriteLiteral("\r\n<style>\r\n  html, body {\r\n    background-color: #f8f9fa;\r\n  }\r\n\r\n  textarea {\r\n    resize: none;\r\n  }\r\n</style>\r\n\r\n<div class=\"bg-primary py-4\">\r\n  ");
            EndContext();
            BeginContext(188, 662, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be569ef890ae005dd88898c37872ab7d9bd662944800", async() => {
                BeginContext(249, 594, true);
                WriteLiteral(@"
    <div class=""input-group"">
      <!-- <select class=""input-group-append border bg-dark text-light rounded"">
        <option selected>All</option>
        <option value=""1"">One</option>
        <option value=""2"">Two</option>
        <option value=""3"">Three</option>
      </select> -->
      <textarea class=""form-control form-control-lg"" id=""validationDefaultUsername"" rows=""1"" placeholder=""Search""></textarea>
      <div class=""input-group-append"">
        <button class=""btn btn-warning"" type=""button""><i class=""fas fa-search""></i></button>
      </div>
      
    </div>
  ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(850, 142, true);
            WriteLiteral("\r\n</div>\r\n<div class=\"container\">\r\n  <div class=\"row mx-0 mt-3\">\r\n    <div class=\"col-md-3\">\r\n      \r\n    </div>\r\n    <div class=\"col-md-9\">\r\n");
            EndContext();
#line 38 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
      
      foreach(Product Product in ViewBag.AllProducts)
      {
        var photoPath = "~/images/" + (Product.ImagePath ?? "noimage.png");

#line default
#line hidden
            BeginContext(1141, 130, true);
            WriteLiteral("        <div class=\"card mb-3 w-100\"\\>\r\n          <div class=\"row no-gutters\">\r\n            <div class=\"col-md-4\">\r\n              ");
            EndContext();
            BeginContext(1271, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "be569ef890ae005dd88898c37872ab7d9bd662947613", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
            WriteLiteral(photoPath);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 45 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1346, 136, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-8\">\r\n              <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
            EndContext();
            BeginContext(1483, 13, false);
#line 49 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
                                  Write(Product.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1496, 44, true);
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
            EndContext();
            BeginContext(1541, 19, false);
#line 50 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
                                Write(Product.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1560, 69, true);
            WriteLiteral("</p>\r\n                <p class=\"card-text\"><small class=\"text-muted\">");
            EndContext();
            BeginContext(1630, 24, false);
#line 51 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
                                                          Write(Product.TimeDiffUpdate());

#line default
#line hidden
            EndContext();
            BeginContext(1654, 88, true);
            WriteLiteral("</small></p>\r\n              </div>\r\n            </div>\r\n          </div>\r\n        </div>");
            EndContext();
#line 55 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Product\Store.cshtml"
              ;
      }
    

#line default
#line hidden
            BeginContext(1761, 28, true);
            WriteLiteral("    </div>\r\n  </div>\r\n</div>");
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
