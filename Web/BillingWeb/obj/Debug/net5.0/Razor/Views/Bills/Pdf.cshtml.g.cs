#pragma checksum "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd342d326c26223bbdeed374dc4996c8af12f2aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bills_Pdf), @"mvc.1.0.view", @"/Views/Bills/Pdf.cshtml")]
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
#line 1 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\_ViewImports.cshtml"
using Web.BillingWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\_ViewImports.cshtml"
using Web.BillingWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd342d326c26223bbdeed374dc4996c8af12f2aa", @"/Views/Bills/Pdf.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb5b1a53dfd769a414f009f57ea397b8b8da4d6f", @"/Views/_ViewImports.cshtml")]
    public class Views_Bills_Pdf : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BillDisplayViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/pdf.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd342d326c26223bbdeed374dc4996c8af12f2aa4436", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>PDF</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bd342d326c26223bbdeed374dc4996c8af12f2aa4789", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd342d326c26223bbdeed374dc4996c8af12f2aa6671", async() => {
                WriteLiteral(@"
    <div id=""profilCadre"">
        <p>NOUVELLE LUNE <br/>
        Les grandes terres <br />
        Vertbois <br />
        71340 St Bonnet de Cray</p>
    </div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p class=""large""><strong>FACTURE N&deg; ");
#nullable restore
#line 25 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                       Write(Model.bill.Num);

#line default
#line hidden
#nullable disable
                WriteLiteral("-");
#nullable restore
#line 25 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                                       Write(Model.bill.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong></p>\r\n    <p>Date : ");
#nullable restore
#line 26 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
         Write(Model.bill.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n    <p class=\"text-right\">");
#nullable restore
#line 27 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                           if (Model.bill.Client.Civil != Common.EntityModels.Title.Société) {

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                                                                         Write(Model.bill.Client.Civil);

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                                                                                                      }

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 27 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                                                                                                   Write(Model.clientName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n    <p>&nbsp;</p>\r\n    <p class=\"large\">Objet : ");
#nullable restore
#line 29 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                        Write(Model.bill.Objet);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
    <table id=""wordingsTable"">
        <tbody>
            <tr class=""headerLine"">
                <th class=""headerCell"" id=""designationCell""><strong><span class="".text-white"">D&eacute;signation</span></strong></th>
                <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">P.U. HT</span></strong></th>
                <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">Quantit&eacute;</span></strong></th>
                <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">Total HT</span></strong></th>
            </tr>
");
#nullable restore
#line 38 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
             for (int i = 0; i < Model.bill.LibelleList.Count; i++)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td class=\"line\">");
#nullable restore
#line 41 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                Write(Model.bill.LibelleList.ElementAt(i).Content);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td class=\"line text-right\">");
#nullable restore
#line 42 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                           Write(Model.bill.LibelleList.ElementAt(i).PrixU);

#line default
#line hidden
#nullable disable
                WriteLiteral(" &euro;</td>\r\n                    <td class=\"line text-right\">");
#nullable restore
#line 43 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                           Write(Model.bill.LibelleList.ElementAt(i).Quantite);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
#nullable restore
#line 44 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                       
                        float total = Model.bill.LibelleList.ElementAt(i).PrixU * Model.bill.LibelleList.ElementAt(i).Quantite;
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td class=\"line text-right\">");
#nullable restore
#line 47 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                           Write(total);

#line default
#line hidden
#nullable disable
                WriteLiteral(" &euro;</td>\r\n                </tr>\r\n");
#nullable restore
#line 49 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n    <table id=\"TotalTable\">\r\n        <tbody>\r\n            <tr>\r\n                <td class=\"headerCell headerLine\"><strong>Total HT</strong></td>\r\n                <td class=\"line text-right\">");
#nullable restore
#line 56 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                       Write(Model.bill.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" &euro;</td>
            </tr>
        </tbody>
    </table>
    <br/>
    <br/>
    <br/>
    <p class=""text-right"">TVA non applicable, art. 293B du CGI</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p class=""spaced"">
        Date limite de r&egrave;glement : ");
#nullable restore
#line 67 "D:\Documents\Programmation\_Visual Studio\BillingManager - Copie\Web\BillingWeb\Views\Bills\Pdf.cshtml"
                                     Write(Model.bill.Date.AddDays(7).ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral(@" (&agrave; reception de la facture) <br />
        Taux des p&eacute;nalit&eacute;s en cas de retard de paiement : taux directeur de refinancement de la BCE, major&eacute; de 10 points <br />
        En cas de retard de paiement, indemnit&eacute; forfaitaire l&eacute;gale pour frais de recouvrement : 40,00&euro; <br />
        Escompte en cas de paiement anticip&eacute; : aucun
    </p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p id=""Credit"" class=""spaced large"">Nouvelle Lune - RNA : W713004346 <br/>
    Email : <a href=""mailto:isgarrigues@free.fr"">isgarrigues@free.fr</a>&nbsp;- T&eacute;l : 07 82 19 88 55</p>
");
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BillDisplayViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
