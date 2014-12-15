using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;

namespace Perbaffo.Web.UI.Admin
{
    public partial class EsportaNewsletter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.QueryString["TIPO"]))
                Response.End();

            string _request = Request.QueryString["TIPO"];
            List<string> _email = null;
            switch (_request)
            {
                case "CANI":
                    _email = base.PerbaffoController.GetUtentiNewsLetterCani();
                    break;
                case "GATTI":
                    _email = base.PerbaffoController.GetUtentiNewsLetterGatti();
                    break;
                case "RODITORI":
                    _email = base.PerbaffoController.GetUtentiNewsLetterRoditori();
                    break;
                case "VOLATILI":
                    _email = base.PerbaffoController.GetUtentiNewsLetterVolatili();
                    break;
                case "PESCI":
                    _email = base.PerbaffoController.GetUtentiNewsLetterPesci();
                    break;
                default:
                    break;
            }

             

            Response.Clear();
            Response.Charset = "";
            Response.AppendHeader("content-disposition", "attachment; filename=NewsLetter" + Request.QueryString["TIPO"] + ".xls");
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            dg.DataSource = _email;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
    }
}
