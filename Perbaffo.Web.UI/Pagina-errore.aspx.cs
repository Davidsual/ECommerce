using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Pagina_errore : BasePage, IPerbaffoSite
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
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GestioneMetaTag();
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Aggiorna i meta tag del sito
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Pagina errore";
            KeywordsPagina = "Pet shop,utente,utenti,password,registrati,accedere,login,dimenticato,e-mail,promozioni,offerte,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Errore durante le operazioni";
        }
        #endregion
    }
}
