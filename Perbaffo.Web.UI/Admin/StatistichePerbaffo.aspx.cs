using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Text;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class StatistichePerbaffo : BasePage
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
            this.rptUtenti.DataSource = base.PerbaffoController.GetStatisticTopBuyer(10);
            this.rptUtenti.DataBind();
            this.rptOmaggi.DataSource = base.PerbaffoController.GetStatisticTopOmaggi(10);
            this.rptOmaggi.DataBind();
            this.rptProdotti.DataSource = base.PerbaffoController.GetStatisticTopProdotti(10);
            this.rptProdotti.DataBind();
            this.rptProvince.DataSource = base.PerbaffoController.GetStatisticAcquistiProvince(10); ;
            this.rptProvince.DataBind();

            //
            List<UtentiStatistiche> utenti = base.PerbaffoController.GetUtentiCompleanno(DateTime.Now);
            if (utenti == null || utenti.Count <= 0)
                this.lblCompleanno.Text = "Nessun utente fà il compleanno oggi";
            else
            {
                StringBuilder _strBuilder = new StringBuilder();
                utenti.ForEach(ut =>
                    {
                        _strBuilder.Append(ut.DataNascita.ToShortDateString() + "   " + ut.Nome + " " + ut.Cognome + "   -   " + ut.EMail + "<br/>");
                    });
                this.lblCompleanno.Text = _strBuilder.ToString();
            }
            

        }

        #endregion

    }
}
