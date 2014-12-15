using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Header : BaseUserControl
    {
        #region PUBLIC MEMBERS
        public enum SezioniHeader
        {
            Home,
            News,
            InfoAnimali,
            Viaggiare,
            AnimaliDaAdottare,
            Allevamenti,
            SitiAmici,
            Veterinari,
            Taglia
        }
        public string Home = string.Empty;
        public string News = string.Empty;
        public string InfoAnimali = string.Empty;
        public string Viaggiare = string.Empty;
        public string AnimaliDaAdottare = string.Empty;
        //public string Allevamenti = string.Empty;
        public string Taglia = string.Empty;
        public string SitiAmici = string.Empty;
        public string Veterinari = string.Empty;
        #endregion

        #region PRIVATE PROPERTY
        private SezioniHeader CurrentSezione
        {
            get 
            {
                if (ViewState["CurrentSezione"] == null)
                    return SezioniHeader.Home;
                return (SezioniHeader)ViewState["CurrentSezione"]; 
            }
            set { ViewState["CurrentSezione"] = value; }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.AggiornaLink(this.CurrentSezione);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Aggiornamento Link
        /// </summary>
        public void AggiornaLink(SezioniHeader sezione)
        {
            this.Home = string.Empty;
            this.News = string.Empty;
            this.InfoAnimali = string.Empty;
            this.Viaggiare = string.Empty;
            this.AnimaliDaAdottare = string.Empty;
            this.Taglia = string.Empty;
            this.SitiAmici = string.Empty;
            this.Veterinari = string.Empty;

            this.CurrentSezione = sezione;
            switch (this.CurrentSezione)
            {
                case SezioniHeader.Home:
                    this.divHome.Visible = true;
                    this.divNews.Visible = false;
                    this.divSitiAmici.Visible = false;
                    this.Home = "background-color:White";
                    break;
                case SezioniHeader.News:
                    this.divHome.Visible = false;
                    this.divNews.Visible = true;
                    this.divSitiAmici.Visible = false;
                    this.News = "background-color:White";
                    break;
                case SezioniHeader.InfoAnimali:
                    this.divHome.Visible = false;
                    this.divNews.Visible = false;
                    this.InfoAnimali = "background-color:White";
                    break;
                case SezioniHeader.Viaggiare:
                    this.divHome.Visible = false;
                    this.divNews.Visible = false;
                    this.divSitiAmici.Visible = false;
                    this.Viaggiare = "background-color:White";
                    break;
                case SezioniHeader.AnimaliDaAdottare:
                    this.divHome.Visible = false;
                    this.divNews.Visible = false;
                    this.divSitiAmici.Visible = false;
                    this.AnimaliDaAdottare = "background-color:White";
                    break;
                case SezioniHeader.Taglia:
                    this.divHome.Visible = false;
                    this.divNews.Visible = false;
                    this.divSitiAmici.Visible = false;
                    this.Taglia = "background-color:White";
                    break;
                case SezioniHeader.SitiAmici:
                    this.divHome.Visible = false;
                    this.divNews.Visible = false;
                    this.divSitiAmici.Visible = true;
                    this.SitiAmici = "background-color:White";
                    break;
                case SezioniHeader.Veterinari:
                    this.divHome.Visible = false;
                    this.divNews.Visible = false;
                    this.divSitiAmici.Visible = false;
                    this.Veterinari = "background-color:White";
                    break;
                default:
                    this.divHome.Visible = true;
                    this.divNews.Visible = false;
                    this.Home = "background-color:White";
                    break;
            }
            ///Utenti loggato
            if (base.UtenteLoggato != null)
            {
                this.lnkHeaderLoginUtente.HRef = "Pannello-Utente.aspx";
                this.lnkHeaderLoginUtente.InnerHtml = "<b>Benvenuto " + base.Capitalize(base.UtenteLoggato.Nome) + " " + base.Capitalize(base.UtenteLoggato.Cognome) + "</b>";
                this.lnkHeaderLoginUtente.Title = "Vai al tuo pannello di controllo";
            }
        } 
        #endregion
    }
}