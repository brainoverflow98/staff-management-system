#pragma checksum "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6ad649c953eb3c51838ebda307f3dd0c9595c098"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Yetkilendirme_Index), @"mvc.1.0.view", @"/Views/Yetkilendirme/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Yetkilendirme/Index.cshtml", typeof(AspNetCore.Views_Yetkilendirme_Index))]
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
#line 1 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using PersonelTakip;

#line default
#line hidden
#line 3 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using PersonelTakip.Core.Models;

#line default
#line hidden
#line 4 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using PersonelTakip.Models;

#line default
#line hidden
#line 5 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using PersonelTakip.Models.AccountViewModels;

#line default
#line hidden
#line 6 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using PersonelTakip.Models.ManageViewModels;

#line default
#line hidden
#line 7 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/_ViewImports.cshtml"
using PersonelTakip.Controllers.Resources;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ad649c953eb3c51838ebda307f3dd0c9595c098", @"/Views/Yetkilendirme/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e794effe67c9ef1f16842075f7d6edf48dd9fb9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Yetkilendirme_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PersonelTakip.Controllers.Resources.YetkilendirmeListResource>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("delete-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Account/Delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(83, 246, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n<table class=\"table table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th scope=\"col\">Kullanıcı Adı</th>\r\n            <th scope=\"col\">Rolü</th>\r\n            <th scope=\"col\">İşlemler</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 16 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(378, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(417, 13, false);
#line 19 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
               Write(item.username);

#line default
#line hidden
            EndContext();
            BeginContext(430, 116, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <select class=\"dropboxRole form-control\">\r\n                        ");
            EndContext();
            BeginContext(546, 26, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ad649c953eb3c51838ebda307f3dd0c9595c0986905", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(572, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 23 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                         foreach (var rol in (List<ApplicationRole>)ViewBag.roles)
                        {
                            if (rol.Name == item.role)
                            {

#line default
#line hidden
            BeginContext(772, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(804, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ad649c953eb3c51838ebda307f3dd0c9595c0988584", async() => {
                BeginContext(843, 8, false);
#line 27 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                                                                 Write(rol.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 27 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                                  WriteLiteral(item.username);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
#line 27 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                                                                                        }
                            else
                            {

#line default
#line hidden
            BeginContext(928, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(960, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ad649c953eb3c51838ebda307f3dd0c9595c09811118", async() => {
                BeginContext(990, 8, false);
#line 30 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                                                        Write(rol.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 30 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                                  WriteLiteral(item.username);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
#line 30 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
                                                                               }
                        }

#line default
#line hidden
            BeginContext(1037, 146, true);
            WriteLiteral("                    </select>\r\n\r\n                </td>\r\n                <td>\r\n                    <button class=\"btn btn-success btnSifreDegistir\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 1183, "", 1204, 1);
#line 36 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
WriteAttributeValue("", 1190, item.username, 1190, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1204, 53, true);
            WriteLiteral(">Şifre Değiştir</button>\r\n                    <button");
            EndContext();
            BeginWriteAttribute("user", " user=\"", 1257, "\"", 1278, 1);
#line 37 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
WriteAttributeValue("", 1264, item.username, 1264, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1279, 72, true);
            WriteLiteral(" class=\"btn btn-danger delete-button\">Sil</button>\r\n                    ");
            EndContext();
            BeginContext(1351, 178, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ad649c953eb3c51838ebda307f3dd0c9595c09814312", async() => {
                BeginContext(1468, 22, true);
                WriteLiteral("<input name=\"username\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1490, "\"", 1512, 1);
#line 38 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
WriteAttributeValue("", 1498, item.username, 1498, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1513, 9, true);
                WriteLiteral(" hidden/>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "user", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 38 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
AddHtmlAttributeValue("", 1363, item.username, 1363, 14, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1529, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 41 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Yetkilendirme/Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1584, 34, true);
            WriteLiteral("\r\n\r\n\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1636, 1182, true);
                WriteLiteral(@"
<script>

    $( document ).ready(function() {

        $('.delete-button').on('click', function (e) {
            e.preventDefault();
            var message = ""Personel kalıcı olarak silinecek !"";
            if (confirm(message)) {
                var user = $(this).attr(""user"");
                $("".delete-form[user='""+user+""'"").submit();
            }
        });

        $("".btnSifreDegistir"").click(function(){
            window.location.href = ""../account/resetpassword/""+this.value;
        })




        $("".dropboxRole"").on(""change"",function(e){
        var role = $(this).find('option:selected').text();
        var username = this.value;
        $.ajax({
        type:""POST"",
        url:""Yetkilendirme"",
        beforeSend:function(xhr){
        xhr.setRequestHeader(""XSRF-TOKEN"",
        $('input:hidden[name=""__RequestVerificationToken""]').val())
        },
        contentType:""application/json;charset=utf-8"",
        dataType:""json"",
        success:function(response");
                WriteLiteral("){\r\n            alert(response.value)\r\n        },\r\n        data:JSON.stringify({username:username,role:role})\r\n        });\r\n\r\n        })\r\n});\r\n\r\n\r\n</script>\r\n");
                EndContext();
            }
            );
            BeginContext(2821, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PersonelTakip.Controllers.Resources.YetkilendirmeListResource>> Html { get; private set; }
    }
}
#pragma warning restore 1591