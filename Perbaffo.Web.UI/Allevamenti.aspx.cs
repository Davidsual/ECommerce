using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Allevamenti : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
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
            this.Header1.AggiornaLink(Perbaffo.Web.UI.Header.SezioniHeader.Allevamenti);
            if (!Page.IsPostBack)
            {
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
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Allevamenti";
            this.DescrizionePagina = "Elenco degli allevamenti italiani amici di Perbaffo";
            this.KeywordsPagina = "Perbaffo,Allevamenti,offerte,promozioni,categorie,cani,gatti,roditori,volatili,terrari";
        }
        #endregion
    }
}
