using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class DettagliUtente : BasePage
    {
        #region PRIVATE MEMBERS

        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Identificativo dell'utente
        /// </summary>
        private int CurrentIDUtente
        {
            get
            {
                if (ViewState["CurrentIDUtente"] == null)
                    return 0;
                return (int)ViewState["CurrentIDUtente"];
            }
            set { ViewState["CurrentIDUtente"] = value; }
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
                if (string.IsNullOrEmpty(Request.QueryString["IDUtente"]))
                {
                    this.CurrentIDUtente = 0;
                }
                else
                {
                    this.CurrentIDUtente = int.Parse(Request.QueryString["IDUtente"]);
                    this.LoadFields(this.CurrentIDUtente);
                }
            }
        }
        /// <summary>
        /// Salva i dettagli dell'utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                Utenti _utent = new Utenti()
                {
                    CAP = this.txtCap.Text.Trim(),
                    CFiscPIva = this.txtCodFisc.Text.Trim(),
                    Citta = this.txtCitta.Text.Trim(),
                    Cognome = this.txtCognome.Text.Trim(),
                    EMail = this.txtEmail.Text.Trim(),
                    RagioneSociale = this.txtRagioneSociale.Text.Trim(),
                    Indirizzo = this.txtIndirizzo.Text.Trim(),
                    IsAttivo = this.chkAttivo.Checked,
                    NumeroCivico = this.txtNumCivico.Text.Trim(),
                    DataNascita = new DateTime(Convert.ToInt32(this.ddlAnno.SelectedValue), Convert.ToInt32(this.ddlMese.SelectedValue), Convert.ToInt32(this.ddlGiorno.SelectedValue)),
                    Nome = this.txtNome.Text.Trim(),
                    NotePerbaffo = this.txtNotePerbaffo.Text.Trim(),
                    Password = this.txtPassword.Text.Trim(),
                    Provincia = this.ddlProvincie.Items[this.ddlProvincie.SelectedIndex].Value,
                    Telefono = this.txtTelefono.Text.Trim(),
                    NewsLetterAcquarologia = this.chkAcquarologia.Checked,
                    NewsLetterCani = this.chkCani.Checked,
                    NewsLetterGatti = this.chkGatti.Checked,
                    NewsLetterRettili = this.chkRettili.Checked,
                    NewsLetterRoditori = this.chkRoditori.Checked,
                    NewsLetterVolatili = this.chkVolatili.Checked
                };
                if (this.CurrentIDUtente == 0)
                {
                    _utent = base.PerbaffoController.SetUtente(_utent);
                }
                else
                {
                    _utent.ID = this.CurrentIDUtente;
                    base.PerbaffoController.UpdateUtente(_utent);
                }
                this.LoadFields(_utent.ID);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Dati utente salvati');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il salvataggio');", true);
            }
        }
        /// <summary>
        /// Cancella in modo definitivo un utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDUtente != 0)
            {
                bool _result = base.PerbaffoController.DeleteUtente(this.CurrentIDUtente);
                if (_result)
                {
                    this.CurrentIDUtente = 0;
                    btnCancella_Click(null, null);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Utente eliminato');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('L\'utente non può essere elinato perchè ha degli ordini a cui è allegato');", true);
                }
            }
        }
        /// <summary>
        /// Annulla le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancella_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDUtente != 0)
                this.LoadFields(this.CurrentIDUtente);
            else
            {
                this.CurrentIDUtente = 0;
                this.txtCap.Text = string.Empty;
                this.txtCodFisc.Text = string.Empty;
                this.txtCitta.Text = string.Empty;
                this.txtCognome.Text = string.Empty;
                this.txtEmail.Text = string.Empty;
                this.txtRagioneSociale.Text = string.Empty;
                this.txtIndirizzo.Text = string.Empty;
                this.chkAttivo.Checked = true;
                this.txtNome.Text = string.Empty;
                this.ddlAnno.SelectedIndex = -1;
                this.ddlGiorno.SelectedIndex = -1;
                this.ddlMese.SelectedIndex = -1;
                this.txtNotePerbaffo.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.ddlProvincie.Value =string.Empty;
                this.txtTelefono.Text = string.Empty;
                this.chkAcquarologia.Checked = false;
                this.chkCani.Checked = false;
                this.chkGatti.Checked = false;
                this.chkRettili.Checked = false;
                this.chkRoditori.Checked = false;
                this.chkVolatili.Checked = false;
                this.txtDataIscrizione.Text = string.Empty;
                this.txtDataLastLogin.Text = string.Empty;
            }

        }
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestioneUtenti.aspx");
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento dei campi
        /// </summary>
        private void LoadFields(int IDUtente)
        {
            for (int i = 1; i <= 31; i++)
            {
                this.ddlGiorno.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1901; i <= DateTime.Now.AddYears(-5).Year; i++)
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

            Utenti _utenti = base.PerbaffoController.GetUtenteByID(IDUtente);           
            if (_utenti != null)
            {
                this.ddlGiorno.SelectedValue = (_utenti.DataNascita == DateTime.MinValue) ? string.Empty : _utenti.DataNascita.Day.ToString();
                this.ddlMese.SelectedValue = (_utenti.DataNascita == DateTime.MinValue) ? string.Empty : _utenti.DataNascita.Month.ToString();
                this.ddlAnno.SelectedValue = (_utenti.DataNascita == DateTime.MinValue) ? string.Empty : _utenti.DataNascita.Year.ToString();
                this.CurrentIDUtente = IDUtente;
                this.txtCap.Text = _utenti.CAP;
                this.txtCodFisc.Text = _utenti.CFiscPIva;
                this.txtCitta.Text = _utenti.Citta;
                this.txtCognome.Text = _utenti.Cognome;
                this.txtEmail.Text = _utenti.EMail;
                this.txtRagioneSociale.Text = (string.IsNullOrEmpty(_utenti.RagioneSociale)) ? string.Empty : _utenti.RagioneSociale;
                this.txtIndirizzo.Text = _utenti.Indirizzo;
                this.txtNumCivico.Text = _utenti.NumeroCivico;
                this.chkAttivo.Checked = _utenti.IsAttivo;
                this.txtNome.Text = _utenti.Nome;
                this.txtNotePerbaffo.Text = _utenti.NotePerbaffo;
                this.txtPassword.Text = _utenti.Password;
                this.ddlProvincie.Value = _utenti.Provincia;
                this.txtTelefono.Text = _utenti.Telefono;
                this.chkAcquarologia.Checked = _utenti.NewsLetterAcquarologia;
                this.chkCani.Checked = _utenti.NewsLetterCani;
                this.chkGatti.Checked = _utenti.NewsLetterGatti;
                this.chkRettili.Checked = _utenti.NewsLetterRettili;
                this.chkRoditori.Checked = _utenti.NewsLetterRoditori;
                this.chkVolatili.Checked = _utenti.NewsLetterVolatili;
                this.txtDataIscrizione.Text = _utenti.DataCreazioneUtente.ToString("dd/MM/yyyy hh:mm:ss");
                this.txtDataLastLogin.Text = _utenti.DataLastLogin.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }
        #endregion
    }
}
