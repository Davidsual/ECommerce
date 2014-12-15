using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class RegistrazioneNewsletter : BasePage,IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
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
                string _email = Request.Form["email"];
                if (!string.IsNullOrEmpty(_email) && _email.Contains('@'))
                {
                    this.txtEMail.Text = _email;
                }
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Registrazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistrati_Click(object sender, EventArgs e)
        {
            if (this.txtEMail.Text.Trim() == string.Empty)
            {
                this.lblErrorMessage.Text = "Inserire l'indirizzo E-Mail sul quale si desidera ricevere le offerte e promozioni di perbaffo";
                this.lblErrorMessage.Visible = true;
                return;
            }
            if (!this.chkDog.Checked &&
                !this.chkGatto.Checked &&
                !this.chkPesci.Checked &&
                !this.chkRoditori.Checked &&
                !this.chkVolatili.Checked)
            {
                this.lblErrorMessage.Text = "Selezionare la categoria per le quali si desidera ricevere le offerte e promozioni di perbaffo";
                this.lblErrorMessage.Visible = true;
                return;
            }
            if (!base.IsEmailValid(this.txtEMail.Text.Trim()))
            {
                this.lblErrorMessage.Text = "Attenzione l'E-Mail inserita non appare valida";
                this.lblErrorMessage.Visible = true;
                return;
            }
            if (base.PerbaffoController.ExistEmailNewsletter(this.txtEMail.Text.Trim()))
            {
                this.lblErrorMessage.Text = "Per aggiornare le categorie di newsletter a cui sei iscritto <a href='Login-Utente.aspx' alt='Vai alla login utente'>clicca qui</a>";
                this.lblErrorMessage.Visible = true;
                return;
            }
            try
            {
                bool _result = base.PerbaffoController.SetNewsletterUtente(this.txtEMail.Text.Trim(),
                    this.chkDog.Checked, this.chkGatto.Checked, this.chkRoditori.Checked,
                    this.chkVolatili.Checked, this.chkPesci.Checked, false);

                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "errore", "alert('Iscrizione alla newsletter avvenuta con successo.');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Default.aspx';", true);
                ///Ripulisco i campi
                this.lblErrorMessage.Visible = false;
                this.txtEMail.Text = string.Empty;
                this.chkDog.Checked = false;
                this.chkGatto.Checked = false;
                this.chkPesci.Checked = false;
                this.chkRoditori.Checked = false;
                this.chkVolatili.Checked = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "errore", "alert('Errore durante l\\'iscrizione alla newsletter');", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Inserimento dei meta tag
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Newsletter, per ricevere sempre nuove offerte e promozioni";
            KeywordsPagina = "Pet shop,newsletter,promozioni,offerte,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Perbaffo - Iscriviti alla newsletter per ricevere sempre nuove offerte e promozioni";
        }
        #endregion
    }
}
