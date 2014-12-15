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
    public partial class DettaglioCodiciPromozioni : BasePage
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
        private int CurrentIDCodicePromoz
        {
            get
            {
                if (ViewState["CurrentIDCodicePromoz"] == null)
                    return -1;
                return (int)ViewState["CurrentIDCodicePromoz"];
            }
            set { ViewState["CurrentIDCodicePromoz"] = value; }
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
            Response.Redirect("CodiciPromozioni.aspx");
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
                if (string.IsNullOrEmpty(Request.QueryString["IDCodicePromozione"]))
                {
                    this.CurrentPageState = PageStatus.Inserimento;
                    this.CurrentIDCodicePromoz = 0;
                }
                else
                {
                    this.CurrentIDCodicePromoz = int.Parse(Request.QueryString["IDCodicePromozione"]);
                    this.CurrentPageState = PageStatus.Modifica;
                }
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


            if (string.IsNullOrEmpty(this.txtCodicePromozione.Text.Trim()) ||
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
            //if (this.txtScontoEuro.Text.Trim() == "0.00" &&
            //    this.txtScontoPerc.Text.Trim() == "0")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare il campo dello sconto');", true);
            //    return;
            //}
            try
            {
                CodicePromozioni _promoz = new CodicePromozioni()
                {
                    Attiva = this.chkAttivo.Checked,
                    CodiceSconto = this.txtCodicePromozione.Text.Trim().ToUpper(),
                    DataScadenza = Convert.ToDateTime(this.txtDataScadenza.Text.Trim()),
                    DescrPromozione = this.txtDescrPromozione.Text.Trim(),
                    MinimoOrdine = Convert.ToDecimal(this.txtMinimoOrdine.Text.Trim().Replace(".", ",")),
                    ScontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ",")),
                    ScontoPercent = Convert.ToInt32(this.txtScontoPerc.Text.Trim())
                };
                if (this.CurrentPageState == PageStatus.Modifica)
                {
                    _promoz.ID = this.CurrentIDCodicePromoz;
                    base.PerbaffoController.UpdateCodicePromozione(_promoz);
                }
                else
                {
                    CodicePromozioni _not = base.PerbaffoController.SetCodicePromozione(_promoz);
                    this.CurrentIDCodicePromoz = _not.ID;
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
        //    base.PerbaffoController.DeleteCodicePromozione(this.CurrentIDCodicePromoz);
        //    Response.Redirect("CodiciPromozioni.aspx");
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
                CodicePromozioni _codice = base.PerbaffoController.GetCodicePromozioneByID(this.CurrentIDCodicePromoz);
                if (_codice != null)
                {
                    this.txtCodicePromozione.Text = _codice.CodiceSconto;
                    this.txtDataScadenza.Text = _codice.DataScadenza.ToShortDateString();
                    this.txtDescrPromozione.Text = _codice.DescrPromozione;
                    this.txtMinimoOrdine.Text = _codice.MinimoOrdine.ToString();
                    this.txtScontoEuro.Text = _codice.ScontoEuro.ToString() ?? "0.00";
                    this.txtScontoPerc.Text = _codice.ScontoPercent.ToString() ?? "0";
                    this.chkAttivo.Checked = _codice.Attiva;
                    this.lblDataInserimento.Text = _codice.DataInserimento.ToShortDateString();
                }                
            }
        } 
        #endregion
    }
}
