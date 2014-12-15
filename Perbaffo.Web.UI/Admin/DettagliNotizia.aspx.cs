using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class DettagliNotizia : BasePage
    {
        #region PRIVATE MEMBERS
        private enum PageStatus
        {
            Inserimento,
            Modifica
        }
        #endregion

        #region PRIVATE PROPERTY
        private PageStatus CurrentPageState
        {
            get
            {
                if (ViewState["CurrentPageState"] == null)
                    return PageStatus.Inserimento;
                return (PageStatus)ViewState["CurrentPageState"];
            }
            set
            {
                ViewState["CurrentPageState"] = value;
            }
        }
        private int CurrentIDNews
        {
            get
            {
                if (ViewState["CurrentIDNews"] == null)
                    return -1;
                return (int)ViewState["CurrentIDNews"];
            }
            set { ViewState["CurrentIDNews"] = value; }
        }

        #endregion

        #region EVENTS
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notizie.aspx");
        }
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["IDNotizia"]))
                {
                    this.CurrentPageState = PageStatus.Inserimento;
                    this.CurrentIDNews = 0;
                }
                else
                {
                    this.CurrentIDNews = int.Parse(Request.QueryString["IDNotizia"]);
                    this.CurrentPageState = PageStatus.Modifica;
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
        /// Salva o aggiorna la notizia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTitolo.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtFonte.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtUrlFonte.Text.Trim()) ||
                string.IsNullOrEmpty(this.descrizione.Value.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare tutti i campi');", true);
                return;
            }
            try
            {
                News _notizia = new News()
                {
                    Titolo = this.txtTitolo.Text.Trim(),
                    DescrioneFonte = this.txtFonte.Text.Trim(),
                    UrlFonte = this.txtUrlFonte.Text.Trim(),
                    Notizia = this.descrizione.Value.Trim()
                };
                if (this.CurrentPageState == PageStatus.Modifica)
                {
                    _notizia.ID = this.CurrentIDNews;
                    base.PerbaffoController.UpdateNews(_notizia);
                }
                else
                {
                    News _not = base.PerbaffoController.SetNews(_notizia);
                    this.CurrentIDNews = _not.ID;
                    this.CurrentPageState = PageStatus.Modifica;
                }
                this.LoadFields();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante l\\'aggiornamento');", true);
            }
        }
        /// <summary>
        /// Ricarica la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancella_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Elimina la notiza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            base.PerbaffoController.DeleteNews(this.CurrentIDNews);
            Response.Redirect("Notizie.aspx");
        }
        /// <summary>
        /// Cancello immagine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            base.PerbaffoController.AggiungiImmagineNews(this.CurrentIDNews, null);
            this.LoadFields();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica la pagina
        /// </summary>
        private void LoadFields()
        {
            if (this.CurrentPageState == PageStatus.Modifica)
            {
                this.btnElimina.Visible = true;
                this.Load.Visible = true;

                News _notizia = base.PerbaffoController.GetNewsByIDNews(this.CurrentIDNews);
                this.imgNews.Src = (!string.IsNullOrEmpty(_notizia.UrlImmagine))? base.UrlServerImagesNews + _notizia.UrlImmagine:"../images/no-image.jpg";
                this.btnDelete.Visible = !string.IsNullOrEmpty(_notizia.UrlImmagine);
                this.txtTitolo.Text = _notizia.Titolo;
                this.txtFonte.Text = _notizia.DescrioneFonte;
                this.txtUrlFonte.Text = _notizia.UrlFonte;
                this.descrizione.Value = _notizia.Notizia;
                this.lblDataInserimento.InnerText = _notizia.DataInserimento.ToShortDateString();
                this.Load.Attributes.Add("src", "LoadImageNews.aspx?IDNotizia="+this.CurrentIDNews.ToString());
            }
            else
            {
                this.btnElimina.Visible = false;
                this.Load.Visible = false;
                this.btnDelete.Visible = false;
            }
        } 
        #endregion
    }
}
