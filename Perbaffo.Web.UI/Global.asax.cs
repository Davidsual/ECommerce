using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;
using System.IO;
using System.Web.UI;
using System.IO.Compression;

namespace Perbaffo.Web.UI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            // PROVA AD ESEGUIRE LA COMPRESSIONE SOLO SE E' UNA PAGINA E NON AJAX
            ////if (Context.Response.ContentType.ToLower().Contains("text") || Context.Response.ContentType.ToLower().Contains("javascript") && !Context.Request.Url.AbsoluteUri.ToLower().Contains("axd"))
            //if (Context.CurrentHandler is Page && Context.Response.ContentType.ToLower().Contains("htm") && Request["HTTP_X_MICROSOFTAJAX"] == null)
            if (!(Context.CurrentHandler is Page ||
                Context.CurrentHandler.GetType().Name == "SyncSessionlessHandler") ||
                Context.Request["HTTP_X_MICROSOFTAJAX"] != null)
                return;
            else
            {
                // VERIFICA SE IL BROWSER SUPPORTA LA COMPRESSIONE
                if (!String.IsNullOrEmpty(Request.Headers["Accept-Encoding"]))
                {
                    if (Request.Headers["Accept-Encoding"].Contains("deflate") || Request.Headers["Accept-Encoding"] == "*")
                    {
                        // COMPRESSIONE DEFLATE
                        Response.Filter = new DeflateStream(Response.Filter, CompressionMode.Compress);
                        Response.AppendHeader("Content-Encoding", "deflate");
                    }
                    else if (Request.Headers["Accept-Encoding"].Contains("gzip"))
                    {
                        // COMPRESSIONE GZIP
                        Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);
                        Response.AppendHeader("Content-Encoding", "gzip");
                    }
                }
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            #region Blocca il fatto che i file cadano
            System.Reflection.PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            object o = p.GetValue(null, null);
            System.Reflection.FieldInfo f = o.GetType().GetField("_dirMonSubdirs", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.IgnoreCase);
            object monitor = f.GetValue(o);
            System.Reflection.MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            m.Invoke(monitor, new object[] { }); 
            #endregion

            #region Variabili di applicazione globali
            Application["UrlServerImages"] = ConfigurationManager.AppSettings["PATHIMAGE"];
            Application["UrlServerImagesUtenti"] = ConfigurationManager.AppSettings["PATHIMAGEUTENTI"];
            Application["UrlServerImagesCategorie"] = ConfigurationManager.AppSettings["PATHIMAGECATEGORIE"];
            Application["UrlServerImagesNews"] = ConfigurationManager.AppSettings["PATHIMAGENEWS"]; 
            #endregion
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Gestione degli errori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server.GetLastError() is HttpException && (((HttpException)Server.GetLastError()).GetHttpCode() == 403 || ((HttpException)Server.GetLastError()).GetHttpCode() == 404))
            {
                return;
            }


            #region gestione tracciamento errore
            try
            {
                using (ControllerPresentation _controller = new ControllerPresentation())
                {
                    Exception _ex = Server.GetLastError();
                    Errori _errore = new Errori();
                    _errore.CurrentIDUtenteLoggato = (HttpContext.Current.Session != null && Session["UtenteLoggato"] != null) ? ((Utenti)Session["UtenteLoggato"]).ID : -1;
                    _errore.DataErrore = DateTime.Now;
                    _errore.DescrException = (_ex != null) ? _ex.Message : string.Empty;
                    _errore.DescrStackTrace = (_ex != null) ? _ex.StackTrace : string.Empty;
                    if (_ex != null && _ex.InnerException != null)
                    {
                        _errore.DescrInnerException = _ex.InnerException.Message;
                        if (_ex.InnerException.InnerException != null)
                            _errore.DescrInnerException += " -- " + _ex.InnerException.InnerException.Message;
                    }
                    _errore.PathPagina = HttpContext.Current.Request.Url.ToString();
                    _errore.Browser = Request.Browser.Browser + " - " + Request.Browser.Version;
                    _controller.SetErrore(_errore);
                    ///Ripulisco in caso di viewstate errato
                    if (_ex != null && !string.IsNullOrEmpty(_ex.Message) && _ex.Message.ToUpper().Contains("VIEWSTATE"))
                        Server.ClearError();
                }
            }
            catch (Exception ex)
            {
                Server.ClearError();
            } 
            #endregion
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}