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
    public partial class DettaglioCodiciAffiliazione : BasePage
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
        private int CurrentIDCodiceAffiliazione
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
            Response.Redirect("CodiciAffiliazione.aspx");
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
                if (string.IsNullOrEmpty(Request.QueryString["IDCodiceAffiliazione"]))
                {
                    this.CurrentPageState = PageStatus.Inserimento;
                    this.CurrentIDCodiceAffiliazione = 0;
                }
                else
                {
                    this.CurrentIDCodiceAffiliazione = int.Parse(Request.QueryString["IDCodiceAffiliazione"]);
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


            if(string.IsNullOrEmpty(this.txtSito.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtCodiceAffiliazione.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare tutti i campi');", true);
                return;
            }
            if (this.txtCodiceAffiliazione.Text.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Codice affiliazione deve avere almeno 5 caratteri');", true);
                return;
            }

            try
            {
                CodiceAffiliazione _affiliaz = new CodiceAffiliazione()
                {
                    Sito = this.txtSito.Text.Trim(),
                    Codice = this.txtCodiceAffiliazione.Text.Trim().ToUpper()

                };
                if (this.CurrentPageState == PageStatus.Modifica)
                {
                    _affiliaz.ID = this.CurrentIDCodiceAffiliazione;
                    base.PerbaffoController.UpdateCodiceAffiliazione(_affiliaz);
                }
                else
                {
                    CodiceAffiliazione _not = base.PerbaffoController.SetCodiceAffiliazione(_affiliaz);
                    this.CurrentIDCodiceAffiliazione = _not.ID;
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
            if (this.CurrentPageState == PageStatus.Modifica)
            {
                base.PerbaffoController.DeleteCodiceAffiliazione(new CodiceAffiliazione() { ID = this.CurrentIDCodiceAffiliazione });
                this.returnLink_Click(null, null);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Nessun codice affiliazione presente');", true);
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
                CodiceAffiliazione _codice = base.PerbaffoController.GetCodiceAffiliazioneByID(this.CurrentIDCodiceAffiliazione);
                if (_codice != null)
                {
                    this.txtSito.Text = _codice.Sito;
                    this.txtCodiceAffiliazione.Text = _codice.Codice;
                    this.lblDataInserimento.Text = _codice.DataInserimento.ToShortDateString();
                }                
            }
        } 
        #endregion
    }
}
