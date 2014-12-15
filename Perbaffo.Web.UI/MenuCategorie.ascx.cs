using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Web.UI.HtmlControls;
using Perbaffo.Presenter.Model;
using System.Web.Caching;

namespace Perbaffo.Web.UI
{
    public partial class MenuCategorie : BaseUserControl
    {
        #region PRIVATE MEMBER
        private bool _isFindCategoria = false;
        #endregion

        private int CurrentCategoriaPadreSelezionata { get; set; }

        #region PUBLIC PROPERTY
        /// <summary>
        /// ID categoria selezionata
        /// </summary>
        public int CurrentIDCategoria
        {
            get
            {
                if (ViewState["CurrentIDCategoria"] == null)
                    return -1;
                return (int)ViewState["CurrentIDCategoria"];
            }
            set
            {
                ViewState["CurrentIDCategoria"] = value;
            }
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
            //if (!Page.IsPostBack)
            //{
                if (!string.IsNullOrEmpty(Request.QueryString["Categoria"]))
                {
                    int _return = 0;
                    if (int.TryParse(Request.QueryString["Categoria"], out _return))
                    {
                        this.CurrentIDCategoria = _return;
                    }
                }
                else
                    this.CurrentIDCategoria = 0;
                ///1)Carico il menu
                this.CaricaMenu();
            //}
        }
        /// <summary>
        /// Ricerca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            Server.Transfer("Risultati-Ricerca.aspx");
        }
        /// <summary>
        /// Gestione dell'elemento selezionato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptMenuCategorie_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ((HtmlAnchor)e.Item.Controls[1]).HRef = "Dettaglio-Categoria.aspx?Categoria=" + ((Categorie)e.Item.DataItem).ID.ToString();
                HtmlGenericControl _divVisibility = e.Item.FindControl("divScelta") as HtmlGenericControl;
                if (this.CurrentIDCategoria > 0)
                {
                    if (((Categorie)e.Item.DataItem).ID == this.CurrentIDCategoria)
                    {
                        ///Gestisco il selezionato
                        ((HtmlAnchor)e.Item.Controls[1]).Attributes.Add("class", "red");
                        _isFindCategoria = true;
                    }
                }
                if (this.CurrentCategoriaPadreSelezionata > 0 && ((Categorie)e.Item.DataItem).ID != this.CurrentCategoriaPadreSelezionata && _divVisibility != null)
                {
                    _divVisibility.Visible = false;
                }
            }
        }
        /// <summary>
        /// Gestione dell'elemento selezionato Secondo Livello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptMenuCategorieSecondoLivello_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ((HtmlAnchor)e.Item.Controls[1]).HRef = "Dettaglio-Categoria.aspx?Categoria=" + ((Categorie)e.Item.DataItem).ID.ToString();

                if (this.CurrentIDCategoria > 0)
                {
                    if (((Categorie)e.Item.DataItem).ID == this.CurrentIDCategoria)
                    {
                        ///Gestisco il selezionato
                        ((HtmlAnchor)e.Item.Controls[1]).Attributes.Add("class", "red");
                        _isFindCategoria = true;
                        ((Repeater)e.Item.Controls[3]).DataSource = ((Categorie)e.Item.DataItem).CategorieFiglie;
                        ((Repeater)e.Item.Controls[3]).DataBind();
                    }
                    else
                    {
                        if (!_isFindCategoria)
                        {
                            ///Controllo se è stato selezionato un 3° livello
                            bool _result = this.IsCategoriaSelezionata(this.CurrentIDCategoria, ((Categorie)e.Item.DataItem).CategorieFiglie);
                            if (_result)
                            {
                                ((Repeater)e.Item.Controls[3]).DataSource = ((Categorie)e.Item.DataItem).CategorieFiglie;
                                ((Repeater)e.Item.Controls[3]).DataBind();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gestione dell'elemento selezionato Terzo Livello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptMenuCategorieTerzoLivello_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ((HtmlAnchor)e.Item.Controls[1]).HRef = "Dettaglio-Categoria.aspx?Categoria=" + ((Categorie)e.Item.DataItem).ID.ToString();

                if (this.CurrentIDCategoria > 0)
                {
                    if (((Categorie)e.Item.DataItem).ID == this.CurrentIDCategoria)
                    {
                        ///Gestisco il selezionato
                        ((HtmlAnchor)e.Item.Controls[1]).Attributes.Add("class", "red");
                        _isFindCategoria = true;
                        ((Repeater)e.Item.Controls[3]).DataSource = ((Categorie)e.Item.DataItem).CategorieFiglie;
                        ((Repeater)e.Item.Controls[3]).DataBind();
                    }
                    else
                    {
                        if (!_isFindCategoria)
                        {
                            ///Controllo se è stato selezionato un 3° livello
                            bool _result = this.IsCategoriaSelezionata(this.CurrentIDCategoria, ((Categorie)e.Item.DataItem).CategorieFiglie);
                            if (_result)
                            {
                                ((Repeater)e.Item.Controls[3]).DataSource = ((Categorie)e.Item.DataItem).CategorieFiglie;
                                ((Repeater)e.Item.Controls[3]).DataBind();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Gestione dell'elemento selezionato Quarto Livello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptMenuCategorieQuartoLivello_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ((HtmlAnchor)e.Item.Controls[1]).HRef = "Dettaglio-Categoria.aspx?Categoria=" + ((Categorie)e.Item.DataItem).ID.ToString();

                if (this.CurrentIDCategoria > 0)
                {
                    if (((Categorie)e.Item.DataItem).ID == this.CurrentIDCategoria)
                    {
                        ///Gestisco il selezionato
                        ((HtmlAnchor)e.Item.Controls[1]).Attributes.Add("class", "red");
                        _isFindCategoria = true;
                    }
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica il menu delle categorie
        /// </summary>
        private void CaricaMenu()
        {
            if (base.UtenteLoggato != null)
            {
                this.AggiornaCountProdottiPreferiti();
            }
            ///Utilizzo della cache
            if (Cache.Get("MENU") == null)
            {
                ///popolo l'albero
                this.rptMenuCategorie.DataSource = base.PerbaffoController.GetCategorie();
                Cache.Insert("MENU", this.rptMenuCategorie.DataSource, null, DateTime.Now.AddHours(1), TimeSpan.Zero,CacheItemPriority.Normal,null);
                //Cache.Add("MENU", this.rptMenuCategorie.DataSource, null, DateTime.Now.AddHours(1),null,CacheItemPriority.Normal,null);
            }
            else
            {
                this.rptMenuCategorie.DataSource = (List<Categorie>)Cache.Get("MENU");
            }
            this.CurrentCategoriaPadreSelezionata = -1;
            ///Gestione della visibilità del menu
            if (this.CurrentIDCategoria > 0)
            {
                foreach (Categorie item in ((List<Categorie>)Cache.Get("MENU")))
                {
                    if (item.ID == this.CurrentIDCategoria)
                    {
                        this.CurrentCategoriaPadreSelezionata = item.ID;
                        break;
                    }
                    else
                    {
                        if (this.GetCategoriaByID(item.CategorieFiglie, this.CurrentIDCategoria))
                        {
                            this.CurrentCategoriaPadreSelezionata = item.ID;
                            break;
                        }
                    }
                }
            }
            ///Fa il databind
            this.rptMenuCategorie.DataBind();
        }
        /// <summary>
        /// Controlla se all'interno dei figli c'è la categoria selezionata
        /// </summary>
        /// <param name="IDCategoria"></param>
        /// <param name="categ"></param>
        /// <returns></returns>
        private bool IsCategoriaSelezionata(int IDCategoria, List<Categorie> categ)
        {
            bool _result = false;

            if (categ == null)
                return false;
            foreach (Categorie item in categ)
            {
                if (item.ID == IDCategoria)
                {
                    _result = true;
                    break;
                }
                if (item.CategorieFiglie != null && item.CategorieFiglie.Count > 0)
                {
                    _result = this.IsCategoriaSelezionata(IDCategoria, item.CategorieFiglie);
                    if (_result)
                        break;
                }
            }
            return _result;
        }
        /// <summary>
        /// Controlla se all'interno della lista c'è quella selezionata
        /// </summary>
        /// <param name="categorie"></param>
        /// <param name="IDCategoria"></param>
        /// <returns></returns>
        private bool GetCategoriaByID(List<Categorie> categorie, int IDCategoria)
        {
            if (IDCategoria <= 0 || categorie == null)
                return false;
            ///Controllo se ha trovato la categoria
            Categorie _categ = categorie.Where(cat => cat.ID == IDCategoria).SingleOrDefault();
            if(_categ != null)
            {
                return true;
            }
            //Ciclo per il padre
            foreach (Categorie item in categorie)
            {
                if (item.CategorieFiglie != null)
                {
                    bool _result = this.GetCategoriaByID(item.CategorieFiglie, IDCategoria);
                    if (_result)
                        return _result;
                }
            }
            return false;
        }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Aggiorna il count dei prodotti preferiti
        /// </summary>
        public void AggiornaCountProdottiPreferiti()
        {
            if (base.UtenteLoggato != null)
            {
                this.lblCountProdottiPreferiti.Text = base.PerbaffoController.GetCountProdottiPreferitiByIDUtente(base.UtenteLoggato.ID).ToString();
                this.updPnlPreferiti.Update();
            }
        }       
        #endregion

    }
}