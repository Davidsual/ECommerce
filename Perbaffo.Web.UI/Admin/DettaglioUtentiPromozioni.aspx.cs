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
    public partial class DettaglioUtentiPromozioni : BasePage
    {
        #region PRIVATE MEMBERS
        private enum PageStatus
        {
            Inserimento,
            Modifica
        }
        #endregion

        #region PRIVATE PROPERTY
        private PageStatus CurrentPageState
        {
            get
            {
                if (ViewState["CurrentPageState"] == null)
                    return PageStatus.Inserimento;
                return (PageStatus)ViewState["CurrentPageState"];
            }
            set
            {
                ViewState["CurrentPageState"] = value;
            }
        }
        private int CurrentIDUtentePromoz
        {
            get
            {
                if (ViewState["CurrentIDUtentePromoz"] == null)
                    return -1;
                return (int)ViewState["CurrentIDUtentePromoz"];
            }
            set { ViewState["CurrentIDUtentePromoz"] = value; }
        }

        #endregion

        #region EVENTS
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("UtentePromozioni.aspx");
        }
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["IDUtentePromozione"]))
                {
                    this.CurrentPageState = PageStatus.Inserimento;
                    this.CurrentIDUtentePromoz = 0;
                }
                else
                {
                    this.CurrentIDUtentePromoz = int.Parse(Request.QueryString["IDUtentePromozione"]);
                    this.CurrentPageState = PageStatus.Modifica;
                }
                this.ddlUtenti.Items.Clear();
                List<Utenti> _utenti = base.PerbaffoController.GetUtentiPaging(0, 2000, string.Empty).OrderBy(c => c.EMail).ToList();
                this.ddlUtenti.Items.Clear();
                _utenti.ForEach(item =>
                    {
                        this.ddlUtenti.Items.Add(new ListItem(item.Nome + " " + item.Cognome + " - " + item.EMail, item.ID.ToString()));
                    });
                this.ddlUtenti.Items.Insert(0, new ListItem("Seleziona un utente", ""));
                this.LoadFields();
            }            
        }
        /// <summary>
        /// Salva o aggiorna la notizia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {


            if (this.ddlUtenti.SelectedIndex <= 0 ||
                string.IsNullOrEmpty(this.txtNumeroVolte.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtDataScadenza.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtDescrPromozione.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtMinimoOrdine.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare tutti i campi');", true);
                return;
            }
            if(string.IsNullOrEmpty(this.txtScontoEuro.Text.Trim()) && 
                string.IsNullOrEmpty(this.txtScontoPerc.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare il campo dello sconto');", true);
                return;
            }
            if (this.txtScontoEuro.Text.Trim() == "0.00" &&
                this.txtScontoPerc.Text.Trim() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare il campo dello sconto');", true);
                return;
            }
            try
            {
                UtentiPromozioni _promoz = new UtentiPromozioni()
                {
                    Attiva = this.chkAttivo.Checked,
                    IDUtente = Convert.ToInt32(this.ddlUtenti.SelectedValue),
                    DataScadenza = Convert.ToDateTime(this.txtDataScadenza.Text.Trim()),
                    DescrPromozione = this.txtDescrPromozione.Text.Trim(),
                    NumVolte = Convert.ToInt32(this.txtNumeroVolte.Text.Trim()),
                    MinimoOrdine = Convert.ToDecimal(this.txtMinimoOrdine.Text.Trim().Replace(".", ",")),
                    ScontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ",")),
                    ScontoPercent = Convert.ToInt32(this.txtScontoPerc.Text.Trim())
                };
                if (this.CurrentPageState == PageStatus.Modifica)
                {
                    _promoz.ID = this.CurrentIDUtentePromoz;
                    base.PerbaffoController.UpdateUtentePromozione(_promoz);
                }
                else
                {
                    UtentiPromozioni _not = base.PerbaffoController.SetUtentePromozione(_promoz);
                    this.CurrentIDUtentePromoz = _not.ID;
                    this.CurrentPageState = PageStatus.Modifica;
                }
                this.LoadFields();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante l\\'aggiornamento');", true);
            }
        }
        /// <summary>
        /// Ricarica la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancella_Click(object sender, EventArgs e)
        {

        }
        ///// <summary>
        ///// Elimina il codice
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnElimina_Click(object sender, EventArgs e)
        //{
        //    base.PerbaffoController.DeleteUtentePromozione(this.CurrentIDUtentePromoz);
        //    Response.Redirect("UtentePromozioni.aspx");
        //}

        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica la pagina
        /// </summary>
        private void LoadFields()
        {
            if (this.CurrentPageState == PageStatus.Modifica)
            {
                UtentiPromozioni _codice = base.PerbaffoController.GetUtentePromozioneByID(this.CurrentIDUtentePromoz);
                if (_codice != null)
                {
                    this.ddlUtenti.SelectedValue = _codice.IDUtente.ToString();
                    this.txtDataScadenza.Text = _codice.DataScadenza.ToShortDateString();
                    this.txtDescrPromozione.Text = _codice.DescrPromozione;
                    this.txtMinimoOrdine.Text = _codice.MinimoOrdine.ToString();
                    this.txtScontoEuro.Text = _codice.ScontoEuro.ToString() ?? "0.00";
                    this.txtScontoPerc.Text = _codice.ScontoPercent.ToString() ?? "0";
                    this.chkAttivo.Checked = _codice.Attiva;
                    this.txtNumeroVolte.Text = _codice.NumVolte.ToString();
                    this.lblDataInserimento.Text = _codice.DataInserimento.ToShortDateString();
                }                
            }
        } 
        #endregion
    }
}
