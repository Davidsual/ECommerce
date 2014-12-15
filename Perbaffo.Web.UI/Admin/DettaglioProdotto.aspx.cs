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
    public partial class DettaglioProdotto : BasePage
    {
        #region PRIVATE MEMBERS
        private enum PageStatus
        {
            Inserimento,
            Modifica
        } 
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
                ///Abilito o meno i link
                this.btnColori.Enabled = (value == PageStatus.Modifica);
                this.btnCategoria.Enabled = (value == PageStatus.Modifica);
                this.btnPhoto.Enabled = (value == PageStatus.Modifica);
                this.btnTaglia.Enabled = (value == PageStatus.Modifica);
                this.btnRelazioni.Enabled = (value == PageStatus.Modifica);
                this.btnPhotoGallery.Enabled = (value == PageStatus.Modifica);
                this.btnDupplica.Enabled = (value == PageStatus.Modifica);
            }
        }
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
        private int CurrentPaginaProdotto
        {
            get
            {
                if (ViewState["CurrentPaginaProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentPaginaProdotto"];
            }
            set { ViewState["CurrentPaginaProdotto"] = value; }
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
            if (this.CurrentPaginaProdotto > 0)
            {
                Response.Redirect("Prodotti.aspx?Pagina=" + this.CurrentPaginaProdotto);
            }
            else
                Response.Redirect("Prodotti.aspx");
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
                    this.CurrentPageState = PageStatus.Inserimento;
                    this.CurrentIDProdotto = 0;
                }
                else
                {
                    this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);
                    this.CurrentPageState = PageStatus.Modifica;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["PaginaProdotto"]))
                {
                    this.CurrentPaginaProdotto = Convert.ToInt32(Request.QueryString["PaginaProdotto"]);
                }
                this.LoadFields();
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
                    Prodotti _prodotti = new Prodotti()
                    {
                        Nome = this.txtNome.Text.Trim(),
                        Codice = this.txtCodice.Text.Trim().ToUpper(),
                        UnitaDiMisura = Convert.ToInt32(this.txtUnita.Text.Trim()),
                        Prezzo = Convert.ToDecimal(this.txtPrezzo.Text.Trim().Replace(".",",")),
                        Keywords = this.txtKeyWords.Text.Trim(),
                        DescrizioneLunga =  base.Capitalize(this.descrizione.Value.Trim()),
                        Giacenza = Convert.ToInt32(this.txtGiacenza.Text.Trim()),
                        IDAliquotaIva = Convert.ToInt32(this.ddlIva.SelectedValue),
                        LivRiordino = Convert.ToInt32(this.txtRiordino.Text.Trim()),
                        ID = this.CurrentIDProdotto,
                        Attivo = this.chkAttivo.Checked,
                        DescrTaglia = this.txtDescrTaglia.Text.Trim(),
                        IsOmaggio = this.chkIsOmaggio.Checked,
                        RangeOmaggio = Convert.ToDecimal(this.txtPrezzoMinimoOmaggio.Text.Trim().Replace(".", ",")),
                        ScontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ",")),
                        ScontoPercent = Convert.ToInt32(this.txtSconto.Text.Trim()),
                        Totale = this.CalcolaTotaleProdotto()
                    };
                    _prodotti = base.PerbaffoController.SetProdotti(_prodotti);
                    if (this.CurrentPageState != PageStatus.Modifica)
                    {
                        this.CurrentIDProdotto = _prodotti.ID;
                        this.CurrentPageState = PageStatus.Modifica;
                    }
                }
                catch(Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il salvataggio del prodotto,controllare di aver inserito i dati correttamente e la lunghezza dei campi');", true);
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
                Response.Redirect("DettaglioProdotto.aspx");
            }
            else
            {
                this.LoadFields();
            }
        }
        /// <summary>
        /// modifica e inserimento attributi del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAction_Click(object sender, EventArgs e)
        {
            string _param = "?IDProdotto=" + this.CurrentIDProdotto;
            switch (((LinkButton)sender).CommandName)
            {
                case "PHOTO":
                    Response.Redirect("ProdottoFoto.aspx" + _param, true);
                    break;
                case "TAGLIA":
                    Response.Redirect("ProdottoTaglia.aspx" + _param, true);
                    break;
                case "CATEGORIA":
                    Response.Redirect("ProdottoCategoria.aspx" + _param, true);
                    break;
                case "COLORE":
                    Response.Redirect("ProdottoColore.aspx" + _param, true);
                    break;
                case "RELAZIONE":
                    Response.Redirect("ProdottoRelazione.aspx" + _param, true);
                    break;
                case "PHOTOGALLERY":
                    Response.Redirect("ProdottoPhotoGallery.aspx" + _param, true);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Calcola il totale del prodotto
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
                if (this.txtSconto.Text.Trim() != string.Empty && this.txtSconto.Text.Trim() != "0")
                {
                    _scontoPerc = Convert.ToInt32(this.txtSconto.Text.Trim());
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
        /// <summary>
        /// Calcola le Keyword se possibile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnKeyWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNome.Text.Trim()))
                return;
            try
            {
                string[] _keywords = this.txtNome.Text.Trim().Split(' ');
                foreach (string item in _keywords)
                {
                    if (!string.IsNullOrEmpty(item) && item.Length > 3)
                    {
                        if (string.IsNullOrEmpty(this.txtKeyWords.Text.Trim()))
                            this.txtKeyWords.Text += item;
                        else
                            this.txtKeyWords.Text += "," + item;
                    }
                }
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// Dupplica un prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDupplica_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageState == PageStatus.Modifica && this.CurrentIDProdotto > 0)
            {
                this.CurrentPageState = PageStatus.Inserimento;
                this.CurrentIDProdotto = -1;
                this.lblDataInserimento.Text = string.Empty;
                this.chkAttivo.Checked = true;
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
                if (this.txtSconto.Text.Trim() != string.Empty && this.txtSconto.Text.Trim() != "0")
                {
                    _scontoPerc = Convert.ToInt32(this.txtSconto.Text.Trim());
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
        /// Carica i campi
        /// </summary>
        private void LoadFields()
        {
            List<AliquotaIva> _list = base.PerbaffoController.GetAliquotaIva();
            foreach (AliquotaIva item in _list)
	        {
        		 this.ddlIva.Items.Add(new ListItem(item.ValoreAliquotaIva.ToString()+"%",item.ID.ToString()));
	        }
            this.ddlIva.Items.Insert(0, new ListItem("Seleziona aliquota iva", ""));

            ///Popolo i campi se sono in modifica
            if (this.CurrentPageState == PageStatus.Modifica)
            {
                Prodotti _prodotto = base.PerbaffoController.GetProdottoByID(this.CurrentIDProdotto);
                if (_prodotto == null)
                    ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.HomePage);
                this.txtNome.Text = _prodotto.Nome;
                this.txtCodice.Text = _prodotto.Codice;
                this.txtKeyWords.Text = _prodotto.Keywords;
                this.txtGiacenza.Text = _prodotto.Giacenza.ToString();
                this.txtPrezzo.Text = _prodotto.Prezzo.ToString();
                this.txtRiordino.Text = _prodotto.LivRiordino.ToString();
                this.descrizione.Value = _prodotto.DescrizioneLunga;
                this.ddlIva.SelectedValue = _prodotto.IDAliquotaIva.ToString();
                this.txtUnita.Text = _prodotto.UnitaDiMisura.ToString();
                this.txtSconto.Text = _prodotto.ScontoPercent.ToString();
                this.txtScontoEuro.Text = _prodotto.ScontoEuro.ToString();
                this.chkIsOmaggio.Checked = _prodotto.IsOmaggio;
                this.txtPrezzoMinimoOmaggio.Text = _prodotto.RangeOmaggio.ToString();
                this.txtTotale.Text = _prodotto.Totale.ToString();
                this.chkAttivo.Checked = _prodotto.Attivo;
                this.txtDescrTaglia.Text = _prodotto.DescrTaglia;
                this.lblDataInserimento.Text = _prodotto.DataInserimento.ToString();
            }
            else
            {
                this.ddlIva.SelectedValue = "1";
            }
        }
        /// <summary>
        /// Controlla i campi obbligatori
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (this.txtNome.Text.Trim() == string.Empty ||
                this.txtCodice.Text.Trim() == string.Empty ||
                this.txtUnita.Text.Trim() == string.Empty ||
                this.ddlIva.SelectedValue == string.Empty ||
                this.txtSconto.Text.Trim() == string.Empty ||
                this.txtPrezzo.Text.Trim() == string.Empty ||
                this.txtScontoEuro.Text.Trim() == string.Empty ||
                this.txtGiacenza.Text.Trim() == string.Empty ||
                this.txtRiordino.Text.Trim() == string.Empty ||
                this.txtKeyWords.Text.Trim() == string.Empty ||
                this.descrizione.Value.Trim() == string.Empty)
                return false;
            if (this.txtNome.Text.Trim().Length > 100 || this.txtKeyWords.Text.Trim().Length > 100 || this.txtDescrTaglia.Text.Trim().Length > 50)
            {
                return false;
            }
            if(this.chkIsOmaggio.Checked && string.IsNullOrEmpty(this.txtPrezzoMinimoOmaggio.Text.Trim()))
            {
                return false;
            }
            return true;
        }
        #endregion
        
        /// <summary>
        /// Salva il prodotto mettendolo nelle novità
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendAsNew_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageState != PageStatus.Modifica)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Utilizzabile solo in modifica per spostare un prodotto come novità');", true);
                return;
            }
            if (CheckFields())
            {
                try
                {
                    Prodotti _prodotti = new Prodotti()
                    {
                        Nome = this.txtNome.Text.Trim(),
                        Codice = this.txtCodice.Text.Trim().ToUpper(),
                        UnitaDiMisura = Convert.ToInt32(this.txtUnita.Text.Trim()),
                        Prezzo = Convert.ToDecimal(this.txtPrezzo.Text.Trim().Replace(".", ",")),
                        Keywords = this.txtKeyWords.Text.Trim(),
                        DescrizioneLunga = base.Capitalize(this.descrizione.Value.Trim()),
                        Giacenza = Convert.ToInt32(this.txtGiacenza.Text.Trim()),
                        IDAliquotaIva = Convert.ToInt32(this.ddlIva.SelectedValue),
                        LivRiordino = Convert.ToInt32(this.txtRiordino.Text.Trim()),
                        ID = this.CurrentIDProdotto,
                        Attivo = this.chkAttivo.Checked,
                        DescrTaglia = this.txtDescrTaglia.Text.Trim(),
                        IsOmaggio = this.chkIsOmaggio.Checked,
                        RangeOmaggio = Convert.ToDecimal(this.txtPrezzoMinimoOmaggio.Text.Trim().Replace(".", ",")),
                        ScontoEuro = Convert.ToDecimal(this.txtScontoEuro.Text.Trim().Replace(".", ",")),
                        ScontoPercent = Convert.ToInt32(this.txtSconto.Text.Trim()),
                        Totale = this.CalcolaTotaleProdotto()
                    };
                    _prodotti = base.PerbaffoController.SetProdottiAsNew(_prodotti);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il salvataggio del prodotto,controllare di aver inserito i dati correttamente e la lunghezza dei campi');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione popolare tutti i campi');", true);
            }
        }

    }
}
