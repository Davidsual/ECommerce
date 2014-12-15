using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Collections;

namespace Perbaffo.Web.UI
{
    public partial class Curiosita_Animali : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const string CATEGORIA_CANI = "DOG";
        private const string CATEGORIA_GATTI = "CAT";
        private const string CATEGORIA_RODITORI = "RABBIT";
        private const string CATEGORIA_VOLATILI = "BIRD";
        private const string CATEGORIA_PESCI = "FISH"; 
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagineNews { get { return base.UrlServerImagesNews; } }
        #endregion

        #region PRIVATE PROPERTY
        private string CurrentCategoriaSelezionata
        {
            get
            {
                if (ViewState["CurrentCategoriaSelezionata"] == null)
                    return string.Empty;
                return ViewState["CurrentCategoriaSelezionata"] as string;
            }
            set { ViewState["CurrentCategoriaSelezionata"] = value; }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Header1.AggiornaLink(Perbaffo.Web.UI.Header.SezioniHeader.InfoAnimali);
            if (!Page.IsPostBack)
            {
                this.tblCani.Style.Add("border", "1px solid red");
                this.CurrentCategoriaSelezionata = CATEGORIA_CANI;
                this.LoadCuriosita(CATEGORIA_CANI);
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// selezione della categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAction_Click(object sender, EventArgs e)
        {
            string _categSelected = string.Empty;
            switch (((LinkButton)sender).CommandName)
            {
                case "CANI":
                    _categSelected = CATEGORIA_CANI;
                    break;
                case "GATTI":
                    _categSelected = CATEGORIA_GATTI;
                    break;
                case "RODITORI":
                    _categSelected = CATEGORIA_RODITORI;
                    break;
                case "VOLATILI":
                    _categSelected = CATEGORIA_VOLATILI;
                    break;
                case "PESCI":
                    _categSelected = CATEGORIA_PESCI;
                    break;
                default:
                    break;
            }
            if (_categSelected == this.CurrentCategoriaSelezionata)
                return;

            //this.CurrentFasciaPrezzoSelezionata = 0;
            this.tblCani.Style.Add("border", "1px solid #cddded");
            this.tblGatti.Style.Add("border", "1px solid #cddded");
            this.tblPesci.Style.Add("border", "1px solid #cddded");
            this.tblRoditori.Style.Add("border", "1px solid #cddded");
            this.tblVolatili.Style.Add("border", "1px solid #cddded");

            switch (((LinkButton)sender).CommandName)
            {
                case "CANI":
                    this.tblCani.Style.Add("border", "1px solid red");
                    this.LoadCuriosita(CATEGORIA_CANI);
                    break;
                case "GATTI":
                    this.tblGatti.Style.Add("border", "1px solid red");
                    this.LoadCuriosita(CATEGORIA_GATTI);
                    break;
                case "RODITORI":
                    this.tblRoditori.Style.Add("border", "1px solid red");
                    this.LoadCuriosita(CATEGORIA_RODITORI);
                    break;
                case "VOLATILI":
                    this.tblVolatili.Style.Add("border", "1px solid red");
                    this.LoadCuriosita(CATEGORIA_VOLATILI);
                    break;
                case "PESCI":
                    this.tblPesci.Style.Add("border", "1px solid red");
                    this.LoadCuriosita(CATEGORIA_PESCI);
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Creazione delle curiosità
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptCuriosita_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Label _descr = e.Item.FindControl("lblDescrizione") as Label;
                if (_descr != null)
                {
                    _descr.Text = base.Capitalize(((Curiosita)e.Item.DataItem).DescrCuriosita.Replace("\r\n","<br/>"));
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica le curiosità data la categoria
        /// </summary>
        private void LoadCuriosita(string categoria)
        {
            this.CurrentCategoriaSelezionata = categoria;
            this.rptCuriosita.DataSource = base.PerbaffoController.GetCuriositaByCategoria(categoria, 0, 500);
            this.rptCuriosita.DataBind();

            this.pnlRighe.Visible = (this.rptCuriosita.DataSource == null || ((IList)this.rptCuriosita.DataSource).Count <= 0);

        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Info e curiosità sul mondo degli animali";
            this.DescrizionePagina = "Informazioni e curiosità sul mondo degli animali";
            this.KeywordsPagina = "Perbaffo,Info,curiosità,promozioni,mondo animale,categorie,cani,gatti,roditori,volatili,terrari,roditori";
        }
        #endregion

    }
}
