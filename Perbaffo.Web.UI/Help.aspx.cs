using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    [PartialCaching(120)]
    public partial class Help : BasePage, IPerbaffoSite
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
            if (!Page.IsPostBack)
            {
                this.GestioneMetaTag();
                //Response.Cache.SetCacheability(HttpCacheability.Public);
                //Response.Cache.SetExpires(System.DateTime.Now.AddDays(7));
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Domande frequenti";
            this.DescrizionePagina = "Perbaffo domande frequenti su ordini,acquisti,spedizioni,pagamenti e privacy";
            this.KeywordsPagina = "Perbaffo,domande,frequenti,ordini,acquisti,spedizioni,pagamenti,privacy,generale,help,F.A.Q.";
        }
        #endregion
    }
}
