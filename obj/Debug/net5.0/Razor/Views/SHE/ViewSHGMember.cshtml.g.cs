#pragma checksum "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac4d62bafd5fcb6428d0d17a801954faeb9b88f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SHE_ViewSHGMember), @"mvc.1.0.view", @"/Views/SHE/ViewSHGMember.cshtml")]
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
#nullable restore
#line 1 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\_ViewImports.cshtml"
using KalamYouthForumWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\_ViewImports.cshtml"
using KalamYouthForumWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac4d62bafd5fcb6428d0d17a801954faeb9b88f7", @"/Views/SHE/ViewSHGMember.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e94fa1f122e6d927d14e449fd6d4d314bae7c0e7", @"/Views/_ViewImports.cshtml")]
    public class Views_SHE_ViewSHGMember : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KalamYouthForumWebApp.Models.SHGMember>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
  
    ViewData["Title"] = "View SHG Member";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>SHG Member Details</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.Dob));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.Dob));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.Phone1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.Phone2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.Phone2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayNameFor(model => model.SHEModel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\SHE\ViewSHGMember.cshtml"
       Write(Html.DisplayFor(model => model.SHEModel.ElectedPresident));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KalamYouthForumWebApp.Models.SHGMember> Html { get; private set; }
    }
}
#pragma warning restore 1591
