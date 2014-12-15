using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Perbaffo.Web.UI.Admin.Classes;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Web.UI.Admin
{
    public partial class LoadImage : BasePage
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
        /// Caricamento pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["IDProdotto"]))
            {
                this.CurrentIDProdotto = int.Parse(Request.QueryString["IDProdotto"]);
                this.LoadFields();
            }
        }
        /// <summary>
        /// Carica file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCarica_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.inputFile.PostedFile == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione bisogna carica un immagine');", true);
                    return;
                }
                //controllo la dimensione del file 
                if (!this.inputFile.PostedFile.ContentType.StartsWith("image"))
                {
                    ///errore
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione bisogna carica un immagine');", true);
                    return;
                }
                else
                {
                    ///effettuo un controllo sulle dimensioni dell'immagine 
                    string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    int FileLen = this.inputFile.PostedFile.ContentLength;
                    byte[] input = new byte[FileLen];
                    System.IO.Stream MyStream = this.inputFile.PostedFile.InputStream;
                    MyStream.Read(input, 0, FileLen);
                    MyStream.Dispose();
                    string _filePathName = this.CurrentIDProdotto.ToString();
                    string _onlyFileName = string.Empty;
                    if (this.rdbPiccola.Checked)
                        _filePathName += "L";
                    else
                        _filePathName += "H";
                    _filePathName += fileExt;
                    _onlyFileName = _filePathName;
                    base.FTPPut(input, "/ImmaginiPerbaffo/" + _onlyFileName);
                    ///Popolo oggetto immagine
                    ProdottiImmagini _prodImmagini = new ProdottiImmagini()
                    {
                        DescrImmagine = this.txtDescrizione.Text.Trim(),
                        IDProdotto = this.CurrentIDProdotto,
                        UrlImmagine = (this.rdbPiccola.Checked) ? _onlyFileName : string.Empty,
                        UrlImmagineHQ = (this.rdbGrande.Checked) ? _onlyFileName : string.Empty
                    };

                    ///Salvo sul db le modifiche
                    base.PerbaffoController.SetProdottiImmagini(_prodImmagini);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "this.parent.fSubmit();", true);
                }

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il caricamento');", true);
                return;
            }
        } 
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Caricamento pagina
        /// </summary>
        private void LoadFields()
        {
            Prodotti _prod = base.PerbaffoController.GetProdottoByID(this.CurrentIDProdotto);
            this.txtDescrizione.Text = _prod.Nome;
        }
        #endregion
    }
}
