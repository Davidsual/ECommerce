using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Perbaffo.Web.UI
{
    public partial class Dettaglio_Categoria : BasePage, IPerbaffoSite
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
        public string UrlImmagineCategoria { get { return base.UrlServerImagesCategorie; } }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        public int CurrentIDCategoria
        {
            get
            {
                if (ViewState["CurrentIDCategoria"] == null)
                    return -1;
                return (int)ViewState["CurrentIDCategoria"];
            }
            set { ViewState["CurrentIDCategoria"] = value; }
        }
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
                if (string.IsNullOrEmpty(Request.QueryString["Categoria"]))
                {
                    Server.Transfer("Default.aspx");
                }
                int _result = 0;
                if (int.TryParse(Request.QueryString["Categoria"], out _result))
                {
                    this.CurrentIDCategoria = _result;
                    ///Carico le categorie
                    if (string.IsNullOrEmpty(Request.QueryString["Page"]))
                        this.LoadCategory(_result, 0);
                    else
                    {
                        int _page = 0;
                        if (int.TryParse(Request.QueryString["Page"], out _page))
                        {
                            this.LoadCategory(_result, _page);
                        }
                        else
                            this.LoadCategory(_result, 0);
                    }
                }
                else
                    Server.Transfer("Default.aspx");
            }
        }
        /// <summary>
        /// Creazione di una riga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptProdotti_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    ProdottoImmagine _prod = e.Item.DataItem as ProdottoImmagine;
                    List<ProdottiTaglie> _taglie = base.PerbaffoController.GetProdottiTaglieByIDProdotto(_prod.ID);
                    if (_taglie != null && _taglie.Count > 0)
                    {
                        Repeater _repeater = e.Item.FindControl("rptTaglie") as Repeater;
                        if (_repeater != null)
                        {
                            _repeater.DataSource = _taglie;
                            _repeater.DataBind();
                        }
                    }
                }
            }
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
        /// Gestione inserimento prodotto nel carrello/dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptProdotti_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DETTAGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                string _url = "Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString();
                if (this.CurrentIDCategoria > 0)
                    _url += "&Categoria=" + this.CurrentIDCategoria;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = '" + _url + "';", true);
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
        /// <summary>
        /// Gestione inserimento prodotto nel carrello/dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dtlNovita_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DETTAGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                string _url = "Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString();
                if (this.CurrentIDCategoria > 0)
                    _url += "&Categoria=" + this.CurrentIDCategoria;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "window.location = '" + _url + "';", true);
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
            if (valore.Length > 330)
                return valore.Substring(0, 320) + "...";
            return valore;
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag(Categorie categ)
        {
            if (categ == null)
                return;
            this.TitoloPagina = categ.DescrizioneCategoria;
            this.DescrizionePagina = categ.DescrizioneCategoria;
            if (!string.IsNullOrEmpty(categ.Keywords))
                this.KeywordsPagina = this.CreateKeyWord(categ.DescrizioneCategoria) + categ.Keywords;
            else
                this.KeywordsPagina = this.CreateKeyWord(categ.DescrizioneCategoria) + "Perbaffo,categoria,cani,gatti,roditori,volatili,acquariologia";
        }
        /// <summary>
        /// Gestisce i metatag
        /// </summary>
        /// <returns></returns>
        private string CreateKeyWord(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return string.Empty;
                value = value.Replace(',', ' ');
                string[] _arr = value.Split(' ');
                StringBuilder _strBuilder = new StringBuilder();
                for (int i = 0; i < _arr.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(_arr[i]) && _arr[i].Length > 2)
                        _strBuilder.Append(_arr[i] + ",");
                }
                return _strBuilder.ToString();
            }
            catch (Exception)
            {
                return value + ",";
            }

        }
        /// <summary>
        /// Carica la pagina
        /// </summary>
        /// <param name="p"></param>
        private void LoadCategory(int IDCategoria, int pageNumber)
        {
            if (IDCategoria > 0)
            {
                Categorie _cat = base.PerbaffoController.GetCategoriaByIDCategoria(IDCategoria);
                if (_cat != null)
                {
                    this.lblDescrCategoria.InnerText = _cat.DescrizioneEstesa;
                    this.GestioneMetaTag(_cat);
                    this.PathCategorie(IDCategoria);
                    this.lblTitoloCategoria.InnerText = _cat.DescrizioneBreve;
                    ///Se la categoria non ha categorie figlie allora carico i prodotti
                    ///altrimenti carico la lista delle categorie figlie
                    if (_cat.CategorieFiglie == null || _cat.CategorieFiglie.Count <= 0)
                    {
                        ///Selezione della combo ordinamento
                        if (this.CurrentOrdinamento == Perbaffo.Presenter.ControllerPresentation.OrderType.Nome)
                            this.ddlOrdinamento.SelectedValue = ORDINAMENT_NOME;
                        else if (this.CurrentOrdinamento == Perbaffo.Presenter.ControllerPresentation.OrderType.Prezzo)
                            this.ddlOrdinamento.SelectedValue = ORDINAMENT_PREZZO;

                        ///Carico i prodotti della categoria
                        this.divVetrina.Visible = false;
                        this.dtlCategorie.Visible = false;
                        this.divListaProdotti.Visible = true;
                        //Totale prodotti
                        this.TotProdotti = this.PerbaffoController.GetCountProdottiByIDCategoria(IDCategoria);
                        ///Nascondo la paginazione se non c'è bisogno
                        if (this.TotProdotti <= MAX_NUMS_ROWS)
                        {
                            this.PagerHeader.Visible = false;
                            this.PagerFooter.Visible = false;
                        }
                        this.PopulateDataSource(pageNumber, MAX_NUMS_ROWS);
                    }
                    else
                    {
                        ///Carico le sotto categorie
                        this.divListaProdotti.Visible = false;
                        //this.rptProdotti.Visible = false;
                        //this.PagerFooter.Visible = false;
                        //this.PagerHeader.Visible = false;
                        this.dtlCategorie.DataSource = _cat.CategorieFiglie;
                        this.dtlCategorie.DataBind();
                        ///Caricol a vetrina
                        this.dtlNovita.DataSource = base.PerbaffoController.GetProdottiCasualiByIDCategoria(IDCategoria, 6);
                        ///Nascondo se non ho vetrina
                        if (this.dtlNovita.DataSource == null || ((List<ProdottoImmagine>)this.dtlNovita.DataSource).Count <= 0)
                        {
                            this.divVetrina.Visible = false;
                        }
                        else
                            this.dtlNovita.DataBind();
                    }
                }
                else
                {
                    this.PagerHeader.Visible = false;
                    this.PagerFooter.Visible = false;
                    this.divPath.InnerHtml = "<strong>Spiacenti la categoria ricercata è stata rimossa...</strong>";
                    ///Imposto il title della pagine se non c'è la categoria
                    this.TitoloPagina = "Perbaffo PetShop - Categoria Rimossa";
                    this.DescrizionePagina = "Perbaffo PetShop - Categoria Rimossa";
                    this.KeywordsPagina = "Articoli,accessori,animali,tiragraffi,cucce,trasportini";

                }
            }
        }
        /// <summary>
        /// Imposta il path delle categorie
        /// </summary>
        /// <param name="IDCategoria"></param>
        private void PathCategorie(int IDCategoria)
        {
            List<Categorie> _lstPath = base.PerbaffoController.GetPathCategoriaByIDCategoria(IDCategoria);

            Categorie _father = _lstPath.Where(cat => cat.IDCategoriaPadre == null).SingleOrDefault();
            if (_father != null)
            {
                StringBuilder _path = new StringBuilder();
                _path.Append("&nbsp;<a href='Default.aspx' title='Torna all HomePage' style='font-size:13px;text-decoration:none;'><b>Home</b></a>");
                _path.Append("&nbsp;/<a href='Dettaglio-Categoria.aspx?Categoria=" + _father.ID.ToString() + "' title='" + _father.DescrizioneCategoria + "' style='font-size:13px;text-decoration:none;'><b>&nbsp;" + _father.DescrizioneBreve + "</b></a>");
                _father = _lstPath.Where(cat => cat.IDCategoriaPadre == _father.ID).SingleOrDefault();
                if (_father != null)
                {
                    _path.Append("&nbsp;/<a href='Dettaglio-Categoria.aspx?Categoria=" + _father.ID.ToString() + "' title='" + _father.DescrizioneCategoria + "' style='font-size:13px;text-decoration:none;'><b>&nbsp;" + _father.DescrizioneBreve + "</b></a>");
                    _father = _lstPath.Where(cat => cat.IDCategoriaPadre == _father.ID).SingleOrDefault();
                    if (_father != null)
                    {
                        _path.Append("&nbsp;/<a href='Dettaglio-Categoria.aspx?Categoria=" + _father.ID.ToString() + "' title='" + _father.DescrizioneCategoria + "' style='font-size:13px;text-decoration:none;'><b>&nbsp;" + _father.DescrizioneBreve + "</b></a>");
                        _father = _lstPath.Where(cat => cat.IDCategoriaPadre == _father.ID).SingleOrDefault();
                        if (_father != null)
                        {
                            _path.Append("&nbsp;/<a href='Dettaglio-Categoria.aspx?Categoria=" + _father.ID.ToString() + "' title='" + _father.DescrizioneCategoria + "' style='font-size:13px;text-decoration:none;'><b>&nbsp;" + _father.DescrizioneBreve + "</b></a>");
                            _father = _lstPath.Where(cat => cat.IDCategoriaPadre == _father.ID).SingleOrDefault();
                            if (_father != null)
                            {
                                _path.Append("&nbsp;/<a href='Dettaglio-Categoria.aspx?Categoria=" + _father.ID.ToString() + "' title='" + _father.DescrizioneCategoria + "' style='font-size:13px;text-decoration:none;'><b>&nbsp;" + _father.DescrizioneBreve + "</b></a>");
                                _father = _lstPath.Where(cat => cat.IDCategoriaPadre == _father.ID).SingleOrDefault();
                            }
                        }
                    }
                }
                this.divPath.InnerHtml = _path.ToString().Replace("\'", "\"");
            }
            else
                this.divPath.InnerHtml = "Categoria inesistente";
        }
        /// <summary>
        /// Carica la griglia
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void PopulateDataSource(int page, int pageSize)
        {
            ///Controllo se il numero pagina che mi arriva non sia maggiore del numero totale di record
            ///che posseggo
            ///altrimenti è un hack
            if (((page - 1) * pageSize) > this.TotProdotti)
                page = 0;

            ((PagerFull)this.PagerHeader).CurrentPageNumber = (page == 0) ? 1 : page;
            ((PagerFull)this.PagerFooter).CurrentPageNumber = (page == 0) ? 1 : page;

            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;

            ///Carico i dati paginati
            this.rptProdotti.DataSource = this.PerbaffoController.GetProdottiByIDCategoriaAndOrder(_startRecord, pageSize, this.CurrentIDCategoria, this.CurrentOrdinamento);
            this.rptProdotti.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiOfferta();
            //Calculates how many pages of a given size are required
            ((PagerFull)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((PagerFull)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((PagerFull)this.PagerHeader).GenerateLinks();
            ((PagerFull)this.PagerFooter).GenerateLinks();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "thumbnailviewer.init();", true);
            ///tolti dopo il full postback
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            //this.updPnlProdotti.Update(); 
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
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// calcola il prezzo della taglia considerando lo sconto
        /// </summary>
        /// <param name="taglia"></param>
        /// <returns></returns>
        public string CheckTagliaPrice(ProdottiTaglie taglia)
        {
            if (taglia == null)
                return string.Empty;
            if (taglia.ScontoEuro > 0 || taglia.ScontoPerc > 0)
            {
                if (taglia.ScontoPerc > 0) return (taglia.Prezzo - (taglia.Prezzo / 100 * taglia.ScontoPerc)).ToString();
                if (taglia.ScontoEuro > 0) return (taglia.Prezzo - taglia.ScontoEuro).ToString();
            }
            return taglia.Prezzo.ToString();
        }
        #endregion
    }
}
