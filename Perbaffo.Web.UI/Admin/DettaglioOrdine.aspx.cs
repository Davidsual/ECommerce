using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Text;
using System.Web.UI.HtmlControls;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class DettaglioOrdine : BasePage
    {
        #region PRIVATE MEMBERS
        private enum PageStatus
        {
            Inserimento,
            Modifica
        }
        #endregion

        #region PRIVATE MEMBERS
        private const int STATO_ATTESA_PAGAMENTO = 1;
        private const int STATO_ANNULLATO = 2;
        private const int STATO_IN_PREPARAZIONE = 3;
        private const int STATO_SPEDITO = 4;
        private const int STATO_ARCHIVIATO = 5;
        private const int STATO_ATTESA = 6;
        #endregion

        #region PRIVATE PROPERTY
        private PageStatus CurrentPageState
        {
            get
            {
                if (ViewState["CurrentPageState"] == null)
                    return PageStatus.Inserimento;
                return (PageStatus)ViewState["CurrentPageState"];
            }
            set
            {
                ViewState["CurrentPageState"] = value;
            }
        }
        private int CurrentIDOrdine
        {
            get
            {
                if (ViewState["CurrentIDOrdine"] == null)
                    return -1;
                return (int)ViewState["CurrentIDOrdine"];
            }
            set { ViewState["CurrentIDOrdine"] = value; }
        }
        private int CurrentPaginaOrdine
        {
            get
            {
                if (ViewState["CurrentPaginaOrdine"] == null)
                    return -1;
                return (int)ViewState["CurrentPaginaOrdine"];
            }
            set { ViewState["CurrentPaginaOrdine"] = value; }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            if (this.CurrentPaginaOrdine > 0)
            {
                Response.Redirect("Ordini.aspx?Pagina=" + this.CurrentPaginaOrdine);
            }
            else
                Response.Redirect("Ordini.aspx");
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
                if (string.IsNullOrEmpty(Request.QueryString["IDOrdine"]))
                {
                    Response.Redirect("Ordini.aspx");
                }
                else
                {
                    this.CurrentIDOrdine = int.Parse(Request.QueryString["IDOrdine"]);
                    this.CurrentPageState = PageStatus.Modifica;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["PaginaOrdine"]))
                {
                    this.CurrentPaginaOrdine = Convert.ToInt32(Request.QueryString["PaginaOrdine"]);
                }
                ///Carico la combo dei clienti
                this.LoadFields();
                ///Disabilito tutto
                if (!string.IsNullOrEmpty(Request.QueryString["READONLY"]))
                {
                    this.DisableFields();
                }
                
            }
        }
        /// <summary>
        /// Invia le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                try
                {
                    Perbaffo.Presenter.Model.Ordini _ordini = new Perbaffo.Presenter.Model.Ordini()
                    {
                        IDStatoOrdine = Convert.ToInt32(this.ddlStato.SelectedValue),
                        CodiceSpedizione = this.txtCodSpedizione.Text.Trim(),
                        CAP = this.txtCAP.Text.Trim(),
                        Citta = this.txtCitta.Text.Trim(),
                        Cognome = this.txtCognome.Text.Trim(),
                        Indirizzo = this.txtIndirizzo.Text.Trim(),
                        Nome = this.txtNome.Text.Trim(),                        
                        Note = this.txtNote.Text.Trim(),
                        Telefono = this.txtTelefono.Text.Trim(),
                        NumeroCivico = this.txtNumeroCivico.Text.Trim(),
                        EMail = this.txtEMail.Text.Trim(),
                        Provincia = this.ddlProvincie.Value,
                        ID = this.CurrentIDOrdine,
                        NotePerbaffo = this.txtNotePerbaffo.Text.Trim()
                    };
                    ///modifica
                    _ordini = base.PerbaffoController.UpdateOrdine(_ordini);
                    this.btnCodiceOrdine.Enabled = (_ordini.IDStatoOrdine == STATO_SPEDITO);
                    this.btnSend.OnClientClick = string.Empty;

                    if (_ordini.IDStatoOrdine == 5)///STATO ARCHIVIATO 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location = 'Ordini_Archiviati.aspx';", true);
                        return;
                    }
                    else if (_ordini.IDStatoOrdine == 2)///Annullato
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location = 'Ordini_Annullati.aspx';", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il salvataggio del ordine,controllare di aver inserito i dati correttamente e la lunghezza dei campi');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare tutti i campi');", true);
            }
        }
        /// <summary>
        /// Annulla le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancella_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageState != PageStatus.Modifica)
            {
                Response.Redirect("DettaglioOrdine.aspx");
            }
            else
            {
                this.LoadFields();
            }
        }
        /// <summary>
        /// Generazione di una colonna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    HtmlGenericControl lblCodice = e.Row.FindControl("lblCodiceProd") as HtmlGenericControl;
                    HtmlAnchor lblDescrProd = e.Row.FindControl("lblDescrProd") as HtmlAnchor;
                    HtmlGenericControl lblTotale = e.Row.FindControl("lblTotale") as HtmlGenericControl;

                    Prodotti _prod = base.PerbaffoController.GetProdottoByID(((DettagliOrdini)e.Row.DataItem).IDProdotto);

                    lblDescrProd.InnerText = _prod.Nome;
                    int _idColore = (((DettagliOrdini)e.Row.DataItem).IDColore.HasValue)?((DettagliOrdini)e.Row.DataItem).IDColore.Value:-1;
                    int _idTaglia = (((DettagliOrdini)e.Row.DataItem).IDTaglia.HasValue)?((DettagliOrdini)e.Row.DataItem).IDTaglia.Value:-1;
                    lblDescrProd.HRef = "../Dettaglio-Prodotto.aspx?Prodotto=" + ((DettagliOrdini)e.Row.DataItem).IDProdotto;
                    lblDescrProd.Title = _prod.DescrizioneLunga;
                    lblDescrProd.Target = "_new";
                    if (_idTaglia > 0)
                        lblDescrProd.HRef += "&amp;Taglia=" + _idTaglia;

                    Colori _col = null;
                    ProdottiTaglie _taglia = null;

                    if(_idColore > 0)
                        _col = base.PerbaffoController.GetColoreByIDColore(_idColore);
                    if (_idTaglia > 0)
                        _taglia = base.PerbaffoController.GetProdottiTaglieByIDTaglia(_idTaglia);
                    lblDescrProd.InnerHtml = "<b>"+_prod.Nome+"</b><br />";
                    if (_taglia != null)
                    {
                        lblDescrProd.InnerHtml += "Taglia scelta: " + _taglia.DescrTaglia + "<br />";
                        lblCodice.InnerText = _taglia.Codice;
                        ///totale calcolato
                        lblTotale.InnerText = "€ " + (((DettagliOrdini)e.Row.DataItem).Quantita * _taglia.Totale).ToString();

                        if (string.IsNullOrEmpty(this.lblTotaleProdotti.Text.Trim()))
                            this.lblTotaleProdotti.Text = (_taglia.Totale * ((DettagliOrdini)e.Row.DataItem).Quantita).ToString();
                        else
                        {
                            decimal _tot = Convert.ToDecimal(this.lblTotaleProdotti.Text.Trim());
                            _tot += (_taglia.Totale * ((DettagliOrdini)e.Row.DataItem).Quantita);
                            this.lblTotaleProdotti.Text = _tot.ToString();
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.lblTotaleProdotti.Text.Trim()))
                            this.lblTotaleProdotti.Text = (_prod.Totale * ((DettagliOrdini)e.Row.DataItem).Quantita).ToString();
                        else
                        {
                            decimal _tot = Convert.ToDecimal(this.lblTotaleProdotti.Text.Trim());
                            _tot += (_prod.Totale * ((DettagliOrdini)e.Row.DataItem).Quantita);
                            this.lblTotaleProdotti.Text = _tot.ToString();
                        }


                        ///totale calcolato
                        lblTotale.InnerText = "€ " + (((DettagliOrdini)e.Row.DataItem).Quantita * _prod.Totale).ToString();
                        lblCodice.InnerText = _prod.Codice;
                        if (string.IsNullOrEmpty(_prod.DescrTaglia))
                        {
                            lblDescrProd.InnerHtml += "Taglia scelta: N.D.<br />";
                        }
                        else
                            lblDescrProd.InnerHtml += "Taglia scelta: " + _prod.DescrTaglia + "<br />";
                    }
                    if (_col != null)
                    {
                        lblDescrProd.InnerHtml += "Variazione scelta: " + _col.Descrizione + "<br />";
                    }
                    else
                    {
                        lblDescrProd.InnerHtml += "Variazione scelta: N.D.<br />";
                    }
                    
                }
            }
        }
        /// <summary>
        /// Gestione del cambio della combo box stato ordine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlStato_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _js = string.Empty;
            if (this.ddlStato.SelectedValue == "1")
            {

            }
            else if (this.ddlStato.SelectedValue == "2")
            {
                _js = "return confirm('Sei sicura di voler annullare l\\'ordine?');";
            }
            else if (this.ddlStato.SelectedValue == "3")
            {
                _js = "return confirm('Sei sicura che l\\'utente abbia pagato l\\'ordine?');";
            }
            else if (this.ddlStato.SelectedValue == "4")
            {
                _js = "return confirm('Sei sicura di aver messo il CODICE SPEDIZIONE?');";
            }
            else if (this.ddlStato.SelectedValue == "5")
            {
                _js = "return confirm('Sei sicura di voler archiviare l\\'ordine?');";
            }
            else if (this.ddlStato.SelectedValue == "5")
            {

            }
            btnSend.OnClientClick = _js;
        }
        /// <summary>
        /// Apre il dettaglio dell'indirizzo di spedizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIndirizzo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "open", "window.open ('DettaglioIndirizzo.aspx?IDOrdine=" + this.CurrentIDOrdine + "','mywindow','width=700px,height=800px,top=0,left=300,location=0,directories=0,resizable=0,scrollbars=0,toolbar=0,menubar=0,status=0');", true);
        }
        /// <summary>
        /// Invia una mail per invitare a controllare il codice ordine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCodiceOrdine_Click(object sender, EventArgs e)
        {
            try
            {
                Perbaffo.Presenter.Model.Ordini _ord = base.PerbaffoController.GetOrdineByIDOrdine(CurrentIDOrdine);
                if (_ord != null && this.txtCodSpedizione.Text.Trim().Length > 3)
                {
                    Utenti _utenti = base.PerbaffoController.GetUtenteByID(_ord.IDUtente);
                    if (_utenti != null)
                    {
                        bool _result = base.PerbaffoController.InvioMailCodiceSpedizione(_ord, _utenti, this.txtCodSpedizione.Text.Trim());
                        if (_result)
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('E-Mail inviata con successo');", true);
                        else
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante l\\'invio dell E-Mail');", true);
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante l\\'invio dell E-Mail');", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante l\\'invio dell E-Mail');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Pagamento Ricevuto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                Perbaffo.Presenter.Model.Ordini _ord = base.PerbaffoController.GetOrdineByIDOrdine(CurrentIDOrdine);
                if (_ord != null)
                {
                    Utenti _utenti = base.PerbaffoController.GetUtenteByID(_ord.IDUtente);
                    if (_utenti != null)
                    {
                        bool _result = base.PerbaffoController.InvioMailConfermaPagamento(_ord, _utenti);
                        if (_result)
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('E-Mail inviata con successo');", true);
                        else
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante l\'invio dell E-Mail');", true);
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante l\'invio dell E-Mail');", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante l\\'invio dell E-Mail');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica i campi
        /// </summary>
        private void LoadFields()
        {
            this.ddlStato.DataSource = base.PerbaffoController.GetStatoOrdine();
            this.ddlStato.DataValueField = "ID";
            this.ddlStato.DataTextField = "DescrStatoOrdine";
            this.ddlStato.DataBind();

            this.ddlStato.Items.Insert(0, new ListItem("Seleziona stato Ordine", ""));
            this.lblTotaleCarrello.Text = string.Empty;
            if(CurrentPageState == PageStatus.Modifica)
            {
                Perbaffo.Presenter.Model.Ordini _currentOrdine = base.PerbaffoController.GetOrdineByIDOrdine(this.CurrentIDOrdine);
                if(_currentOrdine != null)
                {
                    this.txtNome.Text = this.Capitalize(_currentOrdine.Nome);
                    this.txtCognome.Text = this.Capitalize(_currentOrdine.Cognome);
                    this.txtIndirizzo.Text = this.Capitalize(_currentOrdine.Indirizzo);
                    this.txtNumeroCivico.Text = _currentOrdine.NumeroCivico;
                    Utenti _utente = base.PerbaffoController.GetUtenteByID(_currentOrdine.IDUtente);
                    if (_utente != null && !string.IsNullOrEmpty(_utente.CFiscPIva))
                        this.txtCodFisc.Text = _utente.CFiscPIva.Trim();
                    this.txtCitta.Text = this.Capitalize(_currentOrdine.Citta);
                    this.txtCAP.Text = _currentOrdine.CAP;
                    this.txtTelefono.Text = _currentOrdine.Telefono;
                    this.txtEMail.Text = _currentOrdine.EMail;
                    this.ddlProvincie.Value = _currentOrdine.Provincia;
                    this.txtNote.Text = this.Capitalize(_currentOrdine.Note);
                    this.txtNotePerbaffo.Text = this.Capitalize(_currentOrdine.NotePerbaffo);
                    ///aTTIVO I PULSANTI PER INVIARE LE MAIL
                    this.btnCodiceOrdine.Enabled = (_currentOrdine.IDStatoOrdine == STATO_SPEDITO);
                    this.btnPagamento.Enabled = (_currentOrdine.IDStatoOrdine == STATO_ATTESA_PAGAMENTO);
                }
                
                this.ddlStato.SelectedValue = _currentOrdine.IDStatoOrdine.ToString();
                this.txtCodSpedizione.Text = _currentOrdine.CodiceSpedizione;
                Utenti _utenti = base.PerbaffoController.GetUtenteByID(_currentOrdine.IDUtente);
                this.lblNumeroOrdine.Text = _currentOrdine.ID.ToString() + " - " + _currentOrdine.DataOrdine.ToShortDateString() + " " + _currentOrdine.DataOrdine.ToShortTimeString();
                if(_utenti != null)
                {
                    this.lblCliente.Text = _utenti.Nome + " " + _utenti.Cognome + "  ("+_utenti.EMail+")";
                }
                TipoPagamento _pagam = base.PerbaffoController.GetTipoPagamentoByID(_currentOrdine.IDTipoPagamento);
                if (_pagam != null)
                {
                    this.lblTotaleCarrello.Text += "Totale Pag: € " + _pagam.Costo.ToString() + "<br/>";
                    this.lblTipoPagamento.Text = _pagam.DescrizionePagamento + "  (" + _pagam.Costo.ToString()+ ")";
                }
                TipoSpedizioni _sped = base.PerbaffoController.GetTipoSpedizioneByID(_currentOrdine.IDTipoSpedizione);
                if (_sped != null)
                {
                    this.lblTotaleCarrello.Text += "Totale Sped: € " + _sped.CostoSpedizione.ToString() + "<br/>";
                    this.lblTipoSpedizione.Text = _sped.DescrBreveSpedizione + "  (" + _sped.CostoSpedizione.ToString()+ ")";
                }
                this.lblCodiceSconto.Text = "-";
                this.lblScontoUtente.Text = "-";
                ///Aggiungo eventuali sconti
                if (_currentOrdine.IDCodicePromozione.HasValue && _currentOrdine.IDCodicePromozione.Value > 0)
                {
                    CodicePromozioni _codProm = base.PerbaffoController.GetCodicePromozioneByID(_currentOrdine.IDCodicePromozione.Value);
                    if(_codProm != null)
                    {
                        string _sconto = string.Empty;
                        if(_codProm.ScontoEuro.HasValue && _codProm.ScontoEuro.Value > 0)
                            _sconto = "€ " + _codProm.ScontoEuro.Value.ToString();
                        else
                            _sconto = _codProm.ScontoPercent.Value.ToString()+"%";
                        this.lblTotaleCarrello.Text += "Totale Codice Sconto: " + _sconto + "<br/>";
                        this.lblCodiceSconto.Text = _currentOrdine.CodicePromozione + "(" + _sconto+")";
                    }
                }
                if (_currentOrdine.IDUtentePromozione.HasValue && _currentOrdine.IDUtentePromozione.Value > 0)
                {
                    UtentiPromozioni _promo = base.PerbaffoController.GetUtentePromozioneByID(Convert.ToInt32(_currentOrdine.IDUtentePromozione.Value));
                    if (_promo != null)
                    {
                        string _sconto = string.Empty;
                        if (_promo.ScontoEuro.HasValue && _promo.ScontoEuro.Value > 0)
                            _sconto = "€ " + _promo.ScontoEuro.Value.ToString();
                        else
                            _sconto = _promo.ScontoPercent.ToString() + "%";
                        this.lblTotaleCarrello.Text += "Totale Utente Sconto: " + _sconto + "<br/>";
                        this.lblScontoUtente.Text = _promo.DescrPromozione + "(" + _sconto + ")";
                    }
                }
                if (_currentOrdine.TotaleScontoSpedizione.HasValue && _currentOrdine.TotaleScontoSpedizione.Value > 0)
                {
                    this.lblTotaleCarrello.Text += "Totale Sconto spedizione: € " + _currentOrdine.TotaleScontoSpedizione.Value + "<br/>";
                }
                ///Griglia dei prodotti allegati (Carrello)
                this.grdListProdotti.DataSource = base.PerbaffoController.GetDettagliOrdineByIDOrdine(this.CurrentIDOrdine);
                this.grdListProdotti.DataBind();
                ///Prodotto omaggio
                Prodotti _prodOmaggio = base.PerbaffoController.GetProdottoByID(_currentOrdine.IDProdottoOmaggio);
                if (_prodOmaggio != null)
                {
                    this.lblOmaggio.InnerHtml = _prodOmaggio.Codice + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=../Dettaglio-Prodotto.aspx?Prodotto=" + _prodOmaggio.ID + " title=" + _prodOmaggio.DescrizioneLunga + " target='_new'>" + _prodOmaggio.Nome + "</a>";
                }
                if (_currentOrdine.TotaleScontoSpedizione.HasValue && _currentOrdine.TotaleScontoSpedizione.Value > 0)
                {
                    this.lblTotaleCarrello.Text += "Totale Carrello: € " + (_currentOrdine.TotaleOrdine - _currentOrdine.TotaleScontoSpedizione.Value);
                }
                else
                    this.lblTotaleCarrello.Text += "Totale Carrello: € " + _currentOrdine.TotaleOrdine;
            }
        }
        /// <summary>
        /// Controlla i campi obbligatori
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (this.ddlStato.SelectedIndex <= 0 ||
                string.IsNullOrEmpty(this.txtNome.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtCognome.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtEMail.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtIndirizzo.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtTelefono.Text.Trim()) ||
                this.ddlProvincie.SelectedIndex <= 0 ||
                string.IsNullOrEmpty(this.txtCitta.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtCAP.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtNumeroCivico.Text.Trim())
                )
                return false;

            return true;
        }
        /// <summary>
        /// Capitaliza la stringa
        /// </summary>
        /// <param name="toCapitalize"></param>
        /// <returns></returns>
        private string Capitalize(string toCapitalize)
        {
            try
            {
                if (toCapitalize.Length > 1)
                {
                    toCapitalize = toCapitalize.Substring(0, 1).ToUpper() + toCapitalize.Substring(1);
                }
            }
            catch (Exception ex)
            {
                return toCapitalize;
            }
            return toCapitalize;
        }
        /// <summary>
        /// Disabilito tutto
        /// </summary>
        private void DisableFields()
        {
            this.btnCancella.Visible = false;
            this.btnSend.Visible = false;
            this.ddlStato.Enabled = false;
            this.txtCodSpedizione.Enabled = false;
            this.txtNotePerbaffo.Enabled = false;
            this.txtNome.Enabled = false;
            this.txtCognome.Enabled = false;
            this.txtEMail.Enabled = false;
            this.txtIndirizzo.Enabled = false;
            this.txtNote.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.ddlProvincie.Disabled = true;
            this.txtCitta.Enabled = false;
            this.txtCAP.Enabled = false;
            this.txtNumeroCivico.Enabled = false;
        }
        #endregion

    }
}
