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
    public partial class Acquisto_Indirizzo_Spedizione : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private enum Stato_Pagina
        {
            Visualizza,
            Modifica
        }
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE PROPERTY
        private Stato_Pagina CurrentStato
        {
            get { return (Stato_Pagina)ViewState["CurrentStato"]; }
            set { ViewState["CurrentStato"] = value; }
        }
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Login-Utente.aspx';", true);
                return;
            }
            if (base.Carrello == null || base.Carrello.Prodotti == null || base.Carrello.Prodotti.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Carrello-Prodotti.aspx';", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                this.CurrentStato = Stato_Pagina.Visualizza;
                this.LoadField();
                this.AbilitaDisabilitaCampi(false);
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Continua alla sezione successiva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            if (this.CurrentStato != Stato_Pagina.Visualizza)
                return;
            ///Ulteriore controllo
            string _resultCheck = this.CheckField();
            if (!string.IsNullOrEmpty(_resultCheck))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + _resultCheck + "');", true);
                return;
            }
            try
            {
                ///Compongo la testa dell'ordine con l'indirizzo del destinatario
                Ordini _ordini = new Ordini()
                {
                    Nome = (this.txtNome.Text.Trim().Length > 50) ? this.txtNome.Text.Trim().Substring(0, 49) : this.txtNome.Text.Trim(),
                    Cognome = (this.txtCognome.Text.Trim().Length > 50) ? this.txtCognome.Text.Trim().Substring(0, 49) : this.txtCognome.Text.Trim(),
                    NumeroCivico = (this.txtNumCivico.Text.Trim().Length > 50) ? this.txtNumCivico.Text.Trim().Substring(0, 49) : this.txtNumCivico.Text.Trim(),
                    Telefono = (this.txtTelefono.Text.Trim().Length > 50) ? this.txtTelefono.Text.Trim().Substring(0, 49) : this.txtTelefono.Text.Trim(),
                    CAP = this.txtCAP.Text.Trim(),
                    Citta = (this.txtCitta.Text.Trim().Length > 200) ? this.txtCitta.Text.Trim().Substring(0, 198) : this.txtCitta.Text.Trim(),
                    EMail = base.UtenteLoggato.EMail,
                    Indirizzo = this.txtVia.Text.Trim(),
                    Provincia = this.ddlProvincie.Value,
                    Note = (this.txtNote.Text.Trim() == string.Empty) ? null : (this.txtNote.Text.Trim().Length > 295) ? this.txtNote.Text.Trim().Substring(0, 290) : this.txtNote.Text.Trim()
                };
                ///Aggiunge l'ordine
                base.AggiungiOrdine(_ordini);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Pagamenti.aspx';", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Va in modifica/Salva i dati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            if (this.btnModifica.CommandName.ToUpper() == "MOD")
            {
                //abilito
                this.btnContinua.Visible = false;
                this.btnModifica.CommandName = "SAVE";
                this.btnModifica.Text = "Aggiorna";
                this.btnModifica.ValidationGroup = "UTENTE";
                this.AbilitaDisabilitaCampi(true);
                this.CurrentStato = Stato_Pagina.Modifica;
            }
            else
            {
                //disabilito
                string _resultCheck = this.CheckField();
                if (!string.IsNullOrEmpty(_resultCheck))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + _resultCheck + "');", true);
                    return;
                }
                ///Salvo nell'oggetto Ordine
                this.btnContinua.Visible = true;
                this.btnModifica.CommandName = "MOD";
                this.btnModifica.Text = "Modifica";
                this.btnModifica.ValidationGroup = string.Empty;
                this.AbilitaDisabilitaCampi(false);
                this.CurrentStato = Stato_Pagina.Visualizza;
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica i campi con i dettagli del carrello
        /// </summary>
        private void LoadField()
        {
            if (this.CurrentStato != Stato_Pagina.Visualizza)
                return;
            if (base.CurrentOrdine != null)
            {
                this.lblEMail.Text = base.UtenteLoggato.EMail;
                this.txtNome.Text = base.Capitalize(base.CurrentOrdine.Nome);
                this.txtCognome.Text = base.Capitalize(base.CurrentOrdine.Cognome);
                this.ddlProvincie.Value = base.CurrentOrdine.Provincia;
                this.txtCitta.Text = base.Capitalize(base.CurrentOrdine.Citta);
                this.txtVia.Text = base.Capitalize(base.CurrentOrdine.Indirizzo);
                this.txtNumCivico.Text = base.CurrentOrdine.NumeroCivico;
                this.txtCAP.Text = base.CurrentOrdine.CAP.ToString();
                this.txtTelefono.Text = base.CurrentOrdine.Telefono;
                this.txtNote.Text = base.CurrentOrdine.Note;
            }
            else
            {
                this.lblEMail.Text = base.UtenteLoggato.EMail;
                this.txtNome.Text = base.Capitalize(base.UtenteLoggato.Nome);
                this.txtCognome.Text = base.Capitalize(base.UtenteLoggato.Cognome);
                this.ddlProvincie.Value = base.UtenteLoggato.Provincia;
                this.txtCitta.Text = base.Capitalize(base.UtenteLoggato.Citta);
                this.txtVia.Text = base.Capitalize(base.UtenteLoggato.Indirizzo);
                this.txtNumCivico.Text = base.UtenteLoggato.NumeroCivico;
                this.txtCAP.Text = base.UtenteLoggato.CAP.ToString();
                this.txtTelefono.Text = base.UtenteLoggato.Telefono;
                this.txtNote.Text = string.Empty;
            }
        }
        /// <summary>
        /// Controllo formale dei campi
        /// </summary>
        private string CheckField()
        {
            StringBuilder _result = new StringBuilder();

            if (string.IsNullOrEmpty(this.txtNome.Text.Trim()))
                _result.Append("Inserire il proprio Nome \\n");
            if (string.IsNullOrEmpty(this.txtCognome.Text.Trim()))
                _result.Append("Inserire il proprio Cognome \\n");
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

            int _test = 0;
            if (!int.TryParse(this.txtCAP.Text.Trim(), out _test))
                _result.Append("Il CAP inserito non è corretto \\n");
            return _result.ToString();
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Acquisto, Indirizzo di spedizione della merce";
            this.DescrizionePagina = "Perbaffo inserirmento dell'indirizzo dove si desidera che la merce venga recapitata";
            this.KeywordsPagina = "Perbaffo,acquisto,indirizzo,spedizione,merce,prodotti,sconto";
        }
        /// <summary>
        /// Abilita/disabilita campi
        /// </summary>
        private void AbilitaDisabilitaCampi(bool IsAttivo)
        {
            this.txtNome.ReadOnly = !IsAttivo;
            this.txtCognome.ReadOnly = !IsAttivo;
            this.ddlProvincie.Disabled = !IsAttivo;
            this.txtCitta.ReadOnly = !IsAttivo;
            this.txtVia.ReadOnly = !IsAttivo;
            this.txtNumCivico.ReadOnly = !IsAttivo;
            this.txtCAP.ReadOnly = !IsAttivo;
            this.txtTelefono.ReadOnly = !IsAttivo;
            this.txtNote.ReadOnly = !IsAttivo;

            this.txtNome.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            this.txtCognome.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            //this.ddlProvincie.Attributes.Add("class", = !IsAttivo;
            this.txtCitta.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            this.txtVia.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            this.txtNumCivico.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            this.txtCAP.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            this.txtTelefono.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
            this.txtNote.CssClass = (IsAttivo) ? "pp_box_registrazione" : "pp_box_registrazione_disabled";
        }
        #endregion

    }
}
