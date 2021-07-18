#pragma checksum "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "110f27059bedb99e8f1841e230f8747cf33220bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_Details), @"mvc.1.0.view", @"/Views/Administration/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"110f27059bedb99e8f1841e230f8747cf33220bb", @"/Views/Administration/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e94fa1f122e6d927d14e449fd6d4d314bae7c0e7", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KalamYouthForumWebApp.Models.ViewModels.RoleUserListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUsersInRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
  
    ViewData["Title"] = "Role List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details of roles and associated members</h1>\r\n\r\n<div>\r\n    <h4>");
#nullable restore
#line 10 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
   Write(Html.DisplayFor(model => model.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <div class=\"container\">\r\n");
#nullable restore
#line 13 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
          
            if (Model.Users == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>No users associated with this role</p>\r\n");
#nullable restore
#line 17 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Members belonging to this role</p>\r\n                <ul>\r\n");
#nullable restore
#line 22 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                       foreach (var user in Model.Users)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                ");
#nullable restore
#line 25 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                           Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <ul>\r\n                                <li>Name : ");
#nullable restore
#line 27 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                                      Write(user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>Email : ");
#nullable restore
#line 28 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                                       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li>PhoneNumber : ");
#nullable restore
#line 29 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                                             Write(user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                            </ul>\r\n                        </li>\r\n");
#nullable restore
#line 32 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                    }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n");
#nullable restore
#line 35 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n<div>\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "110f27059bedb99e8f1841e230f8747cf33220bb8366", async() => {
                WriteLiteral("Add or Remove Users");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-roleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\Administration\Details.cshtml"
                                                                          WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-roleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["roleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "110f27059bedb99e8f1841e230f8747cf33220bb10883", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KalamYouthForumWebApp.Models.ViewModels.RoleUserListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591