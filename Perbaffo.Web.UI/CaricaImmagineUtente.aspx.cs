using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;
using System.Configuration;

namespace Perbaffo.Web.UI
{
    public partial class CaricaImmagineUtente : BasePage
    {
        #region EVENTS
        /// <summary>
        /// Caricamento Pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion
        /// <summary>
        /// Carica immagine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnContinua_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtDescrizione.Text.Trim()) || string.IsNullOrEmpty(this.inputFile.Value.Trim()))
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
                ///effettuo un controllo sulle dimensioni dell'immagine 
                //System.Drawing.Image _img = System.Drawing.Image.FromStream(this.inputFile.PostedFile.InputStream);
                string fileExt = System.IO.Path.GetExtension(this.inputFile.PostedFile.FileName);
                int FileLen = this.inputFile.PostedFile.ContentLength;
                byte[] input = new byte[FileLen];
                System.IO.Stream MyStream = this.inputFile.PostedFile.InputStream;
                MyStream.Read(input, 0, FileLen);
                MyStream.Dispose();
                string _filePathName = base.UtenteLoggato.ID.ToString();
                string _onlyFileName = string.Empty;
                _filePathName += fileExt;
                _onlyFileName = "UTENTE"+_filePathName;
                base.FTPPut(input, "/ImmaginiPerbaffo/Utenti/" + _onlyFileName);
                ///Popolo oggetto immagine
                base.UtenteLoggato.ImgFriend = _onlyFileName;
                base.UtenteLoggato.NomeFriend = base.Capitalize(this.txtDescrizione.Text.Trim());
                ///Salvo sul db le modifiche
                base.AddUtenteRegistrazione(base.PerbaffoController.UpdateImmagineUtente(UtenteLoggato));
                this.txtDescrizione.Text = null;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "test", "this.parent.fSubmit();", true);
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Errore durante il caricamento');", true);
                return;
            }
        }

    }
}
