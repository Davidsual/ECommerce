using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.ServiceModel.Syndication;
using System.Globalization;
using Perbaffo.Presenter;

namespace Perbaffo.Web.UI
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class RssHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml"; 
            SyndicationFeed myFeed = new SyndicationFeed();
            myFeed.Title = new TextSyndicationContent("Perbaffo feeds");
            myFeed.ImageUrl = new Uri("http://www.perbaffo.it/images/Perbaffo.jpg");
            myFeed.Links.Add(new SyndicationLink(new Uri("http://www.perbaffo.it")));
            myFeed.Contributors.Add(new SyndicationPerson("info@perbaffo.it","Perbaffo","http://www.perbaffo.it/"));
            myFeed.Authors.Add(new SyndicationPerson("info@perbaffo.it","Perbaffo","http://www.perbaffo.it/"));
            
            myFeed.Description = new TextSyndicationContent("Novità prodotti,promozioni"); 
            myFeed.Copyright = TextSyndicationContent.CreatePlaintextContent("Copyright http://www.Perbaffo.it/"); 
            myFeed.Language = CultureInfo.CurrentCulture.Name;

            List<SyndicationItem> feedItems = null;
            using (ControllerUI _ctrl = new ControllerUI())
            {
                feedItems = _ctrl.GetFeeds();
            }
            DateTimeOffset _time = feedItems.OrderByDescending(f => f.PublishDate).Select(f => f.PublishDate).FirstOrDefault();
            if (_time != null)
                myFeed.LastUpdatedTime = _time;
            else
                myFeed.LastUpdatedTime = new DateTimeOffset(DateTime.Now);
            myFeed.Items = feedItems; 
            System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(context.Response.Output); 
            myFeed.SaveAsAtom10(writer); 
            writer.Close();
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
