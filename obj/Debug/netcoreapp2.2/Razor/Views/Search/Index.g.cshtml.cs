#pragma checksum "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a83abf71e1b5d9cc88dd93cf2c1389a882209531"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.view", @"/Views/Search/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Search/Index.cshtml", typeof(AspNetCore.Views_Search_Index))]
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
#line 2 "C:\Users\dev\source\repos\Messege\Views\_ViewImports.cshtml"
using Messege.Models;

#line default
#line hidden
#line 1 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
using Messege.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a83abf71e1b5d9cc88dd93cf2c1389a882209531", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c64ae2d1cd4f2d04742915b75c64e31bf59d044", @"/Views/_ViewImports.cshtml")]
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SearchView>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/search.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 149, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-3\"></div>\r\n        <div class=\"col-md-6\">\r\n            <div class=\"card mb-1\">SearchResults</div>\r\n");
            EndContext();
#line 7 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
             foreach (var result in Model)
            {

#line default
#line hidden
            BeginContext(261, 66, true);
            WriteLiteral("        <div class=\"container text-center mb-2\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 327, "\"", 357, 2);
            WriteAttributeValue("", 333, "/", 333, 1, true);
#line 10 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
WriteAttributeValue("", 334, result.Profile_Picture, 334, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(358, 68, true);
            WriteLiteral(" height=\"55\" width=\"55\" class=\"rounded-circle\" />\r\n            <div>");
            EndContext();
            BeginContext(427, 17, false);
#line 11 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
            Write(result.First_Name);

#line default
#line hidden
            EndContext();
            BeginContext(444, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(446, 16, false);
#line 11 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
                               Write(result.Last_Name);

#line default
#line hidden
            EndContext();
            BeginContext(462, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 12 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
             if (result.Status == 1)
            {

#line default
#line hidden
            BeginContext(523, 70, true);
            WriteLiteral("                <button class=\"btn  btn-primary btn-sm button_request\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 593, "\"", 608, 1);
#line 14 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
WriteAttributeValue("", 598, result.Id, 598, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(609, 41, true);
            WriteLiteral(" value=\"disconnect\">Disconnect</button>\r\n");
            EndContext();
#line 15 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
            }
            else if (result.Status == 2)
            {

#line default
#line hidden
            BeginContext(722, 116, true);
            WriteLiteral("                <div class=\"form-group\">\r\n                    <button class=\"btn  btn-primary btn-sm button_request\"");
            EndContext();
            BeginWriteAttribute("id", " id=", 838, "", 852, 1);
#line 19 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
WriteAttributeValue("", 842, result.Id, 842, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(852, 107, true);
            WriteLiteral(" value=\"accept\">Accept</button>\r\n                    <button class=\"btn  btn-primary btn-sm button_request\"");
            EndContext();
            BeginWriteAttribute("id", " id=", 959, "", 973, 1);
#line 20 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
WriteAttributeValue("", 963, result.Id, 963, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(973, 61, true);
            WriteLiteral(" value=\"decline\">Decline</button>\r\n\r\n                </div>\r\n");
            EndContext();
#line 23 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"

            }
            else if (result.Status == 3)
            {

#line default
#line hidden
            BeginContext(1108, 116, true);
            WriteLiteral("                <div class=\"form-group\">\r\n                    <button class=\"btn  btn-primary btn-sm button_request\"");
            EndContext();
            BeginWriteAttribute("id", " id=", 1224, "", 1238, 1);
#line 28 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
WriteAttributeValue("", 1228, result.Id, 1228, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1238, 73, true);
            WriteLiteral(" value=\"cancel_request\">Cancel Request</button>\r\n                </div>\r\n");
            EndContext();
#line 30 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
            }
            else if (result.Status == 4)
            {

#line default
#line hidden
            BeginContext(1383, 22, true);
            WriteLiteral("        <div ></div>\r\n");
            EndContext();
#line 34 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
            }
            else if (result.Status == 5)
            {
                

#line default
#line hidden
            BeginContext(1495, 70, true);
            WriteLiteral("                <button class=\"btn  btn-primary btn-sm button_request\"");
            EndContext();
            BeginWriteAttribute("id", " id=", 1565, "", 1579, 1);
#line 38 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
WriteAttributeValue("", 1569, result.Id, 1569, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1579, 28, true);
            WriteLiteral(" value=\"connect\"></button>\r\n");
            EndContext();
#line 39 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1622, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 42 "C:\Users\dev\source\repos\Messege\Views\Search\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1655, 64, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-3\"></div>\r\n        ");
            EndContext();
            BeginContext(1719, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a83abf71e1b5d9cc88dd93cf2c1389a88220953110366", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1755, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1765, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a83abf71e1b5d9cc88dd93cf2c1389a88220953111555", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1800, 19, true);
            WriteLiteral("\r\n        \r\n       ");
            EndContext();
            BeginContext(1819, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a83abf71e1b5d9cc88dd93cf2c1389a88220953112755", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1870, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SearchView>> Html { get; private set; }
    }
}
#pragma warning restore 1591