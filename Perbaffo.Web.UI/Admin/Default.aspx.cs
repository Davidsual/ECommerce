using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Perbaffo.Web.UI.Admin
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //    this.pnlDettaglio.Controls.Add(LoadControl("Home.ascx"));

            this.MenuControl.MenuSelectionHandler += new Menu.MenuDelegate(MenuControl_MenuSelectionHandler);
        }

        private void MenuControl_MenuSelectionHandler(Menu.Section sezione)
        {
            switch (sezione)
            {
                case Menu.Section.Home:
                    this.pnlDettaglio.Controls.Clear();
                    this.pnlDettaglio.Controls.Add(LoadControl("Home.ascx"));
                    break;
                case Menu.Section.Prodotti:
                    this.pnlDettaglio.Controls.Clear();
                    this.pnlDettaglio.Controls.Add(LoadControl("Prodotti.ascx"));
                    break;
                case Menu.Section.Categorie:
                    this.pnlDettaglio.Controls.Clear();
                    this.pnlDettaglio.Controls.Add(LoadControl("Prodotti.ascx"));
                    break;
                default:
                    break;
            }
        }
    }
}
