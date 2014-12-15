using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;
using System.Collections;

namespace Perbaffo.Web.UI.Admin
{
    public partial class ProdottoRelazione : BasePage
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
        /// <summary>
        /// IdProdotto corrente
        /// </summary>
        private int CurrentIDProdotto
        {
            get
            {
                if (ViewState["CurrentIDProdotto"] == null)
                    return -1;
                return (int)ViewState["CurrentIDProdotto"];
            }
            set { ViewState["CurrentIDProdotto"] = value; }
        }
        /// <summary>
        /// IdProdotto corrente
        /// </summary>
        private List<Prodotti> CurrentProdottoAssociati
        {
            get
            {
                if (ViewState["CurrentProdottoAssociati"] == null)
                    return new List<Prodotti>() ;
                return (List<Prodotti>)ViewState["CurrentProdottoAssociati"];
            }
            set { ViewState["CurrentProdottoAssociati"] = value; }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// Caricamento della pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["IDProdotto"]))
                {
                    this.CurrentIDProdotto = 0;
                }
                else
                {
                    this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);
                    this.CurrentProdottoAssociati =  base.PerbaffoController.GetProdottiAssociatiByIDProdotto(this.CurrentIDProdotto);
                }
                this.LoadFields();
                this.LoadCategorie();
                ((Pager)this.Pager).Visible = false;
            }
        }
        /// <summary>
        /// Ricerca prodotti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.PopulateDataSource(0, MAX_NUMS_ROWS);
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
        /// Delete di un prodotto associato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaProdAssoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;
            Prodotti _prod = this.CurrentProdottoAssociati.Where(prod => prod.ID == Convert.ToInt32(e.CommandArgument)).SingleOrDefault();
            if (_prod != null)
            {
                this.CurrentProdottoAssociati.Remove(_prod);
            }
            this.LoadFields();
        }
        /// <summary>
        /// Gestione della delete di un prodotto associato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaProdAssoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        /// <summary>
        /// Aggiunge come prodotto associato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;
            if(Convert.ToInt32(e.CommandArgument) == this.CurrentIDProdotto)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "att", "alert('Attenzione non si può associare un prodotto a se stesso');", true);
                return;
            }
            int _count = this.CurrentProdottoAssociati.Where(prod => prod.ID == Convert.ToInt32(e.CommandArgument)).Count();

            if (_count <= 0)
            {
                Prodotti _prod = base.PerbaffoController.GetProdottoByID(Convert.ToInt32(e.CommandArgument));
                this.CurrentProdottoAssociati.Add(_prod);
                this.LoadFields();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "att", "alert('Attenzione il prodotto selezionato è già stato associato');", true);
        }
        /// <summary>
        /// Aggiunge come prodotto associato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListProdotti_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
        }
        /// <summary>
        /// Salva tutti i prodotti associati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            base.PerbaffoController.SetProdottiRelazione(this.CurrentProdottoAssociati, this.CurrentIDProdotto);
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
        }
        /// <summary>
        /// Annulla le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto.ToString());
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
            try
            {
                // This bit is purely to have some data. usually this
                // would be from a database/XML file etc.

                //Set the repeater with a "page" of data
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
                if (this.grdListProdotti.DataSource == null || ((IList)this.grdListProdotti.DataSource).Count == 0)
                    ((Pager)this.Pager).Visible = false;
                else
                    ((Pager)this.Pager).Visible = true;
                this.updPnlListProdotti.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "att", "alert('Errore durante il recupero dati');", true);
            }
        }
        /// <summary>
        /// Caricmaento campi
        /// </summary>
        private void LoadFields()
        {
            try
            {
                this.grdListaProdAssoc.DataSource = this.CurrentProdottoAssociati; 
                this.grdListaProdAssoc.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Caricamento combo categorie
        /// </summary>
        private void LoadCategorie()
        {

            List<Categorie> _lstCategorie = base.PerbaffoController.GetCategorie();
            _lstCategorie.ForEach(categ =>
                {
                    this.ddCategorie.Items.Add(new ListItem(categ.DescrizioneBreve, categ.ID.ToString()));
                    this.LoadComboCategorie(categ,0);
                });
            this.ddCategorie.Items.Insert(0, new ListItem("Seleziona una categoria", ""));
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
                    this.ddCategorie.Items.Add(new ListItem(this.GetSeparator(Level + 1) + " " + categor.DescrizioneBreve, categor.ID.ToString()));
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
        #endregion

    }
}
