#pragma checksum "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fca2feebfd081952071fec902ef4be848e0ed2e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyApp.Namespace.Home.Views_Home_index), @"mvc.1.0.view", @"/Views/Home/index.cshtml")]
namespace MyApp.Namespace.Home
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
#line 1 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
using Chefs_n_dishes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fca2feebfd081952071fec902ef4be848e0ed2e", @"/Views/Home/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc1d1eb37dc6f0d82250bf784d7ea6a0b75ca51c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wrapper>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fca2feebfd081952071fec902ef4be848e0ed2e3050", async() => {
                WriteLiteral("\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>Chefs and Dishes - Chefs</title>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fca2feebfd081952071fec902ef4be848e0ed2e4153", async() => {
                WriteLiteral(@"
    <div>
        <div>
            <h1><a href=""/"">Chefs</a>|<a href=""/dishes"">Dishes</a></h1>
        </div>
        <div>
            <h3>
                <a href=""/new"">Add a Chef</a>
            </h3>
        </div>
    </div>
    <div>
        <div>
            <h2>Check out our roster of Chefs!</h2>
        </div>
        <div>
            <hr>
        </div>
        <div>
            <table>
                <tr>
                    <th>Name</th>
                    <th>Age</th>
                    <th># of Dishes</th>
                </tr>
");
#nullable restore
#line 35 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
                 foreach (var chef in Model.ChefTableModel)
                {
                    var today = DateTime.Today;
                    var age = today.Year - chef.Birthday.Year;

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 40 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
                   Write(chef.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 40 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
                                   Write(chef.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 41 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
                   Write(age);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 42 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
                   Write(chef.CreatedDish.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 44 "/Users/beverly/Desktop/csharp/fundamental/ORMs/Chefs_n_dishes/Views/Home/index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </table>\n        </div>\n    </div>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
