using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class Dettaglio_Notizia : BasePage, IPerbaffoSite
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

        #region EVENTS
                /// <summary>
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["IDNotizia"]))
                { 
                    int _result = -1;
                    if (int.TryParse(Request.QueryString["IDNotizia"], out _result))
                    {
                        this.Header1.AggiornaLink(Perbaffo.Web.UI.Header.SezioniHeader.News);
                        this.LoadFields(_result);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Default.aspx';", true);
                        return;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Default.aspx';", true);
                    return;
                }
            }

            
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica la notizia
        /// </summary>
        /// <param name="idNotizia"></param>
        private void LoadFields(int idNotizia)
        {
            News _notizia = base.PerbaffoController.GetNewsByIDNews(idNotizia);
            if (_notizia == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Default.aspx';", true);
                return;
            }
            this.GestioneMetaTag(_notizia);
            this.lblTitoloNotizia.InnerText = _notizia.Titolo + " (" + _notizia.DataInserimento.ToShortDateString() + ")";
            this.imgNews.Src = (!string.IsNullOrEmpty(_notizia.UrlImmagine))?UrlImmagineNews + _notizia.UrlImmagine:"images/no-image.jpg";
            this.imgNews.Alt = _notizia.Titolo;
            this.lblNews.InnerHtml = _notizia.Notizia.Replace("\r\n", "<br/>");
            this.lnkFonte.HRef = _notizia.UrlFonte;
            this.lnkFonte.Title = _notizia.DescrioneFonte;
            this.lnkFonte.InnerText = _notizia.DescrioneFonte;
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag(News notizia)
        {
            this.TitoloPagina = notizia.Titolo;
            this.DescrizionePagina = "Perbaffo " + notizia.Titolo;
            this.KeywordsPagina = "Perbaffo,news,notizia," + notizia.Titolo.Replace(' ', ',') + "," + notizia.DescrioneFonte.Replace(' ',',');
        }
        #endregion
    }
}
