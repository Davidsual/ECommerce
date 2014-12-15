using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perbaffo.Web.UI
{
    [PartialCaching(120)]
    public partial class WidgetPerbaffo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetExpires(System.DateTime.Now.AddDays(7));
        }
    }
}