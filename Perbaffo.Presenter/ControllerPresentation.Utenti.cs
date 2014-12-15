using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perbaffo.Presenter.Model;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.IO;

namespace Perbaffo.Presenter
{
    public partial class ControllerPresentation : IDisposable
    {
        #region PUBLIC METHODS
        /// <summary>
        /// Lista di foto di utenti
        /// </summary>
        /// <param name="numProdotti"></param>
        /// <returns></returns>
        public List<string> GetFotoAmici(int numFoto)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => ut.IsAttivo == true && ut.ImgFriend != null && ut.ImgFriend != string.Empty && !ut.ImgFriend.ToUpper().Contains("NO-IMAGE")).Select(ut => ut.ImgFriend).OrderByDescending(ut => _model.GetNewId()).Take(numFoto).ToList();
            }
        }
        /// <summary>
        /// Restituisce tutte le foto degli amici
        /// </summary>
        /// <returns></returns>
        public List<FotoAmici> GetFotoAmici()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => ut.IsAttivo == true && ut.ImgFriend != null && ut.ImgFriend != string.Empty && !ut.ImgFriend.ToUpper().Contains("NO-IMAGE")).Select(ut => new FotoAmici { UrlImage = ut.ImgFriend, DescrImage = ut.NomeFriend }).OrderByDescending(ut => _model.GetNewId()).ToList();
            }
        }
        /// <summary>
        /// Lista delle foto amici paginato
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns></returns>
        public List<FotoAmici> GetFotoAmici(int startRowIndex, int maximumRows)
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => ut.IsAttivo == true && ut.ImgFriend != null && ut.ImgFriend != string.Empty && !ut.ImgFriend.ToUpper().Contains("NO-IMAGE")).Select(ut => new FotoAmici { UrlImage = ut.ImgFriend, DescrImage = ut.NomeFriend }).OrderBy(ut => ut.DescrImage).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
        /// <summary>
        /// Totale foto
        /// </summary>
        /// <returns></returns>
        public int GetCountFotoAmici()
        {
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                return _model.Utentis.Where(ut => ut.IsAttivo == true && ut.ImgFriend != null && ut.ImgFriend != string.Empty && !ut.ImgFriend.ToUpper().Contains("NO-IMAGE")).Select(ut => new FotoAmici { UrlImage = ut.ImgFriend, DescrImage = ut.NomeFriend }).Count();
            }
        }
        /// <summary>
        /// Aggiorna i dati
        /// </summary>
        /// <param name="utenti"></param>
        /// <returns></returns>
        public Utenti UpdateDettagliUtente(Utenti utente)
        {
            if (utente == null)
                return utente;

            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                Utenti _utenti = _model.Utentis.Where(ute => ute.ID == utente.ID).SingleOrDefault();
                if (_utenti != null)
                {
                    _utenti.CAP = utente.CAP;
                    _utenti.Provincia = utente.Provincia;
                    _utenti.Citta = utente.Citta;
                    _utenti.Indirizzo = utente.Indirizzo;
                    _utenti.Telefono = utente.Telefono;
                    _utenti.NumeroCivico = utente.NumeroCivico;
                    _utenti.RagioneSociale = utente.RagioneSociale;
                    _utenti.DataNascita = utente.DataNascita;
                    _model.SubmitChanges();
                }
                return _utenti;
            }
        }
        /// <summary>
        /// Aggiorna la password dell'utente
        /// </summary>
        /// <param name="IDUtente"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdatePasswordUtente(int IDUtente,string password)
        {
            bool _result = false;
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                Utenti _utenti = _model.Utentis.Where(ute => ute.ID == IDUtente).SingleOrDefault();
                if (_utenti != null)
                {
                    _utenti.Password = this.Encode(password);
                    _model.SubmitChanges();
                    _result = true;
                }
                return _result;
            }
        }
        /// <summary>
        /// Aggiornamento della newsletter
        /// </summary>
        /// <param name="utenti"></param>
        /// <returns></returns>
        public Utenti UpdateNewsLetter(Utenti utente)
        {
            if (utente == null)
                return utente;

            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                Utenti _utenti = _model.Utentis.Where(ute => ute.ID == utente.ID).SingleOrDefault();
                if (_utenti != null)
                {
                    _utenti.NewsLetterAcquarologia = utente.NewsLetterAcquarologia;
                    _utenti.NewsLetterCani = utente.NewsLetterCani;
                    _utenti.NewsLetterGatti = utente.NewsLetterGatti;
                    _utenti.NewsLetterVolatili = utente.NewsLetterVolatili;
                    _utenti.NewsLetterRoditori = utente.NewsLetterRoditori;
                    _model.SubmitChanges();
                }
                return _utenti;
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

            using (Controller _ctrl = new Controller())
            {
                return _ctrl.UpdateImmagineUtente(utente);
            }
        }
        /// <summary>
        /// Inserisce un nuovo utente
        /// </summary>
        /// <param name="utente"></param>
        public Utenti SetUtente(Utenti utente)
        {
            if (utente.ID > 0)
                return utente;
            try
            {
                using (Controller _ctrl = new Controller())
                {
                    return _ctrl.SetUtente(utente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Invio E-Mail registrazione newsletter
        /// </summary>
        /// <param name="email"></param>
        /// <param name="categoriaCani"></param>
        /// <param name="categoriaGatti"></param>
        /// <param name="categoriaRoditori"></param>
        /// <param name="categoriaVolatili"></param>
        /// <param name="categoriaPesci"></param>
        /// <returns></returns>
        public bool InvioMailNewsletter(string email, bool categoriaCani, bool categoriaGatti, bool categoriaRoditori, bool categoriaVolatili, bool categoriaPesci)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("newsletter@perbaffo.it");
                    message.To.Add(new MailAddress(email));
                    message.Subject = "Perbaffo.it - Iscrizione alla Newsletter di Perbaffo";
                    message.Body = "";
                    message.BodyEncoding = Encoding.UTF8;
                    _strBuilder.Append("Gentile utente" + Environment.NewLine);
                    _strBuilder.Append("Ti sei iscritto alla Newsletter di Perbaffo" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("alle seguenti categorie:" + Environment.NewLine);
                    if(categoriaCani)
                        _strBuilder.Append("Newsletter categoria: cani" + Environment.NewLine);
                    if (categoriaGatti)
                        _strBuilder.Append("Newsletter categoria: gatti" + Environment.NewLine);
                    if (categoriaRoditori)
                        _strBuilder.Append("Newsletter categoria: roditori" + Environment.NewLine);
                    if (categoriaVolatili)
                        _strBuilder.Append("Newsletter categoria: Volatili" + Environment.NewLine);
                    if (categoriaPesci)
                        _strBuilder.Append("Newsletter categoria: Acquariologia / Terrari" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Se non era tua intenzione iscriverti o vuoi essere rimosso dal servizio di newsletter manda un e-mail a info@perbaffo.it con soggetto: ELIMINA" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Cordiali saluti" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Lo Staff di Perbaffo");
                    message.Body = _strBuilder.ToString();
                    SmtpClient client = new SmtpClient();
                    client.Send(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException = email + "  " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "INVIOMAILREGISTRAZIONENEWSLETTER";
                this.SetErrore(_errore);
                throw ex;
            }
        }
        /// <summary>
        /// Invio Email dati di accesso
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool InvioMailRecuperoPassword(string email)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;

                    Utenti _utente = _model.Utentis.Where(ut => ut.EMail.ToLower().Equals(email.ToLower()) && ut.IsAttivo == true).SingleOrDefault();
                    if (_utente == null)
                        return false;

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("info@perbaffo.it");
                    message.To.Add(new MailAddress(_utente.EMail));
                    message.Subject = "Perbaffo.it - Recupero password";
                    message.Body = "";
                    message.BodyEncoding = Encoding.UTF8;
                    _strBuilder.Append("Gentile " + this.Capitalize(_utente.Nome) + " " + this.Capitalize(_utente.Cognome) + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Come da Sua richiesta le inviamo i dati per accedere al nostro sito:" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("E-Mail: " + _utente.EMail + Environment.NewLine);                    
                    _strBuilder.Append("Password: " + this.Decode(_utente.Password) + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Cordiali saluti" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Lo Staff di Perbaffo");
                    message.Body = _strBuilder.ToString();
                    SmtpClient client = new SmtpClient();
                    client.Send(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException = email + "  " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "INVIOMAILRECUPEROPASSWORD";
                this.SetErrore(_errore);
                throw ex;
            }
        }
        /// <summary>
        /// Invio di un'e-mail all'utente
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public bool InvioMailNuovoUtente(Utenti utente)
        {
            if (utente == null)
                return false;
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("info@perbaffo.it");
                    message.To.Add(new MailAddress(utente.EMail));
                    message.Subject = "Perbaffo.it - Conferma di registrazione";
                    message.Body = "";
                    message.BodyEncoding = Encoding.UTF8;
                    _strBuilder.Append("Gentile " + this.Capitalize(utente.Nome) + " " + this.Capitalize(utente.Cognome) + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("La ringraziamo per essersi registrato su www.perbaffo.it" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Di seguito riportiamo i dati per poter accedere ed effettuare ordini:" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("E-Mail (Username): " + utente.EMail + Environment.NewLine);
                    _strBuilder.Append("Password: " + this.Decode(utente.Password) + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Tutti i nostri prodotti sono stati accuratamente selezionati per offrirLe solo accessori di alta qualita'." + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Se si e' iscritto alla nostra Newsletter, ricevera' buoni sconti o promozioni riservate ai soli iscritti, per ringraziarLa di esser entrato a far parte della nostra community." + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Le ricordiamo che Perbaffo tratta i suoi dati nel pieno rispetto della normativa vigente" +Environment.NewLine);
                    _strBuilder.Append("e NON li cede a nessuna azienda esterna, tali dati verranno utilizzati solo ed esclusivamente" +Environment.NewLine);
                    _strBuilder.Append(" per comunicare con Lei o per portare a termine l'evasione degli ordini." + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Cordiali saluti" + Environment.NewLine);
                    _strBuilder.Append(Environment.NewLine);
                    _strBuilder.Append("Lo Staff di Perbaffo");
                    message.Body = _strBuilder.ToString();
                    SmtpClient client = new SmtpClient();
                    client.Send(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TestMail()
        {
            try
            {
                ProdottoImmagine _prod = this.GetProdottoByIDProdotto(972);

                string strMailContent = "Welcome new user";
                string fromAddress = "info@perbaffo.it";
                string toAddress = "trottadavide@hotmail.com";
                string path = "http://192.168.1.3/ImmaginiPerbaffo/"+_prod.UrlImmagine; // my logo is placed in images folder
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
                mailMessage.Subject = "Welcome new User";

                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(path);
                // execute the request
                HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();
                // we will read data via the response stream
                Stream data = response.GetResponseStream();
                LinkedResource logo = new LinkedResource(data, MediaTypeNames.Image.Jpeg);

                logo.ContentId = "companylogo";
                // done HTML formatting in the next line to display my logo
                AlternateView av1 = AlternateView.CreateAlternateViewFromString("<html><body><br/><p>Gentile <b>Davide</b></p><p>Un amico (Antonio - antonio@libero.it) ti ha segnalato un prodotto presente sul sito <a href='http://www.perbaffo.it' title='Perbaffo'>http://www.perbaffo.it</a></p><p>Ottimo puoi vederlo cliccando qui</p><a href='http://www.perbaffo.it/' title='Nome del prodotto'><img src=\"cid:companylogo\" /></a><br></body></html>" + strMailContent, null, MediaTypeNames.Text.Html);
                av1.LinkedResources.Add(logo);


                mailMessage.AlternateViews.Add(av1);
                mailMessage.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Invio Mail per segnalare un prodotto ad un amico
        /// </summary>
        /// <param name="IDProdotto"></param>
        /// <returns></returns>
        public bool InvioMailSegnalaProdotto(int IDProdotto,string nomeAmico,string emailAmico,string nomeCliente,string emailCliente,string testo,string urlImmagine)
        {
            StringBuilder _strBuilder = new StringBuilder();
            try
            {
                ProdottoImmagine _prod = this.GetProdottoByIDProdotto(IDProdotto);
                if (_prod == null)
                    return false;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("info@perbaffo.it");
                message.To.Add(new MailAddress(emailAmico));
                message.Subject = "Perbaffo.it - " + this.Capitalize(nomeCliente) + " ti consiglia un prodotto";

                string path = urlImmagine + _prod.UrlImmagine;
                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(path);
                request.Timeout = 30000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream data = response.GetResponseStream();
                LinkedResource logo = new LinkedResource(data, MediaTypeNames.Image.Jpeg);
                logo.ContentId = "companylogo";

                _strBuilder.Append("<html><body><br/>");
                _strBuilder.Append("<p>Gentile <b>" + this.Capitalize(nomeAmico) + "</b></p>");
                _strBuilder.Append("<p>Un amico (" + this.Capitalize(nomeCliente) + " - " + emailCliente + ") ti ha segnalato un prodotto presente sul sito <a href='http://www.perbaffo.it' title='Perbaffo Pet Shop'>http://www.perbaffo.it</a></p>");
                _strBuilder.Append("<p>\"" + this.Capitalize(testo) + "\"</p>");
                _strBuilder.Append("<p><b>"+_prod.Nome+"</b></p>");
                _strBuilder.Append("<p><a href='http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + IDProdotto.ToString() + "' title='" + _prod.Nome + "'><img src=\"cid:companylogo\" /></a>");
                _strBuilder.Append("<p>Puoi vederlo cliccando su questo link: <a href='http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=" + IDProdotto.ToString() + "' title='"+_prod.Nome+"'>"+_prod.Nome+"</a></p>");
                _strBuilder.Append("<br/><p>Cordiali saluti</p>");
                _strBuilder.Append("<p>Lo Staff di Perbaffo</p>");
                _strBuilder.Append("</body></html>");
                AlternateView av1 = AlternateView.CreateAlternateViewFromString(_strBuilder.ToString(), null, MediaTypeNames.Text.Html);
                av1.LinkedResources.Add(logo);
                message.BodyEncoding = Encoding.UTF8;
                message.AlternateViews.Add(av1);
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                Errori _errore = new Errori();
                _errore.CurrentIDUtenteLoggato = -1;
                _errore.DataErrore = DateTime.Now;
                _errore.DescrException = "IDProdotto: " + IDProdotto + "  " + ex.Message;
                _errore.DescrStackTrace = ex.StackTrace;
                if (ex.InnerException != null)
                {
                    _errore.DescrInnerException = ex.InnerException.Message;
                }
                _errore.PathPagina = "INVIOMAILSEGNALAPRODOTTO";
                this.SetErrore(_errore);
                return false;
            }
        }
        /// <summary>
        /// Controllo se un utente è gia censito data la sua e-mail
        /// </summary>
        /// <param name="eMail"></param>
        /// <returns></returns>
        public bool ExistUtente(string email)
        {
            int _findUtenti = 0;
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                _findUtenti = _model.Utentis.Where(ut => ut.EMail.ToLower().Equals(email.Trim().ToLower()) && ut.IsAttivo == true).Count();
            }
            return (_findUtenti > 0);
        }
        /// <summary>
        /// Controllo di username e password
        /// </summary>
        /// <param name="eMail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Utenti CheckLogin(string eMail, string password)
        {
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    _model.DeferredLoadingEnabled = false;
                    _model.ObjectTrackingEnabled = false;
                    Utenti _utente = _model.Utentis.Where(ut => ut.EMail.ToLower().Equals(eMail.ToLower()) && ut.Password.Equals(this.Encode(password)) && ut.IsAttivo == true).SingleOrDefault();
                    ///Aggiorno la data di ultima modifica
                    if (_utente != null)
                    {
                        this.AggiornaDataUltimoLogin(_utente);
                    }
                    
                    return _utente;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Aggiorna data ultimo login
        /// </summary>
        /// <param name="utente"></param>
        public void AggiornaDataUltimoLogin(Utenti utente)
        {
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    Utenti _utente = _model.Utentis.Where(ut => ut.ID == utente.ID && ut.IsAttivo == true).SingleOrDefault();
                    ///Aggiorno la data di ultima modifica
                    if (_utente != null)
                    {
                        _utente.DataLastLogin = DateTime.Now;
                        _model.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// Indica se esiste già un'email all'interno del sistema
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistEmailNewsletter(string email)
        {
            int _findUtenti = 0;
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                _findUtenti = _model.Utentis.Where(ut => ut.EMail.ToLower().Equals(email.Trim().ToLower()) && ut.IsAttivo == true).Count();
                //_findUtenti += _model.Newsletters.Where(news => news.EMailNewsletter.ToLower().Equals(email.Trim().ToLower())).Count();
            }
            return (_findUtenti > 0);
        }
        /// <summary>
        /// Indica se esiste già un'email all'interno del sistema
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistEmailUtente(string email)
        {
            int _findUtenti = 0;
            using (UtentiModelDataContext _model = new UtentiModelDataContext())
            {
                _findUtenti = _model.Utentis.Where(ut => ut.EMail.ToLower().Equals(email.Trim().ToLower()) && ut.IsAttivo == true).Count();
                _findUtenti += _model.Newsletters.Where(news => news.EMailNewsletter.ToLower().Equals(email.Trim().ToLower())).Count();
            }
            return (_findUtenti > 0);
        }
        /// <summary>
        /// Inserisce una nuova e-mail
        /// </summary>
        /// <param name="eMail"></param>
        /// <param name="cani"></param>
        /// <param name="gatti"></param>
        /// <param name="roditori"></param>
        /// <param name="volatili"></param>
        /// <param name="pesci"></param>
        /// <returns></returns>
        public bool SetNewsletterUtente(string eMail, bool cani, bool gatti, bool roditori, bool volatili, bool pesci,bool rettili)
        {
            try
            {
                using (UtentiModelDataContext _model = new UtentiModelDataContext())
                {
                    Newsletter _letter = _model.Newsletters.Where(news => news.EMailNewsletter.ToLower() == eMail.ToLower()).SingleOrDefault();
                    if (_letter != null)
                    {
                        _letter.NewsLetterAcquarologia = pesci;
                        _letter.NewsLetterCani = cani;
                        _letter.NewsLetterGatti = gatti;
                        _letter.NewsLetterRettili = rettili;
                        _letter.NewsLetterRoditori = roditori;
                        _letter.NewsLetterVolatili = volatili;
                        _model.SubmitChanges();
                        return true;
                    }

                    Newsletter _newsletter = new Newsletter()
                    {
                        EMailNewsletter = eMail,
                        Attivo = true,
                        NewsLetterAcquarologia = pesci,
                        NewsLetterCani = cani,
                        NewsLetterGatti = gatti,
                        NewsLetterRettili = rettili,
                        NewsLetterRoditori = roditori,
                        NewsLetterVolatili = volatili
                    };
                    _model.Newsletters.InsertOnSubmit(_newsletter);
                    _model.SubmitChanges();
                    ///Invio e-mail riepilogativa
                    this.InvioMailNewsletter(eMail, cani, gatti, roditori, volatili, pesci);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
