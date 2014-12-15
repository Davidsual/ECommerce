using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Perbaffo.Presenter;
using Perbaffo.Presenter.Model;
using System.Text;
using System.Web.Caching;
namespace Perbaffo.Web.UI
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ExportProdottiExcel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.ContentType = "text/plain";
            List<ExportProdottiIPrezziResult> _list = null;
            //if (context.Cache.Get("") == null)
            //{
            using (ControllerPresentation _ctrl = new ControllerPresentation())
            {
                _list = _ctrl.ExportProdottiExcel();
            }

            StringBuilder _str = new StringBuilder();
            _list.ForEach(item =>
            {
                _str.Append(item.Nome + "|");
                _str.Append(item.marca.Split('|')[0] + "|");
                _str.Append(item.marca.Split('|')[1] + "|");
                _str.Append(item.marca.Split('|')[2] + "|");
                _str.Append(item.Descr.Replace(Environment.NewLine, " ") + "|");
                _str.Append(item.Totale.ToString().Replace(',', '.') + "|");
                _str.Append(item.url + "|");
                _str.Append(item.Categoria + "|");
                _str.Append(item.urlImage + "\n");
                
                context.Response.Write(_str.ToString());
                _str.Remove(0, _str.Length);
            });
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
