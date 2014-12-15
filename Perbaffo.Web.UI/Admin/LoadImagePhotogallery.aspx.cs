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
    public partial class LoadImagePhotogallery : BasePage
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
                var foto = base.PerbaffoController.GetProdottiFotogallery(this.CurrentIDProdotto);
                if (foto.Count == 4)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione si possono inserire solo 4 immagini');", true);
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
                    //System.Drawing.Image _img = System.Drawing.Image.FromStream(this.inputFile.PostedFile.InputStream);
                    //string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    //string _filePathName = this.CurrentIDProdotto.ToString();
                    //string _onlyFileName = string.Empty;
                    //_filePathName += "G" + DateTime.Now.ToString("yyyyMMddhhmmss");
                    //_filePathName += fileExt;
                    //_onlyFileName = _filePathName;
                    //_filePathName = ConfigurationManager.AppSettings["PATHIMAGETOSAVE"].ToString() + _filePathName;
                    //this.inputFile.PostedFile.SaveAs(_filePathName);

                    string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    int FileLen = this.inputFile.PostedFile.ContentLength;
                    byte[] input = new byte[FileLen];
                    System.IO.Stream MyStream = this.inputFile.PostedFile.InputStream;
                    MyStream.Read(input, 0, FileLen);
                    MyStream.Dispose();
                    string _filePathName = this.CurrentIDProdotto.ToString();
                    string _onlyFileName = string.Empty;
                    _filePathName += "G" + DateTime.Now.ToString("yyyyMMddhhmmss");
                    _filePathName += fileExt;
                    _onlyFileName = _filePathName;
                    base.FTPPut(input, "/ImmaginiPerbaffo/" + _onlyFileName);
                    ///Popolo oggetto immagine
                    ProdottiFotogallery _prodImmagini = new ProdottiFotogallery()
                    {
                        DescrImmagine = this.txtDescrizione.Text.Trim(),
                        IDProdotto = this.CurrentIDProdotto,
                        UrlImmagine = _onlyFileName
                    };

                    ///Salvo sul db le modifiche
                    base.PerbaffoController.SetProdottiFotogallery(_prodImmagini, this.CurrentIDProdotto);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "this.parent.fSubmit();", true);
                    //if (_img != null)
                    //    _img.Dispose();
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
