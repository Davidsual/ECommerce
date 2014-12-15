using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Come_Ordinare : BasePage, IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
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
                this.GestioneMetaTag();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Come ordinare";
            this.DescrizionePagina = "Tutte le informazioni su come ordinare i prodotti sul sito Perbaffo";
            this.KeywordsPagina = "Perbaffo,come,ordinare,acquisti,fornitori,Torino,informazioni,articolo,prodotti,categorie,cani,gatti,roditori,volatili,acquariologia";
        }
        #endregion

    }
}
