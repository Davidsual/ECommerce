using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin.Classes
{
    public class BasePageUserControl : UserControl, IDisposable
    {
        private Controller _currentController = null;
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
        #region IDisposable Members

        void IDisposable.Dispose()
        {
            _currentController.Dispose();
        }

        #endregion
    }
}
