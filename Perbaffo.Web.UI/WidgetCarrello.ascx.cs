using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class WidgetCarrello : BaseUserControl
    {
        #region EVENTS
        /// <summary>
        /// Caricamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.lblNumeroProdotti.Text = base.GetNumeroElementiCarrello().ToString();
            }
        }
        /// <summary>
        /// Selezione del bottone di visualizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVisualizzaProdotti_Click(object sender, EventArgs e)
        {
            Server.Transfer("Carrello-Prodotti.aspx");
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Aggiorna il valore dei prodotti nel carrello
        /// </summary>
        public void AggiornaProdottiCarrello()
        {
            this.lblNumeroProdotti.Text = base.GetNumeroElementiCarrello().ToString();
            this.updPnlCarrello.Update();
        }
        #endregion
    }
}