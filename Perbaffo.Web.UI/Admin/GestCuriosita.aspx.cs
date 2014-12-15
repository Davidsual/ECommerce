using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;

namespace Perbaffo.Web.UI.Admin
{
    public partial class GestCuriosita : BasePage
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10; 
        private const string CATEGORIA_CANI = "DOG";
        private const string CATEGORIA_GATTI = "CAT";
        private const string CATEGORIA_RODITORI = "RABBIT";
        private const string CATEGORIA_VOLATILI = "BIRD";
        private const string CATEGORIA_PESCI = "FISH"; 
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
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ddlCategorie.Items.Clear();
                this.ddlCategorie.Items.Add(new ListItem("Cani", CATEGORIA_CANI));
                this.ddlCategorie.Items.Add(new ListItem("Gatti", CATEGORIA_GATTI));
                this.ddlCategorie.Items.Add(new ListItem("Roditori", CATEGORIA_RODITORI));
                this.ddlCategorie.Items.Add(new ListItem("Volatili", CATEGORIA_VOLATILI));
                this.ddlCategorie.Items.Add(new ListItem("Pesci", CATEGORIA_PESCI));

               // this.TotProdotti = this.PerbaffoController.GetCountCuriositaByCategoria(CATEGORIA_CANI);
                PopulateDataSource(0, MAX_NUMS_ROWS);
            }
        }
        /// <summary>
        /// Richiesta di visionare un dettaglio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _idCuriosita = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(_idCuriosita))
            {
                string _param = "?IDCuriosita=" + _idCuriosita;
                ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.DettaglioCuriosita, _param);
                return;
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
        /// Selezione sulla griglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
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
        /// Selezione sulla combo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDataSource(0, MAX_NUMS_ROWS);
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
            this.grdCuriosita.DataSource = this.PerbaffoController.GetCuriositaByCategoria(this.ddlCategorie.SelectedValue, _startRecord, pageSize);
            this.grdCuriosita.DataBind();
            this.TotProdotti = this.PerbaffoController.GetCountCuriositaByCategoria(this.ddlCategorie.SelectedValue);
            //Calculates how many pages of a given size are required
            ((Pager)this.Pager).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((Pager)this.Pager).GenerateLinks();
            this.updPnlCuriosita.Update();
        }
        #endregion
    }
}
