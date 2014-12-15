using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using Perbaffo.Presenter.Model;

namespace Perbaffo.Presenter
{
    public class ControllerUI :IDisposable
    {
        /// <summary>
        /// Lista dei feed
        /// </summary>
        /// <returns></returns>
        public List<SyndicationItem> GetFeeds()
        {
            SyndicationItem _feedItem = null;
            List<SyndicationItem> _lstFeed = null;
            List<RSSFeed> _lstRssFeed = null;
            using (StatisticheModelDataContext _model = new StatisticheModelDataContext())
            {
                _lstRssFeed = _model.RSSFeeds.OrderByDescending(feed => feed.DataCreazione).ToList();
            }
            if (_lstRssFeed != null)
            {
                _lstFeed = new List<SyndicationItem>(_lstRssFeed.Count());
                _lstRssFeed.ForEach(feed =>
                    {
                        _feedItem = null;
                        _feedItem = new SyndicationItem();
                        _feedItem.Authors.Add(new SyndicationPerson("info@perbaffo.it","Perbaffo","http://www.perbaffo.it/"));
                        _feedItem.Id = feed.UrlDettaglio.Trim();
                        SyndicationLink itemlink = new SyndicationLink();
                        itemlink.Title = "Perbaffo.it";
                        itemlink.Uri = new Uri(feed.UrlDettaglio.Trim());
                        _feedItem.Links.Add(itemlink);
                        //itemlink = new SyndicationLink();
                        //itemlink.Title = "Perbaffo.it";
                        //itemlink.Uri = new Uri("http://www.perbaffo.it/images/pp_logo.gif");
                        //itemlink.MediaType = "image/gif";
                        //_feedItem.Links.Add(itemlink);
                        _feedItem.PublishDate = new DateTimeOffset(feed.DataCreazione);
                        _feedItem.Title = new TextSyndicationContent(feed.Titolo, TextSyndicationContentKind.Plaintext);
                        //_feedItem.Summary = new TextSyndicationContent(feed.Titolo);
                        _feedItem.Content = new TextSyndicationContent("<img src='http://www.perbaffo.it/ImmaginiPerbaffo/" + feed.UrlDettaglio.Substring(feed.UrlDettaglio.LastIndexOf('=') + 1).ToString() + "L.jpg' alt='titolo'/><br/>" + feed.Contenuto + " &nbsp;<a href='" + feed.UrlDettaglio + "' title='Guarda i dettagli'>&nbsp;Guarda sul sito</a>", TextSyndicationContentKind.Html);
                        _feedItem.Categories.Add(new SyndicationCategory(feed.Categoria));
                        _feedItem.Copyright = new TextSyndicationContent("Perbaffo");
                        _lstFeed.Add(_feedItem);
                    });
            }
            return _lstFeed;
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
