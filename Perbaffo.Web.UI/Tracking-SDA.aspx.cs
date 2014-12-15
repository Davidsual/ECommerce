using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perbaffo.Web.UI
{
    public partial class Tracking_SDA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["CODSPED"]))
            {
                this.id_ldv.Value = Request.QueryString["CODSPED"];
            }
        }
    }
}
