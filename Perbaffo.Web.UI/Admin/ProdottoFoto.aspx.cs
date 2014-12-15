using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;
using System.Configuration;

namespace Perbaffo.Web.UI.Admin
{
    public partial class ProdottoFoto : BasePage
    {
        #region PRIVATE MEMBERS
        private const string NO_IMAGE = "img/noimage.gif";
        #endregion

        #region PRIVATE PROPERTY
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
        /// Caricamento della pagina
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
                {
                    this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);
                }
                this.LoadFields();

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
        /// Cancella un immagine dal db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminaImage_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ProdottiImmagini _prodImmagini = new ProdottiImmagini()
                {
                    IDProdotto = this.CurrentIDProdotto
                };
                switch (((ImageButton)sender).CommandName)
                {
                    case "PICCOLA":
                        base.PerbaffoController.DeleteProdottiImmagini(Perbaffo.Presenter.Controller.TypeImage.Piccola, _prodImmagini);
                        base.FTPDelete("/ImmaginiPerbaffo/" + _prodImmagini.UrlImmagine);
                        break;
                    case "GRANDE":
                        base.PerbaffoController.DeleteProdottiImmagini(Perbaffo.Presenter.Controller.TypeImage.Grande, _prodImmagini);
                        base.FTPDelete("/ImmaginiPerbaffo/" + _prodImmagini.UrlImmagineHQ);
                        break;
                    default:
                        break;
                }
                ///Ricarica tutto
                this.LoadFields();
            }
            catch (Exception ex)
            {

                throw ex;
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
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento campi
        /// </summary>
        private void LoadFields()
        {
            try
            {
                ProdottiImmagini _prodImmagini = base.PerbaffoController.GetImmaginiByIdProdotto(this.CurrentIDProdotto);
                if (_prodImmagini != null)
                {
                    if(string.IsNullOrEmpty(_prodImmagini.UrlImmagine))
                    {
                        this.imgPiccola.ImageUrl = NO_IMAGE;
                        this.btnEliminaImagePiccola.Visible = false;
                    }
                    else
                    {
                        this.imgPiccola.ImageUrl = ConfigurationManager.AppSettings["PATHIMAGE"].ToString() + "\\" + _prodImmagini.UrlImmagine;
                        this.btnEliminaImagePiccola.Visible = true;
                    }
                    if(string.IsNullOrEmpty(_prodImmagini.UrlImmagineHQ))
                    {
                        this.imgGrande.ImageUrl =NO_IMAGE;
                        this.btnEliminaImageGrande.Visible = false;
                    }
                    else
                    {
                        this.imgGrande.ImageUrl = ConfigurationManager.AppSettings["PATHIMAGE"].ToString() + "\\" + _prodImmagini.UrlImmagineHQ;
                        this.btnEliminaImageGrande.Visible = true;
                    }
                }
                else
                {
                    this.imgPiccola.ImageUrl = NO_IMAGE;
                    this.imgGrande.ImageUrl = NO_IMAGE;
                }
                updPnlPreviewFoto.Update();
                this.Load.Attributes.Add("src", "LoadImage.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        
    }
}
