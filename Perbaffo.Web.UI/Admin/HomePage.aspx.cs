using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;

namespace Perbaffo.Web.UI.Admin
{
    public partial class HomePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetMaxAge(TimeSpan.Zero);
            if (!Page.IsPostBack)
            {
                this.LoadFields();
                
            }
        }

        private void LoadFields()
        {
                int _totaleProdotti = base.PerbaffoController.GetCountProdotti(true);
                int _prodOfferta = base.PerbaffoController.GetCountProdottiOfferte(true);
                int _categorie = base.PerbaffoController.GetCountCategorie();
                int _categorieVuote = base.PerbaffoController.GetCountCategorieVuote();
                int _totUtenti = base.PerbaffoController.GetCountUtenti(true);
                int _totProdRiordino = base.PerbaffoController.GetCountProdottiSottoScorta(true);
                int _totProdOmaggio = base.PerbaffoController.GetCountProdottiOmaggio(true);
                int _totOrdiniAperti = base.PerbaffoController.GetCountOrdiniByStato(1);
                int _totOrdiniConfermati = base.PerbaffoController.GetCountOrdiniConfermati();
                int _totOrdiniArchiviati = base.PerbaffoController.GetCountOrdiniByStato(5);
                int _totOrdiniSpediti = base.PerbaffoController.GetCountOrdiniByStato(4);
                int _totProdottiSenzaCateg = base.PerbaffoController.GetCountProdottiSenzaCategoria();
                int _totProdottiSenzaImmagini = base.PerbaffoController.GetCountProdottiSenzaImmagini();
                int _totProdnoAttivi = base.PerbaffoController.GetCountProdotti(false);
                int _totUtenteFoto = base.PerbaffoController.GetCountUtentiConFoto();
                int _totOrdiniAffiliazione = base.PerbaffoController.GetCountOrdiniAffiliazione();

                this.lblOfferta.Text = _prodOfferta.ToString() + " prodotti in offerta";
                this.lblTotaleCategorie.Text = "In Perbaffo sono recensite " + _categorie.ToString() + " categorie";
                this.lblCategorieVuote.Text = _categorieVuote.ToString() + " categorie vuote";
                this.lblTotProdotti.Text = "Sono presenti " + _totaleProdotti + " prodotti nel tuo catalogo";
                this.lblTotaleUtenti.Text = "Sono presenti " + _totUtenti + " utenti registrati";
                this.lblProdottiScorta.Text = "Ci sono " + _totProdRiordino + " prodotti sotto scorta";
                this.lblTotOmaggi.Text = "Ci sono " + _totProdOmaggio + " prodotti contrassegnati come omaggio";
                this.lblTotOrdiniAperti.InnerText = _totOrdiniAperti.ToString();

                this.lblTotProdNonAttivi.Text = "Ci sono " + _totProdnoAttivi + " prodotti non attivi";
                this.lblOrdiniConfermati.InnerText = _totOrdiniConfermati.ToString();
                this.lblTotaleOrdiniArchiviati.InnerText = _totOrdiniArchiviati.ToString();
                this.lblSpediti.InnerText = _totOrdiniSpediti.ToString();
                this.lblProdSenzaCategoria.Text = "Ci sono " + _totProdottiSenzaCateg.ToString() + " prodotti senza categoria";
                this.lblProdSenzaImmagine.Text = "Ci sono " + _totProdottiSenzaImmagini.ToString() + " prodotti senza immagini";
                this.lblTotUtentiFoto.InnerText = "(" + _totUtenteFoto + ")";
                this.lblOrdiniAffiliazione.Text = "Ordini Affiliazione (" + _totOrdiniAffiliazione + ")";
        }
    }
}
