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
    public partial class DettaglioCuriosita : BasePage
    {
        #region PRIVATE MEMBERS
        private enum PageStatus
        {
            Inserimento,
            Modifica
        }
        private const string CATEGORIA_CANI = "DOG";
        private const string CATEGORIA_GATTI = "CAT";
        private const string CATEGORIA_RODITORI = "RABBIT";
        private const string CATEGORIA_VOLATILI = "BIRD";
        private const string CATEGORIA_PESCI = "FISH"; 
        #endregion

        #region PRIVATE PROPERTY
        private PageStatus CurrentPageState
        {
            get
            {
                if (ViewState["CurrentPageState"] == null)
                    return PageStatus.Inserimento;
                return (PageStatus)ViewState["CurrentPageState"];
            }
            set
            {
                ViewState["CurrentPageState"] = value;
            }
        }
        private int CurrentIDCuriosita
        {
            get
            {
                if (ViewState["CurrentIDNews"] == null)
                    return -1;
                return (int)ViewState["CurrentIDNews"];
            }
            set { ViewState["CurrentIDNews"] = value; }
        }

        #endregion

        #region EVENTS
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestCuriosita.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["IDCuriosita"]))
                {
                    this.CurrentPageState = PageStatus.Inserimento;
                    this.CurrentIDCuriosita = 0;
                }
                else
                {
                    this.CurrentIDCuriosita = int.Parse(Request.QueryString["IDCuriosita"]);
                    this.CurrentPageState = PageStatus.Modifica;
                    
                }
                this.LoadFields();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Curiosita _curiosita = new Curiosita();
            try
            {
                if (this.CurrentIDCuriosita > 0)
                {
                    _curiosita.ID = this.CurrentIDCuriosita;
                    _curiosita.Categoria = this.ddlCategorie.SelectedValue;
                    _curiosita.DescrCuriosita = this.descrizione.Value.Trim();
                    base.PerbaffoController.UpdateCuriosita(_curiosita);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Aggiornamento effettuato');", true);
                }
                else
                {
                    _curiosita.Categoria = this.ddlCategorie.SelectedValue;
                    _curiosita.DescrCuriosita = this.descrizione.Value.Trim();
                    _curiosita = base.PerbaffoController.SetCuriosita(_curiosita);
                    this.CurrentIDCuriosita = _curiosita.ID;
                    this.btnElimina.Enabled = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Aggiornamento effettuato');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante l\\'aggiornamento');", true);
            }
        }
        protected void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentIDCuriosita > 0)
                {
                    base.PerbaffoController.DeleteCuriosita(this.CurrentIDCuriosita);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "self.location.href = 'GestCuriosita.aspx';", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante l\\'aggiornamento');", true);
            }

        }

        protected void btnCancella_Click(object sender, EventArgs e)
        {
            if (this.CurrentIDCuriosita > 0)
            {
                Curiosita _curiosita = base.PerbaffoController.GetCuriositaByID(this.CurrentIDCuriosita);
                if (_curiosita != null)
                {
                    this.ddlCategorie.SelectedValue = _curiosita.Categoria;
                    this.descrizione.Value = _curiosita.DescrCuriosita;
                }
            }
            else
            {
                this.ddlCategorie.SelectedIndex = -1;
                this.descrizione.Value = string.Empty;
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        private void LoadFields()
        {
            this.ddlCategorie.Items.Clear();
            this.ddlCategorie.Items.Add(new ListItem("Cani", CATEGORIA_CANI));
            this.ddlCategorie.Items.Add(new ListItem("Gatti", CATEGORIA_GATTI));
            this.ddlCategorie.Items.Add(new ListItem("Roditori", CATEGORIA_RODITORI));
            this.ddlCategorie.Items.Add(new ListItem("Volatili", CATEGORIA_VOLATILI));
            this.ddlCategorie.Items.Add(new ListItem("Pesci", CATEGORIA_PESCI));

            this.btnElimina.Enabled = false;

            if (this.CurrentIDCuriosita > 0)
            {
                Curiosita _curiosita = base.PerbaffoController.GetCuriositaByID(this.CurrentIDCuriosita);
                if (_curiosita != null)
                {
                    this.ddlCategorie.SelectedValue = _curiosita.Categoria;
                    this.descrizione.Value = _curiosita.DescrCuriosita;
                }
                this.btnElimina.Enabled = true;
            }
        }
        #endregion
    }
}
