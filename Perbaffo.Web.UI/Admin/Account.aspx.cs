using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class Account : BasePage
    {
        #region EVENTI
        /// <summary>
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtUsername.Text = base.CurrentAmministratore.Username;
            }
        }
        /// <summary>
        /// Cambia password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtUsername.Text.Trim()) || string.IsNullOrEmpty(this.txtPassword.Text.Trim()) || string.IsNullOrEmpty(this.txtRePassword.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Popolare tutti i campi');", true);
                    return;
                }
                if (this.txtUsername.Text.Trim().Length <= 5 || this.txtPassword.Text.Trim().Length <= 5 || this.txtPassword.Text.Trim().Length > 12)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Username e password devono essere maggiore di 5 caratteri');", true);
                    return;
                }
                if (this.txtPassword.Text.Trim() != this.txtRePassword.Text.Trim())
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Le due password devono coincidere');", true);
                    return;
                }
                Amministratore _amm = base.PerbaffoController.ChangePassword(base.CurrentAmministratore, this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim());
                if (_amm == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Errore durante il cambio password');", true);
                    return;
                }
                else
                {
                    this.CurrentAmministratore = _amm;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Cambio password avvenuto con successo!');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Errore durante il cambio password!');", true);
            }
        }
        /// <summary>
        /// Evento annulla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.txtUsername.Text = base.CurrentAmministratore.Username;
        } 
        #endregion
    }
}
