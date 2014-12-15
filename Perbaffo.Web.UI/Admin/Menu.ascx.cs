using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;

namespace Perbaffo.Web.UI.Admin
{
    public partial class Menu : BasePageUserControl
    {
        public enum Section
        {
            Home,
            Prodotti,
            Categorie,
            Novita,
            Offerte,
            Utenti,
            Colori,
            Pagamenti,
            Spedizioni,
            ProdottiSottoScorta,
            Omaggi,
            Ordini,
            Notizie,
            Newsletter,
            Curiosita
        }
        public delegate void MenuDelegate(Section sezione);
        public event MenuDelegate MenuSelectionHandler;

        /// <summary>
        /// Caricamento del menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(CurrentAmministratore != null)
                    this.lblLastAccesso.InnerHtml = base.CurrentAmministratore.Nome + " " + base.CurrentAmministratore.Cognome + "<br/> Ultimo Login: " + base.CurrentAmministratore.DataUltimoLogin.ToShortDateString() + " - " + base.CurrentAmministratore.DataUltimoLogin.ToShortTimeString();
                this.lblCountProdotti.Text = base.PerbaffoController.GetCountProdotti(true).ToString();
                this.lblScorta.Text = base.PerbaffoController.GetCountProdottiSottoScorta(true).ToString();
            }
        }
        /// <summary>
        /// Selezione sul menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAction_Click(object sender, EventArgs e)
        {
            switch (((LinkButton)sender).CommandName.ToUpper())
            {
                case "HOME":
                     if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Home);
                    break;
                case "PRODOTTI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Prodotti);
                    break;
                case "CATEGORIE":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Categorie);
                    break;
                case "NOVITA":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Novita);
                    break;
                case "OFFERTE":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Offerte);
                    break;
                case "UTENTI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Utenti);
                    break;
                case "COLORI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Colori);
                    break;
                case "PAGAMENTI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Pagamenti);
                    break;
                case "SPEDIZIONI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Spedizioni);
                    break;
                case "SCORTA":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.ProdottiSottoScorta);
                    break;
                case "OMAGGI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Omaggi);
                    break;
                case "ORDINI":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Ordini);
                    break;
                case "NEWS":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Notizie);
                    break;
                case "NEWSLETTER":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Newsletter);
                    break;
                case "CURIOSITA":
                    if (MenuSelectionHandler != null)
                        MenuSelectionHandler(Section.Curiosita);
                    break;
                default:
                    break;
            }
        }
    }
}