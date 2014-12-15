using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class Prodotti_Omaggio : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10;
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
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
        /// Carica pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.TotProdotti = this.PerbaffoController.GetCountProdottiOmaggio();
                this.PopulateDataSource(0, MAX_NUMS_ROWS);
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Cambio della pagina si aggiorna il datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            ((Pager)this.PagerHeader).CurrentPageNumber = e.Number;
            ((Pager)this.PagerFooter).CurrentPageNumber = e.Number;
            this.PopulateDataSource(e.Number, MAX_NUMS_ROWS);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Taglia la string se troppo grande
        /// </summary>
        /// <param name="valore"></param>
        /// <returns></returns>
        public string TagliaStringa(string valore)
        {
            if (string.IsNullOrEmpty(valore))
                return valore;
            if (valore.Length > 200)
                return valore.Substring(0, 190) + "...";
            return valore;
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Prodotti e accessori per animali in omaggio";
            DescrizionePagina = "Per ogni ordine fatto su Perbaffo hai diritto ad un omaggio, qui ci sono elencati i prodotti che possono essere scelti come omaggio";
            KeywordsPagina = "Perbaffo,prodotti,omaggio,categoria,ordine,minimo,costo,cani,gatti,volatili,roditori,prodotto,acquariologia,terrari,partire";
        }
        /// <summary>
        /// Carica la griglia
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void PopulateDataSource(int page, int pageSize)
        {
            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;

            this.rptOmaggio.DataSource = this.PerbaffoController.GetProdottiOmaggio(_startRecord, pageSize);
            this.rptOmaggio.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiOmaggio();
            //Calculates how many pages of a given size are required
            ((Pager)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerHeader).GenerateLinks();
            ((Pager)this.PagerFooter).GenerateLinks();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            this.updPnlOmaggio.Update();
        }
        #endregion

    }
}
