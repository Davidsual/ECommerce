using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI
{
    public partial class Commenta_Prodotto : BasePage
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
                        Prodotti _prod = base.PerbaffoController.GetProdottoLightByIDProdotto(this.CurrentIDProdotto);
                        this.lblTitoloProdotto.InnerText = _prod.Nome;
                        if (base.UtenteLoggato != null)
                        {
                            this.txtNomeRecensione.Text = base.UtenteLoggato.Nome;
                        }
                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
            }
        }
        /// <summary>
        /// Salva la recensione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInvia_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDProdotto <= 0 ||
                base.UtenteLoggato == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
                return;
            }

            if (string.IsNullOrEmpty(this.txtNomeRecensione.Text.Trim()) ||
                    string.IsNullOrEmpty(this.txtTitolo.Text.Trim()) ||
                    this.ddlQualita.SelectedIndex <= 0 ||
                    string.IsNullOrEmpty(this.txtTesto.Value.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Popolare tutti i campi!');", true);
                return;
            }
            if (this.txtTesto.Value.Trim().Length > 400)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('La recensione può contenere massimo 400 caratteri!');", true);
                return;
            }
            try
            {
                ///Salva la recensione
                base.PerbaffoController.SetRecensioneProdotto(this.CurrentIDProdotto, base.UtenteLoggato.ID, base.Capitalize(this.txtNomeRecensione.Text.Trim()), base.Capitalize(this.txtTitolo.Text.Trim()),
                    Convert.ToInt32(this.ddlQualita.SelectedValue), base.Capitalize(this.txtTesto.Value.Trim()));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clos", "this.close();", true);
            }
        }
        #endregion

    }
}
