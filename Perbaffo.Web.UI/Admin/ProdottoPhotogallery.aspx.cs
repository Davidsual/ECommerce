using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Configuration;

namespace Perbaffo.Web.UI.Admin
{
    public partial class ProdottoPhotogallery : BasePage
    {
        #region PUBLIC PROPERTY
        public string CurrentPathFoto
        {
            get { return ConfigurationManager.AppSettings["PATHIMAGE"].ToString(); }
        }
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Id Prodotto corrente
        /// </summary>
        private int CurrentIDProdotto
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
        /// Caricamento pagine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["IDProdotto"]))
                {
                    ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.HomePage);
                    return;
                }
                else
                    this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);
                this.LoadFields();
                ///Carico user control
                this.Load.Attributes.Add("src", "LoadImagePhotogallery.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
            }
            else if (HttpContext.Current.Request.Form["__EVENTARGUMENT"] != null &&
                    !string.IsNullOrEmpty(HttpContext.Current.Request.Form["__EVENTARGUMENT"].ToString()) &&
                    HttpContext.Current.Request.Form["__EVENTARGUMENT"].ToString().ToUpper().Contains("RELOAD"))
            {
                ///Ricarica i campi per mostrare le modifiche
                this.LoadFields();
            }
        }
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
        }
        /// <summary>
        /// Cancellazione di un immagine nella photogallery
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptPhoto_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandArgument == null || string.IsNullOrEmpty(e.CommandName))
                return;
            int _idImmagine = Convert.ToInt32(e.CommandArgument);
            ///Cancello immagine
            string _nomeImmagine = base.PerbaffoController.GetNomeImmagineFotogalleryByIDImmagine(_idImmagine);
            if (!string.IsNullOrEmpty(_nomeImmagine))
                base.FTPDelete("/ImmaginiPerbaffo/" + _nomeImmagine);
            ///Cancello il record
            base.PerbaffoController.DeleteProdottiFotogallery(_idImmagine, this.CurrentIDProdotto);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "aler", "alert('Immagine cancellata');", true);
            this.LoadFields();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento campi
        /// </summary>
        private void LoadFields()
        {
            this.rptPhoto.DataSource = base.PerbaffoController.GetProdottiFotogallery(this.CurrentIDProdotto);
            this.rptPhoto.DataBind();
        }
        #endregion


    }
}
