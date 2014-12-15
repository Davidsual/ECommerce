using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Configuration;

namespace Perbaffo.Web.UI.Admin
{
    public partial class LoadImageNews : BasePage
    {
        #region PRIVATE PROPERTY
        private int CurrentIDNews
        {
            get
            {
                if (ViewState["CurrentIDNews"] == null)
                    return -1;
                return (int)ViewState["CurrentIDNews"];
            }
            set { ViewState["CurrentIDNews"] = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["IDNotizia"]))
            {
                this.CurrentIDNews = int.Parse(Request.QueryString["IDNotizia"]);
            }
        }

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
                    string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    int FileLen = this.inputFile.PostedFile.ContentLength;
                    byte[] input = new byte[FileLen];
                    System.IO.Stream MyStream = this.inputFile.PostedFile.InputStream;
                    MyStream.Read(input, 0, FileLen);
                    MyStream.Dispose();
                    string _filePathName = this.CurrentIDNews.ToString();
                    string _onlyFileName = string.Empty;
                    _filePathName += fileExt;
                    _onlyFileName = "NEWS" + _filePathName;
                    base.FTPPut(input, "/ImmaginiPerbaffo/News/" + _onlyFileName);

                    /////effettuo un controllo sulle dimensioni dell'immagine 
                    ////System.Drawing.Image _img = System.Drawing.Image.FromStream(this.inputFile.PostedFile.InputStream);
                    //string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                    //string _filePathName = this.CurrentIDNews.ToString();
                    //string _onlyFileName = string.Empty;
                    //_filePathName += fileExt;
                    //_onlyFileName = "NEWS" + _filePathName;
                    //_filePathName = ConfigurationManager.AppSettings["PATHIMAGETOSAVE"].ToString() + "News\\" + _onlyFileName;
                    //this.inputFile.PostedFile.SaveAs(_filePathName);
                    ///Salvo sul db le modifiche
                    base.PerbaffoController.AggiungiImmagineNews(this.CurrentIDNews, _onlyFileName);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "this.parent.fSubmit();", true);
                    //if (_img != null)
                    //    _img.Dispose();
                }

            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il caricamento');", true);
                return;
            }
        }
    }
}
