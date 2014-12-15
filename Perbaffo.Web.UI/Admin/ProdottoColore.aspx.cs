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
    public partial class ProdottoColore : BasePage
    {
        #region PRIVATE PROPERTY
        private List<Colori> CurrentColoriProdotto
        {
            get
            {
                if (ViewState["CurrentColori"] == null)
                    return null;
                return (List<Colori>)ViewState["CurrentColori"];
            }
            set { ViewState["CurrentColori"] = value; }
        }
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
        public string CurrentLetteraSelezionata
        {
            get
            {
                if (ViewState["CurrentLetteraSelezionata"] == null)
                    return "A";
                return ViewState["CurrentLetteraSelezionata"] as string;
            }
            set { ViewState["CurrentLetteraSelezionata"] = value; }
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
                this.LoadFields();
            }
        }
        /// <summary>
        /// Aggiunge un colore ai colori del prodotto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow item in this.grdListaColori.Rows)
            {
                if (((CheckBox)item.Cells[2].Controls[1]).Checked)
                {
                    string idColore = ((Label)item.Cells[0].Controls[1]).Text;
                    int _count = this.CurrentColoriProdotto.Where(col => col.ID == Convert.ToInt32(idColore)).Count();
                    if (_count == 0)
                    {
                        this.CurrentColoriProdotto.Add(new Colori() { ID = Convert.ToInt32(idColore), Descrizione = item.Cells[1].Text });
                    }
                    ((CheckBox)item.Cells[2].Controls[1]).Checked = false;
                }
            }
            this.LoadColoriProdotto();
        }
        /// <summary>
        /// Cancellazione dell'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaColoriProdotto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.CurrentColoriProdotto.Remove(this.CurrentColoriProdotto.Where(col => col.ID == Convert.ToInt32(e.CommandArgument)).SingleOrDefault());
            this.LoadColoriProdotto();
            return;
        }
        protected void grdListaColoriProdotto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            return;
        }
        /// <summary>
        /// Salva modifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (this.grdListaColori.Rows.Count == 0)
            {
                return;
            }

            try
            {
                List<ProdottiColori> _lstColori = new List<ProdottiColori>(this.grdListaColoriProdotto.Rows.Count);
                ProdottiColori _col;

                foreach (GridViewRow item in this.grdListaColoriProdotto.Rows)
                {
                    _col = new ProdottiColori()
                    {
                        IDColore = Convert.ToInt32(((Label)item.Cells[0].Controls[1]).Text),
                        IDProdotto = this.CurrentIDProdotto
                    };
                    _lstColori.Add(_col);
                }
                base.PerbaffoController.SetProdottiColori(_lstColori, this.CurrentIDProdotto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ///Si ritorna sul dettaglio
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto, true);
        }
        /// <summary>
        /// Annulla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAnnulla_Click(object sender, EventArgs e)
        {
            Response.Redirect("DettaglioProdotto.aspx?IDProdotto=" + this.CurrentIDProdotto, true);
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
        /// Ricerca per lettera e categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            if (this.CurrentLetteraSelezionata.ToLower() == ((LinkButton)sender).CommandName.ToLower())
                return;
            this.CurrentLetteraSelezionata = ((LinkButton)sender).CommandName;
            this.grdListaColori.DataSource = base.PerbaffoController.GetVariazioniByLettera(this.CurrentLetteraSelezionata);
            if (this.grdListaColori.DataSource == null || ((IList)this.grdListaColori.DataSource).Count <= 0)
                this.pnlRighe.Visible = true;
            else
                this.pnlRighe.Visible = false;
            this.grdListaColori.DataBind();
            this.updPnlColors.Update();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "try{ $(document).ready(function(){ screenshotPreview(); }); } catch(err){}", true);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento campi
        /// </summary>
        private void LoadFields()
        {
            try
            {
                this.CurrentColoriProdotto = base.PerbaffoController.GetColoriByIdProdotto(this.CurrentIDProdotto);
                this.grdListaColori.DataSource = base.PerbaffoController.GetVariazioniByLettera("A");
                this.grdListaColori.DataBind();
                this.LoadColoriProdotto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Carica la combo
        /// </summary>
        private void LoadColoriProdotto()
        {
            this.grdListaColoriProdotto.DataSource = this.CurrentColoriProdotto.OrderBy(col => col.Descrizione);
            this.grdListaColoriProdotto.DataBind();
        }

        #endregion




    }
}
