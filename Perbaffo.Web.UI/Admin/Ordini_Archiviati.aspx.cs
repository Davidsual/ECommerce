using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class Ordini_Archiviati : BasePage
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10;
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private int TotOrdini
        {
            get { return (int)ViewState["TotOrdini"]; }
            set { ViewState["TotOrdini"] = value; }
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
        /// Creazione della riga di dettaglio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = Color.FromName("#D6DFF7");

                HtmlGenericControl _stato = e.Row.FindControl("lblStato") as HtmlGenericControl;
                if (_stato != null && e.Row.DataItem != null)
                {
                    _stato.InnerText = base.PerbaffoController.GetDescrStatoByIDStato(((Perbaffo.Presenter.Model.Ordini)e.Row.DataItem).IDStatoOrdine);
                }
                Label _lblUtente = e.Row.FindControl("lblUtente") as Label;
                if (_lblUtente != null && e.Row.DataItem != null)
                {
                    Utenti _utente = base.PerbaffoController.GetUtenteByID(((Perbaffo.Presenter.Model.Ordini)e.Row.DataItem).IDUtente);
                    if (_utente != null)
                        _lblUtente.Text = _utente.Cognome + " " + _utente.Nome;
                }
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
            string _param = "?PaginaProdotto=" + ((Pager)this.Pager).CurrentPageNumber.ToString() + "&READONLY=YES&IDOrdine=" + e.CommandArgument.ToString();
            ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.DettaglioOrdine, _param);
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
            int _stato = 5;
            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;
            this.grdListProdotti.DataSource = this.PerbaffoController.GetOrdiniByStato(_startRecord, pageSize, _stato);
            this.grdListProdotti.DataBind();
            this.TotOrdini = this.PerbaffoController.GetCountOrdiniByStato(_stato);
            //Calculates how many pages of a given size are required
            ((Pager)this.Pager).TotalPages =
                 (this.TotOrdini / pageSize) + (this.TotOrdini % pageSize > 0 ? 1 : 0);

            ((Pager)this.Pager).GenerateLinks();
            this.updPnlListProdotti.Update();
        }
        #endregion

    }
}
