using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Perbaffo.Web.UI.Admin.Classes;
using System.Collections;

namespace Perbaffo.Web.UI.Admin
{
    public partial class OrdiniStatistiche : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LineChart c = new LineChart(500, 400, Page);

            c.Title = "Totale € ordini archiviati";

            c.Xorigin = 1; c.ScaleX = 12; c.Xdivs = 12;

            c.Yorigin = 0; c.ScaleY = 20000; c.Ydivs = 5;

            Dictionary<int, int> _valori = base.PerbaffoController.GetTotaleOrdini();
            
            for (int i = 1; i < 12; i++)
            {                
                c.AddValue(i, (_valori.ContainsKey(i))?_valori[i]:0);
            }
            c.Draw();
        }
    }
}
