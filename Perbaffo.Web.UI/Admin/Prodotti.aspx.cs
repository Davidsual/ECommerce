using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Presenter;
using Perbaffo.Web.UI.Admin.Classes;
using System.Collections;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class Prodotti1 : BasePage
    {
        #region PRIVATE MEMBERS
        private const int MAX_NUMS_ROWS = 10; 
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Num totale prodotti
        /// </summary>
        private int TotProdotti
        {
            get { return (int)ViewState["TotProdotti"]; }
            set { ViewState["TotProdotti"] = value; }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.TotProdotti = this.PerbaffoController.GetCountProdotti();
                if (!string.IsNullOrEmpty(Request.QueryString["Pagina"]))
                {
                    int _pagina = Convert.ToInt32(Request.QueryString["Pagina"]);
                    ((Pager)this.Pager).CurrentPageNumber = _pagina;
                    this.PopulateDataSource(_pagina, MAX_NUMS_ROWS);
                }
                else
                    this.PopulateDataSource(0, MAX_NUMS_ROWS);
                this.LoadFields();
            }
        }
        /// <summary>
        /// Caricamento combo categorie
        /// </summary>
        private void LoadFields()
        {
            List<Categorie> _lstCategorie = base.PerbaffoController.GetCategorie();
            _lstCategorie.ForEach(categ =>
                {
                    this.ddCategorie.Items.Add(new ListItem(categ.DescrizioneBreve, categ.ID.ToString()));
                    this.LoadComboCategorie(categ,0);
                });
            this.ddCategorie.Items.Insert(0,new ListItem("Seleziona una categoria",""));
        }
        /// <summary>
        /// Carica gli elementi della combo figli
        /// </summary>
        /// <param name="categ"></param>
        /// <param name="Level"></param>
        private void LoadComboCategorie(Categorie categ,int Level)
        {
            if (categ.CategorieFiglie == null || categ.CategorieFiglie.Count <= 0)
                return;
            categ.CategorieFiglie.ForEach(categor =>
                {
                    this.ddCategorie.Items.Add(new ListItem(this.GetSeparator(Level+1) + " " + categor.DescrizioneBreve, categor.ID.ToString()));
                    this.LoadComboCategorie(categor, Level+1);
                });
        }
        /// <summary>
        /// Separatore all'interno della combo
        /// </summary>
        /// <param name="Level"></param>
        /// <returns></returns>
        private string GetSeparator(int Level)
        {
            string _valore = string.Empty;
            for (int i = 0; i < Level; i++)
            {
                _valore += "-";
            }
            return _valore;
        }

        /// <summary>
        /// Cambio della pagina si aggiorna il datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_Changed(object sender, PagerEventArgs e)
        {
            this.PopulateDataSource(e.Number, e.PageSize);
        }
        /// <summary>
        /// Ricerca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.PopulateDataSource(0, MAX_NUMS_ROWS);
        }
        /// <summary>
        /// Seleziona sulla lista dei prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string _param = "?PaginaProdotto=" + ((Pager)this.Pager).CurrentPageNumber.ToString() + "&IDProdotto=" + e.CommandArgument;
            ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.DettaglioProdotto, _param);
            return;
        }
        /// <summary>
        /// Seleziona sulla lista dei prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Genera il catalogi per i cani
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCatalogoCani_Click(object sender, EventArgs e)
        {
            try
            {
                bool _result = base.PerbaffoController.CreaCatalogoCani(Server.MapPath("../Documents/Perbaffo-Catalogo-Cani.pdf"));
                if (_result)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Catalogo creato con successo!');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
        }
        /// <summary>
        /// Genera il catalogi per i gatti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCatalogoGatti_Click(object sender, EventArgs e)
        {
            try
            {
                bool _result = base.PerbaffoController.CreaCatalogoGatti(Server.MapPath("../Documents/Perbaffo-Catalogo-Gatti.pdf"));
                if (_result)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Catalogo creato con successo!');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
        }
        /// <summary>
        /// Genera il catalogi per i roditori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCatalogoRoditori_Click(object sender, EventArgs e)
        {
            try
            {
                bool _result = base.PerbaffoController.CreaCatalogoRoditori(Server.MapPath("../Documents/Perbaffo-Catalogo-Roditori.pdf"));
                if (_result)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Catalogo creato con successo!');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
        }
        /// <summary>
        /// Genera il catalogi per i volatili
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCatalogoVolatili_Click(object sender, EventArgs e)
        {
            try
            {
                bool _result = base.PerbaffoController.CreaCatalogoVolatili(Server.MapPath("../Documents/Perbaffo-Catalogo-Volatili.pdf"));
                if (_result)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Catalogo creato con successo!');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
        }
        /// <summary>
        /// Genera il catalogi per i pesci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCatalogoPesci_Click(object sender, EventArgs e)
        {
            try
            {
                bool _result = base.PerbaffoController.CreaCatalogoAcquariologia(Server.MapPath("../Documents/Perbaffo-Catalogo-Acquariologia.pdf"));
                if (_result)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Catalogo creato con successo!');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "al", "alert('Errore durante la generazione del catalogo!');", true);
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica la griglia
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        private void PopulateDataSource(int page, int pageSize)
        {
            page = (page == 0) ? 0 : page - 1;
            int _startRecord = (page == 0) ? 0 : page * pageSize;
            FiltroProdotto _filtro = new FiltroProdotto()
            {
                CodiceProdotto = this.txtCodiceDescrizione.Text.Trim(),
                DescrizioneProdotto = this.txtCodiceDescrizione.Text.Trim(),
                IDCategoria = (this.ddCategorie.SelectedValue == string.Empty) ? 0 : Convert.ToInt32(this.ddCategorie.SelectedValue)
            };
            this.grdListProdotti.DataSource = this.PerbaffoController.GetProdottiByFilter(_filtro, _startRecord, pageSize);
            this.grdListProdotti.DataBind();
            this.TotProdotti = this.PerbaffoController.GetCountProdottiByFilter(_filtro);
            //Calculates how many pages of a given size are required
            ((Pager)this.Pager).TotalPages =
                 (this.TotProdotti / pageSize) + (this.TotProdotti % pageSize > 0 ? 1 : 0);

            ((Pager)this.Pager).GenerateLinks();
            this.updPnlListProdotti.Update();
        }
        #endregion


    }
}
