using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Web.UI.HtmlControls;

namespace Perbaffo.Web.UI
{
    public partial class Controlla_Spedizione : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        #endregion

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
        /// Carica pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.UtenteLoggato == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Login-Utente.aspx';", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                this.LoadFields();
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Carica i campi
        /// </summary>
        private void LoadFields()
        {
            this.rptOrdiniSpediti.DataSource = base.PerbaffoController.GetOrdiniSpeditiByIDUtente(base.UtenteLoggato.ID);
            this.rptOrdiniSpediti.DataBind();
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
            if (valore.Length > 200)
                return valore.Substring(0, 190) + "...";
            return valore;
        }
        /// <summary>
        /// Gestione inserimento prodotto nel carrello/dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptOfferte_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DETTAGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "self.location.href = 'Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString() + "';", true);
            }
            if (e.CommandName == "ACQUISTA" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                try
                {
                    int _result = -1;
                    if (int.TryParse(e.CommandArgument.ToString(), out _result))
                    {
                        ///Aggiungo il prodotto al carrello
                        base.AggiungiProdottoCarrello(_result, -1, -1);
                        ///Aggiorno il widget
                        this.usrCarrello.AggiornaProdottiCarrello();
                        ///Segnala all'utente che il prodotto è nel carrello
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Prodotto inserito nel carrello!');", true);
                    }
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante l\\'inseriemnto del prodotto nel carrello!');", true);
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Controlla la tua spedizione";
            this.DescrizionePagina = "Perbaffo controlla la tua spedizione selezionando il codice spedizione del tuo ordine";
            this.KeywordsPagina = "Perbaffo,Controlla,spedizione,acquisti,articoli,ordini,informazioni,codice spedizione,e-mail,bartolini,cani,gatti,roditori,volatili,acquariologia";
        }
        #endregion
        /// <summary>
        /// Gcrrea la griglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptOrdiniSpediti_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    HtmlGenericControl _lblDescrizione = e.Item.FindControl("lblDescrizioneDettaglio") as HtmlGenericControl;
                    if (_lblDescrizione != null)
                    {
                        _lblDescrizione.InnerText = "Ordine effettuato il " + ((Ordini)e.Item.DataItem).DataOrdine.ToShortDateString();
                    }
                }
            }
        }
        /// <summary>
        /// Selezione del link all'interno del form
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptOrdiniSpediti_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.CommandName) && e.CommandName == "CODICE" && e.CommandArgument != null)
            {
                string _url = "http://as777.bartolini.it/vas/sped_det_show.hsm?referer=sped_numspe_par.htm&Nspediz=" + e.CommandArgument + "&RicercaNumeroSpedizione=Ricerca";
                //string _url = "http://as777.bartolini.it/vas/sped_det_show.hsm?referer=sped_numspe_par.htm&ChiSono=" + e.CommandArgument + "&ClienteMittente=&DataInizioGiorno=01&DataInizioMese=01&DataInizioAnno=0001&DataFineGiorno=31&DataFineMese=12&DataFineAnno=9999&RicercaChiSono=Ricerca";
                this.frmBartolini.Attributes.Add("src", _url);
            }
        }
    }
}
