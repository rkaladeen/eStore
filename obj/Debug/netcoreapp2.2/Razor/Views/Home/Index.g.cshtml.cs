#pragma checksum "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "269f31295a0d5304a840fd905a27746aed654c4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"269f31295a0d5304a840fd905a27746aed654c4d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6a7cd37460f953b9787e736e6c4fe42df2fc1ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Search", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\rkala\Dropbox\c#.net\eStore\Views\Home\Index.cshtml"
  
  ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(43, 106, true);
            WriteLiteral("\r\n<style>\r\nhtml, body {\r\n  background-color: #f8f9fa;\r\n}\r\n\r\ntextarea {\r\n  resize: none;\r\n}\r\n</style>\r\n\r\n\r\n");
            EndContext();
            BeginContext(149, 24, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "269f31295a0d5304a840fd905a27746aed654c4d3677", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(173, 2848, true);
            WriteLiteral(@"</partial>


<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
  <ol class=""carousel-indicators"">
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
    <li data-target=""#carouselExampleIndicators"" data-slide-to=""3""></li>
  </ol>
  <div class=""carousel-inner"">

    <div class=""carousel-item active"">
      <img class=""img-fluid"" src=""//placehold.it/1950X400.png?text=Ad 1 Here"" style=""height: 400px;"" alt=""Image result for landscape images"">
    </div>
    <div class=""carousel-item"">
      <img class=""img-fluid"" src=""//placehold.it/1950X400.png?text=Ad 2 Here"" style=""height: 400px;"" alt=""Image result for landscape images"">
    </div>
    <div class=""carousel-item"">
      <img class=""img-fluid"" src=""//placehold.it/1950X400.png?text=Ad 3 Here"" style=""height: 400px;"" alt=""Image result f");
            WriteLiteral(@"or landscape images"">
    </div>
    <div class=""carousel-item"">
      <img class=""img-fluid"" src=""//placehold.it/1950X400.png?text=Ad 4 Here"" style=""height: 400px;"" alt=""Image result for landscape images"">
    </div>
  </div>
  <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
    <span class=""sr-only"">Previous</span>
  </a>
  <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
    <span class=""sr-only"">Next</span>
  </a>
</div>

<div class=""container"">
<div class=""row mx-0 py-2"">

  <div class=""col-sm-3"">
    <a class=""btn btn-dark h-100 w-100"" href=""/Store"">
      <div class=""card-body"">
        <h5 class=""card-title text-light"">Store</h5>
        <i class=""fas fa-store fa-3x text-warning""></i>
      </div>
    </a>
  </div>

  <div class=""c");
            WriteLiteral(@"ol-sm-3"">
    <a class=""btn btn-dark h-100 w-100"" href=""/Orders"">
      <div class=""card-body"">
        <h5 class=""card-title text-light"">Orders</h5>
        <i class=""fas fa-box-open fa-3x text-warning""></i>
      </div>
    </a>
  </div>

  <div class=""col-sm-3"">
    <a class=""btn btn-dark h-100 w-100"" href=""/Bids"">
      <div class=""card-body"">
        <h5 class=""card-title text-light"">Bids</h5>
        <i class=""fas fa-gavel fa-3x text-warning""></i>
      </div>
    </a>
  </div>

  <div class=""col-sm-3"">
    <a class=""btn btn-dark h-100 w-100"" href=""/Sell"">
      <div class=""card-body"">
        <h5 class=""card-title text-light"">Sell</h5>
        <i class=""fas fa-money-bill-wave fa-3x text-warning""></i>
      </div>
    </a>
  </div>

</div>
</div>




");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3040, 35, true);
                WriteLiteral("\r\n  <script>\r\n    \r\n\r\n  </script>\r\n");
                EndContext();
            }
            );
            BeginContext(3078, 2, true);
            WriteLiteral("\r\n");
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
