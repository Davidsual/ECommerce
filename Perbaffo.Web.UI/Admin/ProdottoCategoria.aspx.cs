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
    public partial class ProdottoCategoria : BasePage
    {
        #region PRIVATE PROPERTY
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
                    ((PerbaffoMaster)this.Master).LoadPage(PerbaffoMaster.SectionMaster.HomePage);
                    return;
                }
                else
                    this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);

                this.LoadTree();
                this.LoadProdottiCategorie(this.CurrentIDProdotto);
            }
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
        /// Aggiunge una categoria al prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAggiungiCategoria_Click(object sender, EventArgs e)
        {
            if (this.treeCategorie.SelectedNode == null)
                return;
            if (this.lstProdottoCategorie.Items.Contains(new ListItem()
            {
                Text = this.treeCategorie.SelectedNode.Text,
                Value = this.treeCategorie.SelectedNode.Value
            }))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Il prodotto è già associato a questa categoria!');", true);
                return;
            }
            else
            {
                this.lstProdottoCategorie.Items.Add(new ListItem()
                {
                    Text = this.treeCategorie.SelectedNode.Text,
                    Value = this.treeCategorie.SelectedNode.Value
                });
            }
            this.treeCategorie.SelectedNode.Selected = false;
        }
        /// <summary>
        /// Elimina il prodotto da una categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEliminaCategoria_Click(object sender, EventArgs e)
        {
            if (this.lstProdottoCategorie.SelectedItem == null)
                return;

            this.lstProdottoCategorie.Items.Remove(this.lstProdottoCategorie.SelectedItem);
        }
        /// <summary>
        /// Salva le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            try
            {
                List<Categorie> _lstCateg = new List<Categorie>(this.lstProdottoCategorie.Items.Count);
                for (int i = 0; i < this.lstProdottoCategorie.Items.Count; i++)
                {
                    _lstCateg.Add(new Categorie() { ID = Convert.ToInt32(this.lstProdottoCategorie.Items[i].Value) });
                }
                base.PerbaffoController.SetProdottiCategoria(_lstCateg, this.CurrentIDProdotto);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ///Si ritorna sul dettaglio
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto, true);
        }
        /// <summary>
        /// Annulla le modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            this.LoadProdottiCategorie(this.CurrentIDProdotto);
            this.updPnlTree.Update();
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Carica le categorie associate al prodotto
        /// </summary>
        /// <param name="IDProdotto"></param>
        private void LoadProdottiCategorie(int IDProdotto)
        {
            this.lstProdottoCategorie.Items.Clear();
            List<Categorie> _categ = base.PerbaffoController.GetProdottiCategoriaByIDProdotto(IDProdotto);
            _categ.ForEach(c =>
                {
                    this.lstProdottoCategorie.Items.Add(new ListItem()
                    {
                         Text = c.DescrizioneBreve,
                         Value = c.ID.ToString()
                    });
                });
        }
        /// <summary>
        /// Caricamento del tree view
        /// </summary>
        private void LoadTree()
        {
            List<Categorie> _cat = base.PerbaffoController.GetCategorie();

            this.treeCategorie.Nodes.Clear();
            this.treeCategorie.CollapseAll();
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
