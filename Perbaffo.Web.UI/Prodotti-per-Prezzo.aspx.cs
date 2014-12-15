using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Web.Caching;
using System.Collections;

namespace Perbaffo.Web.UI
{
    public partial class Prodotti_per_Prezzo : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const int CATEGORIA_CANI = 20;
        private const int CATEGORIA_GATTI = 1;
        private const int CATEGORIA_RODITORI = 18;
        private const int CATEGORIA_VOLATILI = 9;
        private const int CATEGORIA_PESCI = 168;
        private const int CATEGORIA_RETTILI = 443;
        private enum Range
        {
            Inizio,
            Fine
        }
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE PROPERTY
        private int CurrentCategoriaSelezionata
        {
            get
            {
                if (ViewState["CurrentCategoriaSelezionata"] == null)
                    return -1;
                return (int)ViewState["CurrentCategoriaSelezionata"];
            }
            set { ViewState["CurrentCategoriaSelezionata"] = value; }
        }
        public int CurrentFasciaPrezzoSelezionata
        {
            get
            {
                if (ViewState["CurrentFasciaPrezzoSelezionata"] == null)
                    return 0;
                return (int)ViewState["CurrentFasciaPrezzoSelezionata"];
            }
            set { ViewState["CurrentFasciaPrezzoSelezionata"] = value; }
        }
        private List<int> CurrentListaID
        {
            get
            {
                if (ViewState["CurrentListaID"] == null)
                    return new List<int>();
                return (List<int>)ViewState["CurrentListaID"];
            }
            set { ViewState["CurrentListaID"] = value; }
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
                if (string.IsNullOrEmpty(Request.QueryString["Pet"]))
                {
                    this.tblCani.Style.Add("border", "1px solid red");
                    this.CurrentCategoriaSelezionata = CATEGORIA_CANI;
                    this.CurrentFasciaPrezzoSelezionata = 0;
                    //this.LoadProdotti(CATEGORIA_CANI);
                    //this.GestioneMetaTag();
                }
                else
                {
                    ///Categoria selezionata
                    switch (Request.QueryString["Pet"].ToUpper())
                    {
                        case "CANI":
                            this.tblCani.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_CANI;
                            break;
                        case "GATTI":
                            this.tblGatti.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_GATTI;
                            break;
                        case "RODITORI":
                            this.tblRoditori.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_RODITORI;
                            break;
                        case "UCCELLI":
                            this.tblVolatili.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_VOLATILI;
                            break;
                        case "PESCI":
                            this.tblPesci.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_PESCI;
                            break;
                        case "RETTILI":
                            this.tblRettili.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_RETTILI;
                            break;
                        default:
                            this.tblCani.Style.Add("border", "1px solid red");
                            this.CurrentCategoriaSelezionata = CATEGORIA_CANI;
                            this.CurrentFasciaPrezzoSelezionata = 0;
                            break;
                    }
                    ///Controllo se c'è una lettera selezionata
                    if (string.IsNullOrEmpty(Request.QueryString["FasciaPrezzo"]))
                        this.CurrentFasciaPrezzoSelezionata = 0;
                    else
                    {
                        this.CurrentFasciaPrezzoSelezionata = 0;
                        string _letter = Request.QueryString["FasciaPrezzo"].Substring(0, 1);
                        int _value = 0;
                        if (int.TryParse(Request.QueryString["FasciaPrezzo"].Substring(0, 1), out _value))
                            this.CurrentFasciaPrezzoSelezionata = (_value >= 0 && _value <= 7) ? _value : 0;
                    }
                }
                ///Carico gli url correttamente
                switch (this.CurrentCategoriaSelezionata)
                {
                    case CATEGORIA_CANI:
                        this.CreateUrlLink("Cani");
                        break;
                    case CATEGORIA_GATTI:
                        this.CreateUrlLink("Gatti");
                        break;
                    case CATEGORIA_RODITORI:
                        this.CreateUrlLink("Roditori");
                        break;
                    case CATEGORIA_VOLATILI:
                        this.CreateUrlLink("Uccelli");
                        break;
                    case CATEGORIA_PESCI:
                        this.CreateUrlLink("Pesci");
                        break;
                    case CATEGORIA_RETTILI:
                        this.CreateUrlLink("Rettili");
                        break;
                    default:
                        break;
                }
                ///Carica tutto
                this.LoadProdotti(this.CurrentCategoriaSelezionata);
                ///Metatag
                this.GestioneMetaTag();
            }
        }
        ///// <summary>
        ///// selezione della categoria
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lnkAction_Click(object sender, EventArgs e)
        //{
        //    int _categSelected = 0;
        //    switch (((LinkButton)sender).CommandName)
        //    {
        //        case "CANI":
        //            _categSelected = CATEGORIA_CANI;
        //            break;
        //        case "GATTI":
        //            _categSelected = CATEGORIA_GATTI;
        //            break;
        //        case "RODITORI":
        //            _categSelected = CATEGORIA_RODITORI;
        //            break;
        //        case "VOLATILI":
        //            _categSelected = CATEGORIA_VOLATILI;
        //            break;
        //        case "PESCI":
        //            _categSelected = CATEGORIA_PESCI;
        //            break;
        //        default:
        //            break;
        //    }
        //    if (_categSelected == this.CurrentCategoriaSelezionata)
        //        return;

        //    this.CurrentFasciaPrezzoSelezionata = 0;
        //    this.tblCani.Style.Add("border", "1px solid #cddded");
        //    this.tblGatti.Style.Add("border", "1px solid #cddded");
        //    this.tblPesci.Style.Add("border", "1px solid #cddded");
        //    this.tblRoditori.Style.Add("border", "1px solid #cddded");
        //    this.tblVolatili.Style.Add("border", "1px solid #cddded");

        //    switch (((LinkButton)sender).CommandName)
        //    {
        //        case "CANI":
        //            this.tblCani.Style.Add("border", "1px solid red");
        //            this.LoadProdotti(CATEGORIA_CANI);
        //            break;
        //        case "GATTI":
        //            this.tblGatti.Style.Add("border", "1px solid red");
        //            this.LoadProdotti(CATEGORIA_GATTI);
        //            break;
        //        case "RODITORI":
        //            this.tblRoditori.Style.Add("border", "1px solid red");
        //            this.LoadProdotti(CATEGORIA_RODITORI);
        //            break;
        //        case "VOLATILI":
        //            this.tblVolatili.Style.Add("border", "1px solid red");
        //            this.LoadProdotti(CATEGORIA_VOLATILI);
        //            break;
        //        case "PESCI":
        //            this.tblPesci.Style.Add("border", "1px solid red");
        //            this.LoadProdotti(CATEGORIA_PESCI);
        //            break;
        //        default:
        //            break;
        //    }

        //}
        /// <summary>
        /// Crea gli url
        /// </summary>
        private void CreateUrlLink(string categoria)
        {
            this.lnk0.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "0");
            this.lnk1.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "1");
            this.lnk2.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "2");
            this.lnk3.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "3");
            this.lnk4.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "4");
            this.lnk5.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "5");
            this.lnk6.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "6");
            this.lnk7.NavigateUrl = string.Format("Prodotti-per-Prezzo.aspx?Pet={0}&FasciaPrezzo={1}", categoria, "7");
        }
        /// <summary>
        /// Caricamento protti
        /// </summary>
        /// <param name="categoria"></param>
        private void LoadProdotti(int categoria)
        {
            List<Categorie> _categorie = null;
            Categorie _categoria = null;
            List<int> _idCategoria = null;
            if (Cache.Get("MENU") == null)
            {
                ///popolo l'albero
                _categorie = base.PerbaffoController.GetCategorie();
                Cache.Add("MENU", _categorie, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
            }
            else
            {
                _categorie = (List<Categorie>)Cache.Get("MENU");
            }
            _categoria = _categorie.Where(cat => cat.ID == categoria).SingleOrDefault();
            if (_categoria != null)
            {
                _idCategoria = new List<int>();
                _idCategoria.Add(_categoria.ID);
                this.CurrentCategoriaSelezionata = categoria;
                this.GetIDCategorieFiglie(_idCategoria, _categoria.CategorieFiglie);
                this.CurrentListaID = _idCategoria;
                this.rptProdotti.DataSource = base.PerbaffoController.GetProdottiByRangePrezzo(this.CurrentListaID, this.RangePrezzo(Range.Inizio, this.CurrentFasciaPrezzoSelezionata), this.RangePrezzo(Range.Fine, this.CurrentFasciaPrezzoSelezionata));
                if (this.rptProdotti.DataSource == null || ((IList)this.rptProdotti.DataSource).Count <= 0)
                    this.pnlRighe.Visible = true;
                else
                    this.pnlRighe.Visible = false;
                this.rptProdotti.DataBind();


                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "try{ $(document).ready(function(){ screenshotPreview(); }); } catch(err){} ", true);
            }
        }
        /// <summary>
        /// Restituisce il range di prezzo
        /// </summary>
        /// <param name="range"></param>
        /// <param name="Fascia"></param>
        /// <returns></returns>
        private decimal RangePrezzo(Range range, int Fascia)
        {
            switch (range)
            {
                case Range.Inizio:
                    if (Fascia == 0)
                        return new decimal(0.01);
                    else if (Fascia == 1)
                        return new decimal(5.00);
                    else if (Fascia == 2)
                        return new decimal(10.00);
                    else if (Fascia == 3)
                        return new decimal(20.00);
                    else if (Fascia == 4)
                        return new decimal(40.00);
                    else if (Fascia == 5)
                        return new decimal(70.00);
                    else if (Fascia == 6)
                        return new decimal(100.00);
                    else if (Fascia == 7)
                        return new decimal(150.00);
                    break;
                case Range.Fine:
                    if (Fascia == 0)
                        return new decimal(4.99);
                    else if (Fascia == 1)
                        return new decimal(9.99);
                    else if (Fascia == 2)
                        return new decimal(19.99);
                    else if (Fascia == 3)
                        return new decimal(39.99);
                    else if (Fascia == 4)
                        return new decimal(69.99);
                    else if (Fascia == 5)
                        return new decimal(99.99);
                    else if (Fascia == 6)
                        return new decimal(149.99);
                    else if (Fascia == 7)
                        return new decimal(3000.00);
                    break;
                default:
                    return new decimal(0.00);
                    break;
            }
            return new decimal(0.00);
        }

        /// <summary>
        /// Popola l'albero con tutte le categorie figlie
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="categ"></param>
        private void GetIDCategorieFiglie(List<int> lista, List<Categorie> categ)
        {
            if (categ == null)
                return;
            categ.ForEach(item =>
            {
                lista.Add(item.ID);
                this.GetIDCategorieFiglie(lista, item.CategorieFiglie);
            });
        }
        ///// <summary>
        ///// Ricerca per lettera e categoria
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lnkSearch_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(((LinkButton)sender).CommandName) || this.CurrentFasciaPrezzoSelezionata.ToString() == ((LinkButton)sender).CommandName)
        //        return;
        //    this.CurrentFasciaPrezzoSelezionata = Convert.ToInt32(((LinkButton)sender).CommandName);
        //    this.rptProdotti.DataSource = base.PerbaffoController.GetProdottiByRangePrezzo(this.CurrentListaID, this.RangePrezzo(Range.Inizio, this.CurrentFasciaPrezzoSelezionata), this.RangePrezzo(Range.Fine, this.CurrentFasciaPrezzoSelezionata));
        //    if (this.rptProdotti.DataSource == null || ((IList)this.rptProdotti.DataSource).Count <= 0)
        //        this.pnlRighe.Visible = true;
        //    else
        //        this.pnlRighe.Visible = false;
        //    this.rptProdotti.DataBind();
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "try{ $(document).ready(function(){ screenshotPreview(); }); } catch(err){}", true);
        //}
        /// <summary>
        /// Evento prerender sui link selezionati
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            HyperLink _lnk = this.FindControl("lnk" + this.CurrentFasciaPrezzoSelezionata.ToString()) as HyperLink;
            if (_lnk != null)
            {
                _lnk.Enabled = false;
                _lnk.Style.Add("color", "black");
            }
            base.OnPreRender(e);
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
            //this.TitoloPagina = "Tutti i prodotti e gli accessori per animali divisi per prezzo";
            //this.KeywordsPagina = "Pet shop,Tutti,prodotti,categoria,articoli,collari,ricerche,cani,gatti,volatili,roditori,pesci,tiragraffi,terrari,cucce per cani,cibo per animali";
            //this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per animali del sito ordinati per fascia di prezzo";
            switch (this.CurrentCategoriaSelezionata)
            {
                case CATEGORIA_CANI:
                    this.TitoloPagina = "Tutti i prodotti della categoria Cani";
                    this.KeywordsPagina = "Pet shop,Tutti,prodotti per cani,cibo per cani,articoli per cani,collari,cani,ciotole per cani,abbigliamento per cani,alimentazione per cani,cuccia,guinzagli,coperte per cani";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per cani del sito ricercabili dalla A alla Z";
                    break;
                case CATEGORIA_GATTI:
                    this.TitoloPagina = "Tutti i prodotti della categoria Gatti";
                    this.KeywordsPagina = "Pet shop,Tutti,prodotti,cibo per gatti,articoli per gatti,collari,tiragraffi,gatti,guinzagli per gatti,abbigliamento per gatti,alimentazione per gatti,cuccia per gatti,giochi per gatti,palestra gioco";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per gatti del sito ricercabili dalla A alla Z";
                    break;
                case CATEGORIA_RODITORI:
                    this.TitoloPagina = "Tutti i prodotti della categoria Roditori";
                    this.KeywordsPagina = "Pet shop,Tutti,prodotti,categoria,articoli,cucce per roditori,gabbie per roditori,roditori,scoiattoli,abbigliamento per roditori,cibo per roditori,giochi per roditori,fieno,beverino per roditori";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per roditori del sito ricercabili dalla A alla Z";
                    break;
                case CATEGORIA_VOLATILI:
                    this.TitoloPagina = "Tutti i prodotti della categoria Volatili";
                    this.KeywordsPagina = "Pet shop,Tutti,prodotti,categoria,articoli,gabbia per uccelli,posatoio,uccelli,lettiere per uccelli,trasportino per uccelli,cibo per uccelli,accessori per uccelli,voliere,giochi per uccelli";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per volatili del sito ricercabili dalla A alla Z";
                    break;
                case CATEGORIA_PESCI:
                    this.TitoloPagina = "Tutti i prodotti della categoria Acquariologia";
                    this.KeywordsPagina = "Pet shop,Tutti,prodotti,categoria,articoli,acquario,filtri acquario,pesci,cibo per pesci,accessori per pesci,decorazioni acquario,grotta,corallo,veliero";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per acquariologia del sito ricercabili dalla A alla Z";
                    break;
                case CATEGORIA_RETTILI:
                    this.TitoloPagina = "Tutti i prodotti della categoria Rettili";
                    this.KeywordsPagina = "Pet shop,prodotti per rettili,categoria rettili,articoli per rettili,tartarughe,serpenti,pitoni,cibo per tartarughe,accessori per rettili,terrari,emettitore calore";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per rettili del sito ricercabili dalla A alla Z";
                    break;
                default:
                    this.TitoloPagina = "Tutti i prodotti della categoria Cani";
                    this.KeywordsPagina = "Pet shop,Tutti,prodotti,categoria,articoli,collari,ricerche,cani,collari,abbigliamento,cibo,cuccia,guinzagli,coperte";
                    this.DescrizionePagina = "Perbaffo tutti i prodotti e gli accessori per cani del sito ricercabili dalla A alla Z";
                    break;
            }
        }
        #endregion

    }
}
