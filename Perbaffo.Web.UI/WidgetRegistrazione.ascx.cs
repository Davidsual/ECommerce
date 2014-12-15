using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Classes;

namespace Perbaffo.Web.UI
{
    public partial class WidgetRegistrazione : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.UtenteLoggato != null)
                this.Visible = false;
        }
    }
}