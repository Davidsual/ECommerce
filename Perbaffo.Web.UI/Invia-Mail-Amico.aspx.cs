using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Invia_Mail_Amico : BasePage
    {
        #region PUBLIC PROPERTY
        public int CurrentIDProdotto
        {
            get
            {
                if (ViewState["CurrentIDProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentIDProdotto"];
            }
            set { ViewState["CurrentIDProdotto"] = value; }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Prodotto"]))
                {
                    int _result = 0;
                    if (int.TryParse(Request.QueryString["Prodotto"], out _result))
                    {
                        this.CurrentIDProdotto = _result;
                        this.txtTuaEmail.Text = (base.UtenteLoggato != null)?base.UtenteLoggato.EMail:string.Empty;
                        this.txtTuoNome.Text = (base.UtenteLoggato != null)?base.Capitalize(base.UtenteLoggato.Nome):string.Empty;
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
            }
        }
        /// <summary>
        /// Invio Mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNomeAmico.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtEmailAmico.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtTuaEmail.Text.Trim()) ||
                string.IsNullOrEmpty(this.txtTuoNome.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Popolare tutti i campi!');", true);
                return;
            }

            if (!base.IsEmailValid(this.txtEmailAmico.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Indirizzo E-Mail del tuo amico non valido!');", true);
                return;
            }
            if(!base.IsEmailValid(this.txtTuaEmail.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Il tuo indirizzo E-Mail non è valido!');", true);
                return;
            }
            try
            {
                base.PerbaffoController.InvioMailSegnalaProdotto(CurrentIDProdotto, this.txtNomeAmico.Text.Trim(),
                    this.txtEmailAmico.Text.Trim(), this.txtTuoNome.Text.Trim(),
                    this.txtTuaEmail.Text.Trim(), this.txtTesto.Value.Trim(), base.UrlServerImages);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
            }
        } 
        #endregion
    }
}
