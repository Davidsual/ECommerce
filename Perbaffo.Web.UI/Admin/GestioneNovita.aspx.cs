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
    /// <summary>
    /// GESTIONE DEI PRODOTTI NELLE NOVITA
    /// </summary>
    public partial class GestioneNovita : BasePage
    {
        #region PRIVATE MEMBERS
        #endregion
        
        #region PRIVATE PROPERTY
        #endregion

        #region EVENT
        /// <summary>
        /// Selezione sulla griglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _idProdotto = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(_idProdotto))
            {
                string _param = "?IDProdotto=" + _idProdotto;
                ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.DettaglioProdotto, _param);
                return;
            }
        }
        /// <summary>
        /// Selezione sulla griglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
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
                this.grdListProdotti.DataSource = base.PerbaffoController.GetProdottiNovita(true);
                this.grdListProdotti.DataBind();
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
        #endregion
    }
}
