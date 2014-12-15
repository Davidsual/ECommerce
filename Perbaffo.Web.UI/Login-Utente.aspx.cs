using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class LoginUtente : BasePage,IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ///Se sei loggato non c'è ragione per loggarsi di nuovo
            if (this.UtenteLoggato != null)
                Server.Transfer("Default.aspx");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["LOGINACQUISTA"]))
                {
                    this.lblDescrizioneAcquisto.InnerHtml = "<b>Per poter acquistare è necessario essere registrato e loggato su Perbaffo.</b><br/>(Non ti preoccupare, non perderai il tuo carrello durante l'operazione di login / registrazione)";
                    this.lblDescrizioneAcquisto.Style.Add("color", "#C61818");
                }
                ///Faccio logout per sicurezza
                this.LogoutUtente();
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Tentativo di login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            this.lblAlertRegistrazione.Text = string.Empty;
            this.txtEmail.Value = string.Empty;
            if (this.txtEmailUtente.Value.Trim() == string.Empty || this.txtpassword.Value.Trim() == string.Empty)
            {
                this.lblAlertLogin.Text = "Inserire l'indirizzo E-Mail e la password per accedere!";
                return;
            }
            if (!base.IsEmailValid(this.txtEmailUtente.Value.Trim()))
            {
                this.txtEmailUtente.Value = string.Empty;
                this.lblAlertLogin.Text = "Attenzione l'E-Mail inserita non appare valida";
                return;
            }
            if (this.txtpassword.Value.Trim().Length < 6)
            {
                this.txtEmailUtente.Value = string.Empty;
                this.lblAlertLogin.Text = "Attenzione la password inserita non è valida!";
                return;
            }
            Utenti _currUtente = base.PerbaffoController.CheckLogin(this.txtEmailUtente.Value.Trim(),this.txtpassword.Value.Trim());
            ///Utente non riconosciuto
            if (_currUtente == null)
            {
                this.txtpassword.Value = string.Empty;
                this.lblAlertLogin.Text = "Utente non riconosciuto";
                return;
            }
            else
            {
                base.InserisciUtenteCorrente(_currUtente);
                if (!string.IsNullOrEmpty(Request.QueryString["LOGINACQUISTA"]))
                {
                    Response.Redirect("Carrello-Prodotti.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Default.aspx';", true);
            }
        }
        /// <summary>
        /// Registrazione di un nuovo utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            this.txtEmailUtente.Value = string.Empty;
            this.txtpassword.Value = string.Empty;
            this.lblAlertLogin.Text = string.Empty;

            if (this.txtEmail.Value.Trim() == string.Empty)
            {
                this.lblAlertRegistrazione.Text = "Inserire l'indirizzo E-Mail con il quale si intende registrarsi!";
                return;
            }
            if (!base.IsEmailValid(this.txtEmail.Value.Trim()) || this.txtEmail.Value.Trim().ToUpper().Contains("PERBAFFO"))
            {
                this.txtEmail.Value = string.Empty;
                this.lblAlertRegistrazione.Text = "Attenzione l'E-Mail inserita non appare valida";
                return;
            }
            if (base.PerbaffoController.ExistUtente(this.txtEmail.Value.Trim()))
            {
                this.txtEmail.Value = string.Empty;
                this.lblAlertRegistrazione.Text = "Attenzione l'E-Mail è già registrata, se hai dimenticato la tua password fai click sul link 'Password dimenticata'!";
                return;
            }
            Utenti _utenti = new Utenti() {EMail = this.txtEmail.Value.Trim()};
            base.AddUtenteRegistrazione(_utenti);
            Server.Transfer("Registrazione-Utente.aspx");
        } 
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Aggiorna i meta tag del sito
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Login, per accedere o registrarsi a Perbaffo";
            KeywordsPagina = "Pet shop,utente,utenti,password,registrati,accedere,login,dimenticato,e-mail,promozioni,offerte,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Accedi o iscriviti al mondo Perbaffo per ricevere sempre nuove offerte e promozioni";
        }
        #endregion
    }
}
