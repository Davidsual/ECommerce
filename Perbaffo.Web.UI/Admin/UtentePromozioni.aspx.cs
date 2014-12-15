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
    public partial class UtentePromozioni : BasePage
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 20;
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
        /// <summary>
        /// List prodotti novita
        /// </summary>
        private List<Offerte> ProdottiOfferta
        {
            get { return (List<Offerte>)ViewState["ProdottiOfferta"]; }
            set { ViewState["ProdottiOfferta"] = value; }
        }
        #endregion

        #region EVENTS
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
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.TotProdotti = this.PerbaffoController.GetCountUtentiPromozioni();
                this.PopulateDataSource(0, MAX_NUMS_ROWS);
            }
        }
        /// <summary>
        /// Inserisco il nome dell'utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton _lblDescr = e.Row.FindControl("lnlDescr") as LinkButton;
                if (_lblDescr != null && e.Row.DataItem != null)
                {
                    Utenti _utente = base.PerbaffoController.GetUtenteByID(((UtentiPromozioni)e.Row.DataItem).IDUtente);
                    if (_utente != null)
                    {
                        _lblDescr.Text = _utente.EMail;
                    }
                }
            }
        }
        /// <summary>
        /// Seleziona all'interno della griglia dei prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _idUtentePromoz = e.CommandArgument.ToString();
            if (!string.IsNullOrEmpty(_idUtentePromoz))
            {
                string _param = "?IDUtentePromozione=" + _idUtentePromoz;
                ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.UtentePromozione, _param);
                return;
            }
        }
        /// <summary>
        /// Seleziona all'interno della griglia dei prodotti
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
            // This bit is purely to have some data. usually this
            // would be from a database/XML file etc.

            //Set the repeater with a "page" of data
            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;
            this.grdListProdotti.DataSource = this.PerbaffoController.GetUtentiPromozioni(_startRecord, pageSize);
            this.grdListProdotti.DataBind();
            //Calculates how many pages of a given size are required
            ((Pager)this.Pager).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((Pager)this.Pager).GenerateLinks();
            this.updPnlListProdotti.Update();
        }
        #endregion

    }
}
