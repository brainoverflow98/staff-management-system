#pragma checksum "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1121fb76c3e26009225a6f293c459102bca5325d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Puantaj_MonthlyTallyScripts), @"mvc.1.0.view", @"/Views/Puantaj/MonthlyTallyScripts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Puantaj/MonthlyTallyScripts.cshtml", typeof(AspNetCore.Views_Puantaj_MonthlyTallyScripts))]
namespace AspNetCore
{
    #line hidden
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
#line 1 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
using PersonelTakip.Extensions;

#line default
#line hidden
#line 2 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
using System;

#line default
#line hidden
#line 3 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
using System.Text.RegularExpressions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1121fb76c3e26009225a6f293c459102bca5325d", @"/Views/Puantaj/MonthlyTallyScripts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e794effe67c9ef1f16842075f7d6edf48dd9fb9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Puantaj_MonthlyTallyScripts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
  
    List<Unvan> Unvanlar = ViewBag.Unvanlar;
    List<Hesaplama> Hesaplamalar = ViewBag.Hesaplamalar;
    List<SecenekListesi> Secenekler = ViewBag.Secenekler;

#line default
#line hidden
            BeginContext(259, 43, true);
            WriteLiteral("<script>\r\n\r\n    var MonthlyTallyTableNo = \"");
            EndContext();
            BeginContext(304, 45, false);
#line 11 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                           Write(TableConstants.MonthlyTallyTableNo.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(350, 35, true);
            WriteLiteral("\";\r\n    var MonthSummaryTableNo = \"");
            EndContext();
            BeginContext(387, 45, false);
#line 12 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                           Write(TableConstants.MonthSummaryTableNo.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(433, 44, true);
            WriteLiteral("\";\r\n\r\n    var MonthlyTallyTableGorevCol;\r\n\r\n");
            EndContext();
#line 16 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
     foreach (var hesaplama in Hesaplamalar)
    {
        var variableName = Regex.Replace(hesaplama.Baslik, @"\s+", "").ToEnglishChars();


#line default
#line hidden
            BeginContext(622, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(632, 22, true);
            WriteLiteral(" var MonthlyTallyTable");
            EndContext();
            BeginContext(656, 12, false);
#line 20 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                            Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(669, 6, true);
            WriteLiteral("Col;\r\n");
            EndContext();
#line 21 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
        if (hesaplama.OzetGoster)
        {

#line default
#line hidden
            BeginContext(721, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(735, 22, true);
            WriteLiteral(" var MonthSummaryTable");
            EndContext();
            BeginContext(759, 12, false);
#line 23 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(772, 6, true);
            WriteLiteral("Col;\r\n");
            EndContext();
#line 24 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
        }
    }

#line default
#line hidden
            BeginContext(796, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 28 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
     foreach (var unvan in Unvanlar)
    {
        var variableName = Regex.Replace(unvan.UnvanAdi, @"\s+", "").ToEnglishChars();

#line default
#line hidden
            BeginContext(933, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(943, 22, true);
            WriteLiteral(" var MonthSummaryTable");
            EndContext();
            BeginContext(967, 12, false);
#line 31 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                            Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(980, 6, true);
            WriteLiteral("Row;\r\n");
            EndContext();
#line 32 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
    }

#line default
#line hidden
            BeginContext(993, 200, true);
            WriteLiteral("\r\n\r\n\r\n    function updateConstants() {\r\n        \r\n        var table_no = MonthlyTallyTableNo;\r\n        var sum_table_no = MonthSummaryTableNo;\r\n        MonthlyTallyTableGorevCol = getColNo(table_no, \"");
            EndContext();
            BeginContext(1195, 24, false);
#line 40 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                    Write(TableConstants.Gorev.Uid);

#line default
#line hidden
            EndContext();
            BeginContext(1220, 7, true);
            WriteLiteral("\");\r\n\r\n");
            EndContext();
#line 42 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
         foreach (var hesaplama in Hesaplamalar)
        {
            var variableName = Regex.Replace(hesaplama.Baslik, @"\s+", "").ToEnglishChars();
            var cellId = hesaplama.Id;

#line default
#line hidden
            BeginContext(1422, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1436, 17, true);
            WriteLiteral("MonthlyTallyTable");
            EndContext();
            BeginContext(1455, 12, false);
#line 46 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                           Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(1468, 26, true);
            WriteLiteral("Col = getColNo(table_no, \"");
            EndContext();
            BeginContext(1496, 6, false);
#line 46 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                    Write(cellId);

#line default
#line hidden
            EndContext();
            BeginContext(1503, 5, true);
            WriteLiteral("\");\r\n");
            EndContext();
#line 47 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
            if (hesaplama.OzetGoster)
            {

#line default
#line hidden
            BeginContext(1562, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1580, 17, true);
            WriteLiteral("MonthSummaryTable");
            EndContext();
            BeginContext(1599, 12, false);
#line 49 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                               Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(1612, 30, true);
            WriteLiteral("Col = getColNo(sum_table_no, \"");
            EndContext();
            BeginContext(1644, 6, false);
#line 49 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                            Write(cellId);

#line default
#line hidden
            EndContext();
            BeginContext(1651, 5, true);
            WriteLiteral("\");\r\n");
            EndContext();
#line 50 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(1682, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 53 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
         foreach (var unvan in Unvanlar)
        {
            var variableName = Regex.Replace(unvan.UnvanAdi, @"\s+", "").ToEnglishChars();
            var cellId = unvan.Id;

#line default
#line hidden
            BeginContext(1865, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1879, 17, true);
            WriteLiteral("MonthSummaryTable");
            EndContext();
            BeginContext(1898, 12, false);
#line 57 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                           Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(1911, 30, true);
            WriteLiteral("Row = getRowNo(sum_table_no, \"");
            EndContext();
            BeginContext(1943, 6, false);
#line 57 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                        Write(cellId);

#line default
#line hidden
            EndContext();
            BeginContext(1950, 5, true);
            WriteLiteral("\");\r\n");
            EndContext();
#line 58 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
        }

#line default
#line hidden
            BeginContext(1966, 63, true);
            WriteLiteral("\r\n        MonthSummaryTableToplamRow = getRowNo(sum_table_no, \"");
            EndContext();
            BeginContext(2031, 25, false);
#line 60 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                         Write(TableConstants.Toplam.Uid);

#line default
#line hidden
            EndContext();
            BeginContext(2057, 75, true);
            WriteLiteral("\");\r\n    }\r\n\r\n\r\n    function getDutyId(duty) {\r\n        switch (duty) {\r\n\r\n");
            EndContext();
#line 67 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
         foreach (var unvan in Unvanlar)
        {
            var variableName = Regex.Replace(unvan.UnvanAdi, @"\s+", "").ToEnglishChars();


#line default
#line hidden
            BeginContext(2279, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2293, 7, true);
            WriteLiteral(" case \"");
            EndContext();
            BeginContext(2301, 24, false);
#line 71 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                Write(Html.Raw(unvan.UnvanAdi));

#line default
#line hidden
            EndContext();
            BeginContext(2325, 16, true);
            WriteLiteral("\":\r\n            ");
            EndContext();
            BeginContext(2343, 8, true);
            WriteLiteral(" return ");
            EndContext();
            BeginContext(2352, 8, false);
#line 72 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                 Write(unvan.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2360, 10, true);
            WriteLiteral("; break;\r\n");
            EndContext();
#line 73 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
        }

#line default
#line hidden
            BeginContext(2381, 103, true);
            WriteLiteral("\r\n        }\r\n    }\r\n\r\n    function getMonthSummaryTableDutyRow(dutyId) {\r\n        switch (dutyId) {\r\n\r\n");
            EndContext();
#line 81 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
         foreach (var unvan in Unvanlar)
        {
            var variableName = Regex.Replace(unvan.UnvanAdi, @"\s+", "").ToEnglishChars();


#line default
#line hidden
            BeginContext(2631, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(2645, 6, true);
            WriteLiteral(" case ");
            EndContext();
            BeginContext(2652, 8, false);
#line 85 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
               Write(unvan.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2660, 15, true);
            WriteLiteral(":\r\n            ");
            EndContext();
            BeginContext(2677, 25, true);
            WriteLiteral(" return MonthSummaryTable");
            EndContext();
            BeginContext(2704, 12, false);
#line 86 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                   Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(2717, 13, true);
            WriteLiteral("Row; break;\r\n");
            EndContext();
#line 87 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
        }

#line default
#line hidden
            BeginContext(2741, 1095, true);
            WriteLiteral(@"
        }
    }


    function analyseChange(cell, value) {
        var select = cell.children[0];
        var prev_value = parseInt($(select).val());

        if (value == prev_value)
            return;

        var row_no = cell.id.split(""-"")[3];
        var col_no = cell.id.split(""-"")[5];
        var dutyStr = cellGetValue(MonthlyTallyTableNo, row_no, MonthlyTallyTableGorevCol);
        var dutyId = getDutyId(dutyStr);

        var table_no = MonthlyTallyTableNo;
        var sum_table_no = MonthSummaryTableNo;
        var duty_row = getMonthSummaryTableDutyRow(dutyId);
        var pv = prev_value;
        var v = value;

        $(select).val(value);
        var RowObj = TABLES[table_no].rows[row_no];
        var ColObj = RowObj.columns[col_no];
        ColObj.value = value;
        ColObj.changed = true;
        RowObj.changed = true;
        
        var option = TABLES[table_no].optionGroups[0][value];
        var color = option.color;
        cell.style.backgroundColor");
            WriteLiteral(" = color;\r\n        cell.classList.add(\"changed\");        \r\n        \r\n\r\n");
            EndContext();
#line 124 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
         foreach (var secenek in Secenekler)
        {
            var formuller = Hesaplamalar.Where(h => h.HesaplamaSecenekleri.Select(hs => hs.SecenekId).Contains(secenek.Id)).ToList();
            

#line default
#line hidden
            BeginContext(4046, 23, true);
            WriteLiteral("\r\n            if (v == ");
            EndContext();
            BeginContext(4071, 21, false);
#line 128 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                 Write(secenek.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(4093, 31, true);
            WriteLiteral(") {\r\n                if (pv != ");
            EndContext();
            BeginContext(4126, 21, false);
#line 129 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                      Write(secenek.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(4148, 5, true);
            WriteLiteral(") {\r\n");
            EndContext();
#line 130 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
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
            BeginContext(4705, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(4731, 5, true);
            WriteLiteral("if ( ");
            EndContext();
            BeginContext(4738, 11, false);
#line 139 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                           Write(ifStatement);

#line default
#line hidden
            EndContext();
            BeginContext(4750, 6, true);
            WriteLiteral(" ) {\r\n");
            EndContext();
#line 140 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                        var variableName = Regex.Replace(formul.Baslik, @"\s+", "").ToEnglishChars();
                        var count = formul.HesaplamaSecenekleri.Where(hs => hs.SecenekId == secenek.Id).Select(hs=>hs.Katsayi).FirstOrDefault();

#line default
#line hidden
            BeginContext(5005, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(5031, 67, true);
            WriteLiteral("var added_amount = cellAddValue(table_no, row_no, MonthlyTallyTable");
            EndContext();
            BeginContext(5100, 12, false);
#line 142 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                         Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(5113, 5, true);
            WriteLiteral("Col, ");
            EndContext();
            BeginContext(5120, 5, false);
#line 142 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                                             Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(5126, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(5130, 18, false);
#line 142 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                                                       Write(formul.SaymaLimiti);

#line default
#line hidden
            EndContext();
            BeginContext(5149, 4, true);
            WriteLiteral(");\r\n");
            EndContext();
#line 144 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                         if(formul.OzetGoster) { 
                            

#line default
#line hidden
            BeginContext(5240, 104, true);
            WriteLiteral("                        \r\n                        cellAddValue(sum_table_no, duty_row, MonthSummaryTable");
            EndContext();
            BeginContext(5346, 12, false);
#line 146 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                          Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(5359, 5, true);
            WriteLiteral("Col, ");
            EndContext();
            BeginContext(5366, 5, false);
#line 146 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                              Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(5372, 117, true);
            WriteLiteral(", 0, added_amount);\r\n                        cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTable");
            EndContext();
            BeginContext(5491, 12, false);
#line 147 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                            Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(5504, 5, true);
            WriteLiteral("Col, ");
            EndContext();
            BeginContext(5511, 5, false);
#line 147 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                                                Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(5517, 69, true);
            WriteLiteral(", 0, added_amount);                    \r\n                            ");
            EndContext();
#line 148 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                   
                        }

#line default
#line hidden
            BeginContext(5622, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(5648, 3, true);
            WriteLiteral("}\r\n");
            EndContext();
#line 151 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                    }

#line default
#line hidden
            BeginContext(5674, 69, true);
            WriteLiteral("                }\r\n\r\n            } else {\r\n                if (pv == ");
            EndContext();
            BeginContext(5745, 21, false);
#line 155 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                      Write(secenek.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(5767, 5, true);
            WriteLiteral(") {\r\n");
            EndContext();
#line 156 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
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
            BeginContext(6324, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(6350, 5, true);
            WriteLiteral("if ( ");
            EndContext();
            BeginContext(6357, 11, false);
#line 165 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                           Write(ifStatement);

#line default
#line hidden
            EndContext();
            BeginContext(6369, 6, true);
            WriteLiteral(" ) {\r\n");
            EndContext();
#line 166 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                        var variableName = Regex.Replace(formul.Baslik, @"\s+", "").ToEnglishChars();
                        var count = formul.HesaplamaSecenekleri.Where(hs => hs.SecenekId == secenek.Id).Select(hs=>hs.Katsayi).FirstOrDefault();

#line default
#line hidden
            BeginContext(6624, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(6650, 67, true);
            WriteLiteral("var added_amount = cellAddValue(table_no, row_no, MonthlyTallyTable");
            EndContext();
            BeginContext(6719, 12, false);
#line 168 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                         Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(6732, 6, true);
            WriteLiteral("Col, -");
            EndContext();
            BeginContext(6740, 5, false);
#line 168 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                                              Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(6746, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(6750, 18, false);
#line 168 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                                                        Write(formul.SaymaLimiti);

#line default
#line hidden
            EndContext();
            BeginContext(6769, 4, true);
            WriteLiteral(");\r\n");
            EndContext();
#line 170 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                         if(formul.OzetGoster) { 
                            

#line default
#line hidden
            BeginContext(6860, 104, true);
            WriteLiteral("                        \r\n                        cellAddValue(sum_table_no, duty_row, MonthSummaryTable");
            EndContext();
            BeginContext(6966, 12, false);
#line 172 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                          Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(6979, 6, true);
            WriteLiteral("Col, -");
            EndContext();
            BeginContext(6987, 5, false);
#line 172 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                               Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(6993, 117, true);
            WriteLiteral(", 0, added_amount);\r\n                        cellAddValue(sum_table_no, MonthSummaryTableToplamRow, MonthSummaryTable");
            EndContext();
            BeginContext(7112, 12, false);
#line 173 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                            Write(variableName);

#line default
#line hidden
            EndContext();
            BeginContext(7125, 6, true);
            WriteLiteral("Col, -");
            EndContext();
            BeginContext(7133, 5, false);
#line 173 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                                                                                                 Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(7139, 67, true);
            WriteLiteral(", 0, added_amount);                  \r\n                            ");
            EndContext();
#line 174 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                                   
                        }

#line default
#line hidden
            BeginContext(7242, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(7268, 3, true);
            WriteLiteral("}\r\n");
            EndContext();
#line 177 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                    }

#line default
#line hidden
            BeginContext(7294, 46, true);
            WriteLiteral("                }\r\n            }\r\n            ");
            EndContext();
#line 180 "/Users/seyf/Documents/Projeler/Puantaj/sc2/Views/Puantaj/MonthlyTallyScripts.cshtml"
                   
        }

#line default
#line hidden
            BeginContext(7360, 22, true);
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
