using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace Perbaffo.Web.UI
{
    public partial class Prodotti_Images : BasePage, IPerbaffoSite
    {
        #region PUBLIC PROPERTY

        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }

        #endregion

        #region PRIVATE MEMBERS
        private List<ProdottoImmagine> _listProdotti = null;
        private const int DEFAULT_CATEGORIA = 0;
        private const string CATEGORIA_CANI = "CANI";
        private const string CATEGORIA_GATTI = "GATTI";
        private const string CATEGORIA_RODITORI = "RODITORI";
        private const string CATEGORIA_VOLATILI = "VOLATILI";
        private const string CATEGORIA_ACQUARIOLOGIA = "ACQUARIOLOGIA";
        private const string CATEGORIA_RETTILI = "RETTILI";
		private enum Tipologia
        {
            Cani,
            Gatti,
            Roditori,
            Volatili,
            Acquariologia,
            Rettili
        }
	    #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Current tipologia
        /// </summary>
        private Tipologia CurrentTipologia
        {
            get
            {
                if (ViewState["CurrentTipologia"] == null)
                    ViewState["CurrentTipologia"] = Tipologia.Cani;
                return (Tipologia)ViewState["CurrentTipologia"];
            }
            set
            {
                ViewState["CurrentTipologia"] = value;
            }
        }
        /// <summary>
        /// Categoria sceta
        /// </summary>
        private int CurrentCategoria
        {
            get
            {
                if (ViewState["CurrentCategoria"] == null)
                    ViewState["CurrentCategoria"] = DEFAULT_CATEGORIA;
                return (int)ViewState["CurrentCategoria"];
            }
            set
            {
                ViewState["CurrentCategoria"] = value;
            }
        }
        /// <summary>
        /// Current Page Number
        /// </summary>
        private int CurrentPageNumber
        {
            get
            {
                if (ViewState["CurrentPageNumber"] == null)
                    ViewState["CurrentPageNumber"] = 1;
                return (int)ViewState["CurrentPageNumber"];
            }
            set
            {
                ViewState["CurrentPageNumber"] = value;
            }
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
            ///1) leggo il queryString
            ///2) carico le categorie e le foto
            ///3) Tutto in querystring Tipologia/Categoria/Pagina
            if (string.IsNullOrEmpty(Request.QueryString["Animali"]) && 
                string.IsNullOrEmpty(Request.QueryString["Categoria"]) && 
                string.IsNullOrEmpty(Request.QueryString["PAGINA"]))
            {
                ///Prima volta
                this.CurrentTipologia = Tipologia.Cani;
                this.CurrentCategoria = DEFAULT_CATEGORIA;
                this.CurrentPageNumber = 1;
            }
            else
            {
                this.CheckPostbackType();
            }
            ///Carico tutto
            this.LoadFields();
            ///Controllo che se la categoria è = a quella di default allora metto l'immagine
            if (this.CurrentCategoria == DEFAULT_CATEGORIA)
            {
                this.tdShowImageCategory.Style.Add("background-image", "url('images/Ricerca-per-immagine.gif')");
                this.tdShowImageCategory.Style.Add("background-repeat","no-repeat");
                this.tdShowImageCategory.Style.Add("background-position","center");
            }


            ///add metatag
            this.GestioneMetaTag();
        }
        /// <summary>
        /// Bind delle immagini
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptImmaginiProdotti_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Repeater _repeater = e.Item.FindControl("rptImmagine") as Repeater;
                int _value = Convert.ToInt32(e.Item.DataItem);
                _repeater.DataSource = _listProdotti.Skip(_value*5).Take(5);
                _repeater.DataBind();
            }
        }
        /// <summary>
        /// Singola immagine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptImmagine_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlImage _image = e.Item.FindControl("imgProdotto") as HtmlImage;
                Label _descr = e.Item.FindControl("lblDescrProdotto") as Label;
                HtmlAnchor _link = e.Item.FindControl("lnkProdotto") as HtmlAnchor;
                _image.Src = "http://www.perbaffo.it/ImmaginiPerbaffo/" + (e.Item.DataItem as ProdottoImmagine).UrlImmagine;
                _image.Alt = (e.Item.DataItem as ProdottoImmagine).DescrImmagine;
                _image.Attributes.Add("title", (e.Item.DataItem as ProdottoImmagine).DescrImmagine);
                _descr.Text = (e.Item.DataItem as ProdottoImmagine).Nome +  "<br/>€ " + Convert.ToDecimal((e.Item.DataItem as ProdottoImmagine).Totale).ToString();
                _link.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + (e.Item.DataItem as ProdottoImmagine).ID.ToString();
                _link.Title = (e.Item.DataItem as ProdottoImmagine).DescrImmagine;
            }
        }
        /// <summary>
        /// Caricamento Lista categorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptMenuCategorie_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Categorie _categoria = e.Item.DataItem as Categorie;
                HtmlAnchor _link = e.Item.FindControl("lnkCategoria") as HtmlAnchor;
                if (this.CurrentCategoria == _categoria.ID)
                {
                    _link.HRef = "javascript:void(0);";
                    _link.Attributes.Add("style", "color:black;");
                    lblTitoloCategoria.InnerText = _categoria.DescrizioneBreve;
                    this.DescrizionePagina = _categoria.DescrizioneEstesa;
                }
                else
                {
                    string _tipo = string.Empty;
                    switch (this.CurrentTipologia)
                    {
                        case Tipologia.Cani:
                            _tipo = "Cani";
                            break;
                        case Tipologia.Gatti:
                            _tipo = "Gatti";
                            break;
                        case Tipologia.Roditori:
                            _tipo = "Roditori";
                            break;
                        case Tipologia.Volatili:
                            _tipo = "Volatili";
                            break;
                        case Tipologia.Acquariologia:
                            _tipo = "Acquariologia";
                            break;
                        case Tipologia.Rettili:
                            _tipo = "Rettili";
                            break;
                        default:
                            break;
                    }
                    _link.HRef = "Prodotti-Images.aspx?Animali=" + _tipo + "&amp;Categoria=" + _categoria.ID.ToString() + "&amp;Articoli=" + _categoria.DescrizioneBreve.ToUpper(CultureInfo.InvariantCulture).Replace(",", "").Replace("-", "").Replace(" ", "-").ToLower();
                }
                _link.Title = _categoria.DescrizioneEstesa;
                _link.InnerText = _categoria.DescrizioneBreve;
                
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Assegnazione property
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="idCategoria"></param>
        /// <param name="pageNumber"></param>
        private void SetProperty(Tipologia tipo, int idCategoria, int pageNumber)
        {
            this.CurrentTipologia = tipo;
            this.CurrentCategoria = idCategoria;
            this.CurrentPageNumber = pageNumber;
        }
        /// <summary>
        /// Tipo di postback (motore pagina)
        /// </summary>
        private void CheckPostbackType()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Animali"]) &&
                string.IsNullOrEmpty(Request.QueryString["Categoria"]) &&
                string.IsNullOrEmpty(Request.QueryString["PAGINA"]))
            {
                ///Click Tipologia
                if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_CANI)
                    this.SetProperty(Tipologia.Cani, DEFAULT_CATEGORIA, 1);
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_GATTI)
                    this.SetProperty(Tipologia.Gatti, DEFAULT_CATEGORIA, 1);
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_RODITORI)
                    this.SetProperty(Tipologia.Roditori, DEFAULT_CATEGORIA, 1);
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_VOLATILI)
                    this.SetProperty(Tipologia.Volatili, DEFAULT_CATEGORIA, 1);
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_ACQUARIOLOGIA)
                    this.SetProperty(Tipologia.Acquariologia, DEFAULT_CATEGORIA, 1);
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_RETTILI)
                    this.SetProperty(Tipologia.Rettili, DEFAULT_CATEGORIA, 1);
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["Animali"]) &&
                !string.IsNullOrEmpty(Request.QueryString["Categoria"]) &&
                string.IsNullOrEmpty(Request.QueryString["PAGINA"]))
            {
                ///Click Categoria
                if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_CANI)
                    this.CurrentTipologia = Tipologia.Cani;
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_GATTI)
                    this.CurrentTipologia = Tipologia.Gatti;
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_RODITORI)
                    this.CurrentTipologia = Tipologia.Roditori;
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_VOLATILI)
                    this.CurrentTipologia = Tipologia.Volatili;
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_ACQUARIOLOGIA)
                    this.CurrentTipologia = Tipologia.Acquariologia;
                else if (Request.QueryString["Animali"].ToUpper() == CATEGORIA_RETTILI)
                    this.CurrentTipologia = Tipologia.Rettili;  
                ///Set property
                this.SetProperty(this.CurrentTipologia, Convert.ToInt32(Request.QueryString["Categoria"]), 1);
            }
            else if (string.IsNullOrEmpty(Request.QueryString["Animali"]) &&
                string.IsNullOrEmpty(Request.QueryString["Categoria"]) &&
                !string.IsNullOrEmpty(Request.QueryString["PAGINA"]))
            {
                ///Click Categoria
                this.SetProperty(this.CurrentTipologia, this.CurrentCategoria, Convert.ToInt32(Request.QueryString["PAGINA"]));
            }
            else
            {
                ///Click ?
            }
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Perbaffo Prodotti Images";
            this.KeywordsPagina = "Perbaffo,prodotti,cucce per cani,giochi per gatti,guinzagli,abbigliamento per cani,cucce per gatti,tiragraffi,cibo per cani,cibo per gatti";
        }
        /// <summary>
        /// Carica tutti i campi
        /// </summary>
        private void LoadFields()
        {
            ///1) bordo intorno all'immagine
            ///2) CAtegoria selezionata
            ///3) Pagina
            this.DescrizionePagina = "Tutti i prodotti di Perbaffo ricercabili in categorie e visualizzate come immagini";

            ///1) bordo intorno all'immagine cambiano ID tra debug e Release
            switch (this.CurrentTipologia)
            {
                case Tipologia.Cani:
                    this.tblCani.Style.Add("border", "1px solid red");
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER CANI").SingleOrDefault().CategorieFiglie;
                    break;
                case Tipologia.Gatti:
                    this.tblGatti.Style.Add("border", "1px solid red");
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER GATTI").SingleOrDefault().CategorieFiglie;
                    break;
                case Tipologia.Roditori:
                    this.tblRoditori.Style.Add("border", "1px solid red");
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER RODITORI").SingleOrDefault().CategorieFiglie;
                    break;
                case Tipologia.Volatili:
                    this.tblVolatili.Style.Add("border", "1px solid red");
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER ORNITOLOGIA").SingleOrDefault().CategorieFiglie;
                    break;
                case Tipologia.Acquariologia:
                    this.tblPesci.Style.Add("border", "1px solid red");
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER PESCI").SingleOrDefault().CategorieFiglie;
                    break;
                case Tipologia.Rettili:
                    this.tblRettili.Style.Add("border", "1px solid red");
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER RETTILI").SingleOrDefault().CategorieFiglie;
                    break;
                default:
                    this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie().Where(item => item.IDCategoriaPadre == null && item.DescrizioneBreve.ToUpper() == "ARTICOLI PER CANI").SingleOrDefault().CategorieFiglie;
                    break;
            }
            ///2) CAtegoria selezionata
            this.rptMenuCategorie.DataBind();
            if (this.CurrentCategoria != DEFAULT_CATEGORIA)
            {
                _listProdotti = base.PerbaffoController.GetProdottiCategSottoCategDistinctByIDCateg(this.CurrentCategoria);
                if(_listProdotti != null || _listProdotti.Count > 0)
                {
                    int _resto = (_listProdotti.Count % 5);
                    int _div = Convert.ToInt32(_listProdotti.Count / 5);
                    if(_resto > 0)
                        _div++;
                    List<int> _lst = new List<int>(_div);
                    for (int i = 0; i < _div; i++)
                    {
                        _lst.Add(i);
                    }
                    this.rptImmaginiProdotti.DataSource = _lst;
                    this.rptImmaginiProdotti.DataBind();
                }
            }
        }
        #endregion

    }
}
