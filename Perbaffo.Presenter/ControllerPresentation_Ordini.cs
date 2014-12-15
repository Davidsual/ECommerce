using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Data.Common;
using System.Net.Mail;

namespace Perbaffo.Presenter
{
    public partial class ControllerPresentation : IDisposable
    {
        #region PUBLIC MEMBERS
        public const int PAGAMENTO_BONIFICO = 8;
        public const int PAGAMENTO_POSTEPAY = 11;
        public const int PAGAMENTO_PAYPAL = 9;
        public const int PAGAMENTO_RITIROAMANO = 10;
        public const int PAGAMENTO_CONTRASSEGNO = 12;
        #endregion
        
        #region PRIVATE MEMBERS
        private const int STATO_ATTESA_PAGAMENTO = 1;
        private const int STATO_ANNULLATO = 2;
        private const int STATO_IN_PREPARAZIONE = 3;
        private const int STATO_SPEDITO = 4;
        private const int STATO_ARCHIVIATO = 5;
        private const int STATO_ATTESA = 6;
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Invio Mail per segnalare un prodotto ad un amico
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public bool InvioMailOrdineEffettuato(Ordini Ordine, Carrello Carrello, Utenti Utente)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("ordini@perbaffo.it");
                message.To.Add(new MailAddress(Utente.EMail));
                message.Bcc.Add(new MailAddress("ordini@perbaffo.it"));
                message.Subject = "Perbaffo.it - Ordine n° " + Ordine.ID.ToString();
                message.BodyEncoding = Encoding.UTF8;
                message.Body = "";
                _strBuilder.Append("Gentile " + this.Capitalize(Utente.Nome) + " " + this.Capitalize(Utente.Cognome) + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("La ringraziamo per la fiducia accordataci." + Environment.NewLine);
                _strBuilder.Append("La presente e-mail arriva in modo automatico come promemoria dell'acquisto effettuato sul nostro sito www.perbaffo.it " + Environment.NewLine);
                _strBuilder.Append("Resoconto ordine n° " + Ordine.ID.ToString() + " da Lei effettuato:");
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("La merce verrà spedita a questo indirizzo da Lei indicato:" + Environment.NewLine);
                _strBuilder.Append(this.Capitalize(Ordine.Nome) + " " + this.Capitalize(Ordine.Cognome) + Environment.NewLine);
                _strBuilder.Append(this.Capitalize(Ordine.Indirizzo) + "  " + Ordine.NumeroCivico + Environment.NewLine);
                _strBuilder.Append(this.Capitalize(Ordine.Citta) + "  (" + Ordine.Provincia.ToUpper() + ")" + Environment.NewLine);
                _strBuilder.Append(Ordine.CAP + Environment.NewLine);
                _strBuilder.Append("ITALIA" + Environment.NewLine);
                _strBuilder.Append("TEL: " + Ordine.Telefono + Environment.NewLine);
                _strBuilder.Append("E-mail: " + Ordine.EMail + Environment.NewLine);
                _strBuilder.Append(this.Capitalize(Ordine.Note) + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Tabella Riassuntiva" + Environment.NewLine);
                _strBuilder.Append(this.CreaTabellaOrdini(Ordine.DettagliOrdini));
                _strBuilder.Append(this.CreaTabellaTotaleOrdine(Ordine));
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Le ricordiamo che ha 5 giorni di tempo per provvedere al pagamento del suo ordine, a meno che non abbia scelto il pagamento in contrassegno. " + Environment.NewLine);
                _strBuilder.Append("Una volta ricevuto il pagamento provvederemo in breve tempo a spedire l'ordine (max 5 giorni lavorativi dal ricevimento del pagamento).  ");
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Cordiali saluti." + Environment.NewLine);
                _strBuilder.Append("Lo staff di Perbaffo");
                message.Body = _strBuilder.ToString();
                SmtpClient client = new SmtpClient();
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException = Ordine.ID.ToString() + "  " + Ordine.EMail + "  " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "INVIOMAILRIEPILOGOORDINE";
                this.SetErrore(_errore);
                return false;
            }
        }
        /// <summary>
        /// Cra la tabella del totale ordine
        /// </summary>
        /// <param name="ord"></param>
        /// <returns></returns>
        private string CreaTabellaTotaleOrdine(Ordini _ord)
        {
            if (_ord == null)
                return string.Empty;
            decimal _totPagamento = new decimal(0.00);
            decimal _totSpedizione = new decimal(0.00);
            decimal _totCodProm = new decimal(0.00);
            decimal _totUtProm = new decimal(0.00);

            string _tipoPagamento = string.Empty;
            string _tipoSpedizione = string.Empty;
            string _codPromozione = string.Empty;
            string _promUtente = string.Empty;
            string _scontoSpediz = string.Empty;

            StringBuilder _strBuilder = new StringBuilder();

            TipoPagamento _pagam = this.GetTipoPagamentoByIDPagamento(_ord.IDTipoPagamento);
            if (_pagam != null)
            {
                _totPagamento = _pagam.Costo;
                _tipoPagamento = _pagam.DescrizionePagamento;
            }
            TipoSpedizioni _sped = this.GetTipoSpedizioneByIDSpedizione(_ord.IDTipoSpedizione);
            if (_sped != null)
            {
                _totSpedizione = _sped.CostoSpedizione;
                _tipoSpedizione = _sped.DescrBreveSpedizione;
            }

            ///Aggiungo eventuali sconti
            if (_ord.IDCodicePromozione.HasValue && _ord.IDCodicePromozione.Value > 0)
            {
                CodicePromozioni _codProm = this.GetCodicePromozioneAttivoByCodice(_ord.CodicePromozione);
                if (_codProm != null)
                {
                    _codPromozione = _ord.CodicePromozione;
                    string _sconto = string.Empty;
                    if (_codProm.ScontoEuro.HasValue && _codProm.ScontoEuro.Value > 0)
                    {
                        _codPromozione = "Sconto \"" + _codPromozione.ToUpper() + "\" - € " + _codProm.ScontoEuro.Value.ToString() + Environment.NewLine;
                    }
                    else
                    {
                        _codPromozione = "Sconto \"" + _codPromozione.ToUpper() + "\" - " + _codProm.ScontoPercent.Value.ToString() + "%" + Environment.NewLine;
                    }
                   
                }
            }
            if (_ord.IDUtentePromozione.HasValue && _ord.IDUtentePromozione.Value > 0)
            {
                UtentiPromozioni _promo = this.GetUtentePromozioneAttivoByIDUtente(Convert.ToInt32(_ord.IDUtente));
                if (_promo != null)
                {
                    string _sconto = string.Empty;
                    if (_promo.ScontoEuro.HasValue && _promo.ScontoEuro.Value > 0)
                    {
                        _promUtente = "Sconto " + _promo.DescrPromozione + " - € " + _promo.ScontoEuro.Value.ToString() + Environment.NewLine;
                    }
                    else
                    {
                        _promUtente = "Sconto " + _promo.DescrPromozione + " - " + _promo.ScontoPercent.ToString() + "%" + Environment.NewLine;
                    }
                }
            }
            if (_ord.TotaleScontoSpedizione.HasValue && _ord.TotaleScontoSpedizione.Value > 0)
            {
                _scontoSpediz = "Sconto spese di spedizione (ordine maggiore di € 35.00) - € " + _ord.TotaleScontoSpedizione.Value.ToString()+ "0" + Environment.NewLine;
            }
            _strBuilder.Append("Pagamento (" + _tipoPagamento  + ") € " + _totPagamento.ToString() + Environment.NewLine);
            _strBuilder.Append("Spedizione (" + _tipoSpedizione + ") € " + _totSpedizione.ToString() + Environment.NewLine);

            if (!string.IsNullOrEmpty(_codPromozione))
                _strBuilder.Append(_codPromozione);
            if (!string.IsNullOrEmpty(_promUtente))
                _strBuilder.Append(_promUtente);
            ///CALCOLO TOTOLE SCONTO SPEDIZIONE E TOTALE ORDINE
            if (!string.IsNullOrEmpty(_scontoSpediz))
            {
                _strBuilder.Append(_scontoSpediz);
                _strBuilder.Append("Totale Ordine € " + (_ord.TotaleOrdine - _ord.TotaleScontoSpedizione.Value) + Environment.NewLine);
            }
            else
                _strBuilder.Append("Totale Ordine € " + _ord.TotaleOrdine + Environment.NewLine);
            
            ProdottoImmagine _prodOmaggio = this.GetProdottoByIDProdotto(_ord.IDProdottoOmaggio);
            if (_prodOmaggio != null && _prodOmaggio.IsOmaggio)
            {
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Hai scelto quest'omaggio:" + Environment.NewLine);
                _strBuilder.Append(_prodOmaggio.Nome + Environment.NewLine);
            }
            _strBuilder.Append(Environment.NewLine);
            if (_ord.IDTipoPagamento == PAGAMENTO_BONIFICO)
            {
                _strBuilder.Append("HAI SCELTO IL PAGAMENTO TRAMITE BONIFICO" + Environment.NewLine);
                _strBuilder.Append("Conto corrente intestato a: PERBAFFO DI ALBANESI SILVIA " + Environment.NewLine);
                _strBuilder.Append("Codice IBAN: IT38V0200801108000041230254" + Environment.NewLine);
                _strBuilder.Append("Causale Bonifico: Ordine numero " + _ord.ID.ToString() + Environment.NewLine);
            }
            else if (_ord.IDTipoPagamento == PAGAMENTO_CONTRASSEGNO)
            {
                _strBuilder.Append("HAI SCELTO IL PAGAMENTO TRAMITE CONTRASSEGNO" + Environment.NewLine);
                _strBuilder.Append("Il pagamento avverrà in contanti solo al momento della consegna della merce da parte del nostro corriere!" + Environment.NewLine);
            }
            else if (_ord.IDTipoPagamento == PAGAMENTO_PAYPAL)
            {
                _strBuilder.Append("HAI SCELTO IL PAGAMENTO TRAMITE PAYPAL" + Environment.NewLine);
            }
            else if (_ord.IDTipoPagamento == PAGAMENTO_POSTEPAY)
            {
                _strBuilder.Append("HAI SCELTO IL PAGAMENTO TRAMITE POSTEPAY"+ Environment.NewLine);
                _strBuilder.Append("Intestata a: ALBANESI SILVIA"+ Environment.NewLine);
                _strBuilder.Append("Carta n°: 4023600565895788"+ Environment.NewLine);
                _strBuilder.Append("Codice Fiscale: LBNSLV83D49D003D" + Environment.NewLine);
                _strBuilder.Append("N.B. Vi preghiamo di inviarci un E-Mail (info@perbaffo.it) con i dati identificativi della ricarica (data/ora/luogo) per velocizzare l'evasione dell'ordine." + Environment.NewLine);
            }
            else if (_ord.IDTipoPagamento == PAGAMENTO_RITIROAMANO)
            {
                _strBuilder.Append("HAI SCELTO IL PAGAMENTO IN CONTANTI AL MOMENTO DEL RITIRO PRESSO IL MAGAZZINO DI PIANEZZA (TO)" + Environment.NewLine);
                _strBuilder.Append("Verrai contattato dallo Staff di Perbaffo per accordarsi sulla data di ritiro della merce." + Environment.NewLine);
                _strBuilder.Append("Il pagamento al momento dell'incontro avverrà esclusivamente in contanti" + Environment.NewLine);
            }

            return _strBuilder.ToString();
        }
        /// <summary>
        /// Crea la tabella riepilogativa ordini
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string CreaTabellaOrdini(List<DettagliOrdini> list)
        {
            if (list == null || list.Count <= 0)
                return string.Empty;

            StringBuilder _strBuilder = new StringBuilder();

            string _descr = string.Empty;
            ProdottoImmagine _prod = null;
            int _idColore = -1;
            int _idTaglia = -1;
            Colori _col = null;
            ProdottiTaglie _taglia = null;
            decimal _totaleProdotti = new decimal(0.00);
            decimal _totaleProdotto = new decimal(0.00);
            list.ForEach(item =>
                {
                    _descr = string.Empty;
                    _prod = null;
                    _idColore = -1;
                    _idTaglia = -1;
                    _col = null;
                    _taglia = null;
                    _totaleProdotto = new decimal(0.00);

                    _prod = this.GetProdottoByIDProdotto(item.IDProdotto,true);
                    _idColore = (item.IDColore.HasValue) ? item.IDColore.Value : -1;
                    _idTaglia = (item.IDTaglia.HasValue) ? item.IDTaglia.Value : -1;
                    _descr = _prod.Nome;

                    if (_idColore > 0)
                        _col = this.GetColoreByIDColore(_idColore);
                    if (_idTaglia > 0)
                        _taglia = this.GetTagliaByIDTaglia(_idTaglia,_prod.ID);

                    if (_taglia != null)
                    {
                        _descr += "  Taglia scelta: " + _taglia.DescrTaglia;
                        _totaleProdotti += (item.Quantita * _taglia.Totale);
                        _totaleProdotto = (item.Quantita * _taglia.Totale);
                    }
                    else
                    {
                        _descr += (!string.IsNullOrEmpty(_prod.DescrTaglia)) ? "  Taglia: " + _prod.DescrTaglia : string.Empty;
                        _totaleProdotti += (item.Quantita * _prod.Totale);
                        _totaleProdotto = (item.Quantita * _prod.Totale);
                    }
                    if (_col != null)
                    {
                        _descr += "Variazione scelta: " + _col.Descrizione;
                    }
                    _strBuilder.Append("Qta: " + item.Quantita + " - " + _descr + " - Totale € " + _totaleProdotto);
                    _strBuilder.Append(Environment.NewLine);
                });
            _strBuilder.Append(Environment.NewLine);
            _strBuilder.Append(Environment.NewLine);
            _strBuilder.Append("Totale Prodotti € " + _totaleProdotti.ToString() + Environment.NewLine);


            return _strBuilder.ToString();
        }
        /// <summary>
        /// Restituisce tutti gli ordini spediti
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public List<Ordini> GetOrdiniSpeditiByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDUtente == IDUtente && ord.IDStatoOrdine == STATO_SPEDITO).OrderByDescending(ord => ord.DataOrdine).ToList();
            }
        }
        /// <summary>
        /// Lista degli ordini attivi
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public List<OrdiniDettagliato> GetOrdiniAttiviByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.OrdiniDettagliatos.Where(ord => ord.IDUtente == IDUtente && ord.IDStatoOrdine != STATO_ANNULLATO && ord.IDStatoOrdine != STATO_ARCHIVIATO).OrderByDescending(ord => ord.DataOrdine).ToList();
            }
        }
        /// <summary>
        /// Lista degli ordini Storico
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public List<OrdiniDettagliato> GetOrdiniStoricoByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.OrdiniDettagliatos.Where(ord => ord.IDUtente == IDUtente && ord.IDStatoOrdine == STATO_ARCHIVIATO).OrderByDescending(ord => ord.DataOrdine).ToList();
            }
        }
        /// <summary>
        /// Ordini effettuati
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public int GetCountOrdiniEffettuatiByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDUtente == IDUtente && ord.IDStatoOrdine != STATO_ANNULLATO).Count();
            }
        }
        /// <summary>
        /// Totale ordini spediti e con codice di spedizione
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public int GetCountOrdineSpeditoByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDUtente == IDUtente && ord.IDStatoOrdine == STATO_SPEDITO && (ord.CodiceSpedizione != null || ord.CodiceSpedizione != string.Empty)).Count();
            }
        }
        /// <summary>
        /// Ordini effettuati
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public int GetCountOrdiniAttiviByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDUtente == IDUtente && (ord.IDStatoOrdine != STATO_ANNULLATO || ord.IDStatoOrdine == STATO_ARCHIVIATO)).Count();
            }
        }
        /// <summary>
        /// Lista di pagamenti
        /// </summary>
        /// <returns></returns>
        public List<TipoPagamento> GetTipoPagamento()
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return _model.TipoPagamentos.Where(tipo => tipo.Attivo == true).OrderBy(tipo => tipo.DescrizionePagamento).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lista di tipi di spedizione
        /// </summary>
        /// <returns></returns>
        public List<TipoSpedizioni> GetTipoSpedizione()
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return _model.TipoSpedizionis.Where(tipo => tipo.Attivo == true).OrderBy(tipo => tipo.DescrBreveSpedizione).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// singolo pagamento
        /// </summary>
        /// <returns></returns>
        public TipoPagamento GetTipoPagamentoByIDPagamento(int IDPagamento)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return _model.TipoPagamentos.Where(tipo => tipo.Attivo == true && tipo.ID == IDPagamento).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// singolo spedizione
        /// </summary>
        /// <returns></returns>
        public TipoSpedizioni GetTipoSpedizioneByIDSpedizione(int IDSpedizione)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    return _model.TipoSpedizionis.Where(tipo => tipo.Attivo == true && tipo.ID == IDSpedizione).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce i dettagli dell'ordine
        /// </summary>
        /// <param name="IDOrdine"></param>
        /// <returns></returns>
        public List<DettagliOrdini> GetDettagliOrdiniByIDOrdine(int IDOrdine)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.DettagliOrdinis.Where(ord => ord.IDOrdine == IDOrdine).OrderBy(dett => dett.Quantita).ToList();
            }
        }
        /// <summary>
        /// Inserisce Ordine nel carrello
        /// </summary>
        /// <param name="Ordine"></param>
        /// <param name="Carrello"></param>
        /// <param name="Utente"></param>
        /// <returns></returns>
        public Ordini SetOrdine(Ordini Ordine, Carrello Carrello, Utenti Utente)
        {
            if (Ordine == null || Ordine.DettagliOrdini == null || Carrello == null || Utente == null)
                return null;
            DbTransaction _trans = null;
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                try
                {
                    //_model.DeferredLoadingEnabled = false;
                    // OPERA IN TRANSAZIONE
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    ///1)Inserisco la testa
                    ///2)Inserisco i dettagli
                    Ordine.TotaleScontoSpedizione = Carrello.TotaleScontoSpedizione;
                    Ordine.IDStatoOrdine = 1;
                    Ordine.IDUtente = Utente.ID;
                    Ordine.DataOrdine = DateTime.Now;
                    _model.Ordinis.InsertOnSubmit(Ordine);
                    _model.SubmitChanges();

                    Ordine.DettagliOrdini.ForEach(item =>
                        {
                            item.IDOrdine = Ordine.ID;
                            if (item.IDColore == -1)
                                item.IDColore = null;
                            if (item.IDTaglia == -1)
                                item.IDTaglia = null;
                            _model.DettagliOrdinis.InsertOnSubmit(item);
                            ///togliere la giacenza
                            this.UpdateProdottiGiacenza(item.IDProdotto, item.Quantita);
                        });
                    _model.SubmitChanges();
                    // COMMITTA LA TRANSAZIONE E CHIUDE
                    _trans.Commit();
                    _model.Connection.Close();
                    ///Togliere eventuale sconto
                    if (Ordine.IDUtentePromozione.HasValue && Ordine.IDUtentePromozione.Value > 0)
                    {
                        ///Aggiorno al ribasso eventuale NUMERO VOLTE
                        this.UpdateUtentePromozioneNumeroVolte(Ordine.IDUtente, Ordine.IDUtentePromozione.Value);
                    }

                    return Ordine;
                }
                catch (Exception ex)
                {
                    Errori _errore = new Errori();
                    _errore.CurrentIDUtenteLoggato = Utente.ID;
                    _errore.DataErrore = DateTime.Now;
                    _errore.DescrException = ex.Message;
                    _errore.DescrStackTrace = ex.StackTrace;
                    if (ex.InnerException != null)
                    {
                        _errore.DescrInnerException = ex.InnerException.Message;
                    }
                    _errore.PathPagina = "ORDINI";
                    this.SetErrore(_errore);

                    // SE E' RIUSCITO AD APRIRE LA TRANSAZIONE FA ROLLBACK
                    if (_trans != null)
                    {
                        _trans.Rollback();
                    }
                    // CHIUDE LA CONNESSIONE
                    _model.Connection.Close();
                    return null;
                }
            }
        }

        #region SCONTO
        /// <summary>
        /// Aggiorno utente promozione numero volte
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <param name="IDUtentePromozione"></param>
        private void UpdateUtentePromozioneNumeroVolte(int IDUtente, int IDUtentePromozione)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    UtentiPromozioni _prom = _model.UtentiPromozionis.Where(pro => pro.ID == IDUtentePromozione).SingleOrDefault();
                    if (_prom != null)
                    {
                        if (_prom.NumVolte > 0)
                        {
                            ///Controllo il numero di volte in cui è stato utilizzato se ha superato il numero volte lo disattivo
                            int _count = _model.Ordinis.Where(ord => ord.IDUtentePromozione == IDUtentePromozione && ord.IDStatoOrdine != STATO_ANNULLATO).Count();
                            if (_count >= _prom.NumVolte)
                            {
                                _prom.Attiva = false;
                                _model.SubmitChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Ottiene il utente promozione dato il suo id
        /// </summary>
        /// <param name="IDCodicePromozione"></param>
        /// <returns></returns>
        public UtentiPromozioni GetUtentePromozioneAttivoByIDUtente(int IDUtente)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.UtentiPromozionis.Where(cod => cod.IDUtente == IDUtente && cod.DataScadenza >= DateTime.Now && cod.Attiva == true).SingleOrDefault();
            }
        }
        /// <summary>
        /// Ottiene il codice promozione dato il suo id
        /// </summary>
        /// <param name="IDCodicePromozione"></param>
        /// <returns></returns>
        public CodicePromozioni GetCodicePromozioneAttivoByCodice(string codicePromozione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.CodicePromozionis.Where(cod => cod.CodiceSconto.ToUpper() == codicePromozione.ToUpper() && cod.Attiva == true && cod.DataScadenza > DateTime.Now).SingleOrDefault();
            }
       }
               
        /// <summary>
        /// Ottiene il utente promozione dato il suo id
        /// </summary>
        /// <param name="IDCodicePromozione"></param>
        /// <returns></returns>
        public UtentiPromozioni GetUtentePromozioneAttivoByIDPromozione(int IDUtentePromozione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.UtentiPromozionis.Where(cod => cod.ID == IDUtentePromozione && cod.DataScadenza >= DateTime.Now && cod.Attiva == true).SingleOrDefault();
            }
        } 
        #endregion

        #region affiliazione
        /// <summary>
        /// Set di una affiliazione
        /// </summary>
        /// <param name="Codice"></param>
        /// <param name="IDOrdine"></param>
        public void SetAffiliazione(string codice, int idOrdine)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    CodiceAffiliazione _affiliazione = _model.CodiceAffiliaziones.Where(c => c.Codice.ToUpper() == codice.ToUpper()).SingleOrDefault();
                    if (_affiliazione != null)
                    {
                        if (_model.AffiliazioneOrdinis.Where(c => c.IDCodiceAffiliazione == _affiliazione.ID && c.IDOrdine == idOrdine).Count() <= 0)
                        {
                            AffiliazioneOrdini _affiliazioneOrdini = new AffiliazioneOrdini()
                            {
                                IDCodiceAffiliazione = _affiliazione.ID,
                                IDOrdine = idOrdine,
                                DataOrdine = DateTime.Now
                            };
                            _model.AffiliazioneOrdinis.InsertOnSubmit(_affiliazioneOrdini);
                            _model.SubmitChanges();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #endregion
    }
}
