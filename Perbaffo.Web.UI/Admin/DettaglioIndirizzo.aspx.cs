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
    public partial class DettaglioIndirizzo : BasePage
    {
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

        #region EVENTS
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["IDOrdine"]))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "this.close();", true);
                return;
            }
            else
            {
                this.CurrentIDOrdine = int.Parse(Request.QueryString["IDOrdine"]);
                Perbaffo.Presenter.Model.Ordini _ord = base.PerbaffoController.GetOrdineByIDOrdine(this.CurrentIDOrdine);
                StringBuilder _build = new StringBuilder();
                _build.Append(_ord.Cognome + "  " + _ord.Nome + "<br/>");
                _build.Append(_ord.Indirizzo + "  " + _ord.NumeroCivico.ToString() + "<br/>");
                _build.Append(_ord.CAP + "  " + _ord.Citta + "  (" + _ord.Provincia + ")" + "<br/>");
                _build.Append("<br/>");
                _build.Append("TEL: " + _ord.Telefono + "<br/>");
                _build.Append("E-mail: " + _ord.EMail + "<br/>");
                _build.Append(string.Format("Ordine n°{0} - effettuato il: {1}", _ord.ID.ToString(), _ord.DataOrdine.ToString("dd/MM/yyyy hh:mm")));
                _build.Append(_ord.Note);
                lblIndirizzo.Text = _build.ToString();

                TipoPagamento _pag = base.PerbaffoController.GetTipoPagamentoByID(_ord.IDTipoPagamento);
                if (_pag != null)
                    this.lblPagamento.Text = _pag.DescrizionePagamento + " (" + _pag.Costo.ToString() + ")";
                else
                    this.lblPagamento.Text = string.Empty;
                ///Griglia dei prodotti allegati (Carrello)
                this.grdListProdotti.DataSource = base.PerbaffoController.GetDettagliOrdineByIDOrdine(this.CurrentIDOrdine);
                this.grdListProdotti.DataBind();

                TipoPagamento _pagam = base.PerbaffoController.GetTipoPagamentoByID(_ord.IDTipoPagamento);
                if (_pagam != null)
                {
                    this.lblTotaleCarrello.Text += "Totale Pag: € " + _pagam.Costo.ToString() + "<br/>";
                }
                TipoSpedizioni _sped = base.PerbaffoController.GetTipoSpedizioneByID(_ord.IDTipoSpedizione);
                if (_sped != null)
                {
                    this.lblTotaleCarrello.Text += "Totale Sped: € " + _sped.CostoSpedizione.ToString() + "<br/>";
                }
                ///Aggiungo eventuali sconti
                if (_ord.IDCodicePromozione.HasValue && _ord.IDCodicePromozione.Value > 0)
                {
                    CodicePromozioni _codProm = base.PerbaffoController.GetCodicePromozioneByID(_ord.IDCodicePromozione.Value);
                    if(_codProm != null)
                    {
                        string _sconto = string.Empty;
                        if(_codProm.ScontoEuro.HasValue && _codProm.ScontoEuro.Value > 0)
                            _sconto = "€ " + _codProm.ScontoEuro.Value.ToString();
                        else
                            _sconto = _codProm.ScontoPercent.Value.ToString()+"%";
                        this.lblTotaleCarrello.Text += "Totale Codice Sconto: " + _sconto + "<br/>";
                    }
                }
                if (_ord.IDUtentePromozione.HasValue && _ord.IDUtentePromozione.Value > 0)
                {
                    UtentiPromozioni _promo = base.PerbaffoController.GetUtentePromozioneByID(Convert.ToInt32(_ord.IDUtentePromozione.Value));
                    if (_promo != null)
                    {
                        string _sconto = string.Empty;
                        if (_promo.ScontoEuro.HasValue && _promo.ScontoEuro.Value > 0)
                            _sconto = "€ " + _promo.ScontoEuro.Value.ToString();
                        else
                            _sconto = _promo.ScontoPercent.ToString() + "%";
                        this.lblTotaleCarrello.Text += "Totale Utente Sconto: " + _sconto + "<br/>";
                    }
                }
                if (_ord.TotaleScontoSpedizione.HasValue && _ord.TotaleScontoSpedizione.Value > 0)
                {
                    this.lblTotaleCarrello.Text += "Totale Sconto spedizione: € " + _ord.TotaleScontoSpedizione.Value + "<br/>";
                }
                if (_ord.TotaleScontoSpedizione.HasValue && _ord.TotaleScontoSpedizione.Value > 0)
                {
                    this.lblTotaleCarrello.Text += "Totale Carrello: € " + (_ord.TotaleOrdine - _ord.TotaleScontoSpedizione.Value);
                }
                else
                    this.lblTotaleCarrello.Text += "Totale Carrello: € " + _ord.TotaleOrdine;
                //this.lblTotaleCarrello.Text += "Totale Carrello: € " + _ord.TotaleOrdine;

                Prodotti _prod = base.PerbaffoController.GetProdottoByID(_ord.IDProdottoOmaggio);
                if (_prod != null && _prod.IsOmaggio)
                {
                    this.lblOmaggio.Text = _prod.Codice + " - " + _prod.Nome ;
                }
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
                    Label lblDescrProd = e.Row.FindControl("lblDescrProd") as Label;
                    HtmlGenericControl lblTotale = e.Row.FindControl("lblTotale") as HtmlGenericControl;

                    Prodotti _prod = base.PerbaffoController.GetProdottoByID(((DettagliOrdini)e.Row.DataItem).IDProdotto);

                    lblDescrProd.Text = _prod.Nome;
                    int _idColore = (((DettagliOrdini)e.Row.DataItem).IDColore.HasValue) ? ((DettagliOrdini)e.Row.DataItem).IDColore.Value : -1;
                    int _idTaglia = (((DettagliOrdini)e.Row.DataItem).IDTaglia.HasValue) ? ((DettagliOrdini)e.Row.DataItem).IDTaglia.Value : -1;
                    if (_idTaglia > 0)
                        lblDescrProd.Text += "&amp;Taglia=" + _idTaglia;

                    Colori _col = null;
                    ProdottiTaglie _taglia = null;

                    if (_idColore > 0)
                        _col = base.PerbaffoController.GetColoreByIDColore(_idColore);
                    if (_idTaglia > 0)
                        _taglia = base.PerbaffoController.GetProdottiTaglieByIDTaglia(_idTaglia);
                    lblDescrProd.Text = "<b>" + _prod.Nome + "</b><br />";
                    if (_taglia != null)
                    {
                        lblDescrProd.Text += "Taglia scelta: " + _taglia.DescrTaglia + "<br />";
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
                            lblDescrProd.Text += "Taglia scelta: N.D.<br />";
                        }
                        else
                            lblDescrProd.Text += "Taglia scelta: " + _prod.DescrTaglia + "<br />";
                    }
                    if (_col != null)
                    {
                        lblDescrProd.Text += "Variazione scelta: " + _col.Descrizione + "<br />";
                    }
                    else
                    {
                        lblDescrProd.Text += "Variazione scelta: N.D.<br />";
                    }

                }
            }
        } 
        #endregion
    }
}
