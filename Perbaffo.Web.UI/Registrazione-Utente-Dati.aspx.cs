using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Text;

namespace Perbaffo.Web.UI
{
    public partial class Registrazione_Utente_Dati : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        #endregion

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
        /// Carica pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.UtenteLoggato == null)
            {
                Server.Transfer("Login-Utente.aspx");
            }
            if (!Page.IsPostBack)
            {
                this.LoadFields();
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Carica i campi
        /// </summary>
        private void LoadFields()
        {
            for (int i = 1; i <= 31; i++)
            {
                this.ddlGiorno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1929; i <= DateTime.Now.AddYears(-5).Year; i++)
            {
                this.ddlAnno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            this.ddlMese.Items.Add(new ListItem("Gennaio", "1"));
            this.ddlMese.Items.Add(new ListItem("Febbraio", "2"));
            this.ddlMese.Items.Add(new ListItem("Marzo", "3"));
            this.ddlMese.Items.Add(new ListItem("Aprile", "4"));
            this.ddlMese.Items.Add(new ListItem("Maggio", "5"));
            this.ddlMese.Items.Add(new ListItem("Giugno", "6"));
            this.ddlMese.Items.Add(new ListItem("Luglio", "7"));
            this.ddlMese.Items.Add(new ListItem("Agosto", "8"));
            this.ddlMese.Items.Add(new ListItem("Settembre", "9"));
            this.ddlMese.Items.Add(new ListItem("Ottobre", "10"));
            this.ddlMese.Items.Add(new ListItem("Novembre", "11"));
            this.ddlMese.Items.Add(new ListItem("Dicembre", "12"));

            this.ddlGiorno.Items.Insert(0, "");
            this.ddlMese.Items.Insert(0, "");
            this.ddlAnno.Items.Insert(0, "");

            this.lblEMail.Text = base.UtenteLoggato.EMail;
            this.lblNome.Text = base.UtenteLoggato.Nome;
            this.lblCognome.Text = base.UtenteLoggato.Cognome;
            this.ddlGiorno.SelectedValue = base.UtenteLoggato.DataNascita.Day.ToString();
            this.ddlMese.SelectedValue = base.UtenteLoggato.DataNascita.Month.ToString();
            this.ddlAnno.SelectedValue = base.UtenteLoggato.DataNascita.Year.ToString();
            this.lblCodiceFiscale.Text = base.UtenteLoggato.CFiscPIva;
            this.txtAzienda.Text = base.UtenteLoggato.RagioneSociale;
            this.ddlProvincie.Value = base.UtenteLoggato.Provincia;
            this.txtCitta.Text = base.UtenteLoggato.Citta;
            this.txtNumCivico.Text = base.UtenteLoggato.NumeroCivico;
            this.txtVia.Text = base.UtenteLoggato.Indirizzo;
            this.txtCAP.Text = base.UtenteLoggato.CAP.ToString();
            this.txtTelefono.Text = base.UtenteLoggato.Telefono;
        }
        /// <summary>
        /// Taglia la string se troppo grande
        /// </summary>
        /// <param name="valore"></param>
        /// <returns></returns>
        public string TagliaStringa(string valore)
        {
            if (string.IsNullOrEmpty(valore))
                return valore;
            if (valore.Length > 200)
                return valore.Substring(0, 190) + "...";
            return valore;
        }
        /// <summary>
        /// Aggiorna i dati
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
                base.UtenteLoggato.CAP = this.txtCAP.Text.Trim();
                base.UtenteLoggato.Citta = base.Capitalize(this.txtCitta.Text.Trim());
                base.UtenteLoggato.Indirizzo = base.Capitalize(this.txtVia.Text.Trim());
                base.UtenteLoggato.NumeroCivico = this.txtNumCivico.Text.Trim();
                base.UtenteLoggato.Provincia = this.ddlProvincie.Items[this.ddlProvincie.SelectedIndex].Value;
                base.UtenteLoggato.RagioneSociale = base.Capitalize(this.txtAzienda.Text.Trim());
                base.UtenteLoggato.Telefono = this.txtTelefono.Text.Trim();
                base.UtenteLoggato.DataNascita = new DateTime(Convert.ToInt32(this.ddlAnno.SelectedValue), Convert.ToInt32(this.ddlMese.SelectedValue), Convert.ToInt32(this.ddlGiorno.SelectedValue));
                base.InserisciUtenteCorrente(base.PerbaffoController.UpdateDettagliUtente(base.UtenteLoggato));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Pannello-Utente.aspx';", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante la procedura di aggiornamento');", true);
            }
        }
        /// <summary>
        /// Porta l'utente al pannello di controllo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPannello_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Pannello-Utente.aspx';", true);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Perbaffo - Registrazione dati utente";
            this.KeywordsPagina = "Pet shop,registrazione,dati,utente,personali,gatti,volatili,roditori,pesci,ordine,ordini,acquisto,merce";
            this.DescrizionePagina = "Perbaffo registrazione dati utente";
        }
        /// <summary>
        /// Controllo formale dei campi
        /// </summary>
        private string CheckField()
        {
            StringBuilder _result = new StringBuilder();

            if (string.IsNullOrEmpty(this.txtCitta.Text.Trim()))
                _result.Append("Inserire la propria Città di residenza \\n");
            if (string.IsNullOrEmpty(this.txtVia.Text.Trim()))
                _result.Append("Inserire la propria Via di residenza \\n");
            if (string.IsNullOrEmpty(this.txtNumCivico.Text.Trim()))
                _result.Append("Inserire il proprio Numero Civico di residenza \\n");
            if (string.IsNullOrEmpty(this.txtCAP.Text.Trim()))
                _result.Append("Inserire il proprio Cap di residenza \\n");
            if (this.ddlProvincie.SelectedIndex <= 0)
                _result.Append("Inserire la propria Provincia di residenza \\n");
            if (string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
                _result.Append("Inserire il proprio Numero di Telefono \\n");
            if (this.ddlGiorno.SelectedIndex <= 0)
                _result.Append("Inserire il proprio Giorno di Nascita \\n");
            if (this.ddlMese.SelectedIndex <= 0)
                _result.Append("Inserire il proprio Mese di Nascita \\n");
            if (this.ddlAnno.SelectedIndex <= 0)
                _result.Append("Inserire il proprio Anno di Nascita \\n");

            int _test = 0;
            if (!int.TryParse(this.txtCAP.Text.Trim(), out _test))
                _result.Append("Il CAP inserito non è corretto \\n");
            return _result.ToString();
        }
        #endregion


    }
}
