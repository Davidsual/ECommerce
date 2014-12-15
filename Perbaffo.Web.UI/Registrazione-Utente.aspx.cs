using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Text;

namespace Perbaffo.Web.UI
{
    public partial class Registrazione_Utente : BasePage, IPerbaffoSite
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
            if (base.TempUtente == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Login-Utente.aspx';", true);
                return;
            }
            string _resultCheck = this.CheckField();
            if (!string.IsNullOrEmpty(_resultCheck))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + _resultCheck + "');", true);
                return;
            }

            try
            {
                base.TempUtente.CAP = this.txtCAP.Text.Trim();
                base.TempUtente.CFiscPIva = this.txtCodiceFiscale.Text.Trim().ToUpper();
                base.TempUtente.Citta = base.Capitalize(this.txtCitta.Text.Trim());
                base.TempUtente.Cognome = base.Capitalize(this.txtCognome.Text.Trim());
                base.TempUtente.Nome = base.Capitalize(this.txtNome.Text.Trim());
                base.TempUtente.DataCreazioneUtente = DateTime.Now;
                base.TempUtente.DataNascita = new DateTime(Convert.ToInt32(this.ddlAnno.SelectedValue), Convert.ToInt32(this.ddlMese.SelectedValue), Convert.ToInt32(this.ddlGiorno.SelectedValue));
                base.TempUtente.Indirizzo = base.Capitalize(this.txtVia.Text.Trim());
                base.TempUtente.IsAttivo = true;
                base.TempUtente.NumeroCivico = this.txtNumCivico.Text.Trim();
                base.TempUtente.Provincia = this.ddlProvincie.Items[this.ddlProvincie.SelectedIndex].Value;
                base.TempUtente.RagioneSociale = base.Capitalize(this.txtAzienda.Text.Trim());
                base.TempUtente.Telefono = this.txtTelefono.Text.Trim();
                base.TempUtente.NotePerbaffo = string.Empty;
                base.TempUtente.NewsLetterAcquarologia = this.chkPesci.Checked;
                base.TempUtente.NewsLetterCani = this.chkDog.Checked;
                base.TempUtente.NewsLetterGatti = this.chkGatto.Checked;
                base.TempUtente.NewsLetterRettili = false;
                base.TempUtente.NewsLetterRoditori = this.chkRoditori.Checked;
                base.TempUtente.NewsLetterVolatili = this.chkVolatili.Checked;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Registrazione-Utente-Password.aspx';", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante la procedura di registrazione');", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Popolo le 4 combo
        /// </summary>
        private void LoadFieds()
        {
            this.lblEMail.Text = base.TempUtente.EMail;

            for (int i = 1; i <= 31; i++)
            {
                this.ddlGiorno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1929; i <= DateTime.Now.AddYears(-5).Year; i++)
            {
                this.ddlAnno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            this.ddlMese.Items.Add(new ListItem("Gennaio","1"));
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

            this.txtNome.Text = base.TempUtente.Nome;
            this.txtCognome.Text = base.TempUtente.Cognome;
            this.txtCodiceFiscale.Text = base.TempUtente.CFiscPIva;
            this.txtAzienda.Text = base.TempUtente.RagioneSociale;
            this.ddlGiorno.SelectedValue = (base.TempUtente.DataNascita == DateTime.MinValue) ? string.Empty : base.TempUtente.DataNascita.Day.ToString();
            this.ddlMese.SelectedValue = (base.TempUtente.DataNascita == DateTime.MinValue) ? string.Empty : base.TempUtente.DataNascita.Month.ToString();
            this.ddlAnno.SelectedValue = (base.TempUtente.DataNascita == DateTime.MinValue) ? string.Empty : base.TempUtente.DataNascita.Year.ToString();
            this.ddlProvincie.Value = (string.IsNullOrEmpty(base.TempUtente.Provincia)) ? string.Empty : base.TempUtente.Provincia;
            this.txtCitta.Text =  base.TempUtente.Citta;
            this.txtVia.Text =  base.TempUtente.Indirizzo;
            this.txtNumCivico.Text = base.TempUtente.NumeroCivico;
            this.txtCAP.Text = base.TempUtente.CAP;
            this.txtTelefono.Text = base.TempUtente.Telefono;
            this.chkDog.Checked = base.TempUtente.NewsLetterCani;
            this.chkGatto.Checked = base.TempUtente.NewsLetterGatti;
            this.chkPesci.Checked =base.TempUtente.NewsLetterAcquarologia;
            this.chkRoditori.Checked =base.TempUtente.NewsLetterRoditori;
            this.chkVolatili.Checked = base.TempUtente.NewsLetterVolatili;
        }
        /// <summary>
        /// Aggiorna i meta tag del sito
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Registrazione di un nuovo utente Step 1/2";
            KeywordsPagina = "Pet shop,Registrazione,Step 1/2,Newsletter,Login,nuovo,utente,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Registrati al mondo Perbaffo per ricevere sempre nuove offerte e promozioni";
        }
        /// <summary>
        /// Controllo formale dei campi
        /// </summary>
        private string CheckField()
        {
            StringBuilder _result = new StringBuilder();

            if(string.IsNullOrEmpty(this.txtNome.Text.Trim()))
                _result.Append("Inserire il proprio Nome \\n");
            if (string.IsNullOrEmpty(this.txtCognome.Text.Trim()))
                _result.Append("Inserire il proprio Cognome \\n");
            if (string.IsNullOrEmpty(this.txtCodiceFiscale.Text.Trim()))
                _result.Append("Inserire il proprio Codice Fiscale - Partita IVA \\n");
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
            if(this.ddlGiorno.SelectedIndex <= 0)
                _result.Append("Inserire il proprio Giorno di Nascita \\n");
            if (this.ddlMese.SelectedIndex <= 0)
                _result.Append("Inserire il proprio Mese di Nascita \\n");
            if (this.ddlAnno.SelectedIndex <= 0)
                _result.Append("Inserire il proprio Anno di Nascita \\n");
            if (string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
                _result.Append("Inserire il proprio Numero di Telefono \\n");
            if(this.txtCodiceFiscale.Text.Trim().Length != 11 && this.txtCodiceFiscale.Text.Trim().Length != 16)
                _result.Append("Il Codice Fiscale - P.IVA inserito non è corretta \\n");

            int _test = 0;
            if (!int.TryParse(this.txtCAP.Text.Trim(), out _test))
                _result.Append("Il CAP inserito non è corretto \\n");

            if(!this.chkAccetta.Checked)
                _result.Append("Per proseguire con la registrazione bisogna autorizzare il trattamento dei propri dati ai sensi di legge \\n");
            return _result.ToString();
        }
        #endregion


    }
}
