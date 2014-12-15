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
    public partial class Prodotto_Piu_Votati : BasePage, IPerbaffoSite
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
        /// Selezione sulla griglia (dettagli/carrello)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptNovita_ItemCommand(object source, RepeaterCommandEventArgs e)
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
        /// Carica pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.TotProdotti = base.PerbaffoController.GetCountProdottiVotati();
                this.PopulateDataSource(0, MAX_NUMS_ROWS);
                //this.rptNovita.DataSource = base.PerbaffoController.GetProdottiPiuVotati();
                //this.rptNovita.DataBind();
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
        /// Creazione di una riga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptNovita_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl _div = e.Item.FindControl("divVoto") as HtmlGenericControl;
                if (e.Item.DataItem != null && _div != null)
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

                    #region creazione stelle voto
                    StringBuilder _str = new StringBuilder();
                    _str.Append("<table border='0' cellspacing='0' cellpadding='0'><tbody><tr>");
                    _str.Append("<td><img border='0' alt='' src='images/star_red.gif' /></td>");
                    _str.Append("<td><img border='0' alt='' src='images/pixel.gif' width='3' height='15' /></td>");
                    for (int i = 2; i <= 5; i++)
                    {
                        if (((ProdottoImmagine)e.Item.DataItem).Voto >= i)
                        {
                            _str.Append("<td><img border='0' alt='' src='images/star_red.gif' /></td>");
                            _str.Append("<td><img border='0' alt='' src='images/pixel.gif' width='3' height='15' /></td>");
                        }
                        else
                        {
                            _str.Append("<td><img border='0' alt='' src='images/star_red_out.gif' /></td>");
                            _str.Append("<td><img border='0' alt='' src='images/pixel.gif' width='3' height='15' /></td>");
                        }
                    }

                    _str.Append("</tr></tbody></table>");
                    _div.InnerHtml = _str.ToString(); 
                    #endregion
                }
            }
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

            this.rptNovita.DataSource = this.PerbaffoController.GetProdottiPiuVotati(_startRecord, pageSize);
            this.rptNovita.DataBind();
            //this.TotProdotti = this.PerbaffoController.GetCountProdottiOfferta();
            //Calculates how many pages of a given size are required
            ((Pager)this.PagerHeader).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerFooter).TotalPages =
                (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);
            ((Pager)this.PagerHeader).GenerateLinks();
            ((Pager)this.PagerFooter).GenerateLinks();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            this.updPnlPiuVotati.Update();
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "I Prodotti e gli articoli più votati e recensiti";
            DescrizionePagina = "Tutti i prodotti e gli accesssori recensiti e votati dagli utenti di Perbaffo";
            KeywordsPagina = "Perbaffo,prodotti,articoli,omaggio,categoria,ordine,minimo,costo,cani,gatti,volatili,roditori,prodotto,acquariologia,terrari";
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

    }
}
