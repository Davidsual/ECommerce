using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Acquisto : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private int CurrentIDOrdine
        {
            get
            {
                return (int)ViewState["CurrentIDOrdine"];
            }
            set { ViewState["CurrentIDOrdine"] = value; }
        }
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
                this.CurrentIDOrdine = base.CurrentOrdine.ID;
                ///Invio una mail all'utente con il riepilogo ordine
                base.PerbaffoController.InvioMailOrdineEffettuato(base.CurrentOrdine, base.Carrello, base.UtenteLoggato);
                this.LoadField();
                base.OrdineConcluso();
                this.GestioneMetaTag();
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica i campi con i dettagli del carrello
        /// </summary>
        private void LoadField()
        {
            if (base.CurrentOrdine.IDTipoPagamento == PAGAMENTO_BONIFICO)
            {
                this.lblTipoPagamento.InnerText = "HAI SCELTO IL PAGAMENTO TRAMITE BONIFICO";
                this.lblDatiPagamento.InnerHtml = "<br/><b>Conto corrente intestato a: </b>PERBAFFO DI ALBANESI SILVIA</br/><b>Codice IBAN: </b>IT38V0200801108000041230254 <br/><b>Causale Bonifico: </b>Ordine numero " + base.CurrentOrdine.ID.ToString() + "<br/>";
            }
            else if(base.CurrentOrdine.IDTipoPagamento == PAGAMENTO_CONTRASSEGNO)
            {
                this.lblTipoPagamento.InnerText = "HAI SCELTO IL PAGAMENTO TRAMITE CONTRASSEGNO";
                this.lblDatiPagamento.InnerHtml = "Il pagamento avverrà in contanti solo al momento della consegna della merce da parte del nostro corriere! <br/>";
            }
            else if (base.CurrentOrdine.IDTipoPagamento == PAGAMENTO_PAYPAL)
            {
                this.lblTipoPagamento.InnerText = "HAI SCELTO IL PAGAMENTO TRAMITE PAYPAL";
                this.lblDatiPagamento.InnerHtml = "<font style='color:Red;'>Per completare l'ordine devi cliccare su 'PAGA ADESSO'.<br/>Verrai indirizzato sul sito PayPal per il pagamento con carta di credito</font><br/>";
                this.divPayPal.Visible = true;
                this.linkHomePage.Visible = false;
                this.item_name.Value = "Num Ordine: "+base.CurrentOrdine.ID.ToString();
                if (base.CurrentOrdine.TotaleScontoSpedizione.HasValue && base.CurrentOrdine.TotaleScontoSpedizione.Value > 0)
                {
                    ///Aggiungo il codice spedizione
                    this.amount.Value = (base.CurrentOrdine.TotaleOrdine - base.CurrentOrdine.TotaleScontoSpedizione.Value).ToString().Replace(",", ".");
                }
                else
                    this.amount.Value = base.CurrentOrdine.TotaleOrdine.ToString().Replace(",", ".");
                
                //this.shipping.Value = base.CurrentOrdine.TotaleOrdine.ToString().Replace(",", ".");
            }
            else if (base.CurrentOrdine.IDTipoPagamento == PAGAMENTO_POSTEPAY)
            {
                this.lblTipoPagamento.InnerText = "HAI SCELTO IL PAGAMENTO TRAMITE RICARICA POSTEPAY";
                this.lblDatiPagamento.InnerHtml = "Qui di seguito troverà i dati della carta postepay da ricaricare:<br/><b>Carta intestata a: </b>ALBANESI SILVIA</br/><b>Carta n°: </b>4023600565895788  <br/>Codice Fiscale: LBNSLV83D49D003D<br/>N.B. Vi preghiamo di inviarci un E-Mail (info@perbaffo.it) con i dati identificativi della ricarica (data/ora/luogo) per velocizzare l'evasione dell'ordine<br/>";
            }
            else if (base.CurrentOrdine.IDTipoPagamento == PAGAMENTO_RITIROAMANO)
            {
                this.lblTipoPagamento.InnerText = "HAI SCELTO IL PAGAMENTO IN CONTANTI AL MOMENTO DEL RITIRO PRESSO IL MAGAZZINO DI PIANEZZA(TO)";
                this.lblDatiPagamento.InnerHtml = "Verrete contattati dallo Staff di Perbaffo per accordarsi sulla data di ritiro della merce.<br/>Il pagamento avverrà esclusivamente in contanti<br/>";
            }
            this.lblCodOrdine.InnerHtml = base.CurrentOrdine.ID.ToString();

            ///totale
            if (base.CurrentOrdine.TotaleScontoSpedizione.HasValue && base.CurrentOrdine.TotaleScontoSpedizione.Value > 0)
            {
                ///Aggiungo il codice spedizione
                this.lblImportoTotale.InnerHtml = "<b>Importo da versare:</b> € " +(base.CurrentOrdine.TotaleOrdine - base.CurrentOrdine.TotaleScontoSpedizione.Value).ToString();
            }
            else
                this.lblImportoTotale.InnerHtml = "<b>Importo da versare:</b> € " + base.CurrentOrdine.TotaleOrdine.ToString();
        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Acquisto, acquisto prodotti";
            this.DescrizionePagina = "Perbaffo acquisto prodotti,pagamento tramite bonifico,paypal,postepay,contrassegno";
            this.KeywordsPagina = "Perbaffo,acquisto,omaggio,prodotti,pagamento,spedizione,sconto,bonifico,paypal,contrassegno,postepay,riepilogo,conferma,ordine";
        }
        #endregion

    }
}
