using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Collections;
using Perbaffo.Presenter.Model;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Perbaffo.Web.UI
{
    public partial class Default : BasePage, IPerbaffoSite
    {
        #region PUBLIC MEMBERS
        public string ListFoto = string.Empty;
        #endregion

        #region PRIVATE MEMBERS
        private delegate List<ProdottoImmagine> prodottiOfferta(int numProdotti);
        private delegate List<ProdottoImmagine> prodottiVetrina(int numProdotti);
        private delegate List<ProdottoNovita> prodottoNovita();
        private delegate List<string> fotoAmici(int numFoto);
        private IAsyncResult asyncFotoAmici;
        private IAsyncResult asyncProdVetrina;
        private IAsyncResult asyncProdNovita;
        private IAsyncResult asyncProdOfferta;
        #endregion

        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        public string UrlImmagineUtenti { get { return base.UrlServerImagesUtenti; } }
        #endregion

        #region PRIVATE PROPERTY
        private List<ProdottoImmagine> CurrentVetrina { get; set; }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            ///Accesso utente
            if (!Page.IsPostBack)
            {
                ///1) aggiunta delle statistiche
                ///2) carico i prodotti                
                //this.AggiornaLink();
                //this.AggiornaLayout();
                PageAsyncTask _taskVetrina = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork1), new EndEventHandler(this.EndAsyncWork1), new EndEventHandler(this.TimeoutHandler), null, true);
                PageAsyncTask _taskNovita = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork2), new EndEventHandler(this.EndAsyncWork2), new EndEventHandler(this.TimeoutHandler), null, true);
                PageAsyncTask _taskOfferta = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork3), new EndEventHandler(this.EndAsyncWork3), new EndEventHandler(this.TimeoutHandler), null, true);
                PageAsyncTask _taskFotoAmici = new PageAsyncTask(new BeginEventHandler(this.BeginAsyncWork4), new EndEventHandler(this.EndAsyncWork4), new EndEventHandler(this.TimeoutHandler), null, true);
                Page.RegisterAsyncTask(_taskVetrina);
                Page.RegisterAsyncTask(_taskNovita);
                Page.RegisterAsyncTask(_taskOfferta);
                Page.RegisterAsyncTask(_taskFotoAmici);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
             base.OnPreRender(e);
        }

        #region ASYNC METHODS
        /// <summary>
        /// Carica i prodotti in vetrina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork1(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            prodottiVetrina logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottiVetrina;
            asyncProdVetrina = logRunningmethod.BeginInvoke(20, cb, null);
            return asyncProdVetrina;

        }
        /// <summary>
        /// Carica i prodotti in vetrina
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork1(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncProdVetrina;
            prodottiVetrina logRunningmethod = (prodottiVetrina)asyncRes.AsyncDelegate;
            this.CaricaVetrina(logRunningmethod.EndInvoke(result));            
        }
        /// <summary>
        /// Carica tre novità random 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork2(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            prodottoNovita logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetTreProdottiNovita;
            asyncProdNovita = logRunningmethod.BeginInvoke(cb, null);
            return asyncProdNovita;

        }
        /// <summary>
        /// Carica tre novità random 
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork2(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncProdNovita;
            prodottoNovita logRunningmethod = (prodottoNovita)asyncRes.AsyncDelegate;
            this.CaricaProdottiNovita(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica tre offerte random 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork3(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            prodottiOfferta logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetProdottiOfferta;
            asyncProdOfferta = logRunningmethod.BeginInvoke(3,cb, null);
            return asyncProdOfferta;

        }
        /// <summary>
        /// Carica tre offerte random 
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork3(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncProdOfferta;
            prodottiOfferta logRunningmethod = (prodottiOfferta)asyncRes.AsyncDelegate;
            this.CaricaProdottiInOfferta(logRunningmethod.EndInvoke(result));
        }
        /// <summary>
        /// Carica foto randorm 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private IAsyncResult BeginAsyncWork4(Object sender, EventArgs e, AsyncCallback cb, object state)
        {
            fotoAmici logRunningmethod = null;
            logRunningmethod = base.PerbaffoController.GetFotoAmici;
            asyncFotoAmici = logRunningmethod.BeginInvoke(10, cb, null);
            return asyncFotoAmici;

        }
        /// <summary>
        /// Carica foto randorm 10 
        /// </summary>
        /// <param name="result"></param>
        private void EndAsyncWork4(IAsyncResult result)
        {
            AsyncResult asyncRes = (AsyncResult)asyncFotoAmici;
            fotoAmici logRunningmethod = (fotoAmici)asyncRes.AsyncDelegate;
            this.CaricaFotoAmici(logRunningmethod.EndInvoke(result));
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
        /// Carica le foto degli amici
        /// </summary>
        /// <param name="list"></param>
        private void CaricaFotoAmici(List<string> listFoto)
        {
            if (listFoto == null || listFoto.Count <= 0)
            {
                ListFoto = "[ { src: 'images/no-image.jpg' } ]";
                return;
            }
            try
            {
                StringBuilder _list = new StringBuilder(listFoto.Count);
                _list.Append("[\n");
                listFoto.ForEach(foto =>
                    {
                        _list.Append("{ href: 'Galleria-Foto-Animali.aspx', src: '" + UrlImmagineUtenti + foto + "' },\n");
                    });
                _list.Append("]\n");

                ListFoto = _list.ToString();
                ListFoto = ListFoto.Remove(ListFoto.LastIndexOf(",\n"), 1);
            }
            catch (Exception ex)
            {
                ListFoto = "[ { src: 'images/no-image.jpg' } ]";
                return;
            }
        }

        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {

        }
        /// <summary>
        /// Carica i prodotti piu venduti
        /// </summary>
        private void CaricaProdottiInOfferta(List<ProdottoImmagine> prodImmagine) 
        {
            this.rptPiuVenduti.DataSource = prodImmagine;
            this.rptPiuVenduti.DataBind();
        }
        /// <summary>
        /// Carica i prodotti contrassegnati come novità
        /// </summary>
        private void CaricaProdottiNovita(List<ProdottoNovita> _prodImg)
        {
            if (_prodImg != null && _prodImg.Count == 3)
            {
                this.NomeProdottoNovita1.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + _prodImg[0].ID;
                this.NomeProdottoNovita2.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + _prodImg[1].ID;
                this.NomeProdottoNovita3.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + _prodImg[2].ID;
                this.NomeProdottoNovita1.InnerText = _prodImg[0].Nome;
                this.NomeProdottoNovita2.InnerText = _prodImg[1].Nome;
                this.NomeProdottoNovita3.InnerText = _prodImg[2].Nome;
                this.NomeProdottoNovita1.Title = _prodImg[0].Nome;
                this.NomeProdottoNovita2.Title = _prodImg[1].Nome;
                this.NomeProdottoNovita3.Title = _prodImg[2].Nome;
                this.lblDescrizioneProdotto1.Text = _prodImg[0].Nome;
                this.lblDescrizioneProdotto2.Text = _prodImg[1].Nome;
                this.lblDescrizioneProdotto3.Text = _prodImg[2].Nome;
                this.lblPrezzo1.Text = "€ " + _prodImg[0].Totale.ToString();
                this.lblPrezzo2.Text = "€ " + _prodImg[1].Totale.ToString();
                this.lblPrezzo3.Text = "€ " + _prodImg[2].Totale.ToString();
                this.imgProdotto1.ImageUrl = UrlImmagine + _prodImg[0].UrlImmagine;
                this.imgProdotto2.ImageUrl = UrlImmagine + _prodImg[1].UrlImmagine;
                this.imgProdotto3.ImageUrl = UrlImmagine + _prodImg[2].UrlImmagine;
                this.imgProdotto1.AlternateText = _prodImg[0].DescrImmagine;
                this.imgProdotto2.AlternateText = _prodImg[1].DescrImmagine;
                this.imgProdotto3.AlternateText = _prodImg[2].DescrImmagine;
                this.NomeProdottoImmagine1.HRef  = "Dettaglio-Prodotto.aspx?Prodotto="+_prodImg[0].ID;
                this.NomeProdottoImmagine2.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + _prodImg[1].ID;
                this.NomeProdottoImmagine3.HRef = "Dettaglio-Prodotto.aspx?Prodotto=" + _prodImg[2].ID;
                this.NomeProdottoImmagine1.Title = string.Empty;
                this.NomeProdottoImmagine2.Title = string.Empty;
                this.NomeProdottoImmagine3.Title = string.Empty;
                this.lblDataInseriemnto1.InnerText = "Inserito il " + _prodImg[0].DataInserimento.Value.ToShortDateString();
                this.lblDataInseriemnto2.InnerText = "Inserito il " + _prodImg[1].DataInserimento.Value.ToShortDateString();
                this.lblDataInseriemnto3.InnerText = "Inserito il " + _prodImg[2].DataInserimento.Value.ToShortDateString();
            }
        }
        /// <summary>
        /// Carica vetrina prodotti
        /// </summary>
        private void CaricaVetrina(List<ProdottoImmagine> prodImmagine) 
        {
            this.CurrentVetrina = prodImmagine;
            ArrayList _list = new ArrayList(5){0,1,2,3};
            //_list.Add(0);
            //_list.Add(1);
            //_list.Add(2);
            //_list.Add(3);
            //_list.Add(4);
            this.rptVetrina.DataSource = _list;
            this.rptVetrina.DataBind();
        }
        /// <summary>
        /// Carica i dettagli della vetrina prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptVetrina_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem != null && this.CurrentVetrina != null)
                {
                    int _row = Convert.ToInt32(e.Item.DataItem);
                    ((Repeater)e.Item.Controls[1]).DataSource = this.CurrentVetrina.Skip(_row * 5).Take(5);
                    ((Repeater)e.Item.Controls[1]).DataBind();
                }
            }
        }
        #endregion

    }
}
