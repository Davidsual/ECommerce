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
    public partial class GestioneCategorie : BasePage
    {
        #region PRIVATE MEMBERS
        private const string TREE_CATEGORIE_ID = "TREECATEGORIE";
        #endregion

        #region PRIVATE PROPERTY
        /// <summary>
        /// Categoria selezionata sull'albero
        /// </summary>
        private string CurrentCategoria
        {
            get
            {
                if (ViewState["CurrentCategoria"] == null)
                    return string.Empty;
                else
                    return ViewState["CurrentCategoria"] as string;
            }
            set
            {
                ViewState["CurrentCategoria"] = value;
            }
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
                this.LoadTree();
            }
            else
            {
                if (HttpContext.Current.Request.Form["__EVENTTARGET"].ToUpper().Contains(TREE_CATEGORIE_ID))
                {
                    ///Ho selezionato un nodo
                    this.LoadFieldSelectedNode(this.treeCategorie.SelectedNode);
                }
            }
        }
        /// <summary>
        /// Carica i dettagli di una categoria
        /// </summary>
        /// <param name="treeNode"></param>
        private void LoadFieldSelectedNode(TreeNode treeNode)
        {
            if (treeNode == null || string.IsNullOrEmpty(treeNode.Value))
                return;
            if (treeNode.Value == "0")
            {
                this.LoadTree();
                return;
            }

            this.pnlButton.Visible = true;
            this.pnlEditCategoria.Visible = false;
            this.CurrentCategoria = treeNode.Value;
            this.updPnlCateg.Update();
        }
        /// <summary>
        /// Ritorno al dettaglio prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void returnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        /// <summary>
        /// Salva o aggiorna la categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentCategoria) 
                || string.IsNullOrEmpty(this.txtDescrCateg.Text.Trim()) 
                || string.IsNullOrEmpty(this.txtDescrBreveCateg.Text.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"alert","alert('Atenzione inserire tutti i dati della categoria da modificare/aggiungere');",true);
                return;
            }
            if (this.btnSalva.CommandArgument.Contains("INS"))
            {
                ///INSERIMENTO
                Categorie _categ = new Categorie()
                {
                    DescrizioneBreve = this.txtDescrBreveCateg.Text.Trim(),
                    DescrizioneCategoria = this.txtDescrCateg.Text.Trim(),
                    IDCategoriaPadre = Convert.ToInt32(this.CurrentCategoria),
                    DescrizioneEstesa = this.txtDescrCategoriaEsteso.Text.Trim(),
                    Keywords = this.txtKeyWords.Text.Trim()
                };
                base.PerbaffoController.InsertCategoria(_categ);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Inserimento effettuato con successo!');", true);
            }
            else
            {
                ///AGGIORNAMENTO
                Categorie _categ = new Categorie()
                {
                    DescrizioneBreve = this.txtDescrBreveCateg.Text.Trim(),
                    DescrizioneCategoria = this.txtDescrCateg.Text.Trim(),
                    DescrizioneEstesa = this.txtDescrCategoriaEsteso.Text.Trim(),
                    Keywords = this.txtKeyWords.Text.Trim(),
                    ID = Convert.ToInt32(this.CurrentCategoria)
                };
                base.PerbaffoController.UpdateCategoria(_categ);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Modifica effettuata con successo!');", true);
            }
            ///Azzero tutto
            this.CleanFields();
        }
        /// <summary>
        /// Annulla le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            ///Azzero tutto
            this.CleanFields();
        }
        /// <summary>
        /// modifica una categoria esistente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentCategoria))
                return;
            if (this.CurrentCategoria == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Impossibile modificare questa categoria');", true);
                return;
            }
            this.pnlEditCategoria.Visible = true;
            this.pnlButton.Visible = false;
            this.Load.Visible = true;
            this.Load.Attributes.Add("src", "LoadImageCategoria.aspx?IDCategoria=" + this.CurrentCategoria);
            Categorie _categ = base.PerbaffoController.GetCategoriaByIDCategoria(Convert.ToInt32(this.CurrentCategoria));
            if (_categ != null)
            {
                this.txtDescrCateg.Text = _categ.DescrizioneCategoria;
                this.txtDescrBreveCateg.Text = _categ.DescrizioneBreve;
                this.txtDescrCategoriaEsteso.Text = _categ.DescrizioneEstesa;
                this.txtKeyWords.Text = _categ.Keywords;
                this.btnSalva.CommandArgument = "UPD";
            }
        }
        /// <summary>
        /// Inserisce una nuova categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentCategoria))
                return;

            this.pnlEditCategoria.Visible = true;
            this.pnlButton.Visible = false;
            this.Load.Visible = false;
            this.btnSalva.CommandArgument = "INS";
            
        }
        /// <summary>
        /// Cancella la categoria selezionata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancella_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentCategoria))
                return;

            if (this.CurrentCategoria == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Impossibile cancellare questa categoria');", true);
                return;
            }

            ///Avverto se ci sono prodotti presenti o se ci sono delle sottocategorie
            this.pnlDeleteCategorie.Visible = true;
            if (this.treeCategorie.SelectedNode.ChildNodes.Count > 0)
            {
                this.lblDetailDelete.Text = "Attenzione la categoria che si vuole eliminare possiede delle sotto categorie,cancellandola, si cancelleranno tutte le sottocategorie <br/>";
            }
            this.lblDetailDelete.Text += "La categoria, o le sue eventuali sotto categorie possono avere prodotti allegati, cancellando la categoria verranno cancellati anche tutti i legami dei prodotti alla categoria stessa e alle sue sotto categorie";
        }
        /// <summary>
        /// Cancella la categoria e le eventuali sotto categorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfermaDelete_Click(object sender, EventArgs e)
        {
            base.PerbaffoController.DeleteCategoria(Convert.ToInt32(this.CurrentCategoria));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Cancellazione categoria effettuata con successo!');", true);
            ///Azzero tutto
            this.CleanFields();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Ripulisco la UI
        /// </summary>
        private void CleanFields()
        {
            this.txtDescrCateg.Text = string.Empty;
            this.txtDescrBreveCateg.Text = string.Empty;
            this.lblDetailDelete.Text = string.Empty;
            this.txtDescrCategoriaEsteso.Text = string.Empty;
            this.txtKeyWords.Text = string.Empty;
            this.updPnlCateg.Update();
            this.CurrentCategoria = string.Empty;
            
            this.pnlButton.Visible = false;
            this.pnlEditCategoria.Visible = false;
            this.pnlDeleteCategorie.Visible = false;

            this.btnSalva.CommandArgument = string.Empty;
            //this.LoadTree();
        }
        /// <summary>
        /// Caricamento del tree view
        /// </summary>
        private void LoadTree()
        {
            List<Categorie> _cat = base.PerbaffoController.GetCategorie();
            this.treeCategorie.Nodes.Clear();
            this.treeCategorie.Nodes.Add(new TreeNode()
            {
                Text = "Categorie Perbaffo",
                ToolTip = "Categorie Perbaffo",
                Value = "0",
                Expanded = true
            });

            _cat.ForEach(categ =>
                {
                    ///Aggiungiungo i nodi
                    TreeNode _nodeToAdd = new TreeNode()
                    {
                        Text = categ.DescrizioneBreve,
                        ToolTip = categ.DescrizioneCategoria,
                        Value = categ.ID.ToString(),
                        Expanded = true
                    };
                    this.FillChildNode(categ, _nodeToAdd);
                    this.treeCategorie.Nodes[0].ChildNodes.Add(_nodeToAdd);
                });
            //this.treeCategorie.CollapseAll();
        }
        /// <summary>
        /// Aggancio gli eventuali figli
        /// </summary>
        /// <param name="categorie"></param>
        /// <param name="nodeToAdd"></param>
        private void FillChildNode(Categorie categorie, TreeNode nodeToAdd)
        {
            if (categorie.CategorieFiglie == null || categorie.CategorieFiglie.Count <= 0)
                return;
            TreeNode _nodeToAdd = null;
            categorie.CategorieFiglie.ForEach(categ =>
                {
                    _nodeToAdd = new TreeNode()
                    {
                        Text = categ.DescrizioneBreve,
                        ToolTip = categ.DescrizioneCategoria,
                        Value = categ.ID.ToString(),
                        Expanded = false
                    };
                    nodeToAdd.ChildNodes.Add(_nodeToAdd);
                    this.FillChildNode(categ, _nodeToAdd);
                });
        }
        #endregion

    }
}
