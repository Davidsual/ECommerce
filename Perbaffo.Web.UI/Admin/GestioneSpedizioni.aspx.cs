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
    public partial class GestioneSpedizioni : BasePage
    {
        #region PRIVATE PROPERTY
        private int CurrentIDSpedizione
        {
            get
            {
                if (ViewState["CurrentIDSpedizione"] == null)
                    return 0;
                return (int)ViewState["CurrentIDSpedizione"];
            }
            set { ViewState["CurrentIDSpedizione"] = value; }
        }
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
                this.LoadFields();
            }
        }
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        /// <summary>
        /// selezione di una spedizione sulla griglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaSpedizione_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdListaSpedizione.SelectedRow == null)
            {
                return;
            }
            GridViewRow _row = grdListaSpedizione.SelectedRow;
            int _idSpedizione = Convert.ToInt32(((Label)_row.Cells[1].Controls[1]).Text);
            if(_idSpedizione == this.CurrentIDSpedizione)
            {
                this.grdListaSpedizione.SelectedIndex = -1;
                this.btnAnnulla_Click(null,null);
                return;
            }

            this.CurrentIDSpedizione = _idSpedizione;
            TipoSpedizioni _sped = base.PerbaffoController.GetTipoSpedizioneByID(this.CurrentIDSpedizione);
            this.txtCosto.Text = _sped.CostoSpedizione.ToString();
            this.txtDescrSpedizione.Text = _sped.DescrBreveSpedizione;
            this.txtDescrSpedizioneLunga.Text = _sped.DescrSpedizione;
            this.chkAttivo.Checked = _sped.Attivo;
        }
        /// <summary>
        /// Salvataggio di una spedizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCosto.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtDescrSpedizione.Text.Trim()) ||
                    string.IsNullOrEmpty(this.txtDescrSpedizioneLunga.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Popolare tutti i campi');", true);
                return;
            }
            else
            {
                TipoSpedizioni _tipoSpedizione = new TipoSpedizioni()
                {
                    DescrSpedizione = this.txtDescrSpedizioneLunga.Text.Trim(),
                    DescrBreveSpedizione = this.txtDescrSpedizione.Text.Trim(),
                    CostoSpedizione = Convert.ToDecimal(this.txtCosto.Text.Trim()),
                    Attivo = this.chkAttivo.Checked
                };

                if (this.CurrentIDSpedizione != 0)
                {
                    ///Update
                    _tipoSpedizione.ID = this.CurrentIDSpedizione;
                    base.PerbaffoController.UpdateTipoSpedizione(_tipoSpedizione);
                }
                else
                {
                    ///Inserimento
                    base.PerbaffoController.SetTipoSpedizione(_tipoSpedizione);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Tipo spedizione salvato');", true);
                this.btnAnnulla_Click(null, null);
                this.LoadFields();
            }
        }
        /// <summary>
        /// Annullamento di una spedizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.CurrentIDSpedizione = 0;
            this.grdListaSpedizione.SelectedIndex = -1;
            this.txtCosto.Text = "0,00";
            this.txtDescrSpedizione.Text = string.Empty;
            this.txtDescrSpedizioneLunga.Text = string.Empty;
            this.chkAttivo.Checked = false;
        }
        /// <summary>
        /// Cancellazione di un tipo di spedizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDSpedizione == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Selezionare il tipo di spedizione che si desidera cancellare!');", true);
                return;
            }
            TipoSpedizioni _tipoSpedizione = new TipoSpedizioni() { ID = this.CurrentIDSpedizione };
            bool _result = base.PerbaffoController.DeleteTipoSpedizione(_tipoSpedizione);

            if (!_result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Attenzione non è stato possibile cancellare questo tipo spedizione perchè è legato ad un ordine. Disattivalo se desideri che non compaia sul sito!');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Cancellazione tipo spedizione avvenuta con successo!');", true);
                this.btnAnnulla_Click(null, null);
                this.LoadFields();
            }
        }
        #endregion  

        #region PRIVATE METHODS
        /// <summary>
        /// Carica i colori
        /// </summary>
        private void LoadFields()
        {
            this.grdListaSpedizione.DataSource = base.PerbaffoController.GetTipoSpedizione();
            this.grdListaSpedizione.DataBind();
        }
        #endregion
    }
}
