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
    public partial class GestionePagamenti : BasePage
    {
        #region PRIVATE PROPERTY
        private int CurrentIDPagamento 
        {
            get { 
                    if(ViewState["CurrentIDPagamento"] == null)
                        return 0;
                    return (int)ViewState["CurrentIDPagamento"]; 
            }
            set { ViewState["CurrentIDPagamento"] = value; }
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
        /// Salva le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCosto.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtDescrPagamento.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Popolare tutti i campi');", true);
                return;
            }
            else
            {
                TipoPagamento _tipoPagamento = new TipoPagamento()
                {
                    DescrizionePagamento = this.txtDescrPagamento.Text.Trim(),
                    Costo = Convert.ToDecimal(this.txtCosto.Text.Trim()),
                    Attivo = this.chkAttivo.Checked
                };

                if (this.CurrentIDPagamento != 0)
                {
                    ///Update
                    _tipoPagamento.ID = this.CurrentIDPagamento;
                    base.PerbaffoController.UpdateTipoPagamento(_tipoPagamento);
                }
                else
                {
                    ///Inserimento
                    base.PerbaffoController.SetTipoPagamento(_tipoPagamento);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Tipo pagamento salvato');", true);
                this.btnAnnulla_Click(null, null);
                this.LoadFields();
            }

        }
        /// <summary>
        /// Annulla le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.CurrentIDPagamento = 0;
            this.txtCosto.Text = string.Empty;
            this.txtDescrPagamento.Text = string.Empty;
            this.chkAttivo.Checked = false;
            this.grdListaPagamenti.SelectedIndex = -1;
        }
        /// <summary>
        /// Selezione sulla lista dei pagamenti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaPagamenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grdListaPagamenti.SelectedRow == null)
                return;

            GridViewRow _row = grdListaPagamenti.SelectedRow;
            int _idSpedizione = Convert.ToInt32(((Label)_row.Cells[1].Controls[1]).Text);
            if (_idSpedizione == this.CurrentIDPagamento)
            {
                this.grdListaPagamenti.SelectedIndex = -1;
                this.btnAnnulla_Click(null, null);
                return;
            }
            this.CurrentIDPagamento = _idSpedizione;
            this.txtCosto.Text = _row.Cells[3].Text;
            this.txtDescrPagamento.Text = _row.Cells[2].Text;
            this.chkAttivo.Checked = Convert.ToBoolean(_row.Cells[4].Text);

        }
        /// <summary>
        /// Cancella un tipo pagamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDPagamento == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Selezionare il tipo di pagamento che si desidera cancellare!');", true);
                return;
            }
            TipoPagamento _tipoPagamento = new TipoPagamento() {ID = this.CurrentIDPagamento};
            bool _result = base.PerbaffoController.DeleteTipoPagamento(_tipoPagamento);

            if (!_result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Attenzione non è stato possibile cancellare questo tipo pagamento perchè è legato ad un ordine. Disattivalo se desideri che non compaia sul sito!');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Cancellazione tipo pagamento avvenuta con successo!');", true);
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
            this.grdListaPagamenti.DataSource = base.PerbaffoController.GetTipoPagamento();
            this.grdListaPagamenti.DataBind();
        }
        #endregion

    }
}
