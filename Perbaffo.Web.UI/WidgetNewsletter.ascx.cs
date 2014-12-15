using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class WidgetNewsletter : BaseUserControl
    {
        #region EVENTS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.UtenteLoggato != null)
                this.Visible = false;
        }
        /// <summary>
        /// Invia l'utente all'iscrizione della newsletter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNewsLetter_Click(object sender, EventArgs e)
        {
            Server.Transfer("Registrazione-Newsletter.aspx");
        }
        #endregion
 

    }
}