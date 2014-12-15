using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class ProdottoTaglia : BasePage
    {
        #region PRIVATE PROPERTY
        /// <summary>
        /// IdProdotto corrente
        /// </summary>
        private int CurrentIDProdotto
        {
            get
            {
                if (ViewState["CurrentIDProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentIDProdotto"];
            }
            set { ViewState["CurrentIDProdotto"] = value; }
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
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
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
                if (string.IsNullOrEmpty(Request.QueryString["IDProdotto"]))
                {
                    this.CurrentIDProdotto = 0;
                }
                else
                {
                    this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);
                }
                this.LoadFields();
            }
        }
        /// <summary>
        /// Selezione sulla griglia delle taglie (DELETE)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdTaglie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;
            base.PerbaffoController.DeleteProdottiTaglia(Convert.ToInt32(e.CommandArgument), this.CurrentIDProdotto);
            this.LoadFields();
        }
        /// <summary>
        /// Selezione sulla griglia delle taglie (DELETE)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdTaglie_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// Salva una taglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtDescrizioneTaglia.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtCodiceTaglia.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtPrezzo.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtScontoEuro.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtScontoPerc.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione valorizzare tutti i campi');", true);
                    return;
                }
                ProdottiTaglie _taglia = new ProdottiTaglie()
                {
                    DescrTaglia = this.txtDescrizioneTaglia.Text.Trim(),
                    Codice = this.txtCodiceTaglia.Text.Trim(),
                    IDProdotto = this.CurrentIDProdotto,
                    Prezzo = Convert.ToDecimal(this.txtPrezzo.Text.Trim().Replace(".", ",")),
                    ScontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ",")),
                    ScontoPerc = Convert.ToInt32(this.txtScontoPerc.Text.Trim()),
                    Totale = this.CalcolaTotaleProdotto()
                };
                base.PerbaffoController.SetProdottiTaglia(_taglia, this.CurrentIDProdotto);
                ///Ricarica tutta la pagina
                this.LoadFields();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante l\\'aggiornamento');", true);
                return;
            }
        }
        /// <summary>
        /// Annulla le operazioni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.txtDescrizioneTaglia.Text = string.Empty;
            this.txtPrezzo.Text = "0,00";
            this.txtScontoEuro.Text = "0,00";
            this.txtScontoPerc.Text = "0";
            this.txtCodiceTaglia.Text = string.Empty;
        }
        /// <summary>
        /// Calcola il totale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCalcola_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPrezzo.Text.Trim()))
                return;
            try
            {
                Decimal _prezzo = Convert.ToDecimal(this.txtPrezzo.Text.Trim().Replace(".", ","));
                int _scontoPerc = 0;
                decimal _scontoEuro = 0;
                if (this.txtScontoPerc.Text.Trim() != string.Empty && this.txtScontoPerc.Text.Trim() != "0")
                {
                    _scontoPerc = Convert.ToInt32(this.txtScontoPerc.Text.Trim());
                }
                if (this.txtScontoEuro.Text.Trim() != string.Empty && this.txtScontoEuro.Text.Trim() != "0,00")
                {
                    _scontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ","));
                }
                ///Applico la percentuale
                if (_scontoPerc > 0)
                {
                    Decimal _result = (_prezzo * _scontoPerc) / 100;
                    _prezzo = (_prezzo - _result);
                }
                if (_scontoEuro > 0)
                {
                    _prezzo = _prezzo - _scontoEuro;
                }
                this.txtTotale.Text = _prezzo.ToString();
            }
            catch
            {
                this.txtTotale.Text = "Errore durante il calcolo del totale";
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Calcola il totale di un prodotto
        /// </summary>
        /// <returns></returns>
        private decimal CalcolaTotaleProdotto()
        {
            if (string.IsNullOrEmpty(this.txtPrezzo.Text.Trim()))
                return 0;
            try
            {
                Decimal _prezzo = Convert.ToDecimal(this.txtPrezzo.Text.Trim().Replace(".", ","));
                int _scontoPerc = 0;
                decimal _scontoEuro = 0;
                if (this.txtScontoPerc.Text.Trim() != string.Empty && this.txtScontoPerc.Text.Trim() != "0")
                {
                    _scontoPerc = Convert.ToInt32(this.txtScontoPerc.Text.Trim());
                }
                if (this.txtScontoEuro.Text.Trim() != string.Empty && this.txtScontoEuro.Text.Trim() != "0,00")
                {
                    _scontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ","));
                }
                ///Applico la percentuale
                if (_scontoPerc > 0)
                {
                    Decimal _result = (_prezzo * _scontoPerc) / 100;
                    _prezzo = (_prezzo - _result);
                }
                if (_scontoEuro > 0)
                {
                    _prezzo = _prezzo - _scontoEuro;
                }
                return _prezzo;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Caricamento campi
        /// </summary>
        private void LoadFields()
        {
            Prodotti _prod = base.PerbaffoController.GetProdottoByID(this.CurrentIDProdotto);
            if (_prod != null)
            {
                this.txtDescrizioneTaglia.Text = string.Empty;
                this.txtPrezzo.Text = string.Empty;
                this.txtScontoEuro.Text = _prod.ScontoEuro.ToString();
                this.txtScontoPerc.Text = _prod.ScontoPercent.ToString();
                this.txtCodiceTaglia.Text = string.Empty ;
            }
            ///Carica la lista con le taglie già presenti
            this.grdTaglie.DataSource = base.PerbaffoController.GetProdottiTaglieByIDProdotto(this.CurrentIDProdotto);
            this.grdTaglie.DataBind();
        } 
        #endregion

    }
}
