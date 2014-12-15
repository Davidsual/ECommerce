using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.FTPClient;
using System.Configuration;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //            $.blockUI('<h1><img src="busy.gif" /> Just a moment...</h1>'); 
            

            //Perbaffo.Presenter.Controller _ctrl = new Perbaffo.Presenter.Controller();
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "$.blockUI(); ", true);
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string _value = "function(){\n";
            _value += "jQ('#modal_content').remove();";
            _value += "jQ('#modal_overlay').remove();";
			_value +="if(params && params['hide']){ ";
			_value += "	eval(params['hide']);";
			_value += "		}";
            _value += "     }";

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", _value, true);
        }

        protected void btnContinua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtDescrizione.Text.Trim()) || string.IsNullOrEmpty(this.inputFile.Value.Trim()))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "alert('Attenzione popolare tutti i campi!');", true);
                return;
            }
            if (this.inputFile.PostedFile == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione bisogna caricare un immagine');", true);
                return;
            }
            //controllo la dimensione del file 
            if (!this.inputFile.PostedFile.ContentType.StartsWith("image"))
            {
                ///errore
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Attenzione bisogna caricare un immagine');", true);
                return;
            }
            if ((this.inputFile.PostedFile.ContentLength / 1024) > 500)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('La foto può essere grande al massimo 500kb!');", true);
                return;
            }
            try
            {

                int FileLen = this.inputFile.PostedFile.ContentLength;
                byte[] input = new byte[FileLen];
                System.IO.Stream MyStream = this.inputFile.PostedFile.InputStream;
                MyStream.Read(input, 0, FileLen);
                MyStream.Dispose();

                string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                /*
                System.Drawing.Image _img = System.Drawing.Image.FromStream(this.inputFile.PostedFile.InputStream);
                */
                string _urlFTP = ConfigurationManager.AppSettings["FTPURL"];
                string _usernameFTP = ConfigurationManager.AppSettings["FTPUSERNAME"];
                string _passwordFTP = ConfigurationManager.AppSettings["FTPPASSWORD"];
                using (FTPClient.FTPClient _ftpClient = new FTPClient.FTPClient(_urlFTP, 21))
                {
                    // fa login
                    _ftpClient.Login(_usernameFTP, _passwordFTP);
                    _ftpClient.TransferType = FTPTransferType.BINARY;
                    _ftpClient.Put(input, "ImmaginiPerbaffo/FTP/rocco.jpg");
                    //_ftpClient.Delete("Utenti/davide.jpg");
                    // esce
                    _ftpClient.Quit();
                    //_boolToReturn = true;
                }
                //string _filePathName = base.UtenteLoggato.ID.ToString();
                //string _onlyFileName = string.Empty;
                //_filePathName += fileExt;
                //_onlyFileName = "UTENTE" + _filePathName;
                //_filePathName = ConfigurationManager.AppSettings["PATHIMAGETOSAVE"].ToString() + "Utenti\\" + _onlyFileName;
                //this.inputFile.PostedFile.SaveAs(_filePathName);
                /////Popolo oggetto immagine
                //base.UtenteLoggato.ImgFriend = _onlyFileName;
                //base.UtenteLoggato.NomeFriend = this.txtDescrizione.Text.Trim();
                /////Salvo sul db le modifiche
                //base.AddUtenteRegistrazione(base.PerbaffoController.UpdateImmagineUtente(UtenteLoggato));
                //this.txtDescrizione.Text = null;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "this.parent.fSubmit();", true);
                //if (_img != null)
                //    _img.Dispose();
                this.inputFile.PostedFile.InputStream.Dispose();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il caricamento');", true);
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "al", "$.blockUI('<h1><input type=button value=bottone onclick=$.unblockUI(); /> Just a moment...</h1>');", true);
        }
    }
}
