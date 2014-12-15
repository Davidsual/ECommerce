using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class Conferma_Pagamento : BasePage, IPerbaffoSite
    {
        #region PUBLIC PROPERTY
        public string TitoloPagina { get; set; }
        public string KeywordsPagina { get; set; }
        public string DescrizionePagina { get; set; }
        public string UtenteCorrente { get; set; }
        public string UrlImmagine { get { return base.UrlServerImages; } }
        #endregion

        #region PRIVATE MEMBERS
        String sKey, sValue, fname, lname, mc_gross, itemName, Pmtcurrency;
        String item_name1;
        String authToken, txToken, query;
        String strResponse; 
        #endregion


        private void Page_Load(object sender, System.EventArgs e)
        {
            this.GestioneMetaTag();
            // Put user code to initialize the page here

            /*
                             * set this to the value of the PDT token for your account
                             * see http://paypaltech.com/PDTGen/PDTtokenhelp.htm for help with this
                            */
            authToken = "uRRGvEXHv-dP1ckC5Rf7_IwE78FPBhTtspaWksGnTJces-HocnS1uSP-Tb4";

            //read in txn token from querystring
            txToken = Request.QueryString.Get("tx");


            //:::sanity check
            //Response.Write(txToken);

            query = "cmd=_notify-synch&tx=" + txToken +
            "&at=" + authToken;


            // Create the request back
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;

            // Write the request back IPN strings
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(query);
            stOut.Close();

            // Do the request to PayPal and get the response
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();
            stIn.Close();

            //:::sanity check:::
            //Response.Write("PDT returned: " + strResponse + "<p></p>");


            // If response was SUCCESS, parse response string and
            //output details
            if (strResponse.ToUpper().Contains("SUCCESS"))
            {
                //split response into string array using whitespace
                //as delimiter
                String[] StringArray = strResponse.Split();


                // NOTE:
                /*
                * loop is set to start at 1 rather than 0 because first
                string in array will be single word SUCCESS or FAIL
                and there is no splitting of this...so we will skip the
                first string and go to the next.
                */

                // use split to split array we already have
                // using "=" as delimiter
                int i;
                for (i = 1; i < StringArray.Length - 1; i++)
                {
                    String[] StringArray1 = StringArray[i].Split('=');

                    sKey = StringArray1[0];
                    sValue = StringArray1[1];


                    // set string vars to hold variable names using a switch
                    switch (sKey)
                    {
                        case "first_name":
                            fname = sValue;
                            break;

                        case "last_name":
                            lname = sValue;
                            break;

                        case "mc_gross":
                            mc_gross = sValue;
                            break;

                        case "item_name":
                            itemName = sValue;
                            break;

                        //for shopping cart payments the
                        //item_name vars are numbered to reflect
                        //a multi-item purchase.
                        case "item_name1":
                            item_name1 = sValue;
                            break;

                        case "mc_currency":
                            Pmtcurrency = sValue;
                            break;
                    }
                }

                this.divSuccess.Visible = true;
                this.divFail.Visible = false;
                this.lblResult.InnerText = "Positivo";

                if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname))
                    this.lblNome.InnerText = "Gentile " + fname + "  " + lname;
                else
                    this.lblNome.Visible = false;

                if (!string.IsNullOrEmpty(itemName))
                    this.lblOrdine.InnerText = "Il pagamento per l'ordine n° " + itemName + " è andato a buon fine";
                else
                    this.lblOrdine.Visible = false;

                if (!string.IsNullOrEmpty(mc_gross))
                    this.lblTotale.InnerText = "Totale EUR " + mc_gross;
                else
                    this.lblTotale.Visible = false;

            }
            else if (strResponse.Substring(0, 4) == "FAIL")
            {
                this.divSuccess.Visible = false;
                this.divFail.Visible = true;
                this.lblResult.InnerText = "Negativo";
            }
            else
            {
                this.divSuccess.Visible = false;
                this.divFail.Visible = true;
                this.lblResult.InnerText = "Negativo";
            }
        }

        #region PRIVATE METHODS
        /// <summary>
        /// Gestione dei metatag
        /// </summary>
        private void GestioneMetaTag()
        {
            this.TitoloPagina = "Acquisto, acquisto prodotti";
            this.DescrizionePagina = "Perbaffo acquisto prodotti,pagamento tramite bonifico,paypal,postepay,contrassegno";
            this.KeywordsPagina = "Perbaffo,acquisto,omaggio,prodotti,pagamento,spedizione,sconto,bonifico,paypal,contrassegno,postepay,riepilogo,conferma,ordine";
        }
        #endregion
    }
}
