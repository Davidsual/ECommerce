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
    public partial class ProdottoVariazione : BasePage
    {
        #region PRIVATE PROPERTY
        private List<Variazioni> CurrentVariazioniProdotto
        {
            get
            {
                if (ViewState["CurrentVariazioni"] == null)
                    return null;
                return (List<Variazioni>)ViewState["CurrentVariazioni"];
            }
            set { ViewState["CurrentVariazioni"] = value; }
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
        /// Aggiunge un colore ai Variazioni del prodotto
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
                    int _count = this.CurrentVariazioniProdotto.Where(col => col.ID == Convert.ToInt32(idColore)).Count();
                    if (_count == 0)
                    {
                        this.CurrentVariazioniProdotto.Add(new Variazioni() { ID = Convert.ToInt32(idColore), Descrizione = item.Cells[1].Text });
                    }
                    ((CheckBox)item.Cells[2].Controls[1]).Checked = false;
                }
            }
            this.LoadVariazioniProdotto();
        }
        /// <summary>
        /// Cancellazione dell'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdListaColoriProdotto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.CurrentVariazioniProdotto.Remove(this.CurrentVariazioniProdotto.Where(col => col.ID == Convert.ToInt32(e.CommandArgument)).SingleOrDefault());
            this.LoadVariazioniProdotto();
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
                List<ProdottiVariazioni> _lstVariazioni = new List<ProdottiVariazioni>(this.grdListaColoriProdotto.Rows.Count);
                ProdottiVariazioni _col;

                foreach (GridViewRow item in this.grdListaColoriProdotto.Rows)
                {
                    _col = new ProdottiVariazioni()
                    {
                        IDVariazioni = Convert.ToInt32(((Label)item.Cells[0].Controls[1]).Text),
                        IDProdotto = this.CurrentIDProdotto
                    };
                    _lstVariazioni.Add(_col);
                }
                base.PerbaffoController.SetProdottiVariazioni(_lstVariazioni, this.CurrentIDProdotto);
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
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento campi
        /// </summary>
        private void LoadFields()
        {
            try
            {
                this.CurrentVariazioniProdotto = base.PerbaffoController.GetVariazioniByIdProdotto(this.CurrentIDProdotto);
                this.grdListaColori.DataSource = base.PerbaffoController.GetVariazioni();
                this.grdListaColori.DataBind();
                this.LoadVariazioniProdotto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Carica la combo
        /// </summary>
        private void LoadVariazioniProdotto()
        {
            this.grdListaColoriProdotto.DataSource = this.CurrentVariazioniProdotto.OrderBy(col => col.Descrizione);
            this.grdListaColoriProdotto.DataBind();
        }

        #endregion




    }
}
