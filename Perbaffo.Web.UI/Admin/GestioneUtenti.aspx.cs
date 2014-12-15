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
    public partial class GestioneUtenti : BasePage
    {
        private const int MAX_NUMS_ROWS = 10;

        #region PRIVATE PROPERTY
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private int TotUtenti
        {
            get { return (int)ViewState["TotUtenti"]; }
            set { ViewState["TotUtenti"] = value; }
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
                this.TotUtenti = this.PerbaffoController.GetCountUtenti(string.Empty);
                this.PopulateDataSource(0, MAX_NUMS_ROWS);
            }

        }
        /// <summary>
        /// Cambio della pagina si aggiorna il datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            this.PopulateDataSource(e.Number, e.PageSize);
        }
        /// <summary>
        /// Ricerca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.PopulateDataSource(0, MAX_NUMS_ROWS);
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
        /// Selezione sulla griglia degli utenti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListUtenti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _param = "?IDUtente=" + e.CommandArgument;
            ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.GestioneUtente, _param);
            return;
        }
        /// <summary>
        /// Selezione sulla griglia degli utenti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListUtenti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica la griglia
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void PopulateDataSource(int page, int pageSize)
        {
            try
            {
                // This bit is purely to have some data. usually this
                // would be from a database/XML file etc.

                //Set the repeater with a "page" of data
                page = (page == 0) ? 0 : page - 1;
                int _startRecord = (page == 0) ? 0 : page * pageSize;
                this.grdListUtenti.DataSource = this.PerbaffoController.GetUtentiPaging(_startRecord, pageSize, this.txtUtente.Text.Trim());
                this.grdListUtenti.DataBind();
                //Calculates how many pages of a given size are required
                this.TotUtenti = this.PerbaffoController.GetCountUtenti(this.txtUtente.Text.Trim());
                ((Pager)this.Pager).TotalPages =
                     (this.TotUtenti / pageSize) + (this.TotUtenti % pageSize > 0 ? 1 : 0);

                ((Pager)this.Pager).GenerateLinks();
                this.updPnlListProdotti.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
