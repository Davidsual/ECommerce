using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Web.Caching;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class WidgetNews : BaseUserControl
    {
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
                this.LoadNews();
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica le news
        /// </summary>
        private void LoadNews()
        {
            if (Cache.Get("NEWS") == null)
            {
                this.rptNotizie.DataSource = base.PerbaffoController.GetTopNews(7);
                Cache.Add("NEWS", this.rptNotizie.DataSource, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Normal, null);
            }
            else
                this.rptNotizie.DataSource = (List<News>)Cache.Get("NEWS");
            this.rptNotizie.DataBind();
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
            if (valore.Length > 90)
                return valore.Substring(0, 80) + "...";
            return valore;
        } 
        #endregion
    }
}