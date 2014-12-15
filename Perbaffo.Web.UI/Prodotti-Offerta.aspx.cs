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
    public partial class Prodotti_Offerta : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10;
        private const string ORDINAMENT_NOME = "NOME";
        private const string ORDINAMENT_PREZZO = "PREZZO";
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
        /// Ordinamento
        /// </summary>
        private Perbaffo.Presenter.ControllerPresentation.OrderType CurrentOrdinamento
        {
            get
            {
                if (Session["CurrentOrdinamento"] == null)
                    return Perbaffo.Presenter.ControllerPresentation.OrderType.Nome;
                return (Perbaffo.Presenter.ControllerPresentation.OrderType)Session["CurrentOrdinamento"];
            }
            set { Session["CurrentOrdinamento"] = value; }
        }
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
                this.TotProdotti = this.PerbaffoController.GetCountProdottiOfferta();
                if (string.IsNullOrEmpty(Request.QueryString["Page"]))
                {
                    this.PopulateDataSource(0, MAX_NUMS_ROWS);
                }
                else
                {
                    int _page = 0;
                    if (int.TryParse(Request.QueryString["Page"], out _page))
                    {
                        this.PopulateDataSource(_page, MAX_NUMS_ROWS);
                    }
                    else
                        this.PopulateDataSource(0, MAX_NUMS_ROWS);
                }   
                
                
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Selezione ordinamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlOrdinamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlOrdinamento.SelectedValue == ORDINAMENT_NOME)
                this.CurrentOrdinamento = Perbaffo.Presenter.ControllerPresentation.OrderType.Nome;
            else if (this.ddlOrdinamento.SelectedValue == ORDINAMENT_PREZZO)
                this.CurrentOrdinamento = Perbaffo.Presenter.ControllerPresentation.OrderType.Prezzo;
            else
                this.CurrentOrdinamento = Perbaffo.Presenter.ControllerPresentation.OrderType.Nome;
            ((PagerFull)this.PagerHeader).CurrentPageNumber = 1;
            ((PagerFull)this.PagerFooter).CurrentPageNumber = 1;
            this.PopulateDataSource(0, MAX_NUMS_ROWS);
        }
        /// <summary>
        /// Cambio della pagina si aggiorna il datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_Changed(object sender, PagerFullEventArgs e)
        {
            ((PagerFull)this.PagerHeader).CurrentPageNumber = e.Number;
            ((PagerFull)this.PagerFooter).CurrentPageNumber = e.Number;
            this.PopulateDataSource(e.Number, e.PageSize);
        }
        /// <summary>
        /// Creazione di una riga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptOfferte_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    ProdottoImmagine _prod = e.Item.DataItem as ProdottoImmagine;
                    List<ProdottiTaglie> _taglie = base.PerbaffoController.GetProdottiTaglieByIDProdotto(_prod.ID);
                    if (_taglie != null && _taglie.Count > 0)
                    {
                        ((Repeater)e.Item.Controls[2]).DataSource = _taglie;
                        ((Repeater)e.Item.Controls[2]).DataBind();
                    }
                }
            }
        }
        /// <summary>
        /// Gestione inserimento prodotto nel carrello/dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptOfferte_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DETTAGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"red","self.location.href = 'Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString() + "';",true);
            }
            if (e.CommandName == "ACQUISTA" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                try
                {
                    int _result = -1;
                    if (int.TryParse(e.CommandArgument.ToString(), out _result))
                    {
                        ///Aggiungo il prodotto al carrello
                        base.AggiungiProdottoCarrello(_result, -1, -1);
                        ///Aggiorno il widget
                        this.usrCarrello.AggiornaProdottiCarrello();
                        ///Segnala all'utente che il prodotto è nel carrello
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Prodotto inserito nel carrello!');", true);
                    }
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante l\\'inseriemnto del prodotto nel carrello!');", true);
                }
            }
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
            if (valore.Length > 250)
                return valore.Substring(0, 240) + "...";
            return valore;
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Prodotti in offerta su Perbaffo";
            DescrizionePagina = "Perbaffo tutti i prodotti per animali in offerta su Perbaffo";
            KeywordsPagina = "Perbaffo,novità,prodotti,offerta,sconto,cani,gatti,volatili,roditori,acquariologia,categorie,prezzo,omaggio";
        }
        /// <summary>
        /// Carica la griglia
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void PopulateDataSource(int page, int pageSize)
        {
            if (((page - 1) * pageSize) > this.TotProdotti)
                page = 0;

            ((PagerFull)this.PagerHeader).CurrentPageNumber = (page == 0) ? 1 : page;
            ((PagerFull)this.PagerFooter).CurrentPageNumber = (page == 0) ? 1 : page;

            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;

            this.rptOfferte.DataSource = this.PerbaffoController.GetProdottiOfferta(_startRecord, pageSize, this.CurrentOrdinamento);
            this.rptOfferte.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiOfferta();
            //Calculates how many pages of a given size are required
            ((PagerFull)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((PagerFull)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((PagerFull)this.PagerHeader).GenerateLinks();
            ((PagerFull)this.PagerFooter).GenerateLinks();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            //this.updPnlOfferta.Update();
        }
        #endregion
    }
}
