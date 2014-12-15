using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Perbaffo.Web.UI
{
    public partial class Carrello_Prodotti : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private const string UPDATE_COMMAND = "UPD";
        private const string DELETE_COMMAND = "DEL";
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GestioneMetaTag();
                this.LoadCarrello();
            }
        }
        /// <summary>
        /// Acquista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            ///Manda l'utente al wizard per aquistare 
            if(base.UtenteLoggato == null)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Login-Utente.aspx?LOGINACQUISTA=yes';", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Acquisto-Indirizzo-Spedizione.aspx';", true);
        }
        /// <summary>
        /// Eventi sul carrello
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptCarrello_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString() == DELETE_COMMAND)
                {
                    ///Cancello il prodotto
                    CarreloItemKey _key = this.GetCarrelloKey(e.Item);
                    if (_key != null)
                        base.RimuoviProdottoCarrello(_key);
                }
                this.LoadCarrello();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Errore durante l\'aggiornamento del carrello", true);
            }
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

                    HtmlAnchor _lblLinkProdotto = e.Item.FindControl("lnkProdotto") as HtmlAnchor;

                    if (_lblLinkProdotto != null)
                    {
                        _lblLinkProdotto.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + ((CarrelloItem)e.Item.DataItem).Prodotto.ID.ToString();
                        if (((CarrelloItem)e.Item.DataItem).Taglia != null)
                            _lblLinkProdotto.HRef += "&amp;Taglia=" + ((CarrelloItem)e.Item.DataItem).Taglia.ID.ToString();
                    }

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
                    ///Aggiorno il totale del carrello
                    foreach (RepeaterItem item in this.rptCarrello.Items)
                    {
                        TextBox _quantita = item.FindControl("txtQuantita") as TextBox;

                        if (_quantita != null)
                        {
                            int _result = 0;
                            if (int.TryParse(_quantita.Text, out _result))
                            {
                                if (_result == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al11", "alert('La quantità non può essere inferiore ad 1 unità. \\nSe non desideri il prodotto nel carrello fai click sulla X rossa alla sinistra del prodotto!');", true);
                                    break;
                                }
                                base.AggiornaQuantita(this.GetCarrelloKey(item), _result);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Attenzione le quantità degli articoli vanno espresse in valore numerico!');", true);
                                break;
                            }
                        }
                    }
                    ///Aggiorna la situazione
                    this.LoadCarrello();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Errore durante l\'aggiornamento del carrello", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Carrello Prodotti";
            this.DescrizionePagina = "Perbaffo carrello dei prodotti dove si può modificare la quantità e il numero di prodotti inseriti";
            this.KeywordsPagina = "Perbaffo,carrello,prodotti,acquista,quantità,taglia,colore,articolo,cani,gatti,roditori,volatili,acquariologia";
        }
        /// <summary>
        /// Carica tutto il carrello
        /// </summary>
        private void LoadCarrello()
        {
            if (base.Carrello != null && base.Carrello.Prodotti != null)
            {
                ///Ripulisco il carrello
                this.Carrello.IDCodicePromozione = 0;
                this.Carrello.IDUtentePromozione = 0;
                this.Carrello.TotaleCodiceScontoEuro = new decimal(0.00);
                this.Carrello.TotaleCodiceScontoPerc = 0;
                this.Carrello.TotaleUtenteScontoEuro = new decimal(0.00);
                this.Carrello.TotaleUtenteScontoPerc = 0;
                this.Carrello.CodiceSconto = string.Empty;
                this.Carrello.TotaleCarrello = base.GetTotaleProdotti();

                this.btnUpdateCarrello.OnClientClick = string.Empty;
                this.rptCarrello.DataSource = base.GetCarrelloProdotti();
            }
            else
            {
                this.btnUpdateCarrello.OnClientClick = "return false;";
                this.rptCarrello.DataSource = null;
            }
            this.rptCarrello.DataBind();
            if (this.rptCarrello.DataSource == null || ((IList)this.rptCarrello.DataSource).Count <= 0)
                this.btnAcquista.OnClientClick = "alert('Per procedere con l\\'acquisto è necessario inserire almeno un prodotto');return false;";
            
            ///Imposto il totale del carrello
            this.lblTotaleCarrello.InnerText = (base.TotaleCarrello().ToString() == "0") ? "0,00" : base.TotaleCarrello().ToString();
            
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

                if(_arrayChiave == null || _arrayChiave.Length < 3)
                    return _key;

                
                int _result = -1;
                ///Compongo la chiave
                if(!int.TryParse(_arrayChiave[0],out _result))
                    return _key;
                else
                    _key.IDProdotto = _result;
                _result = -1;
                if(int.TryParse(_arrayChiave[1],out _result))
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
        #endregion

    }
}
