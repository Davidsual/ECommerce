using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Web.UI.HtmlControls;
using Perbaffo.Presenter.Model;
using System.Collections;

namespace Perbaffo.Web.UI
{
    public partial class Dettaglio_Ordini_Effettuati : BasePage, IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento PAgina
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
        /// Creazione della riga dell repeater ordini attivi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptOrdiniAttivi_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl _lblDescrizione = e.Item.FindControl("lblDescrizione") as HtmlGenericControl;
                HtmlGenericControl _lblPagamento = e.Item.FindControl("lblPagamento") as HtmlGenericControl;
                HtmlGenericControl _lblStato = e.Item.FindControl("lblStato") as HtmlGenericControl;

                if (_lblDescrizione != null && _lblPagamento != null && _lblStato != null)
                {
                    if (e.Item.DataItem != null)
                    {
                        _lblDescrizione.InnerText = "Ordine effettuato il " + ((OrdiniDettagliato)e.Item.DataItem).DataOrdine.ToShortDateString();
                        _lblPagamento.InnerText = ((OrdiniDettagliato)e.Item.DataItem).DescrizionePagamento;
                        _lblStato.InnerText = ((OrdiniDettagliato)e.Item.DataItem).DescrStatoOrdine; 
                    }
                }
            }
        }
        /// <summary>
        /// Selezione sulla griglia degli ordini attivi per vedere i dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptOrdiniAttivi_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int _result = 0;
                if(int.TryParse(e.CommandArgument.ToString(),out _result))
                    this.LoadDettaglioOrdine(_result);
                HtmlGenericControl _lblDescrizione = e.Item.FindControl("lblDescrizione") as HtmlGenericControl;
                if(_lblDescrizione != null)
                    this.lblDescrDettaglio.InnerText = "Codice Ordine: " + _result.ToString() + " " + _lblDescrizione.InnerText.Replace("Ordine","");
            }
        }
        /// <summary>
        /// Selezione sulla griglia degli ordini attivi per vedere i dettagli
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptOrdiniStorico_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                if (e.CommandArgument != null)
                {
                    int _result = 0;
                    if(int.TryParse(e.CommandArgument.ToString(),out _result))
                        this.LoadDettaglioOrdine(_result);
                    HtmlGenericControl _lblDescrizione = e.Item.FindControl("lblDescrizioneStorico") as HtmlGenericControl;
                    if(_lblDescrizione != null)
                        this.lblDescrDettaglio.InnerText = "Codice Ordine: " + _result.ToString() + " " + _lblDescrizione.InnerText.Replace("Ordine", "");
                }
            }
        }
        /// <summary>
        /// Caricamento Griglia Storico Ordini
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptOrdiniStorico_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl _lblDescrizione = e.Item.FindControl("lblDescrizioneStorico") as HtmlGenericControl;
                HtmlGenericControl _lblPagamento = e.Item.FindControl("lblPagamentoStorico") as HtmlGenericControl;
                HtmlGenericControl _lblStato = e.Item.FindControl("lblStatoStorico") as HtmlGenericControl;

                if (_lblDescrizione != null && _lblPagamento != null && _lblStato != null)
                {
                    if (e.Item.DataItem != null)
                    {
                        _lblDescrizione.InnerText = "Ordine effettuato il " + ((OrdiniDettagliato)e.Item.DataItem).DataOrdine.ToShortDateString();
                        _lblPagamento.InnerText = ((OrdiniDettagliato)e.Item.DataItem).DescrizionePagamento;
                        _lblStato.InnerText = ((OrdiniDettagliato)e.Item.DataItem).DescrStatoOrdine;
                    }
                }
            }
        }
        /// <summary>
        /// Carica il dettaglio del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptDettaglio_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl _lblDescrizione = e.Item.FindControl("lblDescrizioneDettaglio") as HtmlGenericControl;
                if (_lblDescrizione != null)
                {
                    if (e.Item.DataItem != null)
                    {
                        Prodotti _prod = base.PerbaffoController.GetProdottoLightByIDProdotto(((DettagliOrdini)e.Item.DataItem).IDProdotto);
                        if (_prod.Attivo)
                        {
                            int _idTaglia = (((DettagliOrdini)e.Item.DataItem).IDTaglia.HasValue) ? ((DettagliOrdini)e.Item.DataItem).IDTaglia.Value : -1;
                            if (_idTaglia == -1)
                                _lblDescrizione.InnerHtml = "<a href='Dettaglio-Prodotto.aspx?Prodotto=" + _prod.ID.ToString() + "' title='" + _prod.Nome + "'>" + _prod.Nome + "</a>";
                            else
                                _lblDescrizione.InnerHtml = "<a href='Dettaglio-Prodotto.aspx?Prodotto=" + _prod.ID.ToString() + "&amp;Taglia=" + _idTaglia.ToString() + "' title='" + _prod.Nome + "'>" + _prod.Nome + " (Taglia differente)</a>";
                        }
                        else
                            _lblDescrizione.InnerHtml = _prod.Nome;
                    }
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento dei campi
        /// </summary>
        private void LoadFields()
        {
            ///Carico Ordini Attivi
            this.rptOrdiniAttivi.DataSource = base.PerbaffoController.GetOrdiniAttiviByIDUtente(base.UtenteLoggato.ID);
            this.rptOrdiniAttivi.DataBind();
            if (this.rptOrdiniAttivi.DataSource != null && ((IList)this.rptOrdiniAttivi.DataSource).Count > 0)
                this.divOrdiniAttivi.Visible = true;
            ///Carico Ordini Storico
            this.rptOrdiniStorico.DataSource = base.PerbaffoController.GetOrdiniStoricoByIDUtente(base.UtenteLoggato.ID);
            this.rptOrdiniStorico.DataBind();
            if (this.rptOrdiniStorico.DataSource != null && ((IList)this.rptOrdiniStorico.DataSource).Count > 0)
                this.divOrdiniStorico.Visible = true;
            else
                this.divOrdiniStorico.Visible = false;
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Perbaffo - Riepilogo ordini effettuati";
            this.DescrizionePagina = "Perbaffo il riepilogo di tutti gli ordini effettuati";
            this.KeywordsPagina = "Perbaffo,Riepilogo,ordini,effettuati,prodotti,categoria,effettuati,stato ordine,dettaglio,ordine";
        }
        /// <summary>
        /// Carica il dettaglio dell'ordine
        /// </summary>
        /// <param name="IDOrdine"></param>
        private void LoadDettaglioOrdine(int IDOrdine)
        {
            this.rptDettaglio.DataSource = base.PerbaffoController.GetDettagliOrdiniByIDOrdine(IDOrdine);
            this.rptDettaglio.DataBind();
        }
        #endregion


    }
}
