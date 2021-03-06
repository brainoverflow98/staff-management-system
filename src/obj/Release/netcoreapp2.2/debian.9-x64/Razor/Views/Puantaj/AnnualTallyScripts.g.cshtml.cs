#pragma checksum "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7e1bdd1d999ca7431e8d934a91525e076933d2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Puantaj_AnnualTallyScripts), @"mvc.1.0.view", @"/Views/Puantaj/AnnualTallyScripts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Puantaj/AnnualTallyScripts.cshtml", typeof(AspNetCore.Views_Puantaj_AnnualTallyScripts))]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using PersonelTakip;

#line default
#line hidden
#line 3 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using PersonelTakip.Core.Models;

#line default
#line hidden
#line 4 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using PersonelTakip.Models;

#line default
#line hidden
#line 5 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using PersonelTakip.Models.AccountViewModels;

#line default
#line hidden
#line 6 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using PersonelTakip.Models.ManageViewModels;

#line default
#line hidden
#line 7 "D:\C# Projects\PuantajYeni\Views\_ViewImports.cshtml"
using PersonelTakip.Controllers.Resources;

#line default
#line hidden
#line 1 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
using PersonelTakip.Extensions;

#line default
#line hidden
#line 2 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
using System;

#line default
#line hidden
#line 3 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
using System.Text.RegularExpressions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7e1bdd1d999ca7431e8d934a91525e076933d2b", @"/Views/Puantaj/AnnualTallyScripts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e794effe67c9ef1f16842075f7d6edf48dd9fb9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Puantaj_AnnualTallyScripts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
  
    List<Unvan> Unvanlar = ViewBag.Unvanlar;
    List<Hesaplama> Hesaplamalar = ViewBag.Hesaplamalar;
    List<SecenekListesi> Secenekler = ViewBag.Secenekler;

#line default
#line hidden
            BeginContext(259, 42, true);
            WriteLiteral("<script>\r\n\r\n    var AnnualTallyTableNo = \"");
            EndContext();
            BeginContext(303, 44, false);
#line 11 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                          Write(TableConstants.AnnualTallyTableNo.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(348, 15, true);
            WriteLiteral("\";   \r\n    \r\n\r\n");
            EndContext();
