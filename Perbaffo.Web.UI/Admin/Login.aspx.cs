using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class Login : Page
    {
        private Controller _currentController = null;

        /// <summary>
        /// Controller corrente
        /// </summary>
        private Controller PerbaffoController
        {
            get
            {
                if (_currentController == null)
                    _currentController = new Controller();
                return _currentController;
            }
        }
        private DateTime CurrentDataInizioTentativo
        {
            get
            {
                if (ViewState["CurrentDataInizioTentativo"] == null)
                    return DateTime.MinValue;
                return (DateTime)ViewState["CurrentDataInizioTentativo"];
            }
            set
            {
                ViewState["CurrentDataInizioTentativo"] = value;
            }
        }
        private int CurrentTentativi
        {
            get
            {
                if (ViewState["CurrentTentativi"] == null)
                    return 1;
                return (int)ViewState["CurrentTentativi"];
            }
            set
            {
                ViewState["CurrentTentativi"] = value;
            }
        }
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetMaxAge(TimeSpan.Zero);
            if (!Page.IsPostBack)
            {
            }
        }
        /// <summary>
        /// Login 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUser.Text.Trim()) || string.IsNullOrEmpty(this.txtpass.Text.Trim()) || this.txtUser.Text.Trim().Length > 12 || this.txtpass.Text.Trim().Length > 12)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Inserire Username e Password');", true);
                return;
            }
            if (this.CurrentDataInizioTentativo == DateTime.MinValue)
            {
                this.CurrentDataInizioTentativo = DateTime.Now;
            }
            else
                this.CurrentTentativi++;

            if (this.CurrentTentativi > 4 && this.CurrentDataInizioTentativo != DateTime.MinValue && this.CurrentDataInizioTentativo.AddMinutes(5) > DateTime.Now)
                return;
            Amministratore _result = this.PerbaffoController.CheckLoginAmministratore(this.txtUser.Text.Trim(), this.txtpass.Text.Trim());
            if (_result != null)
            {
                Session["CurrentAmministratore"] = _result;
                Server.Transfer("HomePage.aspx");
            }

        }
    }
}
