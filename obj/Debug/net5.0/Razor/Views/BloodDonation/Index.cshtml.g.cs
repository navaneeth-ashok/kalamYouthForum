#pragma checksum "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5ff410cfd5073c346cc5f96df4ae79fcb7ca724"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BloodDonation_Index), @"mvc.1.0.view", @"/Views/BloodDonation/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5ff410cfd5073c346cc5f96df4ae79fcb7ca724", @"/Views/BloodDonation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e94fa1f122e6d927d14e449fd6d4d314bae7c0e7", @"/Views/_ViewImports.cshtml")]
    public class Views_BloodDonation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KalamYouthForumWebApp.Models.DonorDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/BloodDonation/Index"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
  
    ViewData["Title"] = "Blood Donors List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"registration-card blood-form mt-5\">\r\n    <h1 class=\"text-center\" style=\"color:#003844\">Blood Donors List</h1>\r\n    <hr />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5ff410cfd5073c346cc5f96df4ae79fcb7ca7244383", async() => {
                WriteLiteral(@"
        <div class=""container"">
            <div class=""row mb-3"">
                <div class=""col form-floating"">
                    <input type=""text"" class=""form-control"" name=""State"" placeholder=""State"">
                    <label for=""floatingInput"">State</label>
                </div>
                <div class=""col form-floating"">
                    <input type=""text"" class=""form-control"" name=""District"" placeholder=""District"">
                    <label for=""floatingPassword"">District</label>
                </div>
            </div>
            <div class=""ms-auto me-auto text-center"">
                <button class=""btn"" type=""submit"">Search</button>
            </div>
            
        </div>
        
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <table class=\"table table-borderless table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 34 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 37 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 40 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.District));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 43 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 46 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
               Write(Html.Encode("Phone Number"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 49 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
               Write(Html.Encode("Other Number"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 55 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 59 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 62 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 65 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.District));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 68 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <a class=\"blood-donation__phone\"");
            BeginWriteAttribute("href", " href=\"", 2517, "\"", 2570, 2);
            WriteAttributeValue("", 2524, "tel:", 2524, 4, true);
#nullable restore
#line 71 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
WriteAttributeValue("", 2528, Html.DisplayFor(modelItem => item.Phone1), 2528, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 71 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
                                                                                                          Write(Html.DisplayFor(modelItem => item.Phone1));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                    <td>\r\n                        <a class=\"blood-donation__phone\"");
            BeginWriteAttribute("href", " href=\"", 2729, "\"", 2782, 2);
            WriteAttributeValue("", 2736, "tel:", 2736, 4, true);
#nullable restore
#line 74 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
WriteAttributeValue("", 2740, Html.DisplayFor(modelItem => item.Phone2), 2740, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 74 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
                                                                                                          Write(Html.DisplayFor(modelItem => item.Phone2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 77 "C:\Users\navaneeth\source\repos\KalamYouthForumWebApp\Views\BloodDonation\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KalamYouthForumWebApp.Models.DonorDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591