using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BillingWeb.Models;

namespace Web.BillingWeb.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(BillDisplayViewModel model)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div id=""profilCadre"">
                                    <p>NOUVELLE LUNE <br />
                                    Les grandes terres <br />
                                    Vertbois <br />
                                    71340 St Bonnet de Cray</p>
                                </div>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
            ");
            sb.AppendFormat(@"
                                <p class=""large""><strong>FACTURE N&deg; {0}-{1}</strong></p>
                                <p>Date : {2}</p>
                                <p class=""text-right"">", model.bill.Num, model.bill.Year, model.bill.Date.ToShortDateString());
            if(model.bill.Client.Civil != Common.EntityModels.Title.Société) {
                sb.AppendFormat(@"{0}", model.bill.Client.Civil);
            }
            sb.AppendFormat(@" {0}</p>
                                <p>&nbsp;</p>
                                <p class=""large"">Objet : {1}</p>
                                <table id = ""wordingsTable"">
                                    <tbody>
                                        <tr class=""headerLine"">
                                            <th class=""headerCell"" id=""designationCell""><strong><span class="".text-white"">D&eacute;signation</span></strong></th>
                                            <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">P.U.HT</span></strong></th>
                                            <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">Quantit&eacute;</span></strong></th>
                                            <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">Total HT</span></strong></th>
                                        </tr>", model.clientName, model.bill.Objet);
            for (int i = 0; i <model.bill.LibelleList.Count; i++)
            {
                float total = model.bill.LibelleList.ElementAt(i).PrixU * model.bill.LibelleList.ElementAt(i).Quantite;
                sb.AppendFormat(@"      
                                        <tr>
                                            <td class=""line"">{0}</td>
                                            <td class=""line text-right"">{1} &euro;</td>
                                            <td class=""line text-right"">{2}</td>
                                            <td class=""line text-right"">{3} &euro;</td>
                                        </tr>", 
                                model.bill.LibelleList.ElementAt(i).Content,
                                model.bill.LibelleList.ElementAt(i).PrixU,
                                model.bill.LibelleList.ElementAt(i).Quantite,
                                total);
            }
            sb.AppendFormat(@"
                                    </tbody>
                                </table>
                                <table id = ""TotalTable"">
                                    <tbody>
                                        <tr>
                                            <td class=""headerCell headerLine""><strong>Total HT</strong></td>
                                            <td class=""line text-right"">{0} &euro;</td>
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
                                    Date limite de r&egrave;glement : {1} (&agrave; reception de la facture) <br />
                                    Taux des p&eacute;nalit&eacute;s en cas de retard de paiement : taux directeur de refinancement de la BCE, major&eacute; de 10 points<br />
                                    En cas de retard de paiement, indemnit&eacute; forfaitaire l&eacute;gale pour frais de recouvrement : 40,00&euro; <br />
                                    Escompte en cas de paiement anticip&eacute; : aucun
                                </p>
            ", model.bill.Total, model.bill.Date.AddDays(7).ToShortDateString());
            sb.Append(@"
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <p id = ""Credit"" class=""spaced large"">Nouvelle Lune - RNA : W713004346<br/>
                                  Email : <a href = ""mailto:isgarrigues@free.fr""> isgarrigues@free.fr</a>&nbsp;- T&eacute;l : 07 82 19 88 55
                                </p>
                            </body>
                        </html>");

            return sb.ToString();
        }

        public static string GetHTMLString(EstimateDisplayViewModel model)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div id=""profilCadre"">
                                    <p>NOUVELLE LUNE <br />
                                    Les grandes terres <br />
                                    Vertbois <br />
                                    71340 St Bonnet de Cray</p>
                                </div>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
            ");
            sb.AppendFormat(@"
                                <p class=""large""><strong>DEVIS N&deg; {0}-{1}</strong></p>
                                <p>Date : {2}</p>
                                <p class=""text-right"">", model.estimate.Num, model.estimate.Year, model.estimate.Date.ToShortDateString());
            if (model.estimate.Client.Civil != Common.EntityModels.Title.Société)
            {
                sb.AppendFormat(@"{0}", model.estimate.Client.Civil);
            }
            sb.AppendFormat(@" {0}</p>
                                <p>&nbsp;</p>
                                <p class=""large"">Objet : {1}</p>
                                <table id = ""wordingsTable"">
                                    <tbody>
                                        <tr class=""headerLine"">
                                            <th class=""headerCell"" id=""designationCell""><strong><span class="".text-white"">D&eacute;signation</span></strong></th>
                                            <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">P.U.HT</span></strong></th>
                                            <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">Quantit&eacute;</span></strong></th>
                                            <th class=""headerCell headerCellOthers""><strong><span class="".text-white"">Total HT</span></strong></th>
                                        </tr>", model.clientName, model.estimate.Objet);
            for (int i = 0; i < model.estimate.LibelleList.Count; i++)
            {
                float total = model.estimate.LibelleList.ElementAt(i).PrixU * model.estimate.LibelleList.ElementAt(i).Quantite;
                sb.AppendFormat(@"      
                                        <tr>
                                            <td class=""line"">{0}</td>
                                            <td class=""line text-right"">{1} &euro;</td>
                                            <td class=""line text-right"">{2}</td>
                                            <td class=""line text-right"">{3} &euro;</td>
                                        </tr>",
                                model.estimate.LibelleList.ElementAt(i).Content,
                                model.estimate.LibelleList.ElementAt(i).PrixU,
                                model.estimate.LibelleList.ElementAt(i).Quantite,
                                total);
            }
            sb.AppendFormat(@"
                                    </tbody>
                                </table>
                                <table id = ""TotalTable"">
                                    <tbody>
                                        <tr>
                                            <td class=""headerCell headerLine""><strong>Total HT</strong></td>
                                            <td class=""line text-right"">{0} &euro;</td>
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
                                    Date limite de r&egrave;glement : {1} (&agrave; reception du devis) <br />
                                    Taux des p&eacute;nalit&eacute;s en cas de retard de paiement : taux directeur de refinancement de la BCE, major&eacute; de 10 points<br />
                                    En cas de retard de paiement, indemnit&eacute; forfaitaire l&eacute;gale pour frais de recouvrement : 40,00&euro; <br />
                                    Escompte en cas de paiement anticip&eacute; : aucun
                                </p>
            ", model.estimate.Total, model.estimate.Date.AddDays(7).ToShortDateString());
            sb.Append(@"
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <p id = ""Credit"" class=""spaced large"">Nouvelle Lune - RNA : W713004346<br/>
                                  Email : <a href = ""mailto:isgarrigues@free.fr""> isgarrigues@free.fr</a>&nbsp;- T&eacute;l : 07 82 19 88 55
                                </p>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
