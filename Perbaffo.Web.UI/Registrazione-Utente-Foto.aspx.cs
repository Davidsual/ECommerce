using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Text;

namespace Perbaffo.Web.UI
{
    public partial class Registrazione_Utente_Foto : BasePage, IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE PROPERTY
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.UtenteLoggato == null)
            {
                Server.Transfer("Login-Utente.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Registrazione"]))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Registrazione avvenuta con successo!');", true);
                }
                ///Gestisco i metatag
                this.GestioneMetaTag();
                this.LoadFieds();
            }
            else if (HttpContext.Current.Request.Form["__EVENTARGUMENT"] != null &&
                    !string.IsNullOrEmpty(HttpContext.Current.Request.Form["__EVENTARGUMENT"].ToString()) &&
                    HttpContext.Current.Request.Form["__EVENTARGUMENT"].ToString().ToUpper().Contains("RELOAD"))
            {
                this.LoadFieds();
            }
        }
        /// <summary>
        /// Porta l'utente al carrello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCarrello_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Carrello-Prodotti.aspx';", true);
        }
        /// <summary>
        /// Controllo se i dati sono corretti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Default.aspx';", true);
        }
        /// <summary>
        /// Cancella la foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            ///Cancello immagine dal FTP
            if (!string.IsNullOrEmpty(UtenteLoggato.ImgFriend) && !UtenteLoggato.ImgFriend.Contains("no-image.jpg"))
                base.FTPDelete("/ImmaginiPerbaffo/Utenti/" + UtenteLoggato.ImgFriend);
            base.UtenteLoggato.ImgFriend = "no-image.jpg";
            base.UtenteLoggato.NomeFriend = string.Empty;
            this.lblNomeFriend.InnerText = string.Empty;
            ///Salvo sul db le modifiche
            base.AddUtenteRegistrazione(base.PerbaffoController.UpdateImmagineUtente(UtenteLoggato));
            this.imgFriend.ImageUrl = "images/no-image.jpg";
            this.imgFriend.AlternateText = string.Empty;
            this.btnElimina.Visible = false;
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Popolo le 4 combo
        /// </summary>
        private void LoadFieds()
        {
            if (string.IsNullOrEmpty(base.UtenteLoggato.ImgFriend) || base.UtenteLoggato.ImgFriend.Contains("no-image.jpg"))
                this.btnElimina.Visible = false;
            else
                this.btnElimina.Visible = true;
            if (base.Carrello == null)
                this.btnCarrello.Visible = true;
            this.imgFriend.ImageUrl = (string.IsNullOrEmpty(base.UtenteLoggato.ImgFriend)) ? "images/no-image.jpg" : base.UrlServerImagesUtenti + base.UtenteLoggato.ImgFriend;
            this.imgFriend.ToolTip = (string.IsNullOrEmpty(base.UtenteLoggato.ImgFriend)) ? "Nessuna foto" : base.UtenteLoggato.NomeFriend;
            this.lblNomeFriend.InnerText = base.UtenteLoggato.NomeFriend;
            this.updPnlPreviewFoto.Update();
            this.Load.Attributes.Add("src", "CaricaImmagineUtente.aspx");
        }
        /// <summary>
        /// Aggiorna i meta tag del sito
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Inserisci la foto del tuo amico";
            KeywordsPagina = "Pet shop,Registrazione,foto,amico,Login,animaletto,utente,cani,gatti,volatili,roditori,pesci";
            DescrizionePagina = "Inserisci la foto del tuo animaletto";
        }
        #endregion

    }
}
