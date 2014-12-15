using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Chi_Siamo : BasePage, IPerbaffoSite
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
            if(!Page.IsPostBack)
                this.GestioneMetaTag();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Chi siamo";
            this.DescrizionePagina = "Tutte le infomazioni utili per capire chi è Perbaffo";
            this.KeywordsPagina = "Perbaffo,chi siamo,prodotti,acquista,fornitori,Torino,informazioni,articolo,cani,gatti,roditori,volatili,acquariologia";
        }
        #endregion
    }
}
