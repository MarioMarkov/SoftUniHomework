#pragma checksum "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\Categories\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da473d40e71c085d53bb46a88d1c7428b19c020b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_All), @"mvc.1.0.view", @"/Views/Categories/All.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/All.cshtml", typeof(AspNetCore.Views_Categories_All))]
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
#line 1 "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\_ViewImports.cshtml"
using FastFood.Web;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da473d40e71c085d53bb46a88d1c7428b19c020b", @"/Views/Categories/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e2355b4d2dd102d586b09f0f668ac669855f614", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Web.ViewModels.Categories.CategoryAllViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\Categories\All.cshtml"
  
    ViewData["Title"] = "All Categories";

#line default
#line hidden
            BeginContext(123, 267, true);
            WriteLiteral(@"<h1 class=""text-center"">All Categories</h1>
<hr class=""hr-2"" />
<table class=""table mx-auto"">
    <thead>
        <tr class=""row"">
            <th class=""col-md-1"">#</th>
            <th class=""col-md-2"">Category</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 16 "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\Categories\All.cshtml"
         for(var i = 0; i < Model.Count(); i++)
    {

#line default
#line hidden
            BeginContext(446, 59, true);
            WriteLiteral("        <tr class=\"row\">\r\n            <th class=\"col-md-1\">");
            EndContext();
            BeginContext(507, 3, false);
#line 19 "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\Categories\All.cshtml"
                             Write(i+1);

#line default
#line hidden
            EndContext();
            BeginContext(511, 40, true);
            WriteLiteral("</th>\r\n            <td class=\"col-md-2\">");
            EndContext();
            BeginContext(552, 13, false);
#line 20 "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\Categories\All.cshtml"
                            Write(Model[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(565, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 22 "C:\Users\PC\Desktop\SoftUni\C#DB Advanced\FoodShop\FastFood.Web\Views\Categories\All.cshtml"
    }

#line default
#line hidden
            BeginContext(594, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Web.ViewModels.Categories.CategoryAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
