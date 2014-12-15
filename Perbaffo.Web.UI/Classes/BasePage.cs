using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;
using System.Text.RegularExpressions;
using System.Configuration;
using Perbaffo.FTPClient;
using System.IO.Compression;

namespace Perbaffo.Web.UI.Classes
{
    public class BasePage : Page,IDisposable
    {
        #region PUBLIC MEMBERS
        public const int PAGAMENTO_BONIFICO = 8;
        public const int PAGAMENTO_POSTEPAY = 11;
        public const int PAGAMENTO_PAYPAL = 9;
        public const int PAGAMENTO_RITIROAMANO = 10;
        public const int PAGAMENTO_CONTRASSEGNO = 12;
        #endregion

        #region PRIVATE MEMBERS
        private ControllerPresentation _currentController = null; 
        private string EMailRegEx = @"^(?:[a-zA-Z0-9_'^&amp;/+-])+(?:\.(?:[a-zA-Z0-9_'^&amp;/+-])+)*@(?:(?:\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\]?)|(?:[a-zA-Z0-9-]+\.)+(?:[a-zA-Z]){2,}\.?)$";
        #endregion

        #region PUBLIC PROPERTY
        /// <summary>
        /// Controller corrente
        /// </summary>
        public ControllerPresentation PerbaffoController
        {
            get
            {
                if (_currentController == null)
                    _currentController = new ControllerPresentation();
                return _currentController;
            }
        }
        /// <summary>
        /// Carrello utente
        /// </summary>
        public Carrello Carrello
        {
            get 
            {
                if (Session["Carrello"] == null)
                    return null;
                return Session["Carrello"] as Carrello; 
            }
            private set { Session["Carrello"] = value; }
        }
        /// <summary>
        /// Utente correntemente loggato
        /// </summary>
        public Utenti UtenteLoggato
        {
            get 
            {
                    if (Session["UtenteLoggato"] == null)
                        return null;
                    else
                        return Session["UtenteLoggato"] as Utenti;
            }
            private set { Session["UtenteLoggato"] = value; }
        }
        /// <summary>
        /// Utente in fase di registrazione
        /// </summary>
        public Utenti TempUtente
        {
            get
            {
                if (Session["TempUtente"] == null)
                    return null;
                else
                    return Session["TempUtente"] as Utenti;
            }
            private set { Session["TempUtente"] = value; }
        }
        /// <summary>
        /// Ordine dell'utente
        /// </summary>
        public Ordini CurrentOrdine
        {
            get
            {
                if (Session["CurrentOrdine"] == null)
                    return null;
                else
                    return Session["CurrentOrdine"] as Ordini;
            }
            private set { Session["CurrentOrdine"] = value; }
        }
        /// <summary>
        /// Path delle immagini
        /// </summary>
        public string UrlServerImages
        {
            get 
            { 
                if(string.IsNullOrEmpty(Application["UrlServerImages"].ToString()))
                    Application["UrlServerImages"] = ConfigurationManager.AppSettings["PATHIMAGE"];
                return Application["UrlServerImages"] as string; 
            }
        }
        /// <summary>
        /// Indirizzo per le immagini degli utenti
        /// </summary>
        public string UrlServerImagesUtenti
        {
            get 
            {
                if (string.IsNullOrEmpty(Application["UrlServerImagesUtenti"].ToString()))
                    Application["UrlServerImagesUtenti"] = ConfigurationManager.AppSettings["PATHIMAGEUTENTI"];
                return Application["UrlServerImagesUtenti"] as string; 
            }
        }
        /// <summary>
        /// Indirizzo per le immagini degli CATEGORIE
        /// </summary>
        public string UrlServerImagesCategorie
        {
            get 
            {
                if (string.IsNullOrEmpty(Application["UrlServerImagesCategorie"].ToString()))
                    Application["UrlServerImagesCategorie"] = ConfigurationManager.AppSettings["PATHIMAGECATEGORIE"];
                return Application["UrlServerImagesCategorie"] as string; 
            }
        }
        /// <summary>
        /// Indirizzo per le immagini degli CATEGORIE
        /// </summary>
        public string UrlServerImagesNews
        {
            get 
            {
                if (string.IsNullOrEmpty(Application["UrlServerImagesNews"].ToString()))
                    Application["UrlServerImagesNews"] = ConfigurationManager.AppSettings["PATHIMAGENEWS"];
                return Application["UrlServerImagesNews"] as string; 
            }
        }
        /// <summary>
        /// Codice proveniente da un sito di affiliazione
        /// </summary>        
        public string CurrentCodiceAffiliazione
        {
            get
            {
                if (Session["CurrentCodiceAffiliazione"] == null)
                    return null;
                else
                    return Session["CurrentCodiceAffiliazione"] as string;
            }
            private set { Session["CurrentCodiceAffiliazione"] = value; }
        }
        ///// <summary>
        ///// Mette il viewstate in sessione
        ///// </summary>
        //protected override PageStatePersister PageStatePersister
        //{
        //    get
        //    {
        //        return new SessionPageStatePersister(this);
        //    }
        //}
        #endregion

