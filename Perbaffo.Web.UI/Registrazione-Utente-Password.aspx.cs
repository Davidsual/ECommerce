using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Text;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class Registrazione_Utente_Password : BasePage, IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE PROPERTY
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
                if (base.TempUtente == null)
                {
                    Server.Transfer("Login-Utente.aspx");
                }
                ///Gestisco i metatag
                this.GestioneMetaTag();
                this.LoadFieds();
            }
        }
        /// <summary>
        /// Controllo se i dati sono corretti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            string _resultCheck = this.CheckField();
            if (!string.IsNullOrEmpty(_resultCheck))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + _resultCheck + "');", true);
                return;
            }
            try
            {
                base.TempUtente.Password = this.txtPassword.Text.Trim().Replace(" ", "");
                ///Salva utente
                base.AddUtenteRegistrazione(base.PerbaffoController.SetUtente(base.TempUtente));                
                base.InserisciUtenteRegistrato();
                base.PerbaffoController.InvioMailNuovoUtente(this.UtenteLoggato);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Iscrizione avvenuta con successo!');", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Registrazione-Utente-Foto.aspx?Registrazione=YES';", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante la procedura di registrazione');", true);
            }
        }
        /// <summary>
        /// Modifica i dati precedentemente inseriti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Registrazione-Utente.aspx';", true);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Popolo le 4 combo
        /// </summary>
        private void LoadFieds()
        {
            this.lblEMail.Text = base.TempUtente.EMail;
            StringBuilder _strBuilder = new StringBuilder();
            _strBuilder.Append(base.TempUtente.Nome + " - " + base.TempUtente.Cognome + "<br/>");
            _strBuilder.Append(base.TempUtente.DataNascita.ToShortDateString() + "  " + base.TempUtente.CFiscPIva + "<br/>");
            if(!string.IsNullOrEmpty(base.TempUtente.RagioneSociale))
                _strBuilder.Append(base.TempUtente.RagioneSociale + "<br/>");
            _strBuilder.Append(base.TempUtente.Citta + " (" + base.TempUtente.Provincia + ")<br/>");
            _strBuilder.Append(base.TempUtente.Indirizzo + " - " + base.TempUtente.NumeroCivico + "<br/>");
            _strBuilder.Append(base.TempUtente.CAP + "<br/>");
            _strBuilder.Append(base.TempUtente.Telefono);
            this.lblRiepilogo.InnerHtml = _strBuilder.ToString();
        }
        /// <summary>
        /// Aggiorna i meta tag del sito
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Registrazione di un nuovo utente Step 2/2";
            KeywordsPagina = "Pet shop,Registrazione,Step 2/2,Newsletter,Login,nuovo,utente,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Registrati al mondo Perbaffo per ricevere sempre nuove offerte e promozioni";
        }
        /// <summary>
        /// Controllo formale dei campi
        /// </summary>
        private string CheckField()
        {
            StringBuilder _result = new StringBuilder();

            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
                _result.Append("Inserire la propria password (alemeno 6 caratteri) \\n");
            if (string.IsNullOrEmpty(this.txtRetypePassword.Text.Trim()))
                _result.Append("Ridigitare la propria password \\n");
            if (this.txtPassword.Text.Trim().Replace(" ","").Length < 6 )
                _result.Append("La password deve contenere almeno 6 caratteri \\n");
            if (this.txtPassword.Text.Trim().Replace(" ", "").Length > 15)
                _result.Append("La password può contenere al massimo 15 caratteri \\n");
            if (this.txtPassword.Text.Trim().ToLower().Replace(" ", "") != this.txtRetypePassword.Text.Trim().ToLower().Replace(" ",""))
                _result.Append("Le due password inserite devono coincidere! \\n");

            return _result.ToString();
        }
        #endregion

    }
}
