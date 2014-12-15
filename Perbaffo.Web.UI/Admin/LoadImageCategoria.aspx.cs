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
    public partial class LoadImageCategoria : BasePage
    {
        #region PRIVATE PROPERTY
        private int CurrentIDCategoria
        {
            get
            {
                if (ViewState["CurrentIDCategoria"] == null)
                    return -1;
                return (int)ViewState["CurrentIDCategoria"];
            }
            set { ViewState["CurrentIDCategoria"] = value; }
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
            if (!string.IsNullOrEmpty(Request.QueryString["IDCategoria"]))
            {
                this.CurrentIDCategoria = int.Parse(Request.QueryString["IDCategoria"]);
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
                    //System.Drawing.Image _img = System.Drawing.Image.FromStream(this.inputFile.PostedFile.InputStream);
                    //string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    //string _filePathName = this.CurrentIDCategoria.ToString();
                    //string _onlyFileName = string.Empty;
                    //_filePathName += fileExt;
                    //_onlyFileName = "CATEG" + _filePathName;
                    //_filePathName = ConfigurationManager.AppSettings["PATHIMAGETOSAVE"].ToString() + "Categorie\\" + _onlyFileName;
                    //this.inputFile.PostedFile.SaveAs(_filePathName);
                    string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    int FileLen = this.inputFile.PostedFile.ContentLength;
                    byte[] input = new byte[FileLen];
                    System.IO.Stream MyStream = this.inputFile.PostedFile.InputStream;
                    MyStream.Read(input, 0, FileLen);
                    MyStream.Dispose();
                    string _filePathName = this.CurrentIDCategoria.ToString();
                    string _onlyFileName = string.Empty;
                    _filePathName += fileExt;
                    _onlyFileName = "CATEG" + _filePathName;
                    base.FTPPut(input, "/ImmaginiPerbaffo/Categorie/" + _onlyFileName);

                    ///Popolo oggetto immagine
                    Categorie _categ = new Categorie()
                    {
                        ID = this.CurrentIDCategoria,
                        UrlImmagine = _onlyFileName
                    };

                    ///Salvo sul db le modifiche
                    base.PerbaffoController.SetCategoriaImmagine(_categ);
                    this.imgCategoria.Src = ConfigurationManager.AppSettings["PATHIMAGECATEGORIE"] + "/" + _categ.UrlImmagine;
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
            Categorie _categ = base.PerbaffoController.GetCategoriaByIDCategoria(this.CurrentIDCategoria);
            this.imgCategoria.Src = ConfigurationManager.AppSettings["PATHIMAGECATEGORIE"] + "/" + _categ.UrlImmagine;
        }
        #endregion
    }
}
