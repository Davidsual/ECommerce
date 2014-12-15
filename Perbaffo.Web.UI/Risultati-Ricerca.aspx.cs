using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Net;
using Perbaffo.Presenter.Model;
using System.Runtime.Remoting.Messaging;

namespace Perbaffo.Web.UI
{
    public partial class Risultati_Ricerca : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 20; 
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
        /// Filtro di ricerca
        /// </summary>
        private string SearchFilter
        {
            get
            {
                return ViewState["SearchFilter"] as string;
            }
            set { ViewState["SearchFilter"] = value; }
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
            if(!Page.IsPostBack)
            {
                string _value = Request.Form["MenuPerbaffo$txtCerca"];
                if (!string.IsNullOrEmpty(_value))
                    this.SearchFilter = _value.Trim();
                else
                    this.SearchFilter = string.Empty;
                this.RicercaProdotti();
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
        /// Aggiunta delle eventuali taglie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dtlRisultati_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    ProdottoImmagine _prod = e.Item.DataItem as ProdottoImmagine;
                    List<ProdottiTaglie> _taglie = base.PerbaffoController.GetProdottiTaglieByIDProdotto(_prod.ID);
                    if (_taglie != null && _taglie.Count > 0)
                    {
                        ((Repeater)e.Item.Controls[1]).DataSource = _taglie;
                        ((Repeater)e.Item.Controls[1]).DataBind();
                    }
                }
            }
        }
        /// <summary>
        /// Gestione inserimento prodotto nel carrello/dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dtlRisultati_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DETTAGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString() + "';", true);
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
        /// <summary>
        /// Ricerca all'interno della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            if (this.txtCercaProdotto.Text.Trim().Length <= 0)
                return;
            this.SearchFilter = this.txtCercaProdotto.Text.Trim();
            this.RicercaProdotti();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Ricerca dei prodotti in base alla categoria scelta
        /// </summary>
        private void RicercaProdotti()
        {
            this.TotProdotti = this.PerbaffoController.GetCountProdottiByDescription(this.SearchFilter);
            this.PopulateDataSource(0, MAX_NUMS_ROWS);

            ///Aggiungo le categorie
            List<Categorie> _categ = base.PerbaffoController.FindAdvancedCategorieByDescription(this.SearchFilter);
            if (_categ == null || _categ.Count <= 0 || _categ.Count > 30)
                this.tblCategorie.Visible = false;
            else
            {
                this.tblCategorie.Visible = true;
                this.rptSearchCategorie.DataSource = _categ;
                this.rptSearchCategorie.DataBind();
            }
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - risultati della ricerca";
            KeywordsPagina = "Pet shop,ricerca,risultati,prodotti,categorie,articoli,ricerche,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Perbaffo Risultati della ricerca dei prodotti";
        }
        /// <summary>
        /// Nasconde o visualizza la tabella con prezzo in offerta oppure no
        /// </summary>
        /// <param name="_prezzo1"></param>
        /// <param name="_prezzo2"></param>
        /// <returns></returns>
        public string IsOfferta(decimal _prezzo1, decimal _prezzo2)
        {
            if (_prezzo1 == _prezzo2)
                return "none";
            else
                return "block";

        }
        /// <summary>
        /// visualizza o meno la tabella del prezzo singolo
        /// </summary>
        /// <param name="_prezzo1"></param>
        /// <param name="_prezzo2"></param>
        /// <returns></returns>
        public string IsNotOfferta(decimal _prezzo1, decimal _prezzo2)
        {
            if (_prezzo1 == _prezzo2)
                return "block";
            else
                return "none";

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
            this.lblProdottoRicercato.InnerText = this.SearchFilter;
            if (this.TotProdotti == 0)
                this.tblNessuno.Visible = true;
            else
                this.tblNessuno.Visible = false;
            this.dtlRisultati.DataSource = this.PerbaffoController.FindProdottiByDescription(_startRecord, pageSize, this.SearchFilter);
            this.dtlRisultati.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiByDescription(SearchFilter);
            //Calculates how many pages of a given size are required
            ((Pager)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerHeader).GenerateLinks();
            ((Pager)this.PagerFooter).GenerateLinks();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            this.updPnlProdotti.Update();
        }
        #endregion

    }
}
