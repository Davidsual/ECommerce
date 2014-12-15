using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Presenter;
using Perbaffo.Web.UI.Admin.Classes;
using System.Collections;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class ProdottiNonAttivi : BasePage
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10; 
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private int TotProdotti
        {
            get { return (int)ViewState["TotProdotti"]; }
            set { ViewState["TotProdotti"] = value; }
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
                this.TotProdotti = this.PerbaffoController.GetCountProdotti(false);
                if (!string.IsNullOrEmpty(Request.QueryString["Pagina"]))
                {
                    int _pagina = Convert.ToInt32(Request.QueryString["Pagina"]);
                    ((Pager)this.Pager).CurrentPageNumber = _pagina;
                    this.PopulateDataSource(_pagina, MAX_NUMS_ROWS);
                }
                else
                    this.PopulateDataSource(0, MAX_NUMS_ROWS);
            }
        }
        /// <summary>
        /// Separatore all'interno della combo
        /// </summary>
        /// <param name="Level"></param>
        /// <returns></returns>
        private string GetSeparator(int Level)
        {
            string _valore = string.Empty;
            for (int i = 0; i < Level; i++)
            {
                _valore += "-";
            }
            return _valore;
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
            string _param = "?PaginaProdotto=" + ((Pager)this.Pager).CurrentPageNumber.ToString() + "&IDProdotto=" + e.CommandArgument;
            ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.DettaglioProdotto, _param);
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
            this.grdListProdotti.DataSource = this.PerbaffoController.GetProdottiByIsAttivo(false, _startRecord, pageSize);
            this.grdListProdotti.DataBind();
            this.TotProdotti = this.PerbaffoController.GetCountProdotti(false);
            //Calculates how many pages of a given size are required
            ((Pager)this.Pager).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((Pager)this.Pager).GenerateLinks();
            this.updPnlListProdotti.Update();
        }
        #endregion
    }
}
