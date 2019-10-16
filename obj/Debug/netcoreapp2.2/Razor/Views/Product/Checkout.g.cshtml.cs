#pragma checksum "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d5b4fc8d9a1208ffcc2a7244f5b69b93275cfae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Checkout), @"mvc.1.0.view", @"/Views/Product/Checkout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Checkout.cshtml", typeof(AspNetCore.Views_Product_Checkout))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d5b4fc8d9a1208ffcc2a7244f5b69b93275cfae", @"/Views/Product/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a7cd37460f953b9787e736e6c4fe42df2fc1ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveFromCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link btn-sm pl-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
  
  ViewData["Title"] = "Checkout";
  int Quantity = 0;
  double Subtotal = 0;

#line default
#line hidden
            BeginContext(87, 61, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n  <h1 class=\"display-4\">Checkout (");
            EndContext();
            BeginContext(149, 31, false);
#line 8 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
                             Write(ViewBag.UserCart.Products.Count);

#line default
#line hidden
            EndContext();
            BeginContext(180, 100, true);
            WriteLiteral(" item)</h1>\r\n\r\n  <div class=\"row\">\r\n    <div class=\"col-sm-9 mb-3\">\r\n      <ul class=\"list-group\">\r\n");
            EndContext();
#line 13 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
         foreach(Product item in ViewBag.UserCart.Products)
        {
          var photoPath = "~/images/" + (item.ImagePath ?? "noimage.png");
          Subtotal += (double)item.Price;

#line default
#line hidden
            BeginContext(471, 147, true);
            WriteLiteral("          <li class=\"list-group-item\">\r\n            \r\n            <div class=\"row no-gutters\">\r\n              <div class=\"col-2\">\r\n                ");
            EndContext();
            BeginContext(618, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9d5b4fc8d9a1208ffcc2a7244f5b69b93275cfae6575", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
#line 21 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
              WriteLiteral(photoPath);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 21 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 21 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
AddHtmlAttributeValue("", 688, photoPath, 688, 10, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(700, 142, true);
            WriteLiteral("\r\n              </div>\r\n              <div class=\"col-10\">\r\n                <div class=\"card-body\">\r\n                  <h5 class=\"card-title\">");
            EndContext();
            BeginContext(843, 10, false);
#line 25 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
                                    Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(853, 59, true);
            WriteLiteral("</h5>\r\n                  <p class=\"card-text text-danger\">$");
            EndContext();
            BeginContext(913, 10, false);
#line 26 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
                                               Write(item.Price);

#line default
#line hidden
            EndContext();
            BeginContext(923, 24, true);
            WriteLiteral("</p>\r\n                  ");
            EndContext();
            BeginContext(947, 98, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d5b4fc8d9a1208ffcc2a7244f5b69b93275cfae10050", async() => {
                BeginContext(1035, 6, true);
                WriteLiteral("Remove");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 27 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
                                                   WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1045, 83, true);
            WriteLiteral("\r\n                </div>\r\n              </div>\r\n            </div>\r\n          </li>");
            EndContext();
#line 31 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
               ;
        }

#line default
#line hidden
            BeginContext(1142, 27, true);
            WriteLiteral("      </ul>\r\n    </div>\r\n\r\n");
            EndContext();
#line 36 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
     if(ViewBag.UserCart.Products.Count != 0)
    {
      Quantity = ViewBag.UserCart.Products.Count;

#line default
#line hidden
            BeginContext(1274, 1181, true);
            WriteLiteral(@"      <div class=""col-sm-3 card bg-light h-100"">
        <div class=""card-body"">
          <div class=""card-title"">Order Summary</div>
          
          <div class=""d-flex justify-content-between"">
            <small class=""card-text mb-0"">Items:</small>
            <small class=""card-text mb-0"">$12.39</small>
          </div>

          <div class=""d-flex justify-content-between"">
            <small class=""card-text mb-0"">Shipping:</small>
            <small class=""card-text mb-0"">$12.39</small>
          </div>

          <div class=""d-flex justify-content-between"">
            <small class=""card-text mb-0"">Total before tax:</small>
            <small class=""card-text mb-0"">$12.39</small>
          </div>

          <div class=""d-flex justify-content-between"">
            <small class=""card-text mb-0"">Tax:</small>
            <small class=""card-text mb-0"">$12.39</small>
          </div>

          <div class=""d-flex justify-content-between border-top border-bottom"">
            <");
            WriteLiteral("p class=\"card-text text-danger mb-0\">Order Total:</p>\r\n            <p class=\"card-text text-danger mb-0\">$12.39</p>\r\n          </div>\r\n          \r\n          ");
            EndContext();
            BeginContext(2455, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d5b4fc8d9a1208ffcc2a7244f5b69b93275cfae14404", async() => {
                BeginContext(2539, 16, true);
                WriteLiteral("Place your order");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2559, 32, true);
            WriteLiteral("\r\n        </div>\r\n      </div>\r\n");
            EndContext();
#line 71 "C:\Users\rkala\Dropbox\Projects\estore\Views\Product\Checkout.cshtml"
    }

#line default
#line hidden
            BeginContext(2598, 36, true);
            WriteLiteral("    </div> <!--End of Row-->\r\n</div>");
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
