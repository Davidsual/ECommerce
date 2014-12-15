using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;

namespace Perbaffo.Web.UI.Admin
{
    public partial class Notizie : BasePage
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10;
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private int TotNews
        {
            get { return (int)ViewState["TotNews"]; }
            set { ViewState["TotNews"] = value; }
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
                this.TotNews = this.PerbaffoController.GetCountNewsByFilter(string.Empty);
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
        /// Seleziona sulla lista dei prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _param = "?IDNotizia=" + e.CommandArgument;
            ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.DettaglioNotizia, _param);
            return;
        }
        /// <summary>
        /// Seleziona sulla lista dei prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowEditing(object sender, GridViewEditEventArgs e)
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
            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;
            this.grdListProdotti.DataSource = this.PerbaffoController.GetNewsByFilter(_startRecord, pageSize, this.txtCodiceDescrizione.Text.Trim());
            this.grdListProdotti.DataBind();
            this.TotNews = this.PerbaffoController.GetCountNewsByFilter(this.txtCodiceDescrizione.Text.Trim());
            //Calculates how many pages of a given size are required
            ((Pager)this.Pager).TotalPages =
                 (this.TotNews / pageSize) + (this.TotNews % pageSize > 0 ? 1 : 0);

            ((Pager)this.Pager).GenerateLinks();
            this.updPnlListProdotti.Update();
        }
        #endregion

    }
}
