using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perbaffo.Web.UI.Admin
{
    public partial class PerbaffoMaster : System.Web.UI.MasterPage
    {
        public enum SectionMaster
        {
            HomePage,
            DettaglioProdotto,
            DettaglioOrdine,
            GestioneCategorie,
            GestioneNovita,
            GestioneOfferte,
            GestioneUtente,
            DettaglioNotizia,
            CodicePromozione,
            UtentePromozione,
            DettaglioCuriosita,
            DettaglioCodiceAffiliazione
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ///Controllo sessione
            if (Session["CurrentAmministratore"] == null)
            {
                Server.Transfer("Login.aspx");
            }
            this.MenuControl.MenuSelectionHandler += new Menu.MenuDelegate(MenuControl_MenuSelectionHandler);
        }

        public void LoadPage(SectionMaster sezione)
        {
            this.LoadPage(sezione, string.Empty);
        }
        public void LoadPage(SectionMaster sezione,string Params)
        {
            switch (sezione)
            {
                case SectionMaster.DettaglioProdotto:
                    if(string.IsNullOrEmpty(Params))
                        Response.Redirect("DettaglioProdotto.aspx", true);
                    else
                        Response.Redirect("DettaglioProdotto.aspx" + Params, true);
                    break;
                case SectionMaster.DettaglioOrdine:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettaglioOrdine.aspx", true);
                    else
                        Response.Redirect("DettaglioOrdine.aspx" + Params, true);
                    break;
                case SectionMaster.HomePage:
                    Response.Redirect("HomePage.aspx", true);
                    break;
                case SectionMaster.GestioneCategorie:
                    Response.Redirect("GestioneCategorie.aspx", true);
                    break;
                case SectionMaster.GestioneNovita:
                    Response.Redirect("GestioneNovita.aspx", true);
                    break;
                case SectionMaster.GestioneUtente:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettagliUtente.aspx", true);
                    else
                        Response.Redirect("DettagliUtente.aspx" + Params, true);
                    break;
                case SectionMaster.DettaglioNotizia:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettagliNotizia.aspx", true);
                    else
                        Response.Redirect("DettagliNotizia.aspx" + Params, true);
                    break;
                case SectionMaster.CodicePromozione:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettaglioCodiciPromozioni.aspx", true);
                    else
                        Response.Redirect("DettaglioCodiciPromozioni.aspx" + Params, true);
                    break;
                case SectionMaster.UtentePromozione:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettaglioUtentiPromozioni.aspx", true);
                    else
                        Response.Redirect("DettaglioUtentiPromozioni.aspx" + Params, true);
                    break;
                case SectionMaster.DettaglioCuriosita:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettaglioCuriosita.aspx", true);
                    else
                        Response.Redirect("DettaglioCuriosita.aspx" + Params, true);
                    break;
                case SectionMaster.DettaglioCodiceAffiliazione:
                    if (string.IsNullOrEmpty(Params))
                        Response.Redirect("DettaglioCodiciAffiliazione.aspx", true);
                    else
                        Response.Redirect("DettaglioCodiciAffiliazione.aspx" + Params, true);
                    break;
                default:
                    break;
            }
        }
        private void MenuControl_MenuSelectionHandler(Menu.Section sezione)
        {
            switch (sezione)
            {
                case Menu.Section.Home:
                    Response.Redirect("HomePage.aspx", true);
                    break;
                case Menu.Section.Prodotti:
                    Response.Redirect("Prodotti.aspx",true);
                    break;
                case Menu.Section.Categorie:
                    Response.Redirect("GestioneCategorie.aspx", true);
                    break;
                case Menu.Section.Novita:
                    Response.Redirect("GestioneNovita.aspx", true);
                    break;
                case Menu.Section.Offerte:
                    Response.Redirect("GestioneOfferte.aspx", true);
                    break;
                case Menu.Section.Utenti:
                    Response.Redirect("GestioneUtenti.aspx", true);
                    break;
                case Menu.Section.Colori:
                    Response.Redirect("GestioneColori.aspx", true);
                    break;
                case Menu.Section.Pagamenti:
                    Response.Redirect("GestionePagamenti.aspx", true);
                    break;
                case Menu.Section.Spedizioni:
                    Response.Redirect("GestioneSpedizioni.aspx", true);
                    break;
                case Menu.Section.ProdottiSottoScorta:
                    Response.Redirect("GestioneProdottiSottoScorta.aspx", true);
                    break;
                case Menu.Section.Omaggi:
                    Response.Redirect("GestioneOmaggi.aspx", true);
                    break;
                case Menu.Section.Notizie:
                    Response.Redirect("Notizie.aspx", true);
                    break;
                case Menu.Section.Ordini:
                    Response.Redirect("Ordini.aspx", true);
                    break;
                case Menu.Section.Newsletter:
                    Response.Redirect("GestioneNewsLetter.aspx", true);
                    break;
                case Menu.Section.Curiosita:
                    Response.Redirect("GestCuriosita.aspx", true);
                    break;
                default:
                    break;
            }
        }
    }
}
