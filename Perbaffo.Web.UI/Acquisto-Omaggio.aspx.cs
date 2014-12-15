using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Web.UI.HtmlControls;

namespace Perbaffo.Web.UI
{
    public partial class Acquisto_Omaggio : BasePage, IPerbaffoSite
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
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private int CurrentIDSelectedOmaggio
        {
            get 
            {
                if (ViewState["CurrentIDSelectedOmaggio"] == null)
                    return -1;
                return (int)ViewState["CurrentIDSelectedOmaggio"]; 
            }
            set { ViewState["CurrentIDSelectedOmaggio"] = value; }
        }
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private string CurrentNomeSelectedOmaggio
        {
            get { return ViewState["CurrentNomeSelectedOmaggio"] as string; }
            set { ViewState["CurrentNomeSelectedOmaggio"] = value; }
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
            if (base.UtenteLoggato == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Login-Utente.aspx';", true);
                return;
            }
            if (base.Carrello == null || base.Carrello.Prodotti == null || base.Carrello.Prodotti.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Carrello-Prodotti.aspx';", true);
                return;
            }
            if (base.CurrentOrdine == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Indirizzo_Spedizione.aspx';", true);
                return;
            }
            if (base.CurrentOrdine.DettagliOrdini == null || base.CurrentOrdine.DettagliOrdini.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Pagamenti.aspx';", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                this.lblNomeProdottoSceltoHeader.InnerHtml = (string.IsNullOrEmpty(CurrentNomeSelectedOmaggio)) ? "Nessun omaggio selezionato" : CurrentNomeSelectedOmaggio;
                this.lblNomeProdottoSceltoFooter.InnerHtml = (string.IsNullOrEmpty(CurrentNomeSelectedOmaggio)) ? "Nessun omaggio selezionato" : CurrentNomeSelectedOmaggio;
                this.TotProdotti = this.PerbaffoController.GetCountProdottoOmaggioByRange(base.CurrentOrdine.TotaleParziale);
                this.PopulateDataSource(0, MAX_NUMS_ROWS);
                this.GestioneMetaTag();
            }
        }
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
        /// Continua al riepilogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDSelectedOmaggio <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Seleziona il tuo omaggio!');", true);
                return;
            }
            base.CurrentOrdine.IDProdottoOmaggio = this.CurrentIDSelectedOmaggio;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Riepilogo.aspx';", true);
        }
        /// <summary>
        /// Gestione inserimento prodotto nel carrello/dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptOfferte_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SCEGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                string _valore =((HtmlGenericControl)e.Item.FindControl("lblNomeProdotto")).InnerText;
                this.lblNomeProdottoSceltoHeader.InnerHtml = _valore;
                this.lblNomeProdottoSceltoFooter.InnerHtml = _valore;
                this.CurrentIDSelectedOmaggio = Convert.ToInt32(e.CommandArgument);
                this.CurrentNomeSelectedOmaggio = _valore;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString() + "';", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Acquisto, scelta prodotto omaggio";
            this.DescrizionePagina = "Perbaffo scegli il tuo omaggio, per ogni ordine effettuato hai diritto ad un omaggio";
            this.KeywordsPagina = "Perbaffo,acquisto,omaggio,prodotto,omaggi,acquisti,prodotti";
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

            this.rptOfferte.DataSource = this.PerbaffoController.GetProdottiOmaggioByRange(_startRecord, pageSize, base.CurrentOrdine.TotaleParziale);
            this.rptOfferte.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiOfferta();
            //Calculates how many pages of a given size are required
            ((Pager)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerHeader).GenerateLinks();
            ((Pager)this.PagerFooter).GenerateLinks();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            this.updPnlUtente.Update();
        }
        #endregion
    }
}
