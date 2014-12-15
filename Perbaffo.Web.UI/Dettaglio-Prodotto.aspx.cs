using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Perbaffo.Web.UI
{
    public partial class Dettaglio_Prodotto : BasePage, IPerbaffoSite
    {
        #region PRIVATE MEMBERS
        private delegate ProdottoImmagine prodotto(int IDProdotto);
        private delegate List<Colori> colori(int IDProdotto);
        private delegate List<ProdottiTaglie> taglie(int IDProdotto);
        private delegate List<ProdottiFotogallery> fotogallery(int IDProdotto);
        private delegate List<ProdottoImmagine> prodottiAllegati(int IDProdotto);
        private delegate List<Categorie> categorie(int IDProdotto);
        private delegate List<ProdottiRecensioni> recensioni(int IDProdotto, int NumRecensioni);
        private IAsyncResult asyncProdotto;
        private IAsyncResult asyncColori;
        private IAsyncResult asyncTaglie;
        private IAsyncResult asyncFotogallery;
        private IAsyncResult asyncProdAllegati;
        private IAsyncResult asyncCategorie;
        private IAsyncResult asyncRecensioni;
        #endregion

        #region PUBLIC PROPERTY
        public int CurrentIDTagliaProdotto
        {
            get
            {
                if (ViewState["CurrentIDTagliaProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentIDTagliaProdotto"];
            }
            set { ViewState["CurrentIDTagliaProdotto"] = value; }
        }
        public int CurrentIDProdotto
        {
            get
            {
                if (ViewState["CurrentIDProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentIDProdotto"];
            }
            set { ViewState["CurrentIDProdotto"] = value; }
        }
        public int CurrentIDCategoria
        {
            get
            {
                if (ViewState["CurrentIDCategoria"] == null)
                    return -1;
                return (int)ViewState["CurrentIDCategoria"];
            }
            set { ViewState["CurrentIDCategoria"] = value; }
        }
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
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["Prodotto"]))
                {
                    int _result = 0;
                    if (int.TryParse(Request.QueryString["Prodotto"], out _result))
                        this.CurrentIDProdotto = _result;
                    else
                        Server.Transfer("Default.aspx");
                }
                else
                    Server.Transfer("Default.aspx");

                if (!string.IsNullOrEmpty(Request.QueryString["Taglia"]))
                {
                    int _result = 0;
                    if (int.TryParse(Request.QueryString["Taglia"], out _result))
                        this.CurrentIDTagliaProdotto = _result;
                    else
                        this.CurrentIDTagliaProdotto = -1;
                }
                if (!string.IsNullOrEmpty(Request.QueryString["Categoria"]))
                {
                    int _result = 0;
                    if (int.TryParse(Request.QueryString["Categoria"], out _result))
                        this.CurrentIDCategoria = _result;
                }
                ///Carica la maschera
                if (this.CurrentIDProdotto > 0)
                    this.LoadProdotto(this.CurrentIDProdotto, this.CurrentIDTagliaProdotto);
                else
                    Server.Transfer("Default.aspx");

                if (base.UtenteLoggato == null)
                    this.btnFavorito.OnClientClick = "alert('Bisogna essere registrati per poter accedere a questa funzione!');return false;";
                this.btnAmico.OnClientClick = this.JsFinestraEMail();
            }

        }
        /// <summary>
        /// Evento sui prodotti allegati
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void dtlProdottiAllegati_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DETTAGLI" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                string _url = "Dettaglio-Prodotto.aspx?Prodotto=" + e.CommandArgument.ToString();
                if (this.CurrentIDCategoria > 0)
                    _url += "&Categoria=" + this.CurrentIDCategoria;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "red", "window.location = '" + _url + "';", true);
            }
            if (e.CommandName == "ACQUISTA" && !string.IsNullOrEmpty(e.CommandArgument.ToString()))
            {
                try
                {
                    int _result = -1;
                    if (int.TryParse(e.CommandArgument.ToString(), out _result))
                    {
                        ///Aggiungo il prodotto al carrello
                        base.AggiungiProdottoCarrello(_result, -1, -1);
                        ///Aggiorno il widget
                        this.usrCarrello.AggiornaProdottiCarrello();
                        ///Segnala all'utente che il prodotto è nel carrello
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Prodotto inserito nel carrello!');", true);
                    }
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante l\\'inseriemnto del prodotto nel carrello!');", true);
                }
            }
        }
        /// <summary>
        /// SElezione della taglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkTaglia_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((LinkButton)sender).CommandArgument))
            {
                int _result = 0;
                if (int.TryParse(((LinkButton)sender).CommandArgument, out _result))
                {
                    this.CurrentIDTagliaProdotto = _result;
                    PageAsyncTask _taskProdotto = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork1), new EndEventHandler(this.EndAsyncWork1), new EndEventHandler(this.TimeoutHandler), null, true);
                    PageAsyncTask _taskTaglie = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork3), new EndEventHandler(this.EndAsyncWork3), new EndEventHandler(this.TimeoutHandler), null, true);
                    Page.RegisterAsyncTask(_taskProdotto);
                    Page.RegisterAsyncTask(_taskTaglie);
                }
            }
        }
        /// <summary>
        /// Aggiungi il prodotto al carrello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int idColore = -1;
                if (this.ddlVarianti.Items != null && this.ddlVarianti.Items.Count > 0)
                {
                    if (this.ddlVarianti.SelectedIndex != -1)
                    {
                        idColore = Convert.ToInt32(this.ddlVarianti.Items[this.ddlVarianti.SelectedIndex].Value);
                    }
                }
                ///Aggiungo il prodotto al carrello
                base.AggiungiProdottoCarrello(this.CurrentIDProdotto, idColore, this.CurrentIDTagliaProdotto);
                ///Aggiorno il widget carrello
                this.usrCarrello.AggiornaProdottiCarrello();
                ///Segnala all'utente che il prodotto è nel carrello
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Prodotto inserito nel carrello!');", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante l\\'inseriemnto del prodotto nel carrello!');", true);
            }
        }
        /// <summary>
        /// Aggiunge il prodotto ai prodotti favoriti dell'utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.UtenteLoggato != null && this.CurrentIDProdotto > 0)
                {
                    bool _result = base.PerbaffoController.AggiungiProdottoPreferito(base.UtenteLoggato.ID, this.CurrentIDProdotto);
                    if (!_result)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Attenzione si possono inserire 30 prodotti tra i preferiti!\\n (Vai alla Lista dei Desideri per gestire i prodotti)');", true);
                        return;
                    }
                    else
                    {
                        ///Aggiorno il widget del menu
                        this.MenuPerbaffo.AggiornaCountProdottiPreferiti();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Prodotto inserito nella lista dei desideri!');", true);
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante l\\'inseriemnto del prodotto nella listadei prodotti preferiti!');", true);
            }
        }
        /// <summary>
        /// Aggiungo il voto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptRecensioni_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl _div = e.Item.FindControl("divVoto") as HtmlGenericControl;
                if (e.Item.DataItem != null && _div != null)
                {
                    #region creazione stelle voto
                    StringBuilder _str = new StringBuilder();
                    _str.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tbody><tr>");
                    _str.Append("<td><img border=\"0\" alt=\"\" src=\"images/star_red.gif\" /></td>");
                    _str.Append("<td><img border=\"0\" alt=\"\" src=\"images/pixel.gif\" width=\"3\" height=\"15\" /></td>");
                    for (int i = 2; i <= 5; i++)
                    {
                        if (((ProdottiRecensioni)e.Item.DataItem).Voto >= i)
                        {
                            _str.Append("<td><img border=\"0\" alt=\"\" src=\"images/star_red.gif\" /></td>");
                            _str.Append("<td><img border=\"0\" alt=\"\" src=\"images/pixel.gif\" width=\"3\" height=\"15\" /></td>");
                        }
                        else
                        {
                            _str.Append("<td><img border=\"0\" alt=\"\" src=\"images/star_red_out.gif\" /></td>");
                            _str.Append("<td><img border=\"0\" alt=\"\" src=\"images/pixel.gif\" width=\"3\" height=\"15\" /></td>");
                        }
                    }

                    _str.Append("</tr></tbody></table>");
                    _div.InnerHtml = _str.ToString();
                    #endregion
                }
            }
        }

        #region ASYNC METHODS
        /// <summary>
        /// Carica il prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork1(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            prodotto logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottoByIDProdotto;
            asyncProdotto = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, cb, null);
            return asyncProdotto;

        }
        /// <summary>
        /// Carica il prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork1(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncProdotto;
            prodotto logRunningmethod = (prodotto)asyncRes.AsyncDelegate;
            this.BindProdotto(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica i colori del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork2(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            colori logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottoColoriByIDProdotto;
            asyncColori = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, cb, null);
            return asyncColori;

        }
        /// <summary>
        /// Carica i colori del prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork2(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncColori;
            colori logRunningmethod = (colori)asyncRes.AsyncDelegate;
            this.BindProdottoColori(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica le taglie del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork3(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            taglie logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottoTaglieByIDProdotto;
            asyncTaglie = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, cb, null);
            return asyncTaglie;

        }
        /// <summary>
        /// Carica le taglie del prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork3(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncTaglie;
            taglie logRunningmethod = (taglie)asyncRes.AsyncDelegate;
            this.BindProdottoTaglie(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica la fotogallery del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork4(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            fotogallery logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottoFotoGalleryByIDProdotto;
            asyncFotogallery = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, cb, null);
            return asyncFotogallery;

        }
        /// <summary>
        /// Carica la fotogallery del prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork4(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncFotogallery;
            fotogallery logRunningmethod = (fotogallery)asyncRes.AsyncDelegate;
            this.BindProdottoFotoGallery(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica i prodotti allegati del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork5(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            prodottiAllegati logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottiAllegatiByIDProdotto;
            asyncProdAllegati = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, cb, null);
            return asyncProdAllegati;

        }
        /// <summary>
        /// Carica i prodotti allegati del prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork5(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncProdAllegati;
            prodottiAllegati logRunningmethod = (prodottiAllegati)asyncRes.AsyncDelegate;
            this.BindProdottiAllegati(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica le categorie del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork6(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            categorie logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetCategorieDelProdottoByIDProdotto;
            asyncCategorie = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, cb, null);
            return asyncCategorie;

        }
        /// <summary>
        /// Carica le categorie del prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork6(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncCategorie;
            categorie logRunningmethod = (categorie)asyncRes.AsyncDelegate;
            this.BindCategorie(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica le recensioni del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork7(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            recensioni logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetRecensioniByIDProdotto;
            asyncRecensioni = logRunningmethod.BeginInvoke(this.CurrentIDProdotto, 2, cb, null);
            return asyncRecensioni;

        }
        /// <summary>
        /// Carica le recensioni del prodotto
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork7(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncRecensioni;
            recensioni logRunningmethod = (recensioni)asyncRes.AsyncDelegate;
            this.BindRecensioni(logRunningmethod.EndInvoke(result));
        }



        /// <summary>
        /// Eventuale timeout
        /// </summary>
        /// <param name="asyncResult"></param>
        private void TimeoutHandler(IAsyncResult asyncResult)
        {
        }
        #endregion

        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Compone il link per creare la finestra per l'invio della mail
        /// </summary>
        /// <returns></returns>
        private string JsFinestraEMail()
        {
            if (this.CurrentIDProdotto <= 0)
                return "return false;";
            StringBuilder _str = new StringBuilder();

            _str.Append("javascript:window.open ('Invia-Mail-Amico.aspx?Prodotto=" + this.CurrentIDProdotto.ToString() + "','mywindow','width=600px,height=350px,top=250,left=300,location=0,directories=0,resizable=0,scrollbars=0,toolbar=0,menubar=0,status=0'); ");
            _str.Append("return false;");

            return _str.ToString();
        }
        /// <summary>
        /// Taglia la string se troppo grande
        /// </summary>
        /// <param name="valore"></param>
        /// <returns></returns>
        public string TagliaStringa(string valore)
        {
            if (string.IsNullOrEmpty(valore))
                return valore;
            if (valore.Length > 120)
                return valore.Substring(0, 110) + "...";
            return valore;
        }
        /// <summary>
        /// Caricamento di un prodotto/prodotto-taglia
        /// </summary>
        /// <param name="IDProdotto"></param>
        private void LoadProdotto(int IDProdotto)
        {
            this.LoadProdotto(IDProdotto, -1);
        }
        /// <summary>
        /// Caricamento di un prodotto/prodotto-taglia
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <param name="IDTaglia"></param>
        private void LoadProdotto(int IDProdotto, int IDTaglia)
        {
            this.CurrentIDProdotto = IDProdotto;
            PageAsyncTask _taskProdotto = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork1), new EndEventHandler(this.EndAsyncWork1), new EndEventHandler(this.TimeoutHandler), null, true);
            PageAsyncTask _taskColori = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork2), new EndEventHandler(this.EndAsyncWork2), new EndEventHandler(this.TimeoutHandler), null, true);
            PageAsyncTask _taskTaglie = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork3), new EndEventHandler(this.EndAsyncWork3), new EndEventHandler(this.TimeoutHandler), null, true);
            PageAsyncTask _taskFotogallery = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork4), new EndEventHandler(this.EndAsyncWork4), new EndEventHandler(this.TimeoutHandler), null, true);
            PageAsyncTask _taskProdAllegati = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork5), new EndEventHandler(this.EndAsyncWork5), new EndEventHandler(this.TimeoutHandler), null, true);
            PageAsyncTask _taskCategorie = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork6), new EndEventHandler(this.EndAsyncWork6), new EndEventHandler(this.TimeoutHandler), null, true);
            PageAsyncTask _taskRecensioni = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork7), new EndEventHandler(this.EndAsyncWork7), new EndEventHandler(this.TimeoutHandler), null, true);
            Page.RegisterAsyncTask(_taskProdotto);
            Page.RegisterAsyncTask(_taskColori);
            Page.RegisterAsyncTask(_taskTaglie);
            Page.RegisterAsyncTask(_taskFotogallery);
            Page.RegisterAsyncTask(_taskProdAllegati);
            Page.RegisterAsyncTask(_taskCategorie);
            Page.RegisterAsyncTask(_taskRecensioni);
        }
        /// <summary>
        /// Binda il prodotto sulla pagina
        /// </summary>
        /// <param name="prod"></param>
        private void BindProdotto(ProdottoImmagine prod)
        {
            if (prod == null)
                Server.Transfer("Default.aspx");

            this.lblNomeProdotto.InnerText = prod.Nome;
            this.lblDescrProdotto.InnerHtml = base.Capitalize(prod.DescrizioneLunga.Replace("\r\n", "<br/>"));
            this.imgProdotto.Src = base.UrlServerImages + prod.UrlImmagineHQ;
            this.imgProdotto.Alt = prod.DescrImmagine;
            this.imgProdotto.Attributes.Add("title", prod.DescrImmagine);// = prod.DescrImmagine;
            this.hdImageProdotto.Value = base.UrlServerImages + prod.UrlImmagineHQ;

            //Controllo Metatag
            this.GestioneMetaTag(prod);

            ProdottiTaglie _taglia = null;
            if (this.CurrentIDTagliaProdotto > 0)
            {
                _taglia = base.PerbaffoController.GetTagliaByIDTaglia(this.CurrentIDTagliaProdotto, this.CurrentIDProdotto);
                if (_taglia == null)
                    this.CurrentIDTagliaProdotto = -1;
            }
            if (this.CurrentIDTagliaProdotto <= 0 || _taglia == null)
            {
                if (!string.IsNullOrEmpty(prod.DescrTaglia))
                {
                    this.divMisura.Visible = true;
                    this.lblTagliaProdotto.InnerText = prod.DescrTaglia;
                }
                ///rendo visibile l'offerta
                this.divOfferta.Visible = (prod.Prezzo != prod.Totale);
                this.lblTotale.InnerText = string.Format("€ {0}", prod.Totale.ToString());
                this.lblPrezzoPrecedente.InnerText = string.Format("€ {0}", prod.Prezzo.ToString());
                ///Rendo visibile il div prezzo
                this.divPrezzo.Visible = (prod.Prezzo == prod.Totale);
                this.lblPrezzoTotale.InnerText = string.Format("€ {0}", prod.Totale.ToString());
            }
            else
            {
                if (_taglia != null)
                {
                    this.divMisura.Visible = true;
                    this.lblTagliaProdotto.InnerText = _taglia.DescrTaglia;
                    ///rendo visibile l'offerta
                    this.divOfferta.Visible = (_taglia.Prezzo != _taglia.Totale);
                    this.lblTotale.InnerText = string.Format("€ {0}", _taglia.Totale.ToString());
                    this.lblPrezzoPrecedente.InnerText = string.Format("€ {0}", _taglia.Prezzo.ToString());
                    ///Rendo visibile il div prezzo
                    this.divPrezzo.Visible = (_taglia.Prezzo == _taglia.Totale);
                    this.lblPrezzoTotale.InnerText = string.Format("€ {0}", _taglia.Totale.ToString());
                }
            }
        }
        /// <summary>
        /// Carica la combo dei colori
        /// </summary>
        /// <param name="colori"></param>
        private void BindProdottoColori(List<Colori> colori)
        {
            if (colori == null || colori.Count <= 0)
                return;

            this.divColori.Visible = true;
            ///popolo la combo delle varienti
            colori.ForEach(item =>
                {
                    this.ddlVarianti.Items.Add(new ListItem(item.Descrizione, item.ID.ToString()));
                });
        }
        /// <summary>
        /// Carica la fotogallery
        /// </summary>
        /// <param name="fotogallery"></param>
        private void BindProdottoFotoGallery(List<ProdottiFotogallery> fotogallery)
        {
            if (fotogallery == null || fotogallery.Count <= 0)
                return;

            this.divFotoGallery.Visible = true;

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "photo", "javascript:fInitPhotoGallery('" + fotogallery[0].IDProdotto.ToString() + "');", true);
            this.dtlFoto.DataSource = fotogallery;
            this.dtlFoto.DataBind();
        }
        /// <summary>
        /// Carica le taglie
        /// </summary>
        /// <param name="taglie"></param>
        private void BindProdottoTaglie(List<ProdottiTaglie> taglie)
        {
            if (taglie == null || taglie.Count <= 0)
                return;
            this.divTaglia.Visible = true;
            if (this.CurrentIDTagliaProdotto > 0)
            {
                ProdottiTaglie _taglia = taglie.Where(tag => tag.ID == this.CurrentIDTagliaProdotto).SingleOrDefault();
                if (_taglia != null)
                {
                    taglie.Remove(_taglia);
                    var ret = base.PerbaffoController.GetDescrizioneTagliaProdottoByIDProdotto(this.CurrentIDProdotto);
                    var price = ret.Prezzo;
                    if (ret.ScontoEuro > 0 || ret.ScontoPercent > 0)
                    {
                        if (ret.ScontoEuro > 0)
                            price = (ret.Prezzo - ret.ScontoEuro);
                        if (ret.ScontoPercent > 0)
                            price = (ret.Prezzo - (ret.Prezzo / 100 * ret.ScontoPercent));
                    }
                    taglie.Add(new ProdottiTaglie()
                    {
                        ID = -1,
                        DescrTaglia = ret.DescrTaglia,
                        Prezzo = price                       
                    });
                }
            }
            this.rptTaglie.DataSource = taglie.OrderBy(tag => tag.Totale);
            this.rptTaglie.DataBind();
        }
        /// <summary>
        /// Carica i prodotti allegati
        /// </summary>
        /// <param name="prodAllegati"></param>
        private void BindProdottiAllegati(List<ProdottoImmagine> prodAllegati)
        {
            if (prodAllegati == null || prodAllegati.Count <= 0)
                return;

            this.divProdottiAllegati.Visible = true;

            this.dtlProdottiAllegati.DataSource = prodAllegati;
            this.dtlProdottiAllegati.DataBind();
        }
        /// <summary>
        /// Carica le categorie
        /// </summary>
        /// <param name="categorie"></param>
        private void BindCategorie(List<Categorie> categorie)
        {
            if (categorie == null || categorie.Count <= 0)
                return;

            StringBuilder _categ = new StringBuilder(categorie.Count);
            categorie.ForEach(item =>
                {
                    _categ.Append("<a href='Dettaglio-Categoria.aspx?Categoria=" + item.ID + "' title='" + item.DescrizioneCategoria + "'>" + item.DescrizioneBreve + "</a>&nbsp;|&nbsp;");
                });
            string _categorie = _categ.ToString().Substring(0, _categ.ToString().LastIndexOf('|'));
            this.divCategorie.InnerHtml = _categorie;
        }
        /// <summary>
        /// Lista di recensioni del prodotto
        /// </summary>
        /// <param name="recensioni"></param>
        private void BindRecensioni(List<ProdottiRecensioni> recensioni)
        {
            if (base.UtenteLoggato == null)
            {
                this.lnkScrivi.HRef = "javascript:alert('Bisogna essere registrati per poter recensire un prodotto!');";
            }
            else
            {                
                this.lnkScrivi.HRef = "javascript:void(0);";
                bool _isGiaRecensito = base.PerbaffoController.ExistRecensioneByIDUtente(base.UtenteLoggato.ID, this.CurrentIDProdotto);
                ///Controllo se l'utente ha già recensito il prodotto
                if (!_isGiaRecensito)
                    this.lnkScrivi.Attributes.Add("onclick", "javascript:window.open ('Commenta-Prodotto.aspx?Prodotto=" + this.CurrentIDProdotto.ToString() + "','mywindow','width=500px,height=400px,top=250,left=300,location=0,directories=0,resizable=0,scrollbars=0,toolbar=0,menubar=0,status=0');");
                else
                    this.lnkScrivi.HRef = "javascript:alert('Hai già recensito questo prodotto!');";
            }
            ///Visualizzo o meno le recensioni
            if (recensioni == null || recensioni.Count <= 0)
            {
                this.divNoRecensione.Visible = true;
                this.lnkReadAll.HRef = "javascript:alert('Nessuna recensione presente per questo prodotto!');";
                return;
            }
            this.lnkReadAll.HRef = "Leggi-Recensioni.aspx?Categoria=" + this.CurrentIDCategoria + "&amp;Prodotto=" + this.CurrentIDProdotto;
            this.divNoRecensione.Visible = false;
            ///Carico le recensioni
            this.rptRecensioni.DataSource = recensioni;
            this.rptRecensioni.DataBind();

        }
        /// <summary>
        /// Nasconde o visualizza la tabella con prezzo in offerta oppure no
        /// </summary>
        /// <param name="_prezzo1"></param>
        /// <param name="_prezzo2"></param>
        /// <returns></returns>
        public string IsOfferta(decimal _prezzo1, decimal _prezzo2)
        {
            if (_prezzo1 == _prezzo2)
                return "none";
            else
                return "block";

        }
        /// <summary>
        /// visualizza o meno la tabella del prezzo singolo
        /// </summary>
        /// <param name="_prezzo1"></param>
        /// <param name="_prezzo2"></param>
        /// <returns></returns>
        public string IsNotOfferta(decimal _prezzo1, decimal _prezzo2)
        {
            if (_prezzo1 == _prezzo2)
                return "block";
            else
                return "none";

        }
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag(ProdottoImmagine prod)
        {
            this.TitoloPagina = prod.Nome;
            this.DescrizionePagina = prod.Nome;
            if (string.IsNullOrEmpty(prod.Keywords))
                this.KeywordsPagina = prod.Nome.Replace(' ', ',') + ",Perbaffo,cani,gatti,volatili,roditori,acquariologia";
            else
                this.KeywordsPagina = prod.Keywords + ","+prod.Nome.Replace(' ', ',') ;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// calcola il prezzo della taglia considerando lo sconto
        /// </summary>
        /// <param name="taglia"></param>
        /// <returns></returns>
        public string CheckTagliaPrice(ProdottiTaglie taglia)
        {
            if (taglia == null)
                return string.Empty;
            if (taglia.ScontoEuro > 0 || taglia.ScontoPerc > 0)
            {
                if (taglia.ScontoPerc > 0) return (taglia.Prezzo - (taglia.Prezzo / 100 * taglia.ScontoPerc)).ToString();
                if (taglia.ScontoEuro > 0) return (taglia.Prezzo - taglia.ScontoEuro).ToString();
            }
            return Math.Round(taglia.Prezzo,2).ToString();
        } 
        #endregion
    }
}
