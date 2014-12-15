using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using Perbaffo.Presenter;

namespace Perbaffo.Web.UI
{
    public partial class WebForm2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //base.PerbaffoController.InvioMailSegnalaProdotto(972, "davide", "trottadavide@hotmail.com", "antonio", "trottolino9@hotmail.com", "molto bene", "http://www.cabuna.it/ImmaginiPerbaffo/");
            //base.PerbaffoController.InvioMailNewsletter("trottadavide@hotmail.com", true, false, false, false, false);
            //base.PerbaffoController.InvioMailNuovoUtente(base.PerbaffoController.CheckLogin("trottadavide@hotmail.com", "trotta"));
            //base.PerbaffoController.InvioMailRecuperoPassword("trottadavide@hotmail.com");

            //base.PerbaffoController.InvioMailOrdineEffettuato(new Controller().GetOrdineByIDOrdine(102), null, base.PerbaffoController.CheckLogin("trottadavide@hotmail.com", "trotta"));
            Controller _ctrl = new Controller();
            _ctrl.SetFaceBook("Novità su Perbaffo", "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=2398",
                "http://www.perbaffo.it/ImmaginiPerbaffo/2086H.jpg", @"Snack premio catena 8 salsicce al manzo
contengono almeno il 90% di carne
Arricchite con vitamine essenziali
essiccate all’aria
8 cm /minimo garantito 8 gr
","www.perbaffo.it");
            //_ctrl.SetTwitter("Gioco di attivazione mentale Mini Solitario", "http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Prodotto=2398");
        }
    }
}
