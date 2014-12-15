using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Web.UI.HtmlControls;
using Perbaffo.Presenter;
using System.Collections;
using System.Text;
using Perbaffo.Presenter.Model;
using Perbaffo.Web.UI.Admin;

namespace Perbaffo.Web.UI
{
    public partial class Acquisto_Pagamenti : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const string UPDATE_COMMAND = "UPD";
        private const string SPED_RITIRO_A_MANO = "4";
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// lista Pagamenti
        /// </summary>
        private List<TipoPagamento> CurrentPagamenti
        {
            get { return (List<TipoPagamento>)ViewState["CurrentPagamenti"]; }
            set { ViewState["CurrentPagamenti"] = value; }
        }
        /// <summary>
        /// lista Spedizioni
        /// </summary>
        private List<TipoSpedizioni> CurrentSpedizioni
        {
            get { return (List<TipoSpedizioni>)ViewState["CurrentSpedizioni"]; }
            set { ViewState["CurrentSpedizioni"] = value; }
        }
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
            if (!Page.IsPostBack)
            {
                this.GestioneMetaTag();
                this.LoadDatiDestinatario();
                this.LoadCombo();
                this.LoadCarrello();
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
        /// <summary>
        /// Aggiornamento del carrello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateCarrello_Click(object sender, ImageClickEventArgs e)
        {
            if (base.Carrello == null)
                return;
            try
            {
                if (btnUpdateCarrello.CommandName.ToString() == UPDATE_COMMAND)
                {
                    if (!string.IsNullOrEmpty(this.txtCodiceSconto.Text.Trim()))
                    {
                        base.CheckCodiceSconto(this.txtCodiceSconto.Text.Trim());
                    }
                    else
                    {
                        base.CheckCodiceSconto(string.Empty);
                    }
                    ///Aggiorna la situazione
                    this.LoadCarrello();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Errore durante l\'aggiornamento del carrello", true);
            }
        }
        /// <summary>
        /// Ritorna alla modifica dei dati del destinatario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "location.href = 'Acquisto-Indirizzo-Spedizione.aspx';", true);
        }
        /// <summary>
        /// Conferma ordine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            if (this.ddlSpedizione.SelectedIndex <= 0 || this.ddlPagamento.SelectedIndex <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aler", "alert('Selezionare il Tipo di Pagamento e il Tipo di Spedizione!');", true);
                return;
            }

            if (!string.IsNullOrEmpty(this.txtCodiceSconto.Text.Trim()))
            {
                base.CheckCodiceSconto(this.txtCodiceSconto.Text.Trim());
            }
            else
            {
                base.CheckCodiceSconto(string.Empty);
            }
            this.LoadCarrello();