#line 14 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
     foreach (var hesaplama in Hesaplamalar)
    {
        var variableName = Regex.Replace(hesaplama.Baslik, @"\s+", "").ToEnglishChars();


#line default
#line hidden
            BeginContext(508, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(518, 21, true);
            WriteLiteral(" var AnnualTallyTable");
            EndContext();
            BeginContext(541, 12, false);
#line 18 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                           Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(554, 14, true);
            WriteLiteral("Col;        \r\n");
            EndContext();
#line 19 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
    }

#line default
#line hidden
            BeginContext(575, 96, true);
            WriteLiteral("\r\n\r\n    function updateConstants() {\r\n\r\n        var table_no = AnnualTallyTableNo;          \r\n\r\n");
            EndContext();
#line 26 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
         foreach (var hesaplama in Hesaplamalar)
        {
            var variableName = Regex.Replace(hesaplama.Baslik, @"\s+", "").ToEnglishChars();
            var cellId = hesaplama.Id;

#line default
#line hidden
            BeginContext(866, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(880, 16, true);
            WriteLiteral("AnnualTallyTable");
            EndContext();
            BeginContext(898, 12, false);
#line 30 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                          Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(911, 26, true);
            WriteLiteral("Col = getColNo(table_no, \"");
            EndContext();
            BeginContext(939, 6, false);
#line 30 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                                                                   Write(cellId);

#line default
#line hidden
            EndContext();
            BeginContext(946, 17, true);
            WriteLiteral("\");            \r\n");
            EndContext();
#line 31 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
        }

#line default
#line hidden
            BeginContext(974, 949, true);
            WriteLiteral(@"        
    }
    


    function analyseChange(cell, value) {
        var select = cell.children[0];
        var prev_value = parseInt($(select).val());

        if (value == prev_value)
            return;

        var row_no = cell.id.split(""-"")[3];
        var col_no = cell.id.split(""-"")[5];

        $(select).val(value);
        var table_no = AnnualTallyTableNo;
        var dutyId = document.getElementById(""GorevId"").value;        
        var pv = prev_value;
        var v = value;


        var RowObj = TABLES[table_no].rows[row_no];
        var ColObj = RowObj.columns[col_no];
        ColObj.value = value;
        ColObj.changed = true;
        RowObj.changed = true;

        var optionGroup = ColObj.optionGroup;
        var option = TABLES[table_no].optionGroups[0][value];
        var color = option.color;
        cell.style.backgroundColor = color;
        cell.classList.add(""changed"");


");
            EndContext();
#line 67 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
         foreach (var secenek in Secenekler)
        {
            var formuller = Hesaplamalar.Where(h => h.HesaplamaSecenekleri.Select(hs => hs.SecenekId).Contains(secenek.Id)).ToList();
            

#line default
#line hidden
            BeginContext(2133, 23, true);
            WriteLiteral("\r\n            if (v == ");
            EndContext();
            BeginContext(2158, 21, false);
#line 71 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                 Write(secenek.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2180, 31, true);
            WriteLiteral(") {\r\n                if (pv != ");
            EndContext();
            BeginContext(2213, 21, false);
#line 72 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                      Write(secenek.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2235, 5, true);
            WriteLiteral(") {\r\n");
            EndContext();
#line 73 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                     foreach (var formul in formuller)
                    {
                        var ifStatement = "";
                        bool first = true;
                        foreach (var unvan in formul.HesaplamaUnvanlari)
                        {
                            if (!first) { ifStatement += " || dutyId==" + unvan.UnvanId.ToString(); } else { ifStatement += "dutyId==" + unvan.UnvanId.ToString(); first = false; }
                        }
                        if (ifStatement == "") { ifStatement = "true";}

#line default
#line hidden
            BeginContext(2792, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2818, 5, true);
            WriteLiteral("if ( ");
            EndContext();
            BeginContext(2825, 11, false);
#line 82 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                           Write(ifStatement);

#line default
#line hidden
            EndContext();
            BeginContext(2837, 6, true);
            WriteLiteral(" ) {\r\n");
            EndContext();
#line 83 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                        var variableName = Regex.Replace(formul.Baslik, @"\s+", "").ToEnglishChars();
                        var count = formul.HesaplamaSecenekleri.Where(hs => hs.SecenekId == secenek.Id).Select(hs=>hs.Katsayi).FirstOrDefault();

#line default
#line hidden
            BeginContext(3092, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(3118, 47, true);
            WriteLiteral("cellAddValue(table_no, row_no, AnnualTallyTable");
            EndContext();
            BeginContext(3167, 12, false);
#line 85 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                                                                     Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(3180, 5, true);
            WriteLiteral("Col, ");
            EndContext();
            BeginContext(3187, 5, false);
#line 85 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                                                                                         Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(3193, 52, true);
            WriteLiteral(");                        \r\n                        ");
            EndContext();
            BeginContext(3247, 3, true);
            WriteLiteral("}\r\n");
            EndContext();
#line 87 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                    }

#line default
#line hidden
            BeginContext(3273, 69, true);
            WriteLiteral("                }\r\n\r\n            } else {\r\n                if (pv == ");
            EndContext();
            BeginContext(3344, 21, false);
#line 91 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                      Write(secenek.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(3366, 5, true);
            WriteLiteral(") {\r\n");
            EndContext();
#line 92 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                     foreach (var formul in formuller)
                    {
                        var ifStatement = "";
                        bool first = true;
                        foreach (var unvan in formul.HesaplamaUnvanlari)
                        {
                            if (!first) { ifStatement += " || dutyId==" + unvan.UnvanId.ToString(); } else { ifStatement += "dutyId==" + unvan.UnvanId.ToString(); first = false; }
                        }
                        if (ifStatement == "") { ifStatement = "true";}

#line default
#line hidden
            BeginContext(3923, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(3949, 5, true);
            WriteLiteral("if ( ");
            EndContext();
            BeginContext(3956, 11, false);
#line 101 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                           Write(ifStatement);

#line default
#line hidden
            EndContext();
            BeginContext(3968, 6, true);
            WriteLiteral(" ) {\r\n");
            EndContext();
#line 102 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                        var variableName = Regex.Replace(formul.Baslik, @"\s+", "").ToEnglishChars();
                        var count = formul.HesaplamaSecenekleri.Where(hs => hs.SecenekId == secenek.Id).Select(hs=>hs.Katsayi).FirstOrDefault();

#line default
#line hidden
            BeginContext(4223, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(4249, 47, true);
            WriteLiteral("cellAddValue(table_no, row_no, AnnualTallyTable");
            EndContext();
            BeginContext(4298, 12, false);
#line 104 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                                                                     Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(4311, 6, true);
            WriteLiteral("Col, -");
            EndContext();
            BeginContext(4319, 5, false);
#line 104 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                                                                                          Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(4325, 52, true);
            WriteLiteral(");                        \r\n                        ");
            EndContext();
            BeginContext(4379, 3, true);
            WriteLiteral("}\r\n");
            EndContext();
#line 106 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                    }

#line default
#line hidden
            BeginContext(4405, 46, true);
            WriteLiteral("                }\r\n            }\r\n            ");
            EndContext();
#line 109 "D:\C# Projects\PuantajYeni\Views\Puantaj\AnnualTallyScripts.cshtml"
                   
        }

#line default
#line hidden
            BeginContext(4471, 22, true);
            WriteLiteral("    }\r\n\r\n\r\n</script>\r\n");
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
