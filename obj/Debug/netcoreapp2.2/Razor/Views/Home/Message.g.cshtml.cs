#pragma checksum "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0711395bca4586da466b1d28759f730a8f5e5dd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Message), @"mvc.1.0.view", @"/Views/Home/Message.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Message.cshtml", typeof(AspNetCore.Views_Home_Message))]
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
#line 1 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
using Messege.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
using Messege.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0711395bca4586da466b1d28759f730a8f5e5dd0", @"/Views/Home/Message.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c64ae2d1cd4f2d04742915b75c64e31bf59d044", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Message : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MessageView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Message", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/message.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(74, 169, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div  class=\"col-md-4\">\r\n        <div class=\"card h5\" style=\"background-color:rgb(219, 166, 242)\">Messages</div>\r\n    <div id=\"frnmsg_update\">\r\n");
            EndContext();
#line 11 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
    if (Model.FriendNMessage != null)
   {
         

#line default
#line hidden
#line 13 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
          foreach (var friend in Model.FriendNMessage)
   {
             

#line default
#line hidden
#line 15 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
              if (friend.Friend != null)
   {

#line default
#line hidden
            BeginContext(398, 25, true);
            WriteLiteral("        <div class=\"card\"");
            EndContext();
            BeginWriteAttribute("id", " id=", 423, "", 444, 1);
#line 17 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
WriteAttributeValue("", 427, friend.Friend.Id, 427, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(444, 15, true);
            WriteLiteral(">\r\n            ");
            EndContext();
            BeginContext(459, 451, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0711395bca4586da466b1d28759f730a8f5e5dd05888", async() => {
                BeginContext(538, 4, true);
                WriteLiteral("<img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 542, "\"", 579, 2);
                WriteAttributeValue("", 548, "/", 548, 1, true);
#line 18 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
WriteAttributeValue("", 549, friend.Friend.Profile_Picture, 549, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(580, 62, true);
                WriteLiteral("  height=\"30 \" width=\"30\" class=\"rounded-circle ml-1\" /><span>");
                EndContext();
                BeginContext(643, 24, false);
#line 18 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                                                                                                                                                              Write(friend.Friend.First_Name);

#line default
#line hidden
                EndContext();
                BeginContext(667, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(669, 23, false);
#line 18 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                                                                                                                                                                                        Write(friend.Friend.Last_Name);

#line default
#line hidden
                EndContext();
                BeginContext(692, 9, true);
                WriteLiteral("</span>\r\n");
                EndContext();
#line 19 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
             if (friend.Message != null)
   {

#line default
#line hidden
                BeginContext(749, 47, true);
                WriteLiteral("            <div cass=\"ml-3\"><div class=\"ml-4\">");
                EndContext();
                BeginContext(797, 13, false);
#line 21 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                          Write(friend.Sender);

#line default
#line hidden
                EndContext();
                BeginContext(810, 4, true);
                WriteLiteral("  : ");
                EndContext();
                BeginContext(815, 14, false);
#line 21 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                            Write(friend.Message);

#line default
#line hidden
                EndContext();
                BeginContext(829, 14, true);
                WriteLiteral("</div></div>\r\n");
                EndContext();
#line 22 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
   }
   else
   {

#line default
#line hidden
                BeginContext(864, 24, true);
                WriteLiteral("               <p></p>\r\n");
                EndContext();
#line 26 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
   }

#line default
#line hidden
                BeginContext(894, 12, true);
                WriteLiteral("            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 18 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                            WriteLiteral(friend.Friend.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(910, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 29 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
        
   }

#line default
#line hidden
#line 30 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
    
   }

#line default
#line hidden
#line 31 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
    
   }

#line default
#line hidden
            BeginContext(956, 84, true);
            WriteLiteral("        </div>\r\n        </div>\r\n            \r\n\r\n\r\n    \r\n    <div class=\"col-md-7\">\r\n");
            EndContext();
#line 40 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
        if (ViewBag.UserName != null)
       {

#line default
#line hidden
            BeginContext(1089, 85, true);
            WriteLiteral("        <div class=\"card h5 \" style=\"background-color:rgb(219, 166, 242);height:5vh\">");
            EndContext();
            BeginContext(1175, 16, false);
#line 42 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                                                Write(ViewBag.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1191, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
            BeginContext(1203, 144, true);
            WriteLiteral("        <div class=\'card message_update\' id=\"scrollanimate\" style=\'height:63vh;overflow-y:scroll;overflow-x:hidden\'>\r\n          \r\n            \r\n");
            EndContext();
#line 48 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                 foreach (var msg in Model.Conversation)
       {
                    

#line default
#line hidden
#line 50 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                     if (msg != null)
       {
                    

#line default
#line hidden
#line 52 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                     if (ViewBag.MyId == msg.Sender_Id)
       {


#line default
#line hidden
            BeginContext(1533, 86, true);
            WriteLiteral("                        <div class=\"ml-auto mt-1 \"><span class=\'alert alert-danger  \'>");
            EndContext();
            BeginContext(1620, 11, false);
#line 55 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                                                 Write(msg.Message);

#line default
#line hidden
            EndContext();
            BeginContext(1631, 75, true);
            WriteLiteral("</span> <img class=\'rounded-circle profile_picture_afno\' height=30 width=30");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1706, "\"", 1740, 2);
            WriteAttributeValue("", 1712, "/", 1712, 1, true);
#line 55 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
WriteAttributeValue("", 1713, msg.Sender_Profile_Picture, 1713, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1741, 9, true);
            WriteLiteral("></div>\r\n");
            EndContext();
#line 56 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"

       }
       else
       {

#line default
#line hidden
            BeginContext(1785, 119, true);
            WriteLiteral("                        <div class=\"mr-auto mt-1 \"> <img class=\'rounded-circle profile_picture_arko\' height=30 width=30");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1904, "\"", 1938, 2);
            WriteAttributeValue("", 1910, "/", 1910, 1, true);
#line 60 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
WriteAttributeValue("", 1911, msg.Sender_Profile_Picture, 1911, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1939, 63, true);
            WriteLiteral("><span class=\'alert alert-info  mr-1 mt-1\' style=\"height:auto\">");
            EndContext();
            BeginContext(2003, 11, false);
#line 60 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
                                                                                                                                                                                                                    Write(msg.Message);

#line default
#line hidden
            EndContext();
            BeginContext(2014, 15, true);
            WriteLiteral("</span></div>\r\n");
            EndContext();
#line 61 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"

       }

#line default
#line hidden
#line 62 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
        
       }

#line default
#line hidden
#line 63 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
        
       }

#line default
#line hidden
            BeginContext(2061, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
            BeginContext(2087, 29, true);
            WriteLiteral("            <div id=\"cuserid\"");
            EndContext();
            BeginWriteAttribute("value", "value=\"", 2116, "\"", 2136, 1);
#line 69 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
WriteAttributeValue("", 2123, ViewBag.MyId, 2123, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2137, 58, true);
            WriteLiteral(" hidden></div>\r\n            <div id=\"userid\" name=\"userid\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2195, "\"", 2218, 1);
#line 70 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"
WriteAttributeValue("", 2203, ViewBag.UserId, 2203, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2219, 240, true);
            WriteLiteral(" hidden></div>\r\n            <textarea id=\'message\' name=\'message\' class=\'mt-auto form-control\' cols=36 rows=1 style=\"border-radius:20px\"></textarea>\r\n            <button type=\'submit\' id=\"send\" class=\'btn btn-success btn-sm\'>Send</button>\r\n");
            EndContext();
#line 73 "C:\Users\dev\source\repos\Messege\Views\Home\Message.cshtml"

       }

#line default
#line hidden
            BeginContext(2471, 95, true);
            WriteLiteral("        </div>\r\n        \r\n         \r\n        <div class=\"col-md-1\"></div>\r\n    </div>\r\n\r\n    \r\n");
            EndContext();
            BeginContext(2566, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0711395bca4586da466b1d28759f730a8f5e5dd018240", async() => {
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
            BeginContext(2602, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2604, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0711395bca4586da466b1d28759f730a8f5e5dd019420", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MessageView> Html { get; private set; }
    }
}
#pragma warning restore 1591
