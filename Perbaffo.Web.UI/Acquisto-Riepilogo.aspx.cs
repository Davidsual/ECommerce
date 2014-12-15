 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Text;
using Perbaffo.Presenter;
using System.Web.UI.HtmlControls;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class Acquisto_Riepilogo : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        /// <summary>
        /// Applicabile solo su minimo ordine (senza sconti utente o codici promozioni) 35 euro!!!!!!
        /// </summary>
        private const decimal TOTALE_SCONTO_SPEDIZIONE = (decimal)5.10;
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE PROPERTY
        private bool CurrentOrdineSalvato
        {
            get 
            {
                if (ViewState["CurrentOrdineSalvato"] == null)
                    return false;
                else
                    return (bool)ViewState["CurrentOrdineSalvato"]; 
            }
            set { ViewState["CurrentOrdineSalvato"] = value; }
        }
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
            if (base.Carrello == null || base.Carrello.Prodotti == null || base.Carrello.Prodotti.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Carrello-Prodotti.aspx';", true);
                return;
            }
            if (base.CurrentOrdine == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Indirizzo_Spedizione.aspx';", true);
                return;
            }
            if (base.CurrentOrdine.DettagliOrdini == null || base.CurrentOrdine.DettagliOrdini.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Pagamenti.aspx';", true);
                return;
            }
            if (!Page.IsPostBack)
            {
                this.CurrentOrdineSalvato = false;
                this.LoadField();
                this.LoadCarrello();
                this.LoadOmaggio();
                this.GestioneMetaTag();
            }
        }
        /// <summary>
        /// Continua alla sezione successiva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            ///Manda al pagamento
            try
            {
                ///Salva l'ordine solo una volta.. contro il refresh
                if (this.CurrentOrdineSalvato)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto.aspx';", true);
                    return;
                }               
                Ordini _result = base.PerbaffoController.SetOrdine(base.CurrentOrdine, base.Carrello, base.UtenteLoggato);
                if (_result != null)
                {
                    this.CurrentOrdineSalvato = true;
                    ///Aggiorna ordine salvato
                    base.AggiornaOrdine(_result);
                    if (!string.IsNullOrEmpty(base.CurrentCodiceAffiliazione))
                        base.PerbaffoController.SetAffiliazione(base.CurrentCodiceAffiliazione, _result.ID);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto.aspx';", true);
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "all","alert('Errore durante il salvataggio dell\\'Ordine');", true);
            }
        }
        /// <summary>
        /// Eventi sul carrello
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptCarrello_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
        }
        /// <summary>
        /// Eventi durante la creazione del carrello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptCarrello_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null)
                {
                    HtmlGenericControl _divTaglia = e.Item.FindControl("divTaglia") as HtmlGenericControl;
                    HtmlGenericControl _labelTaglia = e.Item.FindControl("lblTaglia") as HtmlGenericControl;
                    HtmlGenericControl _divColore = e.Item.FindControl("divColore") as HtmlGenericControl;
                    HtmlGenericControl _labelColore = e.Item.FindControl("lblColore") as HtmlGenericControl;
                    HtmlGenericControl _totaleCalcolato = e.Item.FindControl("lblTotaleCalcolato") as HtmlGenericControl;

                    HtmlGenericControl _divPrezzoOffertaParziale = e.Item.FindControl("divPrezzoParzialeOfferta") as HtmlGenericControl;
                    HtmlGenericControl _divPrezzoParziale = e.Item.FindControl("divPrezzoParziale") as HtmlGenericControl;

                    HtmlGenericControl _lblPrezzoDaScontare = e.Item.FindControl("lblPrezzoProdottoDaScontare") as HtmlGenericControl;
                    HtmlGenericControl _lblPrezzoScontato = e.Item.FindControl("lblPrezzoProdottoScontato") as HtmlGenericControl;
                    HtmlGenericControl _lblPrezzoParziale = e.Item.FindControl("lblPrezzoProdotto") as HtmlGenericControl;

                    #region taglia
                    if (((CarrelloItem)e.Item.DataItem).Taglia != null)
                    {
                        if (_divTaglia != null)
                        {
                            _divTaglia.Visible = true;
                            if (_labelTaglia != null)
                                _labelTaglia.InnerText = ((CarrelloItem)e.Item.DataItem).Taglia.DescrTaglia;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(((CarrelloItem)e.Item.DataItem).Prodotto.DescrTaglia))
                        {
                            if (_divTaglia != null)
                            {
                                _divTaglia.Visible = true;
                                if (_labelTaglia != null)
                                    _labelTaglia.InnerText = ((CarrelloItem)e.Item.DataItem).Prodotto.DescrTaglia;
                            }
                        }
                    }
                    #endregion

                    #region colore
                    if (((CarrelloItem)e.Item.DataItem).Colore != null)
                    {
                        if (_divColore != null)
                        {
                            _divColore.Visible = true;
                            if (_labelColore != null)
                                _labelColore.InnerText = ((CarrelloItem)e.Item.DataItem).Colore.Descrizione;
                        }
                    }
                    #endregion

                    #region prezzo parziale
                    if (((CarrelloItem)e.Item.DataItem).Taglia != null)
                    {
                        if (((CarrelloItem)e.Item.DataItem).Taglia.Prezzo == ((CarrelloItem)e.Item.DataItem).Taglia.Totale)
                        {
                            //normale
                            if (_lblPrezzoParziale != null)
                                _lblPrezzoParziale.InnerText = ((CarrelloItem)e.Item.DataItem).Taglia.Totale.ToString();
                        }
                        else
                        {
                            ///in offerta
                            if (_divPrezzoOffertaParziale != null && _divPrezzoParziale != null)
                            {
                                _divPrezzoOffertaParziale.Visible = true;
                                _divPrezzoParziale.Visible = false;
                                if (_lblPrezzoDaScontare != null && _lblPrezzoScontato != null)
                                {
                                    _lblPrezzoDaScontare.InnerText = ((CarrelloItem)e.Item.DataItem).Taglia.Prezzo.ToString();
                                    _lblPrezzoScontato.InnerText = ((CarrelloItem)e.Item.DataItem).Taglia.Totale.ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (((CarrelloItem)e.Item.DataItem).Prodotto.Prezzo == ((CarrelloItem)e.Item.DataItem).Prodotto.Totale)
                        {
                            //normale
                            if (_lblPrezzoParziale != null)
                                _lblPrezzoParziale.InnerText = ((CarrelloItem)e.Item.DataItem).Prodotto.Totale.ToString();
                        }
                        else
                        {
                            ///in offerta
                            if (_divPrezzoOffertaParziale != null && _divPrezzoParziale != null)
                            {
                                _divPrezzoOffertaParziale.Visible = true;
                                _divPrezzoParziale.Visible = false;
                                if (_lblPrezzoDaScontare != null && _lblPrezzoScontato != null)
                                {
                                    _lblPrezzoDaScontare.InnerText = ((CarrelloItem)e.Item.DataItem).Prodotto.Prezzo.ToString();
                                    _lblPrezzoScontato.InnerText = ((CarrelloItem)e.Item.DataItem).Prodotto.Totale.ToString();
                                }
                            }
                        }
                    }
                    #endregion

                    ///Aggiungo il totale calcolato per la quantita
                    if (_totaleCalcolato != null)
                    {
                        _totaleCalcolato.InnerText = ((CarrelloItem)e.Item.DataItem).Totale.ToString();
                    }
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica un omaggio
        /// </summary>
        private void LoadOmaggio()
        {
            ProdottoImmagine _prod = base.PerbaffoController.GetProdottoByIDProdotto(base.CurrentOrdine.IDProdottoOmaggio);
            if (_prod != null)
            {
                this.imgOmaggio.Src = UrlImmagine + _prod.UrlImmagine;
                this.imgOmaggio.Alt = _prod.Nome;
                this.lblNomeOmaggio.InnerHtml = "<b>" + _prod.Nome + "</b>";
                this.lblDescrizioneOmaggio.InnerText = (_prod.DescrizioneLunga.Length > 200) ? _prod.DescrizioneLunga.Substring(0, 190) + "..." : _prod.DescrizioneLunga;
            }
        }
        /// <summary>
        /// Carica i campi con i dettagli del carrello
        /// </summary>
        private void LoadField()
        {
            StringBuilder _strBuilder = new StringBuilder();
            _strBuilder.Append(base.Capitalize(base.CurrentOrdine.Nome) + " " + base.Capitalize(base.CurrentOrdine.Cognome) + "<br/>");
            _strBuilder.Append(base.Capitalize(base.CurrentOrdine.Indirizzo) + " - " + base.CurrentOrdine.NumeroCivico + "<br/>");
            _strBuilder.Append(base.CurrentOrdine.CAP + "<br/>");
            _strBuilder.Append(base.Capitalize(base.CurrentOrdine.Citta) + " (" + base.CurrentOrdine.Provincia + ")<br/>");
            _strBuilder.Append("ITALIA<br/>");
            _strBuilder.Append(base.CurrentOrdine.Telefono + "<br/>");
            _strBuilder.Append(base.CurrentOrdine.EMail + "<br/>");
            _strBuilder.Append(base.Capitalize(base.CurrentOrdine.Note));
            this.lblRiepilogo.InnerHtml = _strBuilder.ToString();
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Acquisto, riepilogo e conferma ordine";
            this.DescrizionePagina = "Perbaffo riepilogo e conferma del tuo ordine";
            this.KeywordsPagina = "Perbaffo,acquisto,omaggio,prodotti,pagamento,spedizione,sconto,codice sconto,sconto Perbaffo,riepilogo,conferma,ordine";
        }
        /// <summary>
        /// Carica tutto il carrello
        /// </summary>
        private void LoadCarrello()
        {
            decimal _totaleProdotti = new decimal(0.00);
            decimal _totaleParzSconto = new decimal(0.00);

            if (base.Carrello != null && base.Carrello.Prodotti != null)
                this.rptCarrello.DataSource = base.GetCarrelloProdotti();
            else
                this.rptCarrello.DataSource = null;
            this.rptCarrello.DataBind();

            _totaleProdotti = base.GetTotaleProdotti();
            this.lblTotaleParziale.InnerText = _totaleProdotti.ToString();
            ///Aggiungo
            #region codice sconto
            if (!string.IsNullOrEmpty(this.Carrello.CodiceSconto) && this.Carrello.IDCodicePromozione > 0)
            {
                CodicePromozioni _promoz = base.PerbaffoController.GetCodicePromozioneAttivoByCodice(this.Carrello.CodiceSconto);
                if (_promoz != null)
                {
                    if (this.Carrello.TotaleCarrello > _promoz.MinimoOrdine)
                    {
                        this.Carrello.IDCodicePromozione = _promoz.ID;
                        this.Carrello.CodiceSconto = _promoz.CodiceSconto;
                        this.lblCodiceSconto.InnerText = this.Carrello.CodiceSconto.ToUpper();
                        if (_promoz.ScontoEuro.HasValue && _promoz.ScontoEuro.Value > 0)
                        {
                            this.lblTotaleCodiceSconto.InnerHtml = "<font style='color:Red;'>-&nbsp;<b>€</b>&nbsp;" + _promoz.ScontoEuro.Value.ToString() + "</font>";
                            this.Carrello.TotaleCodiceScontoEuro = _promoz.ScontoEuro.Value;
                            this.Carrello.TotaleCodiceScontoPerc = 0;
                        }
                        else
                        {
                            _totaleParzSconto = Math.Round(_totaleProdotti * _promoz.ScontoPercent.Value / 100, 2);
                            this.lblTotaleCodiceSconto.InnerHtml = "<font style='color:Red;'>-&nbsp;" + _promoz.ScontoPercent.Value.ToString() + "<b>%</b>&nbsp;(€&nbsp;" + _totaleParzSconto.ToString() + ")</font>";
                            this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                            this.Carrello.TotaleCodiceScontoPerc = _promoz.ScontoPercent.Value;
                        }
                    }
                    else
                    {
                        this.Carrello.IDCodicePromozione = 0;
                        this.Carrello.CodiceSconto = string.Empty;
                        this.Carrello.TotaleCodiceScontoPerc = 0;
                        this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                        this.lblCodiceSconto.InnerText = string.Empty;
                        this.lblTotaleCodiceSconto.InnerHtml = "<b>€</b>&nbsp;0,00";
                    }
                }
                else
                {
                    this.Carrello.IDCodicePromozione = 0;
                    this.Carrello.CodiceSconto = string.Empty;
                    this.Carrello.TotaleCodiceScontoPerc = 0;
                    this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                    this.lblCodiceSconto.InnerText = string.Empty;
                    this.lblTotaleCodiceSconto.InnerHtml = "<b>€</b>&nbsp;0,00";
                }
            }
            else
            {
                this.Carrello.IDCodicePromozione = 0;
                this.Carrello.CodiceSconto = string.Empty;
                this.Carrello.TotaleCodiceScontoPerc = 0;
                this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                this.lblCodiceSconto.InnerText = string.Empty;
                this.lblTotaleCodiceSconto.InnerHtml = "<b>€</b>&nbsp;0,00";
            }
            #endregion

            #region sconto utente
            if (this.Carrello.IDUtentePromozione > 0)
            {
                UtentiPromozioni _prom = base.PerbaffoController.GetUtentePromozioneAttivoByIDUtente(this.UtenteLoggato.ID);
                if (_prom != null)
                {
                    ///Calcolo sul minimo d'ordine
                    if (this.Carrello.TotaleCarrello > _prom.MinimoOrdine)
                    {
                        this.tblScontoPerbaffo.Visible = true;
                        this.lblScontoPerbaffo.InnerText = _prom.DescrPromozione;
                        this.Carrello.IDUtentePromozione = _prom.ID;
                        this.lblScontoPerbaffo.InnerText = _prom.DescrPromozione;
                        if (_prom.ScontoEuro.HasValue && _prom.ScontoEuro.Value > 0)
                        {
                            this.lblTotaleScontoPerbaffo.InnerHtml = "<font style='color:Red;'>-&nbsp;<b>€</b>&nbsp;" + _prom.ScontoEuro.Value.ToString() +"</font>";
                            this.Carrello.TotaleUtenteScontoEuro = _prom.ScontoEuro.Value;
                            this.Carrello.TotaleUtenteScontoPerc = 0;
                        }
                        else
                        {
                            if (_totaleParzSconto > 0)
                                _totaleParzSconto = Math.Round((_totaleProdotti - _totaleParzSconto) * _prom.ScontoPercent.Value / 100,2);
                            else
                                _totaleParzSconto = Math.Round(_totaleProdotti * _prom.ScontoPercent.Value / 100,2);
                            this.lblTotaleScontoPerbaffo.InnerHtml = "<font style='color:Red;'>-&nbsp;" + _prom.ScontoPercent.Value.ToString() + "<b>%</b>&nbsp;(€&nbsp;" + _totaleParzSconto.ToString() + ")</font>";
                            this.Carrello.TotaleUtenteScontoEuro = new decimal(0.00);
                            this.Carrello.TotaleUtenteScontoPerc = _prom.ScontoPercent.Value;
                        }
                        this.Carrello.IDUtentePromozione = _prom.ID;
                    }
                    else
                    {
                        this.tblScontoPerbaffo.Visible = false;
                        this.lblScontoPerbaffo.InnerText = string.Empty;
                        this.lblTotaleScontoPerbaffo.InnerText = string.Empty;

                        this.Carrello.IDUtentePromozione = 0;
                        this.Carrello.TotaleUtenteScontoEuro = new decimal(0.00);
                        this.Carrello.TotaleUtenteScontoPerc = 0;
                    }
                }
                else
                {
                    this.tblScontoPerbaffo.Visible = false;
                    this.lblScontoPerbaffo.InnerText = string.Empty;
                    this.lblTotaleScontoPerbaffo.InnerText = string.Empty;

                    this.Carrello.IDUtentePromozione = 0;
                    this.Carrello.TotaleUtenteScontoEuro = new decimal(0.00);
                    this.Carrello.TotaleUtenteScontoPerc = 0;
                }
            }
            else
            {
                this.tblScontoPerbaffo.Visible = false;
                this.lblScontoPerbaffo.InnerText = string.Empty;
                this.lblTotaleScontoPerbaffo.InnerText = string.Empty;

                this.Carrello.IDUtentePromozione = 0;
                this.Carrello.TotaleUtenteScontoEuro = new decimal(0.00);
                this.Carrello.TotaleUtenteScontoPerc = 0;
            }
            #endregion
            ///Diverso da spedizione a mano presso il magazzino
            if (base.IsScontoSpedizione() && base.CurrentOrdine.IDTipoSpedizione != 4)
            {
                ///Aggiungo il codice spedizione
                base.Carrello.TotaleScontoSpedizione = TOTALE_SCONTO_SPEDIZIONE;
                this.tblScontoSpedizione.Visible = true;
                this.lblScontoSpedizione.InnerHtml = "<font style='color:Red;'>-&nbsp;<b>€</b>&nbsp;" + TOTALE_SCONTO_SPEDIZIONE.ToString() + "0" + "</font>";
                this.lblTotaleCarrello.InnerText = (base.CurrentOrdine.TotaleOrdine - TOTALE_SCONTO_SPEDIZIONE).ToString();
            }
            else
            {
                base.Carrello.TotaleScontoSpedizione = new decimal(0.00);
                this.tblScontoSpedizione.Visible = false;
                this.lblScontoSpedizione.InnerHtml = string.Empty;
                this.lblTotaleCarrello.InnerText = base.CurrentOrdine.TotaleOrdine.ToString();
            }

            ///Imposto il totale del carrello
            
            TipoPagamento _pagamento = base.PerbaffoController.GetTipoPagamentoByIDPagamento(base.CurrentOrdine.IDTipoPagamento);
            TipoSpedizioni _spedizioni = base.PerbaffoController.GetTipoSpedizioneByIDSpedizione(base.CurrentOrdine.IDTipoSpedizione);
            if (_pagamento != null && _spedizioni != null)
            {
                this.lblDescTipoSpedizione.InnerText = _spedizioni.DescrBreveSpedizione;
                this.lblDescrTipoPagamento.InnerText = _pagamento.DescrizionePagamento;
                this.lblPrezzoPagamento.InnerText = "€ "+_pagamento.Costo.ToString();
                this.lblPrezzoSpedizione.InnerText = "€ " + _spedizioni.CostoSpedizione.ToString();
            }
        }
        #endregion

    }
}
