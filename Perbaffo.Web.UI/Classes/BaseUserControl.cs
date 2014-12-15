using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;
using System.Configuration;

namespace Perbaffo.Web.UI.Classes
{
    public class BaseUserControl : UserControl, IDisposable
    {
        #region PRIVATE MEMBERS
        private ControllerPresentation _currentController = null;
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
        /// Indirizzo per le immagini degli utenti
        /// </summary>
        public string UrlServerImagesUtenti
        {
            get { return Application["UrlServerImagesUtenti"] as string; }
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
        #endregion

        #region PUBLIC PROPERTY
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
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            _currentController.Dispose();
        }
        #endregion
    }
}
