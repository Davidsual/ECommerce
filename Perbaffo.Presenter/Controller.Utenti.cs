using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Data.Common;
using System.Net.Mail;

namespace Perbaffo.Presenter
{
    public partial class Controller : IDisposable
    {
        #region PUBLIC METHODS
        /// <summary>
        /// Nome immagine uploadata dall'utente
        /// </summary>
        /// <param name="_idImmagine"></param>
        /// <returns></returns>
        public string GetNomeFotoUtenteByIDUtente(int _idImmagine)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ute => ute.ID == _idImmagine).Select(c => c.ImgFriend).SingleOrDefault();
            }
        }
        /// <summary>
        /// Controlla username e password per accedere
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Amministratore CheckLoginAmministratore(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            using (UtentiModelDataContext _model = new UtentiModelDataContext())            
            {
                //string _Test = this.Decode("YmFsaTNibGlzcw==");
                ///Recupero i dati dell'amministratore
                Amministratore _amm = _model.Amministratores.Where(amm => amm.Username.Equals(username) && amm.Password.Equals(this.Encode(password))).SingleOrDefault();
                if (_amm != null)
                {
                    ///TODO: Invio e-Mail utente
                    if (_amm.DataUltimoLogin.Date < DateTime.Now.Date)
                    {
                        ///Prima volta nella giornata!!!!! odierna...
                        ///quindi invio e.mail del compleanno
                        this.CheckBirthdayUsers();
                    }
                    ///Aggiorno amministratore
                    _amm.DataUltimoLogin = _amm.DataLogin;
                    _amm.DataLogin = DateTime.Now;
                    _model.SubmitChanges();
                }
                return _amm;
            }
        }
        /// <summary>
        /// Cambio password amministratore
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public Amministratore ChangePassword(Amministratore currentUser,string username,string newPassword)
        {
            if (currentUser == null || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(username))
                return null;
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {

                Amministratore _amm = _model.Amministratores.Where(amm => amm.ID == currentUser.ID).SingleOrDefault();
                if (_amm != null)
                {
                    _amm.Username = username;
                    _amm.Password = this.Encode(newPassword);
                    _model.SubmitChanges();
                }
                return _amm;
            }
        }
        /// <summary>
        /// Aggiorna immagine utente
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public Utenti UpdateImmagineUtente(Utenti utente)
        {
            if (utente == null)
                return utente;

            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                Utenti _utenti = _model.Utentis.Where(ute => ute.ID == utente.ID).SingleOrDefault();
                if (_utenti != null)
                {
                    _utenti.ImgFriend = utente.ImgFriend;
                    _utenti.NomeFriend = utente.NomeFriend;
                    _model.SubmitChanges();
                }
                return _utenti;
            }
        }
        /// <summary>
        /// Totale degli utenti con immagini
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiConFoto()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => !ut.ImgFriend.ToUpper().Contains("NO-IMAGE") || ut.NomeFriend != string.Empty).Count();
            }
        }
        /// <summary>
        /// Lista degli utenti con immagini
        /// </summary>
        /// <returns></returns>
        public List<Utenti> GetUtentiConFoto()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => !ut.ImgFriend.ToUpper().Contains("NO-IMAGE") || ut.NomeFriend != string.Empty).ToList();
            }
        }
        /// <summary>
        /// Lista degli utenti con immagini
        /// </summary>
        /// <returns></returns>
        public List<Utenti> GetUtentiConFoto(int startRowIndex, int maximumRows)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => !ut.ImgFriend.ToUpper().Contains("NO-IMAGE") || ut.NomeFriend != string.Empty).OrderBy(ut => ut.DataCreazioneUtente).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale degli utenti registrati
        /// </summary>
        /// <param name="attivi"></param>
        /// <returns></returns>
        public int GetCountUtenti(bool attivi)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => ut.IsAttivo == attivi).Count();
            }
        }
        /// <summary>
        /// Numero totale di utenti
        /// </summary>
        /// <returns></returns>
        public int GetCountUtenti(string search)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => ut.EMail.ToLower().Contains(search.ToLower()) || ut.Cognome.ToLower().Contains(search.ToLower()) || ut.Nome.Contains(search.ToLower())).Count();
            }
        }
        /// <summary>
        /// Restituisce i prodotti paginati
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="attivi"></param>
        /// <returns></returns>
        public List<Utenti> GetUtentiPaging(int startRowIndex, int maximumRows,string search)
        {
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    return _model.Utentis.Where(ut => ut.EMail.ToLower().Contains(search.ToLower()) || ut.Cognome.ToLower().Contains(search.ToLower()) || ut.Nome.Contains(search.ToLower())).OrderByDescending(ut => ut.DataCreazioneUtente).Skip(startRowIndex).Take(maximumRows).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Restituisce un utente dato il suo id
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <returns></returns>
        public Utenti GetUtenteByID(int IDUtente)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                _model.DeferredLoadingEnabled = false;
                return _model.Utentis.Where(ut => ut.ID == IDUtente).SingleOrDefault();
            }
        }
        /// <summary>
        /// Salva un utente
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public Utenti SetUtente(Utenti utente)
        {
            try
            {
                DbTransaction _trans = null;
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    try
                    {
                        _model.DeferredLoadingEnabled = false;
                        // OPERA IN TRANSAZIONE
                        _model.Connection.Open();
                        _trans = _model.Connection.BeginTransaction();
                        _model.Transaction = _trans;

                        utente.DataCreazioneUtente = DateTime.Now;
                        utente.DataLastLogin = DateTime.Now;
                        utente.Password = this.Encode(utente.Password);
                        utente.CFiscPIva = utente.CFiscPIva.ToUpper();
                        _model.Utentis.InsertOnSubmit(utente);
                        _model.SubmitChanges();

                        Newsletter _newsletter = _model.Newsletters.Where(news => news.EMailNewsletter.ToLower() == utente.EMail.ToLower()).SingleOrDefault();
                        if (_newsletter != null)
                        {
                            _model.Newsletters.DeleteOnSubmit(_newsletter);
                            _model.SubmitChanges();
                        }
                        _trans.Commit();
                        _model.Connection.Close();

                        return utente;
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
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Aggiorna i dettagli di un utente
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public bool UpdateUtente(Utenti utente)
        {
            try
            {
                Utenti _utente = null;
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _utente = _model.Utentis.Where(ut => ut.ID == utente.ID).SingleOrDefault();
                    if (_utente != null)
                    {
                        _utente.CAP = utente.CAP;
                        _utente.NumeroCivico = utente.NumeroCivico;
                        _utente.DataNascita = utente.DataNascita;
                        _utente.CFiscPIva = utente.CFiscPIva;
                        _utente.Citta = utente.Citta;
                        _utente.Cognome = utente.Cognome;
                        _utente.EMail = utente.EMail;
                        _utente.RagioneSociale = utente.RagioneSociale;
                        _utente.Indirizzo = utente.Indirizzo;
                        _utente.IsAttivo = utente.IsAttivo;
                        _utente.NewsLetterAcquarologia = utente.NewsLetterAcquarologia;
                        _utente.NewsLetterCani = utente.NewsLetterCani;
                        _utente.NewsLetterGatti = utente.NewsLetterGatti;
                        _utente.NewsLetterRettili = utente.NewsLetterRettili;
                        _utente.NewsLetterRoditori = utente.NewsLetterRoditori;
                        _utente.NewsLetterVolatili = utente.NewsLetterVolatili;
                        _utente.Nome = utente.Nome;
                        _utente.NotePerbaffo = utente.NotePerbaffo;
                        _utente.Password = utente.Password;
                        _utente.Provincia = utente.Provincia;
                        _utente.Telefono = utente.Telefono;
                        _model.SubmitChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cancella un utente
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public bool DeleteUtente(int IDUtente)
        {
            try
            {
                int _count = 0;
                using (OrdiniModelDataContext _modelOrdini = new OrdiniModelDataContext())
                {
                    _count = _modelOrdini.Ordinis.Where(ord => ord.IDUtente == IDUtente).Count();
                }
                if (_count > 0)
                    return false;
                ///Posso cancellare
                Utenti _utente = null;
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _utente = _model.Utentis.Where(ut => ut.ID == IDUtente).SingleOrDefault();
                    if (_utente != null)
                    {
                        _model.Utentis.DeleteOnSubmit(_utente);
                        _model.SubmitChanges();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei cani
        /// </summary>
        /// <returns></returns>
        public List<string> GetUtentiNewsLetterCani()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                List<string> _newsletter = _model.Newsletters.Where(ut => ut.NewsLetterCani == true && ut.Attivo == true).Select(ut => ut.EMailNewsletter).ToList();
                List<string> _newsletterUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterCani == true).Select(ut => ut.EMail).ToList();

                _newsletter.AddRange(_newsletterUtenti);
                return _newsletter.Distinct().ToList();
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei gatti
        /// </summary>
        /// <returns></returns>
        public List<string> GetUtentiNewsLetterGatti()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                List<string> _newsletter = _model.Newsletters.Where(ut => ut.NewsLetterGatti == true && ut.Attivo == true).Select(ut => ut.EMailNewsletter).ToList();
                List<string> _newsletterUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterGatti == true).Select(ut => ut.EMail).ToList();

                _newsletter.AddRange(_newsletterUtenti);
                return _newsletter.Distinct().ToList();
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei roditori
        /// </summary>
        /// <returns></returns>
        public List<string> GetUtentiNewsLetterRoditori()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                List<string> _newsletter = _model.Newsletters.Where(ut => ut.NewsLetterRoditori == true && ut.Attivo == true).Select(ut => ut.EMailNewsletter).ToList();
                List<string> _newsletterUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterRoditori == true).Select(ut => ut.EMail).ToList();

                _newsletter.AddRange(_newsletterUtenti);
                return _newsletter.Distinct().ToList();
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei volatili
        /// </summary>
        /// <returns></returns>
        public List<string> GetUtentiNewsLetterVolatili()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                List<string> _newsletter = _model.Newsletters.Where(ut => ut.NewsLetterVolatili == true && ut.Attivo == true).Select(ut => ut.EMailNewsletter).ToList();
                List<string> _newsletterUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterVolatili == true).Select(ut => ut.EMail).ToList();

                _newsletter.AddRange(_newsletterUtenti);
                return _newsletter.Distinct().ToList();
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei volatili
        /// </summary>
        /// <returns></returns>
        public List<string> GetUtentiNewsLetterPesci()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                List<string> _newsletter = _model.Newsletters.Where(ut => ut.NewsLetterAcquarologia == true && ut.Attivo == true).Select(ut => ut.EMailNewsletter).ToList();
                List<string> _newsletterUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterAcquarologia == true).Select(ut => ut.EMail).ToList();

                _newsletter.AddRange(_newsletterUtenti);
                return _newsletter.Distinct().ToList();
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei cani
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiNewsLetterCani()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                int _count = _model.Newsletters.Where(ut => ut.NewsLetterCani == true && ut.Attivo == true).Count();
                int _coutUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterCani == true).Count();
                return _count + _coutUtenti;
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei cani
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiNewsLetterGatti()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                int _count = _model.Newsletters.Where(ut => ut.NewsLetterGatti == true && ut.Attivo == true).Count();
                int _coutUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterGatti == true).Count();
                return _count + _coutUtenti;
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei cani
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiNewsLetterRoditori()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                int _count = _model.Newsletters.Where(ut => ut.NewsLetterRoditori == true && ut.Attivo == true).Count();
                int _coutUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterRoditori == true).Count();
                return _count + _coutUtenti;
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei cani
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiNewsLetterPesci()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                int _count = _model.Newsletters.Where(ut => ut.NewsLetterAcquarologia == true && ut.Attivo == true).Count();
                int _coutUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterAcquarologia == true).Count();
                return _count + _coutUtenti;
            }
        }
        /// <summary>
        /// Totale degli utenti che sono iscritti alla newsletter dei cani
        /// </summary>
        /// <returns></returns>
        public int GetCountUtentiNewsLetterVolatili()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                int _count = _model.Newsletters.Where(ut => ut.NewsLetterVolatili == true && ut.Attivo == true).Count();
                int _coutUtenti = _model.Utentis.Where(ut => ut.IsAttivo == true && ut.NewsLetterVolatili == true).Count();
                return _count + _coutUtenti;
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Invia email di compleanno all'utente
        /// </summary>
        /// <param name="utente"></param>
        private void InvioEmailBirthday(UtentiStatistiche utente)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("info@perbaffo.it");
                message.To.Add(new MailAddress(utente.EMail));
                message.Subject = "Perbaffo.it - Buon compleanno " + this.Capitalize(utente.Nome) + " " + this.Capitalize(utente.Cognome);
                message.BodyEncoding = Encoding.UTF8;
                message.Body = string.Empty;
                _strBuilder.Append("Oggi abbiamo una missione speciale…" + Environment.NewLine);
                _strBuilder.Append("Festeggiare il tuo compleanno!!" + Environment.NewLine);
                _strBuilder.Append("Per farti i nostri migliori auguri ti regaliamo un buono sconto di 3 euro da utilizzare entro il 15 aprile 2011." + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Il codice sconto da utilizzare è COMPL0311" + Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Per usufruire il buono sconto dovrà inserire il codice in fase di conferma d’ordine. Il buono sconto va inserito nel campo “codice sconto” e poi bisogna cliccare su “aggiorna” l’importo dello sconto verrà automaticamente detratto dal totale ordine. Il buono è utilizzabile solo per un acquisto.");
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("Ancora tantissimi auguri!!" + Environment.NewLine);
                _strBuilder.Append("Lo staff di Perbaffo");
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append(Environment.NewLine);
                _strBuilder.Append("PERBAFFO" + Environment.NewLine);
                _strBuilder.Append("il tuo pet shop di fiducia" + Environment.NewLine);
                _strBuilder.Append("www.perbaffo.it" + Environment.NewLine);
                _strBuilder.Append("info@perbaffo.it" + Environment.NewLine);
                _strBuilder.Append("Chat MSN in tempo reale:  perbaffo@hotmail.it" + Environment.NewLine);
                _strBuilder.Append("Tel. 011/19567088" + Environment.NewLine);
                message.Body = _strBuilder.ToString();
                SmtpClient client = new SmtpClient();                
                client.Send(message);
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException =  "InvioEmailBirthday " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "InvioEmailBirthday";
                this.SetErrore(_errore);
            }
        }
        /// <summary>
        /// Invio e-mail di compleanno per il giorno odierno
        /// </summary>
        private void CheckBirthdayUsers()
        {
            try
            {
                ///Recupero gli utenti che hanno il compleanno in data ordierna
                var utenti = this.GetUtentiCompleanno(DateTime.Now.Date).ToList();
                if (utenti == null || utenti.Count <= 0)
                    return;
                ///Per ogni utente invio una mail di compleanno.
                utenti.ForEach(ut =>
                    {
                        this.InvioEmailBirthday(ut);
                    });
                ///Controllo se esiste un codice compleanno
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException = "CheckBirthdayUsers " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "CheckBirthdayUsers";
                this.SetErrore(_errore);
            }
        }
        #endregion
    }
}
