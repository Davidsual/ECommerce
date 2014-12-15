using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class GestioneUtentiFoto : BasePage
    {
        private const int MAX_NUMS_ROWS = 24;

        #region PUBLIC PROPERTY
        public string CurrentPathFoto
        {
            get { return ConfigurationManager.AppSettings["PATHIMAGEUTENTI"].ToString(); }
        }
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
        /// Cambio della pagina si aggiorna il datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            ((Pager)this.PagerHeader).CurrentPageNumber = e.Number;
            ((Pager)this.PagerFooter).CurrentPageNumber = e.Number;
            this.PopulateDataSource(e.Number, e.PageSize);

        }
        /// <summary>
        /// Caricamento pagine
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
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        /// <summary>
        /// Cancellazione di un immagine nella photogallery
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptPhoto_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandArgument == null || string.IsNullOrEmpty(e.CommandName))
                return;
            int _idImmagine = Convert.ToInt32(e.CommandArgument);            
            Utenti _utenti = new Utenti();
            _utenti.ID = _idImmagine;
            _utenti.ImgFriend = "no-image.jpg";
            _utenti.NomeFriend = null;

            string _nomeImmagine = base.PerbaffoController.GetNomeFotoUtenteByIDUtente(_idImmagine);
            if (!string.IsNullOrEmpty(_nomeImmagine))
                base.FTPDelete("/ImmaginiPerbaffo/Utenti/" + _nomeImmagine);

            base.PerbaffoController.UpdateImmagineUtente(_utenti);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Immagine cancellata');", true);
            this.LoadFields();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento campi
        /// </summary>
        private void LoadFields()
        {
            //this.rptPhoto.DataSource = base.PerbaffoController.GetUtentiConFoto();
            //this.rptPhoto.DataBind();
            this.TotProdotti = base.PerbaffoController.GetUtentiConFoto().Count();
            this.PopulateDataSource(0, MAX_NUMS_ROWS);
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

            this.rptPhoto.DataSource = this.PerbaffoController.GetUtentiConFoto(_startRecord, pageSize);
            this.rptPhoto.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiOfferta();
            //Calculates how many pages of a given size are required
            ((Pager)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((Pager)this.PagerHeader).GenerateLinks();
            ((Pager)this.PagerFooter).GenerateLinks();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "thumbnailviewer.init();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            this.updPnlPhotoGallery.Update();
        }
        #endregion


    }
}