        #region EVENTS
        /// <summary>
        /// Inserisco un eventuale codice affiliazione
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request.QueryString["AFL"]))
            {
                this.CurrentCodiceAffiliazione = Request.QueryString["AFL"].Trim().ToUpper();
            }
            base.OnPreRender(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //HttpContext context = HttpContext.Current;
            //HttpRequest request = context.Request;
            //string acceptEncoding = request.Headers["Accept-Encoding"];
            //HttpResponse response = context.Response;
            //if (!string.IsNullOrEmpty(acceptEncoding))
            //{
            //    acceptEncoding = acceptEncoding.ToUpperInvariant();
            //    response.Filter = new GZipStream(context.Response.Filter,
            //                          CompressionMode.Compress);
            //    if (acceptEncoding.Contains("GZIP"))
            //    {
            //        response.AppendHeader("Content-encoding",
            //                              "gzip");
            //    }
            //    else if (acceptEncoding.Contains("DEFLATE"))
            //    {
            //        response.AppendHeader("Content-encoding",
            //                              "deflate");
            //    }
            //}
            //response.Cache.VaryByHeaders["Accept-Encoding"] = true;    
            base.Render(writer);
        }
        /// <summary>
        /// Cancella variabili di sessione inutile
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Buffer = true;
             base.OnInit(e);
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Capitaliza la stringa
        /// </summary>
        /// <param name="toCapitalize"></param>
        /// <returns></returns>
        public string Capitalize(string toCapitalize)
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
        /// Inserisce un utente corrente
        /// </summary>
        /// <param name="utente"></param>
        public void InserisciUtenteCorrente(Utenti utente)
        {
            if (utente != null)
                this.UtenteLoggato = utente;
        }
        /// <summary>
        /// Indica se l'email è valida oppure no
        /// </summary>
        /// <param name="eMail"></param>
        /// <returns></returns>
        public bool IsEmailValid(string eMail)
        {
            Regex objNotNaturalPattern = new Regex(EMailRegEx);
            return objNotNaturalPattern.IsMatch(eMail);
        }
        /// <summary>
        /// Esegue il logout dell'utente
        /// </summary>
        public void LogoutUtente()
        {
            this.UtenteLoggato = null;
            this.CurrentOrdine = null;
            this.TempUtente = null;
        }
        /// <summary>
        /// Pulisco le variabili di sessione
        /// </summary>
        public void OrdineConcluso()
        {
            this.CurrentOrdine = null;
            this.TempUtente = null;
            this.Carrello = null;
        }

        #region FTP
        /// <summary>
        /// Inseriscie / sostituisce un immagine
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool FTPPut(Byte[] file, string fileName)
        {
            try
            {
                string _urlFTP = ConfigurationManager.AppSettings["FTPURL"];
                string _usernameFTP = ConfigurationManager.AppSettings["FTPUSERNAME"];
                string _passwordFTP = ConfigurationManager.AppSettings["FTPPASSWORD"];
                using (FTPClient.FTPClient _ftpClient = new FTPClient.FTPClient(_urlFTP, 21))
                {
                    // fa login
                    _ftpClient.Login(_usernameFTP, _passwordFTP);
                    _ftpClient.TransferType = FTPTransferType.BINARY;
                    _ftpClient.Put(file, fileName);
                    // esce
                    _ftpClient.Quit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Cancella un immagine
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool FTPDelete(string fileName)
        {
            try
            {
                string _urlFTP = ConfigurationManager.AppSettings["FTPURL"];
                string _usernameFTP = ConfigurationManager.AppSettings["FTPUSERNAME"];
                string _passwordFTP = ConfigurationManager.AppSettings["FTPPASSWORD"];
                using (FTPClient.FTPClient _ftpClient = new FTPClient.FTPClient(_urlFTP, 21))
                {
                    // fa login
                    _ftpClient.Login(_usernameFTP, _passwordFTP);
                    _ftpClient.TransferType = FTPTransferType.BINARY;
                    _ftpClient.Delete(fileName);
                    // esce
                    _ftpClient.Quit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region registrazione utente
        /// <summary>
        /// Aggiunge utente Registrazione
        /// </summary>
        /// <param name="utenti"></param>
        public void AddUtenteRegistrazione(Utenti utenti)
        {
            this.TempUtente = utenti;
        }
        /// <summary>
        /// Configura come utente loggato quello appena registrato
        /// e ripulisce la variabile di sessione
        /// </summary>
        public void InserisciUtenteRegistrato()
        {
            if (this.TempUtente != null && this.UtenteLoggato == null)
            {
                this.UtenteLoggato = this.TempUtente;
                this.TempUtente = null;
            }
        }
        /// <summary>
        /// Rimuove utente Registrazione
        /// </summary>
        /// <param name="utenti"></param>
        public void RemoveUtenteRegistrazione(Utenti utenti)
        {
            this.TempUtente = null;
        }
        #endregion

        #region CARRELLO
        /// <summary>
        /// Controlla il codice sconto immesso dall'utente
        /// </summary>
        /// <param name="CodiceSconto"></param>
        public void CheckCodiceSconto(string CodiceSconto)
        {
            if (string.IsNullOrEmpty(CodiceSconto))
            {
                this.Carrello.CodiceSconto = string.Empty;
                return;
            }
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0 && !string.IsNullOrEmpty(CodiceSconto))
            {
                this.Carrello.CodiceSconto = CodiceSconto;
            }
        }
        /// <summary>
        /// Aggiorno la quantità
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Quantita"></param>
        public void AggiornaQuantita(CarreloItemKey _key, int Quantita)
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                ///Cerco se esiste un prodotto con quella chiave nel carrello
                CarrelloItem _item = this.Carrello.Prodotti.Where(car => car.IDCarrelloItem.IDProdotto == _key.IDProdotto
                                    && car.IDCarrelloItem.IDColore == _key.IDColore
                                    && car.IDCarrelloItem.IDTaglia == _key.IDTaglia).SingleOrDefault();
                if (_item != null)
                {
                    _item.Quantita = Quantita;
                    _item.Totale = _item.Prodotto.Totale * _item.Quantita;
                }
            }
        }
        /// <summary>
        /// Aggiunge un prodotto nel carrello
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <param name="IDColore"></param>
        /// <param name="IDTaglia"></param>
        public void AggiungiProdottoCarrello(int IDProdotto, int IDColore, int IDTaglia)
        {
            if (IDProdotto <= 0)
                return;
            try
            {
                Colori _colore = null;
                ProdottiTaglie _taglia = null;
                ProdottoImmagine _prod = this.PerbaffoController.GetProdottoByIDProdotto(IDProdotto);
                if (IDColore > 0)
                    _colore = this.PerbaffoController.GetColoreByIDColore(IDColore);
                else
                {
                    ///Aggiungo il colore di default
                    List<Colori> _coloreDefault = this.PerbaffoController.GetProdottoColoriByIDProdotto(IDProdotto);
                    if (_coloreDefault != null && _coloreDefault.Count > 0)
                    {
                        _colore = _coloreDefault.FirstOrDefault();
                    }
                }
                if (IDTaglia > 0)
                    _taglia = this.PerbaffoController.GetTagliaByIDTaglia(IDTaglia, _prod.ID);

                this.AggiungiProdottoCarrello(_prod, _taglia, _colore);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Aggiunge un prodotto al carrello
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="taglia"></param>
        /// <param name="colore"></param>
        public void AggiungiProdottoCarrello(ProdottoImmagine prodotto, ProdottiTaglie taglia, Colori colore)
        {
            if (this.Carrello == null)
            {
                ///Inizializzo il carrello per l'utente
                this.Carrello = new Carrello()
                {
                    IDCarrello = new Guid(),
                    DataCarrello = DateTime.Now,
                    IDUtente = (this.UtenteLoggato != null) ? this.UtenteLoggato.ID : 0,
                    CodiceSconto = string.Empty,
                    Prodotti = new List<CarrelloItem>()
                };
            }

            ///Compongo la chiave
            CarreloItemKey _key = new CarreloItemKey();
            _key.IDProdotto = prodotto.ID;
            if (colore != null)
                    _key.IDColore = colore.ID;
            else
                _key.IDColore = -1;
            if (taglia != null)
                _key.IDTaglia = taglia.ID;
            else
                _key.IDTaglia = -1;
            ///Cerco se esiste un prodotto con quella chiave nel carrello
            CarrelloItem _item = this.Carrello.Prodotti.Where(car => car.IDCarrelloItem.IDProdotto == _key.IDProdotto
                                && car.IDCarrelloItem.IDColore == _key.IDColore
                                && car.IDCarrelloItem.IDTaglia == _key.IDTaglia).SingleOrDefault();

            if (_item == null)
            {
                this.Carrello.Prodotti.Add(new CarrelloItem()
                {
                    Colore = colore,
                    Quantita = 1,
                    Taglia = taglia,
                    Prodotto = prodotto,
                    IDCarrelloItem = _key,
                    Totale = prodotto.Totale * 1
                });
            }
            else
            {
                _item.Quantita += 1;
                _item.Totale = _item.Prodotto.Totale * _item.Quantita;
            }
        }
        /// <summary>
        /// Restituisce il totale di elementi nel carrello
        /// </summary>
        /// <returns></returns>
        public int GetNumeroElementiCarrello()
        {
            if (this.Carrello == null)
                return 0;
            else
            {
                if (this.Carrello.Prodotti == null)
                    return 0;
                return this.Carrello.Prodotti.Count();
            }
        }
        /// <summary>
        /// Rimuove gli elementi dal carrello
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <param name="IDColore"></param>
        /// <param name="IDTaglia"></param>
        /// <returns></returns>
        public void RimuoviProdottoCarrello(CarreloItemKey _key)
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                ///Cerco se esiste un prodotto con quella chiave nel carrello
                CarrelloItem _item = this.Carrello.Prodotti.Where(car => car.IDCarrelloItem.IDProdotto == _key.IDProdotto
                                    && car.IDCarrelloItem.IDColore == _key.IDColore
                                    && car.IDCarrelloItem.IDTaglia == _key.IDTaglia).SingleOrDefault();
                if (_item != null)
                    this.Carrello.Prodotti.Remove(_item);
                ///Ripulisco il carrello se questo è vuoto
                if (this.Carrello.Prodotti.Count == 0)
                    this.Carrello = null;
            }
        }
        /// <summary>
        /// Calcola tutti i prezzi dei singoli prodotti
        /// </summary>
        private void CalcolaTotaleProdotti()
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                this.Carrello.Prodotti.ForEach(prod =>
                {
                    prod.Totale = new decimal(0.00);
                    if (prod.Taglia == null)
                        prod.Totale = prod.Prodotto.Totale * prod.Quantita;
                    else
                        prod.Totale = prod.Taglia.Totale * prod.Quantita;
                });
            }
        }
        /// <summary>
        /// Totale del carrello
        /// </summary>
        public void CalcolaTotaleCarrello()
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                ///Aggiorna i totali dei singoli prodotti
                this.CalcolaTotaleProdotti();
                ///Aggiorna il totale del carrello
                this.Carrello.TotaleCarrello = new decimal(0.00);
                this.Carrello.Prodotti.ForEach(prod =>
                    {
                        this.Carrello.TotaleCarrello += prod.Totale;
                    });
                ///Aggiungo gli eventuali sconti
                if (this.Carrello.IDCodicePromozione > 0 && (this.Carrello.TotaleCodiceScontoEuro > 0 || this.Carrello.TotaleCodiceScontoPerc > 0))
                {
                    if (this.Carrello.TotaleCodiceScontoEuro > 0)
                    {
                        this.Carrello.TotaleCarrello -= this.Carrello.TotaleCodiceScontoEuro;
                    }
                    else
                    {
                        decimal _result = (this.Carrello.TotaleCarrello * this.Carrello.TotaleCodiceScontoPerc) / 100;
                        this.Carrello.TotaleCarrello = (this.Carrello.TotaleCarrello - _result);
                    }
                }
                if (this.Carrello.IDUtentePromozione > 0 && (this.Carrello.TotaleUtenteScontoEuro > 0 || this.Carrello.TotaleUtenteScontoPerc > 0))
                {
                    if (this.Carrello.TotaleUtenteScontoEuro > 0)
                    {
                        this.Carrello.TotaleCarrello -= this.Carrello.TotaleUtenteScontoEuro;
                    }
                    else
                    {
                        decimal _result = (this.Carrello.TotaleCarrello * this.Carrello.TotaleUtenteScontoPerc) / 100;
                        this.Carrello.TotaleCarrello = (this.Carrello.TotaleCarrello - _result);
                    }
                }
                ///Totale carrello
                this.Carrello.TotaleCarrello = Math.Round(this.Carrello.TotaleCarrello, 2);
            }
        }
        /// <summary>
        /// Indica se c'è o meno uno sconto spedizione
        /// </summary>
        /// <returns></returns>
        public bool IsScontoSpedizione()
        {
            if (this.Carrello.TotaleScontoSpedizione <= 0)
            {
                this.CalcolaTotaleCarrello();
                return this.Carrello.TotaleCarrello > new decimal(35.00);
            }
            return true;
        }
        /// <summary>
        /// Ritorna il totale del carrello
        /// </summary>
        /// <returns></returns>
        public decimal TotaleCarrello()
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                return Math.Round(this.Carrello.TotaleCarrello,2);
            }
            else
                return new decimal(0.00);
        }
        /// <summary>
        /// Ottiene il carrello
        /// </summary>
        /// <returns></returns>
        public List<CarrelloItem> GetCarrelloProdotti()
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                ///Restituisce il totale del carrello
                this.CalcolaTotaleCarrello();
                return this.Carrello.Prodotti;
            }
            else
                return null;
        }
        /// <summary>
        /// Totale carrello senza sconti
        /// </summary>
        /// <returns></returns>
        public decimal GetTotaleProdotti()
        {
            if (this.Carrello != null && this.Carrello.Prodotti != null && this.Carrello.Prodotti.Count > 0)
            {
                decimal _tot = new decimal(0.00);
                this.Carrello.Prodotti.ForEach(item =>
                    {
                        _tot += item.Totale;
                    });
                return _tot;
            }
            else
                return new decimal(0.00);
        }
        #endregion

        #region ORDINI
        /// <summary>
        /// Aggiorna un ordine
        /// </summary>
        /// <param name="ordine"></param>
        public void AggiornaOrdine(Ordini ordine)
        {
            this.CurrentOrdine = ordine;
        }
        /// <summary>
        /// Aggiunge un ordine alla sessione
        /// </summary>
        /// <param name="ordini"></param>
        public void AggiungiOrdine(Ordini ordini)
        {
            ordini.IDUtente = this.UtenteLoggato.ID;
            ordini.IDStatoOrdine = 1;
            ordini.TotaleOrdine = this.Carrello.TotaleCarrello;
            ordini.DataOrdine = DateTime.Now;

            this.CurrentOrdine = ordini;
        }
        /// <summary>
        /// Aggiunge un ordine alla sessione
        /// </summary>
        public void RimuoviOrdine()
        {
            this.CurrentOrdine = null;
        }
        /// <summary>
        /// Aggiunge un dettaglio all'ordine
        /// </summary>
        public void AggiungiDettaglioOrdine(int IDProdotto,int IDColore,int IDTaglia,int Quantita,decimal Totale)
        {
            if (this.CurrentOrdine == null)
                return;
            if (this.CurrentOrdine.DettagliOrdini == null)
                this.CurrentOrdine.DettagliOrdini = new List<DettagliOrdini>();
            this.CurrentOrdine.DettagliOrdini.Add(new DettagliOrdini()
            {
                IDProdotto = IDProdotto,
                IDColore = IDColore,
                IDTaglia = IDTaglia,
                Quantita = Quantita,
                Totale = Totale
            });
        }
        /// <summary>
        /// Totale senza spese di spedizione
        /// </summary>
        /// <returns></returns>
        public decimal GetTotaleParzialeOrdine()
        {
            decimal _totale = new decimal(0.00);
            if (this.CurrentOrdine == null || this.CurrentOrdine.DettagliOrdini == null || this.CurrentOrdine.DettagliOrdini.Count <= 0)
                return _totale;
            this.CurrentOrdine.DettagliOrdini.ForEach(item =>
                {
                    _totale = item.Totale;
                });
            return _totale;
        }
        #endregion

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            _currentController.Dispose();
        }
        #endregion
    }
}
