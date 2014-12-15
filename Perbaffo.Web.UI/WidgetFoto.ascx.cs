using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class WidgetFoto : BaseUserControl
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
                if (base.UtenteLoggato != null)
                {
                    if (!string.IsNullOrEmpty(base.UtenteLoggato.ImgFriend))
                    {
                        this.imgFriend.Src = base.UrlServerImagesUtenti + base.UtenteLoggato.ImgFriend;
                        this.imgFriend.Alt = base.UtenteLoggato.NomeFriend;
                    }
                    this.Visible = true;
                }
            }
        } 
        #endregion
    }
}