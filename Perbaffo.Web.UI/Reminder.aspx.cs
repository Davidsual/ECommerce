using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Reminder : BasePage,IPerbaffoSite
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
            if (!Page.IsPostBack)
            {
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Pulsante per recuperare la propria password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRecuperoDati_Click(object sender, EventArgs e)
        {
            if (this.txtEMailUser.Value.Trim() == string.Empty)
            {
                this.lblAlertLogin.Text = "Inserire l'indirizzo E-Mail per il quale si desidere riottenere i dati di accesso!";
                return;
            }
            if (!base.IsEmailValid(this.txtEMailUser.Value.Trim()))
            {
                this.txtEMailUser.Value = string.Empty;
                this.lblAlertLogin.Text = "Attenzione l'E-Mail inserita non appare valida";
                return;
            }
            if (!base.PerbaffoController.ExistUtente(this.txtEMailUser.Value.Trim()))
            {
                this.txtEMailUser.Value = string.Empty;
                this.lblAlertLogin.Text = "Attenzione l'E-Mail inserita non è stata trovata all'interno di Perbaffo vai alla pagina di registrazione nuovo utente seguendo il link 'Ritorna alla pagina di login'!";
                return;
            }
            bool _result = base.PerbaffoController.InvioMailRecuperoPassword(this.txtEMailUser.Value.Trim());

            if (_result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('E\\' stata inviata un\\'E-Mail riepilogativa con i dati per accedere a Perbaffo, all\\'indirizzo E-Mail indicato!');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Login-Utente.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante l\\'invio della mail, ci scusiamo per l\\'errore.');", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Aggiorna i meta tag del sito
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Recupero credenziali per accedere a Perbaffo";
            KeywordsPagina = "Pet shop,Registrati,accedere,Login,promozioniofferte,credenziali,indirizzo,e-mail";
            DescrizionePagina = "Recupero dei propri dati di accesso, per accedere a Perbaffo";
        }
        #endregion


    }
}
