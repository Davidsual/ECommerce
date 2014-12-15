using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Text;

namespace Perbaffo.Web.UI.Admin
{
    public partial class GestioneNewsLetter : BasePage
    {
        #region PRIVATE MEMBERS
        #endregion

        #region PRIVATE PROPERTY
        #endregion

        #region EVENTS
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
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
                this.LoadFields();
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica i campi
        /// </summary>
        private void LoadFields()
        {
            this.lblNewsletterCani.Text = base.PerbaffoController.GetCountUtentiNewsLetterCani().ToString();
            this.lblNewsletterGatti.Text = base.PerbaffoController.GetCountUtentiNewsLetterGatti().ToString();
            this.lblNewsletterPesci.Text = base.PerbaffoController.GetCountUtentiNewsLetterPesci().ToString();
            this.lblNewsletterRoditori.Text = base.PerbaffoController.GetCountUtentiNewsLetterRoditori().ToString();
            this.lblNewsletterVoltatili.Text = base.PerbaffoController.GetCountUtentiNewsLetterVolatili().ToString();
        }

        #endregion
        /// <summary>
        /// Apre il popup che esporta i risultaiti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAction_Click(object sender, EventArgs e)
        {
            //StringBuilder _str = new StringBuilder();

            //_str.Append("javascript:window.open ('EsportaNewsletter.aspx?TIPO=" + ((Button)sender).CommandName + "','mywindow','width=500px,height=350px,top=250,left=300,location=0,directories=0,resizable=0,scrollbars=0,toolbar=0,menubar=0,status=0');");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "open", _str.ToString(), true);
            Response.Redirect("EsportaNewsletter.aspx?TIPO=" + ((Button)sender).CommandName);
        }
    }
}
