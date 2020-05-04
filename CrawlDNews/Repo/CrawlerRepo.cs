using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using CrawlDNews.Models;

namespace CrawlDNews.Repo {
    public class CrawlerRepo : ICrawlerRepo {
        public async Task<List<Newsinfo>> GetNewsAsync (SiteInfo siteInfo) {

            List<Newsinfo> newsInfoDb = new List<Newsinfo> ();

            var config = Configuration.Default.WithDefaultLoader ();
            var context = BrowsingContext.New (config);
            var document = await context.OpenAsync (siteInfo.Url);
            var newsContent = document.QuerySelectorAll (siteInfo.NewsSectionClass);

            foreach (var item in newsContent) {
                var eachNews = new Newsinfo () {
                    Title = item.QuerySelector (siteInfo.TitleClass).TextContent.ToUpper (),
                    Summary = item.QuerySelector (siteInfo.SummaryClass).TextContent,
                    Link = item.QuerySelector (siteInfo.LinkClass).GetAttribute ("href"),
                    Date = item.QuerySelector (siteInfo.DateClass).TextContent
                };

                newsInfoDb.Add (eachNews);
            }

            return newsInfoDb;
        }
    }
}