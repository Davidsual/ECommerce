using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Perbaffo.Web.UI
{
    public partial class Leggi_Recensioni : BasePage, IPerbaffoSite
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
        public ProdottoImmagine CurrentProdotto
        {
            get
            {
                if (ViewState["CurrentProdotto"] == null)
                    return null;
                return (ProdottoImmagine)ViewState["CurrentProdotto"];
            }
            set { ViewState["CurrentProdotto"] = value; }
        }
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        public int CurrentIDProdotto
        {
            get
            {
                if (ViewState["CurrentIDProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentIDProdotto"];
            }
            set { ViewState["CurrentIDProdotto"] = value; }
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
                if (!string.IsNullOrEmpty(Request.QueryString["Prodotto"]))
                {
                    int _result = 0;
                    if (int.TryParse(Request.QueryString["Prodotto"], out _result))
                        this.CurrentIDProdotto = _result;
                    else
                    {
                        Server.Transfer("Default.aspx", false);
                    }
                }
                else
                {
                    Server.Transfer("Default.aspx", false);
                }

                if (!string.IsNullOrEmpty(Request.QueryString["Categoria"]))
                {
                    int _result = 0;
                    if (int.TryParse(Request.QueryString["Categoria"], out _result))
                        this.CurrentIDCategoria = _result;
                }
                this.LoadRecensioni();
            }
        }
        /// <summary>
        /// Crea il voto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptRecensioni_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl _div = e.Item.FindControl("divVoto") as HtmlGenericControl;
                if (e.Item.DataItem != null && _div != null)
                {
                    StringBuilder _str = new StringBuilder();
                    _str.Append("<table border='0' cellspacing='0' cellpadding='0'><tbody><tr>");
                    _str.Append("<td><img border='0' alt='' src='images/star_red.gif' /></td>");
                    _str.Append("<td><img border='0' alt='' src='images/pixel.gif' width='3' height='15' /></td>");
                    for (int i = 2; i <= 5; i++)
			        {
                        if (((ProdottiRecensioni)e.Item.DataItem).Voto >= i)
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
                }
            }
        }
        /// <summary>
        /// Porta al dettaglio del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDettagliProd_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Dettaglio-Prodotto.aspx?Categoria=" + this.CurrentIDCategoria + "&amp;Prodotto=" + this.CurrentIDProdotto.ToString() + "';", true);
        }
        /// <summary>
        /// Acquisto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            try
            {
                ///Aggiungo il prodotto al carrello
                base.AggiungiProdottoCarrello(this.CurrentIDProdotto, -1, -1);
                ///Aggiorno il widget
                this.usrCarrello.AggiornaProdottiCarrello();
                ///Segnala all'utente che il prodotto è nel carrello
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Prodotto inserito nel carrello!');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante l\\'inseriemnto del prodotto nel carrello!');", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag(ProdottoImmagine prod)
        {
            if (prod == null)
                return;
            this.TitoloPagina = prod.Nome;
            this.DescrizionePagina = "Perbaffo prodotto: " + prod.Nome;
            if (string.IsNullOrEmpty(prod.Keywords))
                this.KeywordsPagina = prod.Nome.Replace(' ', ',');
            else
                this.KeywordsPagina = prod.Keywords+",Perbaffo,cani,gatti,volatili,roditori,acquariologia";
        }
        /// <summary>
        /// Carica la maschera con tutte le recensioni
        /// </summary>
        private void LoadRecensioni()
        {
            this.CurrentProdotto = base.PerbaffoController.GetProdottoByIDProdotto(this.CurrentIDProdotto);
            if (this.CurrentProdotto != null && this.CurrentProdotto.Attivo)
            {
                this.GestioneMetaTag(this.CurrentProdotto);
                this.lblNomeProdotto.InnerText = this.CurrentProdotto.Nome;
                this.rptRecensioni.DataSource = base.PerbaffoController.GetRecensioniByIDProdotto(this.CurrentIDProdotto);
                this.rptRecensioni.DataBind();
            }
            else
                Server.Transfer("Default.aspx", false);
        }
        #endregion

        #region PUBLIC METHODS
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
