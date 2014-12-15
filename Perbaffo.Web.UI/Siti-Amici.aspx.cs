using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Siti_Amici : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private enum TipoLink
        {
            Informazioni,
            Forum,
            Blog,
            Negozi,
            Varie,
            Allevamenti,
            Tutti
        }
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagineNews { get { return base.UrlServerImagesNews; } }
        #endregion

        #region PRIVATE PROPERTY
        #endregion

        #region EVENTS
        /// <summary>
        /// Carica pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Header1.AggiornaLink(Perbaffo.Web.UI.Header.SezioniHeader.SitiAmici);
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["Link"]))
                {
                    this.LoadFields(TipoLink.Tutti);
                }
                else
                {
                    switch (Request.QueryString["Link"].ToUpper())
                    {
                        case "INFORMAZIONI":
                            this.LoadFields(TipoLink.Informazioni);
                            break;
                        case "FORUM":
                            this.LoadFields(TipoLink.Forum);
                            break;
                        case "BLOG":
                            this.LoadFields(TipoLink.Blog);
                            break;
                        case "NEGOZI":
                            this.LoadFields(TipoLink.Negozi);
                            break;
                        case "VARIE":
                            this.LoadFields(TipoLink.Varie);
                            break;
                        case "ALLEVAMENTI":
                            this.LoadFields(TipoLink.Allevamenti);
                            break;
                        default:
                            this.LoadFields(TipoLink.Informazioni);
                            break;
                    }
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica il tipo di link
        /// </summary>
        /// <param name="tipoLink"></param>
        private void LoadFields(TipoLink tipoLink)
        {
            this.tblBlog.Visible = false;
            this.tblForum.Visible = false;
            this.tblInfo.Visible = false;
            this.tblNegozi.Visible = false;
            this.tblVarie.Visible = false;
            this.tblAllevamenti.Visible = false;
            switch (tipoLink)
            {
                case TipoLink.Tutti:
                    this.lblTitoloPagina.Text = "Siti Amici - Scambio Link";
                    this.GestioneMetaTag("Siti Amici - Scambio Link");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei nostri amici";
                    this.tblBlog.Visible = true;
                    this.tblForum.Visible = true;
                    this.tblInfo.Visible = true;
                    this.tblNegozi.Visible = true;
                    this.tblVarie.Visible = true;
                    this.tblAllevamenti.Visible = true;
                    break;
                case TipoLink.Informazioni:
                    this.lblTitoloPagina.Text = "Siti Amici - Informazioni sugli animali";
                    this.GestioneMetaTag("Siti Amici - Informazioni sugli animali");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei nostri amici con le info sul mondo animale";
                    this.tblInfo.Visible = true;
                    break;
                case TipoLink.Forum:
                    this.lblTitoloPagina.Text = "Siti Amici - Forum";
                    this.GestioneMetaTag("Siti Amici - Forum");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei forum dei nostri amici";
                    this.tblForum.Visible = true;
                    break;
                case TipoLink.Blog:
                    this.lblTitoloPagina.Text = "Siti Amici - Blog";
                    this.GestioneMetaTag("Siti Amici - Blog");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei blog dei nostri amici";
                    this.tblBlog.Visible = true;
                    break;
                case TipoLink.Negozi:
                    this.lblTitoloPagina.Text = "Siti Amici - Negozi";
                    this.GestioneMetaTag("Siti Amici - Negozi");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei siti di negozi dei nostri amici";
                    this.tblNegozi.Visible = true;
                    break;
                case TipoLink.Varie:
                    this.lblTitoloPagina.Text = "Siti Amici - Varie";
                    this.GestioneMetaTag("Siti Amici - Varie");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei nostri amici che riguardano vari argomenti";
                    this.tblVarie.Visible = true;
                    break;
                case TipoLink.Allevamenti:
                    this.lblTitoloPagina.Text = "Siti Amici - Allevamenti";
                    this.GestioneMetaTag("Siti Amici - Allevamenti");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei nostri amici che posseggono un allevamento";
                    this.tblAllevamenti.Visible = true;
                    break;
                default:
                    this.lblTitoloPagina.Text = "Siti Amici - Informazioni sugli animali";
                    this.GestioneMetaTag("Siti Amici - Informazioni sugli animali");
                    this.lblScambioBannerTitolo.Text = "Qui sono raccolti i link e i banner dei nostri amici che riguardano tutte le informazioni sul mondo animale";
                    this.tblInfo.Visible = true;
                    break;
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
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag(string titolo)
        {
            this.TitoloPagina = "Perbaffo - " + titolo;
            this.KeywordsPagina = "Pet shop,siti,informazioni,blog,forum,varie,amici,link,banner,articoli,ricerche,cani,gatti,volatili,roditori,pesci,scambio,reciproco";
            this.DescrizionePagina = "Perbaffo Siti amici e scambio banner";
        }
        #endregion
    }
}
