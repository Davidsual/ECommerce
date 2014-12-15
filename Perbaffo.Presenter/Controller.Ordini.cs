using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Data.Common;
using System.Net.Mail;
using System.Collections;
using Perbaffo.Presenter;

namespace Perbaffo.Presenter
{
    public partial class Controller : IDisposable
    {
        #region PRIVATE MEMBERS
        private const int STATO_ATTESA_PAGAMENTO = 1;
        private const int STATO_ANNULLATO = 2;
        private const int STATO_IN_PREPARAZIONE = 3;
        private const int STATO_SPEDITO = 4;
        private const int STATO_ARCHIVIATO = 5;
        private const int STATO_ATTESA_DISPONIBILITA = 6;
        #endregion

        #region PUBLIC METHODS

        #region GET
        /// <summary>
        /// Utenti che fanno il compleanno in questo giorno
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<UtentiStatistiche> GetUtentiCompleanno(DateTime data)
        {
            using (StatisticheModelDataContext _model = new StatisticheModelDataContext())
            {
                return _model.UtentiStatistiches.Where(ut => ut.DataNascita.Date.Day == data.Date.Day && ut.DataNascita.Date.Month == data.Date.Month).ToList();
            }
        }

        /// <summary>
        /// Lista delle provincie in ordine di acquisti
        /// </summary>
        /// <param name="numeroRighe"></param>
        /// <returns></returns>
        public IList<StatisticheProvince> GetStatisticAcquistiProvince(int numeroRighe)
        {
            using (StatisticheModelDataContext _model = new StatisticheModelDataContext())
            { 
                return(from OrdiniStatistiche ord in _model.OrdiniStatistiches
                       where ord.IDStatoOrdine == 5 
                       group ord by new {ord.Provincia} into Group
                       orderby Group.Count(a => a.Provincia != null) descending
                       select new StatisticheProvince
                       {
                           Provincia = Group.Key.Provincia,
                           NumeroOrdini = Group.Count(item => item.Provincia != null)
                       }).Take(numeroRighe).ToList();
            }
        }
        /// <summary>
        /// Top prodotti venduti
        /// </summary>
        /// <param name="numeroRighe"></param>
        /// <returns></returns>
        public IList<StatisticheProdotti> GetStatisticTopProdotti(int numeroRighe)
        {
            using (StatisticheModelDataContext _model = new StatisticheModelDataContext())
            {
                return (from OrdiniStatistiche ord in _model.OrdiniStatistiches
                        join DettagliOrdiniStatistiche dettOrd in _model.DettagliOrdiniStatistiches on ord.ID equals dettOrd.IDOrdine into j1
                        from sum in j1.DefaultIfEmpty()
                        join ProdottiStatistiche prod in _model.ProdottiStatistiches on sum.IDProdotto equals prod.ID 
                        where ord.IDStatoOrdine == 5 
                        group sum by new { sum.IDProdotto, prod.Nome} into Group
                        orderby Group.Count(a => a.ID != null) descending
                        select new StatisticheProdotti
                        {
                            IdProdotto = Group.Key.IDProdotto,
                            NumeroOrdini = Group.Count(item => item.ID != null),
                            Nome = Group.Key.Nome
                        }).Take(numeroRighe).ToList();
            }
        }
        /// <summary>
        /// Statistiche top degli acquirenti
        /// </summary>
        /// <param name="numeroAcquirenti"></param>
        /// <returns></returns>
        public IList<StatisticheOrdiniUtenti> GetStatisticTopBuyer(int numeroRighe)
        {
            using (StatisticheModelDataContext _model = new StatisticheModelDataContext())
            {
                return (from OrdiniStatistiche ord in _model.OrdiniStatistiches
                        join UtentiStatistiche ut in _model.UtentiStatistiches on ord.IDUtente equals ut.ID into j1
                        where ord.IDStatoOrdine == 5 && ord.IDUtente != 1307
                        from sum in j1.DefaultIfEmpty()
                        group sum by new { ord.IDUtente, sum.Nome, sum.Cognome } into Group
                        orderby Group.Count(a => a.ID != null) descending
                        select new StatisticheOrdiniUtenti
                        {
                            IdUtente = Group.Key.IDUtente,
                            NumeroOrdini = Group.Count(item => item.ID != null),
                            Nome = Group.Key.Nome,
                            Cognome = Group.Key.Cognome
                        }).Take(numeroRighe).ToList();
            }
        }
        /// <summary>
        /// Statistiche prodotti in omaggio
        /// </summary>
        /// <param name="numeroRighe"></param>
        /// <returns></returns>
        public IList<StatisticheOmaggi> GetStatisticTopOmaggi(int numeroRighe)
        {
            using (StatisticheModelDataContext _model = new StatisticheModelDataContext())
            {
                return (from OrdiniStatistiche ord in _model.OrdiniStatistiches
                        join ProdottiStatistiche ut in _model.ProdottiStatistiches on ord.IDProdottoOmaggio equals ut.ID into j1
                        where ord.IDStatoOrdine == 5
                        from sum in j1.DefaultIfEmpty()
                        group sum by new { ord.IDProdottoOmaggio, sum.Nome } into Group
                        orderby Group.Count(a => a.ID != null) descending
                        select new StatisticheOmaggi
                        {
                            IDProdottoOmaggio = Group.Key.IDProdottoOmaggio,
                            Totale = Group.Count(item => item.ID != null),
                            Nome = Group.Key.Nome
                        }).Take(numeroRighe).ToList();
            }
        }
        /// <summary>
        /// Invio Mail Conferma pagamento
        /// </summary>
        /// <param name="Ordine"></param>
        /// <param name="Utente"></param>
        /// <returns></returns>
        public bool InvioMailConfermaPagamento(Ordini Ordine, Utenti Utente)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("ordini@perbaffo.it");
                message.To.Add(new MailAddress(Utente.EMail));
                message.Subject = "Perbaffo.it - Conferma Pagamento";
                message.BodyEncoding = Encoding.UTF8;
                message.Body = "";
                _strBuilder.Append("Gentile " + this.Capitalize(Utente.Nome) + " " + this.Capitalize(Utente.Cognome) + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("La informiamo che il suo pagamento ci è stato correttamente accreditato." + Environment.NewLine);
                _strBuilder.Append("Il suo ordine è in PREPARAZIONE." + Environment.NewLine);
                //_strBuilder.Append("Il codice spedizione che Bartolini Le ha assegnato è: " + CodiceSpedizione + Environment.NewLine);
                _strBuilder.Append("Verrà spedito nel più breve tempo possibile." + Environment.NewLine);
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
                _errore.PathPagina = "INVIOMAILCODICESPEDIZIONE";
                this.SetErrore(_errore);
                return false;
            }
        }
        /// <summary>
        /// Invia una mail all'utente con il codice spedizione che può essere controllato sul sito
        /// </summary>
        /// <param name="ordine"></param>
        /// <returns></returns>
        public bool InvioMailCodiceSpedizione(Ordini Ordine, Utenti Utente,string CodiceSpedizione)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("ordini@perbaffo.it");
                message.To.Add(new MailAddress(Utente.EMail));
                message.Subject = "Perbaffo.it - Codice Spedizione - Ordine n° " + Ordine.ID.ToString();
                message.BodyEncoding = Encoding.UTF8;
                message.Body = "";
                _strBuilder.Append("Gentile " + this.Capitalize(Utente.Nome) + " " + this.Capitalize(Utente.Cognome) + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("La informiamo che il suo ordine è stato spedito!" + Environment.NewLine);
                _strBuilder.Append("Se accede su http://www.perbaffo.it/Controlla-Spedizione.aspx sezione [Controlla spedizione] può monitorare la sua spedizione." + Environment.NewLine);
                //_strBuilder.Append("Il codice spedizione che Bartolini Le ha assegnato è: " + CodiceSpedizione + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Se il pacco risulta danneggiato, al momento del ritiro La preghiamo di scrivere: 'Firmato con riserva di controllo per pacco danneggiato o aperto' prima di apporre la firma sul cedolino di consegna!");
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
                _errore.PathPagina = "INVIOMAILCODICESPEDIZIONE";
                this.SetErrore(_errore);
                return false;
            }
        }
        /// <summary>
        /// Totale degli ordini per mese
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> GetTotaleOrdini()
        {
            Dictionary<int, int> _dic = new Dictionary<int, int>();
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            { 
                var _valore = from Ordini _ord in _model.Ordinis
                              where _ord.IDStatoOrdine == 5 && _ord.DataOrdine.Year == DateTime.Now.Year
                              group _ord by new
                              {
                                _ord.DataOrdine.Year,
                                _ord.DataOrdine.Month
                              }
                            into g
                            select new 
                            {
                                totale = g.Sum(c => c.TotaleOrdine),
                                mese = g.Select(c => c.DataOrdine.Month).FirstOrDefault()
                            };
                int _totale = 0;

                _valore.OrderBy(c => c.mese).ToList().ForEach(item =>
                    {
                        _totale = 0;
                        _totale = Convert.ToInt32(item.totale);
                        _dic.Add(item.mese,_totale);

                    });
                return _dic;
                //var valore = _model.Ordinis.Where(c => c.IDStatoOrdine = 5).GroupBy(new 
            }
        }
        /// <summary>
        /// numero di promozioni utentiu
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiPromozioni()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.UtentiPromozionis.Count();
            }
        }
        /// <summary>
        /// Ottiene il utente promozione dato il suo id
        /// </summary>
        /// <param name="IDCodicePromozione"></param>
        /// <returns></returns>
        public UtentiPromozioni GetUtentePromozioneAttivoByID(int IDUtentePromozione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.UtentiPromozionis.Where(cod => cod.ID == IDUtentePromozione && cod.DataScadenza >= DateTime.Now && cod.Attiva == true).SingleOrDefault();
            }
        }
        /// <summary>
        /// Ottiene il utente promozione dato il suo id
        /// </summary>
        /// <param name="IDCodicePromozione"></param>
        /// <returns></returns>
        public UtentiPromozioni GetUtentePromozioneByID(int IDUtentePromozione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.UtentiPromozionis.Where(cod => cod.ID == IDUtentePromozione).SingleOrDefault();
            }
        }
        /// <summary>
        /// Restituisce tutti
        /// </summary>
        /// <returns></returns>
        public List<UtentiPromozioni> GetUtentiPromozioni(int startRowIndex, int maximumRows)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.UtentiPromozionis.OrderByDescending(cod => cod.DataScadenza).ThenBy(cod => cod.MinimoOrdine).Skip(startRowIndex).Take(maximumRows).ToList();
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
        /// Ottiene il codice promozione dato il suo id
        /// </summary>
        /// <param name="IDCodicePromozione"></param>
        /// <returns></returns>
        public CodicePromozioni GetCodicePromozioneByID(int IDCodicePromozione)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.CodicePromozionis.Where(cod => cod.ID == IDCodicePromozione).SingleOrDefault();
            }
        }
        /// <summary>
        /// Totale dei codici promozioni presenti
        /// </summary>
        /// <returns></returns>
        public int GetCountCodiciPromozioni()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.CodicePromozionis.Count();
            }
        }
        /// <summary>
        /// Restituisce tutti
        /// </summary>
        /// <returns></returns>
        public List<CodicePromozioni> GetCodiciPromozioni(int startRowIndex, int maximumRows)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.CodicePromozionis.OrderByDescending(cod => cod.DataScadenza).ThenBy(cod => cod.MinimoOrdine).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Ottiene i dettagli di un ordine
        /// </summary>
        /// <param name="IDOrdine"></param>
        /// <returns></returns>
        public List<DettagliOrdini> GetDettagliOrdineByIDOrdine(int IDOrdine)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.DettagliOrdinis.Where(st => st.IDOrdine == IDOrdine).OrderBy(p => p.Quantita).ToList();
            }
        }
        /// <summary>
        /// Descrizione dato l'ID
        /// </summary>
        /// <param name="IDStato"></param>
        /// <returns></returns>
        public string GetDescrStatoByIDStato(int IDStato)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.StatoOrdines.Where(st => st.ID == IDStato).Select(st => st.DescrStatoOrdine).SingleOrDefault();
            }
        }
        /// <summary>
        /// Restituisce tutti gli stati ordine possibili
        /// </summary>
        /// <returns></returns>
        public List<StatoOrdine> GetStatoOrdine()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.StatoOrdines.OrderBy(st => st.DescrStatoOrdine).ToList();
            }
        }
        /// <summary>
        /// Totale Ordini dato lo stato
        /// </summary>
        /// <param name="stato"></param>
        /// <returns></returns>
        public int GetCountOrdiniByStato(int stato)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.Ordinis.Where(ord => ord.IDStatoOrdine == stato).Count();
            }
        }
        /// <summary>
        /// Restituisce tutti gli ordini
        /// </summary>
        /// <param name="stato"></param>
        /// <returns></returns>
        public List<Ordini> GetOrdiniByStato(int startRowIndex, int maximumRows,int stato)
        {
             using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.Ordinis.Where(ord => ord.IDStatoOrdine == stato).OrderByDescending(prod => prod.DataOrdine).Skip(startRowIndex).Take(maximumRows).ToList();
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
                    return _model.TipoPagamentos.OrderBy(tipo => tipo.DescrizionePagamento).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ottiene il tipo pagamento
        /// </summary>
        /// <returns></returns>
        public TipoPagamento GetTipoPagamentoByID(int IDTipoPagamento)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    return _model.TipoPagamentos.Where(pag => pag.ID == IDTipoPagamento).SingleOrDefault();
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
                    return _model.TipoSpedizionis.OrderBy(tipo => tipo.DescrBreveSpedizione).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ottiene una spedizione dato il suo ID
        /// </summary>
        /// <param name="IDTipoSpedizione"></param>
        /// <returns></returns>
        public TipoSpedizioni GetTipoSpedizioneByID(int IDTipoSpedizione)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    return _model.TipoSpedizionis.Where(sped => sped.ID == IDTipoSpedizione).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ottiene gli ordini di un certo utente
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public List<Ordini> GetOrdiniByIDUtente(int IDUtente)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    return _model.Ordinis.Where(ord => ord.IDUtente == IDUtente).OrderBy(ord => ord.DataOrdine).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ottiene l'ordine dato il suo id
        /// </summary>
        /// <param name="IDOrdine"></param>
        /// <returns></returns>
        public Ordini GetOrdineByIDOrdine(int IDOrdine)
        {
            try
            {
                Ordini _ordini = null;
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _ordini = _model.Ordinis.Where(ord => ord.ID == IDOrdine).SingleOrDefault();
                    if (_ordini != null)
                    {
                        _ordini.DettagliOrdini = _model.DettagliOrdinis.Where(dett => dett.IDOrdine == _ordini.ID).ToList();
                    }
                    return _ordini;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Ottiene tutti gli ordini compresi in un certo range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public List<Ordini> GetOrdiniByDate(DateTime start, DateTime finish)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    return _model.Ordinis.Where(ord => ord.DataOrdine >= start && ord.DataOrdine <= finish).OrderBy(ord => ord.DataOrdine).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Totale degli ordini fatti
        /// </summary>
        /// <returns></returns>
        public int GetCountOrdiniChiusi()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDStatoOrdine == STATO_ARCHIVIATO).Count();
            }
        }
        /// <summary>
        /// Lista ordini confermati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<Ordini> GetOrdiniConfermati(int startRowIndex, int maximumRows)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDStatoOrdine == STATO_IN_PREPARAZIONE || ord.IDStatoOrdine == STATO_ATTESA_DISPONIBILITA).OrderByDescending(prod => prod.DataOrdine).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale Ordini Confermati
        /// </summary>
        /// <returns></returns>
        public int GetCountOrdiniConfermati()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.Ordinis.Where(ord => ord.IDStatoOrdine == STATO_IN_PREPARAZIONE || ord.IDStatoOrdine == STATO_ATTESA_DISPONIBILITA).Count();
            }
        }
        /// <summary>
        /// Totale ordini provenienti da affiliazione
        /// </summary>
        /// <returns></returns>
        public int GetCountOrdiniAffiliazione()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return _model.AffiliazioneOrdinis.Count();
            }
        }
        /// <summary>
        /// Restituisce lista degli ordini effettuati tramite affiliazione
        /// </summary>
        public IEnumerable GetOrdiniAffiliazione()
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                return (from AffiliazioneOrdini aff in _model.AffiliazioneOrdinis
                               join CodiceAffiliazione codAff in _model.CodiceAffiliaziones on aff.IDCodiceAffiliazione equals codAff.ID
                               orderby aff.DataOrdine descending
                               select new
                               { 
                                   ID = aff.ID,
                                   Sito = codAff.Sito,
                                   DataOrdine = aff.DataOrdine,
                                   CodOrdine = aff.IDOrdine
                               }).ToList();

            }
        }
        #endregion

        #region SET
        /// <summary>
        /// Salva un ordine 
        /// </summary>
        /// <param name="ordine"></param>
        /// <returns></returns>
        public Ordini SetOrdine(Ordini ordine)
        {
            DbTransaction _trans = null;

            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                try
                {
                    // OPERA IN TRANSAZIONE
                    _model.Connection.Open();
                    _trans = _model.Connection.BeginTransaction();
                    _model.Transaction = _trans;

                    _model.Ordinis.InsertOnSubmit(ordine);
                    _model.SubmitChanges();
                    if (ordine.DettagliOrdini != null)
                    {
                        ////Salvo i dettagli
                        ordine.DettagliOrdini.ForEach(dett =>
                            {
                                dett.IDOrdine = ordine.ID;
                                _model.DettagliOrdinis.InsertOnSubmit(dett);
                            });
                        _model.SubmitChanges();
                    }
                    // COMMITTA LA TRANSAZIONE E CHIUDE
                    _trans.Commit();
                    _model.Connection.Close();

                    return ordine;
                }
                catch (Exception ex)
                {
                    // SE E' RIUSCITO AD APRIRE LA TRANSAZIONE FA ROLLBACK
                    if (_trans != null)
                    {
                        _trans.Rollback();
                    }
                    // CHIUDE LA CONNESSIONE
                    _model.Connection.Close();
                    throw ex;
                }

            }
        }
        /// <summary>
        /// Aggiorna un ordine
        /// </summary>
        /// <param name="ordine"></param>
        /// <returns></returns>
        public Ordini UpdateOrdine(Ordini ordine)
        {
            Ordini _ordini = null;
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                _ordini = _model.Ordinis.Where(ord => ord.ID == ordine.ID).SingleOrDefault();
                if (_ordini != null)
                {
                     _ordini.IDStatoOrdine = ordine.IDStatoOrdine;
                     _ordini.CodiceSpedizione = ordine.CodiceSpedizione;
                     _ordini.Cognome = ordine.Cognome;
                     _ordini.CAP = ordine.CAP;
                     _ordini.Citta = ordine.Citta;
                     _ordini.EMail = ordine.EMail;
                     _ordini.Indirizzo = ordine.Indirizzo;
                     _ordini.Nome = ordine.Nome;
                     _ordini.Note = ordine.Note;
                     _ordini.NumeroCivico = ordine.NumeroCivico;
                     _ordini.Provincia = ordine.Provincia;
                     _ordini.Telefono = ordine.Telefono;
                     _ordini.NotePerbaffo = ordine.NotePerbaffo;
                     _model.SubmitChanges();

                     if (ordine.IDStatoOrdine == STATO_ANNULLATO)
                     {
                         ///Ripristino la giacenza
                         List<DettagliOrdini> _dett = _model.DettagliOrdinis.Where(ord => ord.IDOrdine == ordine.ID).ToList();
                         _dett.ForEach(item =>
                             {
                                 this.UpdateProdottiRipristinaGiacenza(item.IDProdotto, item.Quantita);
                             });
                     }
                }
                return _ordini;
            }
        }
        /// <summary>
        /// Inserisce un codice promozione
        /// </summary>
        /// <param name="codicePromoz"></param>
        /// <returns></returns>
        public CodicePromozioni SetCodicePromozione(CodicePromozioni codicePromoz)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                codicePromoz.DataInserimento = DateTime.Now;
                _model.CodicePromozionis.InsertOnSubmit(codicePromoz);
                _model.SubmitChanges();
                return codicePromoz;
            }
        }
        /// <summary>
        /// Cancella un codice promozione
        /// </summary>
        /// <param name="codicePromoz"></param>
        /// <returns></returns>
        public bool DeleteCodicePromozione(int IDCodicePromoz)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                CodicePromozioni _promoz = _model.CodicePromozionis.Where(cod => cod.ID == IDCodicePromoz).SingleOrDefault();
                if (_promoz != null)
                {
                    _model.CodicePromozionis.DeleteOnSubmit(_promoz);
                    _model.SubmitChanges();
                }
                return true;
            }
        }
        /// <summary>
        /// Aggiorna un codice promozione
        /// </summary>
        /// <param name="codicePromoz"></param>
        /// <returns></returns>
        public bool UpdateCodicePromozione(CodicePromozioni codicePromoz)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                CodicePromozioni _promoz = _model.CodicePromozionis.Where(cod => cod.ID == codicePromoz.ID).SingleOrDefault();
                if (_promoz != null)
                {
                    _promoz.Attiva = codicePromoz.Attiva;
                    _promoz.CodiceSconto = codicePromoz.CodiceSconto;
                    _promoz.DataScadenza = codicePromoz.DataScadenza;
                    _promoz.DescrPromozione = codicePromoz.DescrPromozione;
                    _promoz.MinimoOrdine = codicePromoz.MinimoOrdine;
                    _promoz.ScontoEuro = codicePromoz.ScontoEuro;
                    _promoz.ScontoPercent = codicePromoz.ScontoPercent;
                    _model.SubmitChanges();
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// Delete Tipo Spedizione
        /// </summary>
        /// <param name="tipoPagamento"></param>
        public bool DeleteTipoSpedizione(TipoSpedizioni tipoSpedizione)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    int _count = _model.Ordinis.Where(ord => ord.IDTipoSpedizione == tipoSpedizione.ID).Count();
                    if (_count > 0)
                        return false;
                    TipoSpedizioni _tipoPag = _model.TipoSpedizionis.Where(pag => pag.ID == tipoSpedizione.ID).SingleOrDefault();
                    if (_tipoPag == null)
                        return false;
                    _model.TipoSpedizionis.DeleteOnSubmit(_tipoPag);
                    _model.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Inserimento Tipo Spedizione
        /// </summary>
        /// <param name="tipoPagamento"></param>
        public void SetTipoSpedizione(TipoSpedizioni tipoSpedizione)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.TipoSpedizionis.InsertOnSubmit(tipoSpedizione);
                    _model.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Aggiornamento Tipo Pagamento
        /// </summary>
        /// <param name="tipoPagamento"></param>
        public void UpdateTipoSpedizione(TipoSpedizioni tipoSpedizione)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    TipoSpedizioni _pagame = _model.TipoSpedizionis.Where(pag => pag.ID == tipoSpedizione.ID).SingleOrDefault();
                    if (_pagame != null)
                    {
                        _pagame.CostoSpedizione = tipoSpedizione.CostoSpedizione;
                        _pagame.Attivo = tipoSpedizione.Attivo;
                        _pagame.DescrBreveSpedizione = tipoSpedizione.DescrBreveSpedizione;
                        _pagame.DescrSpedizione = tipoSpedizione.DescrSpedizione;
                        _model.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Tipo Pagamento
        /// </summary>
        /// <param name="tipoPagamento"></param>
        public bool DeleteTipoPagamento(TipoPagamento tipoPagamento)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    int _count = _model.Ordinis.Where(ord => ord.IDTipoPagamento == tipoPagamento.ID).Count();
                    if (_count > 0)
                        return false;
                    TipoPagamento _tipoPag = _model.TipoPagamentos.Where(pag => pag.ID == tipoPagamento.ID).SingleOrDefault();
                    if (_tipoPag == null)
                        return false;
                    _model.TipoPagamentos.DeleteOnSubmit(_tipoPag);
                    _model.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Inserimento Tipo Pagamento
        /// </summary>
        /// <param name="tipoPagamento"></param>
        public void SetTipoPagamento(TipoPagamento tipoPagamento)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    _model.TipoPagamentos.InsertOnSubmit(tipoPagamento);
                    _model.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Aggiornamento Tipo Pagamento
        /// </summary>
        /// <param name="tipoPagamento"></param>
        public void UpdateTipoPagamento(TipoPagamento tipoPagamento)
        {
            try
            {
                using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
                {
                    TipoPagamento _pagame = _model.TipoPagamentos.Where(pag => pag.ID == tipoPagamento.ID).SingleOrDefault();
                    if (_pagame != null)
                    {
                        _pagame.Costo = tipoPagamento.Costo;
                        _pagame.Attivo = tipoPagamento.Attivo;
                        _pagame.DescrizionePagamento = tipoPagamento.DescrizionePagamento;
                        _model.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inserisce un utente promozione
        /// </summary>
        /// <param name="codicePromoz"></param>
        /// <returns></returns>
        public UtentiPromozioni SetUtentePromozione(UtentiPromozioni utentePromoz)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                utentePromoz.DataInserimento = DateTime.Now;
                _model.UtentiPromozionis.InsertOnSubmit(utentePromoz);
                _model.SubmitChanges();
                return utentePromoz;
            }
        }
        /// <summary>
        /// Cancella un utente promozione
        /// </summary>
        /// <param name="codicePromoz"></param>
        /// <returns></returns>
        public bool DeleteUtentePromozione(int IDUtentePromoz)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                UtentiPromozioni _promoz = _model.UtentiPromozionis.Where(cod => cod.ID == IDUtentePromoz).SingleOrDefault();
                if (_promoz != null)
                {
                    _model.UtentiPromozionis.DeleteOnSubmit(_promoz);
                    _model.SubmitChanges();
                }
                return true;
            }
        }
        /// <summary>
        /// Aggiorna un utente promozione
        /// </summary>
        /// <param name="codicePromoz"></param>
        /// <returns></returns>
        public bool UpdateUtentePromozione(UtentiPromozioni utentePromoz)
        {
            using (OrdiniModelDataContext _model = new OrdiniModelDataContext())
            {
                UtentiPromozioni _promoz = _model.UtentiPromozionis.Where(cod => cod.ID == utentePromoz.ID).SingleOrDefault();
                if (_promoz != null)
                {
                    _promoz.Attiva = utentePromoz.Attiva;
                    _promoz.IDUtente = utentePromoz.IDUtente;
                    _promoz.DataScadenza = utentePromoz.DataScadenza;
                    _promoz.DescrPromozione = utentePromoz.DescrPromozione;
                    _promoz.MinimoOrdine = utentePromoz.MinimoOrdine;
                    _promoz.ScontoEuro = utentePromoz.ScontoEuro;
                    _promoz.ScontoPercent = utentePromoz.ScontoPercent;
                    _promoz.NumVolte = utentePromoz.NumVolte;
                    _model.SubmitChanges();
                    return true;
                }
                else
                    return false;
            }
        }


        #endregion

        #endregion
    }
}
