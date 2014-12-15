using System;
using System.Configuration;
using System.Web.UI;
using Perbaffo.FTPClient;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin.Classes
{
    public class BasePage : Page, IDisposable
    {
        #region PRIVATE MEMBERS
        private Controller _currentController = null; 
        #endregion

        #region PUBLIC PROPERTY
        /// <summary>
        /// Controller corrente
        /// </summary>
        public Controller PerbaffoController
        {
            get
            {
                if (_currentController == null)
                    _currentController = new Controller();
                return _currentController;
            }
        }
        /// <summary>
        /// Indirizzo per le immagini degli CATEGORIE
        /// </summary>
        public string UrlServerImagesNews
        {
            get { return Application["UrlServerImagesNews"] as string; }
        }
        /// <summary>
        /// Amministratore loggato
        /// </summary>
        public Amministratore CurrentAmministratore
        {
            get
            {
                return Session["CurrentAmministratore"] as Amministratore;
            }
            set
            {
                Session["CurrentAmministratore"] = value;
            }
        }
        #endregion
        /// <summary>
        /// Controllo utente loggato
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            ///Controllo sessione
            if (CurrentAmministratore == null)
            {
                Server.Transfer("Login.aspx");
            }
            base.OnInit(e);
        }

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
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            _currentController.Dispose();
        }
        #endregion
    }
}