            base.CurrentOrdine.IDCodicePromozione = this.Carrello.IDCodicePromozione;
            base.CurrentOrdine.IDUtentePromozione = this.Carrello.IDUtentePromozione;
            base.CurrentOrdine.CodicePromozione = this.Carrello.CodiceSconto;
            base.CurrentOrdine.TotaleScontoCodice = (this.Carrello.TotaleCodiceScontoPerc > 0) ? this.Carrello.TotaleCodiceScontoPerc : this.Carrello.TotaleCodiceScontoEuro;
            base.CurrentOrdine.TotaleScontoPerbaffo = (this.Carrello.TotaleUtenteScontoPerc > 0) ? this.Carrello.TotaleUtenteScontoPerc : this.Carrello.TotaleUtenteScontoEuro;
            base.CurrentOrdine.IDTipoPagamento = Convert.ToInt32(this.ddlPagamento.SelectedValue);
            base.CurrentOrdine.IDTipoSpedizione = Convert.ToInt32(this.ddlSpedizione.SelectedValue);
            base.CurrentOrdine.TotaleParziale = base.TotaleCarrello();///prodotti - sconti
            base.CurrentOrdine.TotaleOrdine = (base.TotaleCarrello() + this.CalcolaPagamentoSpedizione());
            ///Ripulisco in caso di ordini precedenti
            if(base.CurrentOrdine.DettagliOrdini != null)
                base.CurrentOrdine.DettagliOrdini.Clear();
            base.Carrello.Prodotti.ForEach(item =>
                {
                    base.AggiungiDettaglioOrdine(item.Prodotto.ID,(item.Colore != null)?item.Colore.ID:-1 ,(item.Taglia != null)?item.Taglia.ID:-1 , item.Quantita,item.Totale);

                });
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Omaggio.aspx';", true);
        }
        /// <summary>
        /// Selezione del pagamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSpedizione_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _result = 0;
            if (this.ddlSpedizione.SelectedIndex <= 0)
            {
                this.lblPrezzoSpedizione.InnerHtml = "<b>€</b>&nbsp;0,00";
            }
            else if (int.TryParse(this.ddlSpedizione.SelectedValue, out _result))
            {
                TipoSpedizioni _spedizione = this.CurrentSpedizioni.Where(spe => spe.ID == _result).SingleOrDefault();
                if (_spedizione != null)
                    this.lblPrezzoSpedizione.InnerHtml = "<b>€</b>&nbsp;" + _spedizione.CostoSpedizione.ToString();
            }
            decimal _sommaPagamentoSpedizione = this.CalcolaPagamentoSpedizione();
            this.lblTotaleCarrello.InnerText = (base.TotaleCarrello() + _sommaPagamentoSpedizione).ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
        }
        /// <summary>
        /// Selezione della spedizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _result = 0;
            this.tblCarte.Visible = false;
            this.lblDettaglioPagamento.InnerHtml = string.Empty;
            if (this.ddlPagamento.SelectedIndex <= 0)
            {
                this.lblPrezzoPagamento.InnerHtml = "<b>€</b>&nbsp;0,00";
            }
            else if (int.TryParse(this.ddlPagamento.SelectedValue, out _result))
            {
                TipoPagamento _pagamento = this.CurrentPagamenti.Where(pag => pag.ID == _result).SingleOrDefault();
                if (_pagamento != null)
                {
                    this.lblPrezzoPagamento.InnerHtml = "<b>€</b>&nbsp;" + _pagamento.Costo.ToString();
                    if (_pagamento.ID == PAGAMENTO_BONIFICO)
                    {
                        this.lblDettaglioPagamento.InnerHtml = string.Empty;
                    }
                    else if(_pagamento.ID == PAGAMENTO_CONTRASSEGNO)
                    {
                        this.lblDettaglioPagamento.InnerHtml = "<b>Pagamento in contanti alla consegna della merce</b>";
                    }
                    else if (_pagamento.ID == PAGAMENTO_PAYPAL)
                    {
                        this.lblDettaglioPagamento.InnerHtml = string.Empty;
                        this.tblCarte.Visible = true;
                    }
                    else if (_pagamento.ID == PAGAMENTO_POSTEPAY)
                    {
                        this.lblDettaglioPagamento.InnerHtml = "<b>Pagamento presso le Poste Italiane</b>";
                    }
                    else if (_pagamento.ID == PAGAMENTO_RITIROAMANO)
                    {
                        this.ddlSpedizione.SelectedValue = SPED_RITIRO_A_MANO;
                        this.ddlSpedizione_SelectedIndexChanged(this.ddlSpedizione, null);
                        this.lblDettaglioPagamento.InnerHtml = "<b>Solo ed esclusivamente a Pianezza(TO) e su appuntamento</b>";
                    }
                }
            }
            decimal _sommaPagamentoSpedizione = this.CalcolaPagamentoSpedizione();
            this.lblTotaleCarrello.InnerText = (base.TotaleCarrello() + _sommaPagamentoSpedizione).ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "img", "fInit();", true);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica le combo
        /// </summary>
        private void LoadCombo()
        {
            this.CurrentPagamenti = base.PerbaffoController.GetTipoPagamento();
            this.CurrentSpedizioni = base.PerbaffoController.GetTipoSpedizione();
            if (this.CurrentPagamenti != null)
            {
                this.CurrentPagamenti.ForEach(item =>
                    {
                        this.ddlPagamento.Items.Add(new ListItem(item.DescrizionePagamento + " (€ " + item.Costo.ToString() + ")", item.ID.ToString()));
                    });
            }
            this.ddlPagamento.Items.Insert(0, new ListItem("Seleziona il tipo di pagamento", ""));
            if (this.CurrentSpedizioni != null)
            {
                this.CurrentSpedizioni.ForEach(item =>
                {
                    this.ddlSpedizione.Items.Add(new ListItem(item.DescrBreveSpedizione + " (€ " + item.CostoSpedizione.ToString() + ")", item.ID.ToString()));
                });
            }
            this.ddlSpedizione.Items.Insert(0, new ListItem("Seleziona il tipo di spedizione", ""));
            this.lblPrezzoPagamento.InnerHtml = "<b>€</b>&nbsp;0,00";
            this.lblPrezzoSpedizione.InnerHtml = "<b>€</b>&nbsp;0,00";
        }   
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Acquisto, selezione pagamento,spedizione e sconti";
            this.DescrizionePagina = "Perbaffo scegli il tipo di pagamento che vuoi effettuare,il tipo di spedizione e gli eventuali sconti";
            this.KeywordsPagina = "Perbaffo,acquisto,omaggio,ordine,prodotti,pagamento,spedizione,sconto,codice sconto,sconto Perbaffo";
        }
        /// <summary>
        /// Carica tutto il carrello
        /// </summary>
        private void LoadCarrello()
        {
            this.divDescrCodice.Visible = false;
            this.lblDescrCodSconto.InnerHtml = string.Empty;
            decimal _totaleProdotti = new decimal(0.00);
            decimal _totaleParzSconto = new decimal(0.00);
            if (base.Carrello != null && base.Carrello.Prodotti != null)
                this.rptCarrello.DataSource = base.GetCarrelloProdotti();
            else
                this.rptCarrello.DataSource = null;
            this.rptCarrello.DataBind();
            _totaleProdotti = base.GetTotaleProdotti();
            this.lblTotaleParziale.InnerText = _totaleProdotti.ToString();
            ///Imposto sconto del carrello
            if (this.Carrello != null)
            {
                //1) Controllo se c'è il codice nel carrello..
                //2) Controllo se l'utente ha diritto allo sconto)
                #region codice sconto
                if (!string.IsNullOrEmpty(this.Carrello.CodiceSconto))
                {
                    CodicePromozioni _promoz = base.PerbaffoController.GetCodicePromozioneAttivoByCodice(this.Carrello.CodiceSconto);
                    if (_promoz != null)
                    {
                        if (this.Carrello.TotaleCarrello > _promoz.MinimoOrdine)
                        {
                            this.Carrello.IDCodicePromozione = _promoz.ID;
                            this.Carrello.CodiceSconto = _promoz.CodiceSconto;
                            this.txtCodiceSconto.Text = this.Carrello.CodiceSconto;
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
                            if (!string.IsNullOrEmpty(_promoz.DescrPromozione))
                            {
                                this.divDescrCodice.Visible = true;
                                this.lblDescrCodSconto.InnerHtml = "<strong>" + _promoz.DescrPromozione + "</strong>";
                            }
                        }
                        else
                        {
                            this.Carrello.IDCodicePromozione = 0;
                            this.Carrello.CodiceSconto = string.Empty;
                            this.Carrello.TotaleCodiceScontoPerc = 0;
                            this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                            this.txtCodiceSconto.Text = string.Empty;
                            this.lblTotaleCodiceSconto.InnerHtml = "<b>€</b>&nbsp;0,00";
                        }
                    }
                    else
                    {
                        this.Carrello.IDCodicePromozione = 0;
                        this.Carrello.CodiceSconto = string.Empty;
                        this.Carrello.TotaleCodiceScontoPerc = 0;
                        this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                        this.txtCodiceSconto.Text = string.Empty;
                        this.lblTotaleCodiceSconto.InnerHtml = "<b>€</b>&nbsp;0,00";
                    } 
                }
                else
                {
                    this.Carrello.IDCodicePromozione = 0;
                    this.Carrello.CodiceSconto = string.Empty;
                    this.Carrello.TotaleCodiceScontoPerc = 0;
                    this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                    this.txtCodiceSconto.Text = string.Empty;                   
                    this.lblTotaleCodiceSconto.InnerHtml = "<b>€</b>&nbsp;0,00";
                }
                #endregion

                #region sconto utente
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
                            this.lblTotaleScontoPerbaffo.InnerHtml = "<font style='color:Red;'>-&nbsp;<b>€</b>&nbsp;" + _prom.ScontoEuro.Value.ToString() + "</font>";
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
                #endregion
            }
            base.CalcolaTotaleCarrello();
            ///Imposto il totale del carrello
            decimal _sommaPagamentoSpedizione = this.CalcolaPagamentoSpedizione();
            this.lblTotaleCarrello.InnerText = (base.TotaleCarrello() + _sommaPagamentoSpedizione).ToString();

        }
        /// <summary>
        /// Restituisce la chiave composta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private CarreloItemKey GetCarrelloKey(RepeaterItem item)
        {
            CarreloItemKey _key = new CarreloItemKey();
            if (item == null)
                return _key;
            try
            {
                HiddenField _chiave = item.Controls[0] as HiddenField;
                if (_chiave == null || !_chiave.Value.Contains('$'))
                    return _key;

                string[] _arrayChiave = _chiave.Value.Split('$');

                if (_arrayChiave == null || _arrayChiave.Length < 3)
                    return _key;


                int _result = -1;
                ///Compongo la chiave
                if (!int.TryParse(_arrayChiave[0], out _result))
                    return _key;
                else
                    _key.IDProdotto = _result;
                _result = -1;
                if (int.TryParse(_arrayChiave[1], out _result))
                    _key.IDColore = _result;
                else
                    _key.IDColore = _result;
                _result = -1;
                if (int.TryParse(_arrayChiave[2], out _result))
                    _key.IDTaglia = _result;
                else
                    _key.IDTaglia = _result;

                return _key;
            }
            catch
            {
                return _key;
            }
        }
        /// <summary>
        /// Carica i dati del destinatario
        /// </summary>
        private void LoadDatiDestinatario()
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
        /// Calcola pagamento /spedizione
        /// </summary>
        /// <returns></returns>
        private decimal CalcolaPagamentoSpedizione()
        {
            decimal _costoPaga = new decimal(0.00);
            decimal _costoSped = new decimal(0.00);
            int _result = 0;
            if (this.ddlPagamento.SelectedIndex > 0)
            {
                if (int.TryParse(this.ddlPagamento.SelectedValue, out _result))
                {
                    TipoPagamento _pagamento = this.CurrentPagamenti.Where(pag => pag.ID == _result).SingleOrDefault();
                    if (_pagamento != null)
                        _costoPaga = _pagamento.Costo;
                }
            }
            if (this.ddlSpedizione.SelectedIndex > 0)
            {
                if (int.TryParse(this.ddlSpedizione.SelectedValue, out _result))
                {
                    TipoSpedizioni _spedizione = this.CurrentSpedizioni.Where(spe => spe.ID == _result).SingleOrDefault();
                    if (_spedizione != null)
                        _costoSped = _spedizione.CostoSpedizione;
                }
            }
            return _costoPaga + _costoSped;
        }
        #endregion
    }
}
