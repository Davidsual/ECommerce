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
    public partial class GestioneColori : BasePage
    {
        #region PRIVATE MEMBERS
        #endregion

        #region PRIVATE PROPERTY
        #endregion

        #region EVENTS
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
        /// Caricamento Pagina
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
        /// Cancella un colore dalla lista 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaColori_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.IsNullOrEmpty(e.CommandName) || e.CommandArgument == null)
                return;

            bool _result = base.PerbaffoController.DeleteColore(Convert.ToInt32(e.CommandArgument));
            if (!_result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Attenzione il colore non si può cancellare in quanto è legato a qualche prodotto');", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Colore cancellato');", true);
                this.LoadFields();
            }
            return;
        }
        /// <summary>
        /// Cancella un colore dalla lista 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaColori_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            return;
        }
        /// <summary>
        /// Salva un colore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDescrizioneColore.Text.Trim()))
                return;

            base.PerbaffoController.SetColore(this.txtDescrizioneColore.Text.Trim());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Colore salvato');", true);
            this.txtDescrizioneColore.Text = string.Empty;
            this.LoadFields();
        }
        /// <summary>
        /// Annulla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.txtDescrizioneColore.Text = string.Empty;
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica i colori
        /// </summary>
        private void LoadFields()
        {
            this.grdListaColori.DataSource = base.PerbaffoController.GetColori();
            this.grdListaColori.DataBind();
        }
        #endregion


    }
}
