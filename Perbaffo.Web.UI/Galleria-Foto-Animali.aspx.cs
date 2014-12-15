using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Galleria_Foto_Animali : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 24;
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImagesUtenti; } }
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
                this.LoadPhotoGallery();
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
            ((Pager)this.PagerFooter).CurrentPageNumber = e.Number;
            this.PopulateDataSource(e.Number, e.PageSize);

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

            this.rptPhotoGallery.DataSource = this.PerbaffoController.GetFotoAmici(_startRecord, pageSize);
            this.rptPhotoGallery.DataBind();
            
            //Calculates how many pages of a given size are required
            ((Pager)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((Pager)this.PagerFooter).GenerateLinks();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "thumbnailviewer.init();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);


            this.updPnlFoto.Update();
        }
        /// <summary>
        /// Caricamento della galleria
        /// </summary>
        private void LoadPhotoGallery()
        {
           //this.rptPhotoGallery.DataSource = base.PerbaffoController.GetFotoAmici();
           //this.rptPhotoGallery.DataBind();
            this.TotProdotti = this.PerbaffoController.GetCountFotoAmici();
            this.PopulateDataSource(0, MAX_NUMS_ROWS);
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Galleria foto animali";
            this.DescrizionePagina = "Galleria fotografica di immagini inseriti dagli utenti sui loro amici";
            this.KeywordsPagina = "Perbaffo,galleria,foto,animali,amici,iscriviti,effettuati,utenti,foto cani,foto gatti,foto criceti";
        }
        #endregion
    }
}
