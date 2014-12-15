using System;
using System.Text;
using System.Web.UI;
using Perbaffo.Web.UI.Classes;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Perbaffo.Presenter.Model;
using System.Collections;
using Perbaffo.Web.UI.Admin;

namespace Perbaffo.Web.UI
{
    public partial class Pannello_Utente : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagineUtenti{ get { return base.UrlServerImagesUtenti; } }
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
        /// Manda l'utente alla pagina di modifica foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModificaFoto_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Registrazione-Utente-Foto.aspx';", true);
            return;
        }
        /// <summary>
        /// Modifica l'iscrizzione alla newsletter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModificaNewsletter_Click(object sender, EventArgs e)
        {
            if (base.UtenteLoggato == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Login-Utente.aspx';", true);
                return;
            }
            try
            {
                base.UtenteLoggato.NewsLetterCani = this.chkDog.Checked;
                base.UtenteLoggato.NewsLetterGatti = this.chkGatto.Checked;
                base.UtenteLoggato.NewsLetterAcquarologia = this.chkPesci.Checked;
                base.UtenteLoggato.NewsLetterRoditori = this.chkRoditori.Checked;
                base.UtenteLoggato.NewsLetterVolatili = this.chkVolatili.Checked;
                base.InserisciUtenteCorrente(base.PerbaffoController.UpdateNewsLetter(base.UtenteLoggato));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Iscrizione alla newsletter aggiornata!');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Invia l'utente al riepilogo ordini
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVisualizza_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Dettaglio-Ordini-Effettuati.aspx';", true);
        }
        /// <summary>
        /// Modifica dell'indirizzo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModificaIndirizzo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "document.location.href = 'Registrazione-Utente-Dati.aspx';", true);
            return;
        }
        /// <summary>
        /// Cambio della password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAggiornaPassword_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtPassword.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtRetypePassword.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Popolare il campo password!');", true);
                return;
            }
            if(this.txtPassword.Text.Trim() != this.txtRetypePassword.Text.Trim())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('La password non è stata ridigitata correttamente!');", true);
                return;
            }
            if(this.txtPassword.Text.Trim().Length < 6)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('La password deve contenere almeno 6 caratteri!');", true);
                return;
            }
            bool _result = base.PerbaffoController.UpdatePasswordUtente(base.UtenteLoggato.ID,this.txtPassword.Text.Trim());
            if(_result)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('La tua password è stata modificata!');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "alert('Errore durante la modifica della password, la tua password non è stata cambiata!');", true);
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
        #endregion

        #region PRIVATE METHODS
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
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            TitoloPagina = "Perbaffo - Pannello utente di " + base.UtenteLoggato.Nome;
            DescrizionePagina = "Perbaffo pannello utente di " + base.UtenteLoggato.Nome + " possibilità di cambiare password,aggiornare newsletter";
            KeywordsPagina = "Perbaffo,pannello,utente,foto,amici,dati,personali,password,newsletter,categoria,ordini,sconti";
        }
        /// <summary>
        /// Carica tutti i campi sulla form
        /// </summary>
        private void LoadFields()
        {
            try
            {
                if (base.UtenteLoggato.ImgFriend != null && !base.UtenteLoggato.ImgFriend.ToUpper().Contains("NO-IMAGE"))
                {
                    this.imgFriend.ImageUrl = UrlImmagineUtenti + base.UtenteLoggato.ImgFriend;
                    this.imgFriend.ToolTip = base.UtenteLoggato.NomeFriend;
                    this.lblDescrFriend.InnerText = base.UtenteLoggato.NomeFriend; 
                }
                StringBuilder _strBuilder = new StringBuilder();
                _strBuilder.Append(base.Capitalize(base.UtenteLoggato.Nome) + " - " + base.Capitalize(base.UtenteLoggato.Cognome) + "<br/>");
                _strBuilder.Append(base.UtenteLoggato.DataNascita.ToShortDateString() + "<br/>");
                _strBuilder.Append(base.UtenteLoggato.CFiscPIva + "<br/>");
                if (!string.IsNullOrEmpty(base.UtenteLoggato.RagioneSociale))
                    _strBuilder.Append(base.Capitalize(base.UtenteLoggato.RagioneSociale) + "<br/>");
                _strBuilder.Append(base.Capitalize(base.UtenteLoggato.Indirizzo) + " - " + base.UtenteLoggato.NumeroCivico + "<br/>");
                _strBuilder.Append(base.UtenteLoggato.CAP + "<br/>");
                _strBuilder.Append(base.Capitalize(base.UtenteLoggato.Citta) + " (" + base.UtenteLoggato.Provincia + ")<br/>");
                _strBuilder.Append(base.UtenteLoggato.EMail + "<br/>");
                _strBuilder.Append(base.UtenteLoggato.Telefono + "<br/>");
                _strBuilder.Append("<span class='small_text'>iscritto dal: " + base.UtenteLoggato.DataCreazioneUtente.ToShortDateString() +"</span>");
                this.lblRiepilogoDati.InnerHtml = _strBuilder.ToString();

                ///Aggiorno le news letter
                this.chkDog.Checked = base.UtenteLoggato.NewsLetterCani;
                this.chkGatto.Checked= base.UtenteLoggato.NewsLetterGatti;
                this.chkPesci.Checked= base.UtenteLoggato.NewsLetterAcquarologia;
                this.chkRoditori.Checked = base.UtenteLoggato.NewsLetterRoditori;
                this.chkVolatili.Checked = base.UtenteLoggato.NewsLetterVolatili;

                ///Carico gli ordini
                /////
                int _numOrdiniAttivi = 0;
                int _idTotaleOrdini = base.PerbaffoController.GetCountOrdiniEffettuatiByIDUtente(base.UtenteLoggato.ID);
                if (_idTotaleOrdini > 0)
                {
                    this.rptOrdiniAttivi.DataSource = base.PerbaffoController.GetOrdiniAttiviByIDUtente(base.UtenteLoggato.ID);
                    this.rptOrdiniAttivi.DataBind();
                    _numOrdiniAttivi = (this.rptOrdiniAttivi.DataSource != null) ? ((IList)this.rptOrdiniAttivi.DataSource).Count : 0;
                }
                this.lblOrdini.InnerText = "Hai effettuato " + _idTotaleOrdini.ToString() + " ordini da quando sei iscritto";
                if (_numOrdiniAttivi > 0)
                {
                    this.divOrdineAttivo.Visible = true;
                    int _countOrdine = base.PerbaffoController.GetCountOrdineSpeditoByIDUtente(base.UtenteLoggato.ID);
                    lnkOrdineSpedito.Visible = (_countOrdine > 0);

                }
                this.btnVisualizza.Visible = (_idTotaleOrdini > 0); //da nascondere se 0 ordini

                ///Controllo Sconto
                UtentiPromozioni _promoz = base.PerbaffoController.GetUtentePromozioneAttivoByIDUtente(this.UtenteLoggato.ID);
                if (_promoz != null)
                {
                    this.divScontoPersonale.Visible = true;
                    _strBuilder.Remove(0, _strBuilder.Length);
                    _strBuilder.Append("<b>Per ogni ordine che effettuerai avrai uno sconto&nbsp;");
                    if(_promoz.ScontoEuro.HasValue && _promoz.ScontoEuro.Value > 0)
                        _strBuilder.Append(" € " + _promoz.ScontoEuro.Value.ToString());
                    else
                        _strBuilder.Append(_promoz.ScontoPercent.Value.ToString() + "%&nbsp;");
                    _strBuilder.Append("sul totale valevole per ordini di almeno:&nbsp;€&nbsp;" + _promoz.MinimoOrdine.ToString() +"</b>");
                    this.lblScontoPersonale.InnerHtml = _strBuilder.ToString();
                }
                else
                {
                    this.divScontoPersonale.Visible = false;
                    this.lblScontoPersonale.InnerText = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Controlla eventuale codice sconto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnControlla_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCodiceSconto.Text.Trim()) || this.txtCodiceSconto.Text.Trim().Length > 10)
            {
                this.lblEntitaSconto.InnerHtml = "<b>Codice sconto non valido!</b>";
                return;
            }
            CodicePromozioni _cod = base.PerbaffoController.GetCodicePromozioneAttivoByCodice(this.txtCodiceSconto.Text.Trim());
            if (_cod != null)
            {
                string _codice = "Inserendo questo codice '" + this.txtCodiceSconto.Text.Trim().ToUpper() + "' al momento dell'acquisto avrai diritto ad uno sconto di ";
                if (_cod.ScontoEuro.HasValue && _cod.ScontoEuro.Value > 0)
                {
                    _codice += "€ " + _cod.ScontoEuro.Value.ToString();
                }
                else
                {
                    _codice += _cod.ScontoPercent.Value.ToString() +"% ";
                }
                _codice += " per ordini di almeno € " + _cod.MinimoOrdine.ToString();

                this.lblEntitaSconto.InnerHtml = "<b>"+_codice+"</b>";
            }
            else
            {
                this.lblEntitaSconto.InnerHtml = "<b>Codice sconto non valido!</b>";
            }

        }
        #endregion
    }
}
