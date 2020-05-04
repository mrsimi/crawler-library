using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlDNews.Models;

namespace CrawlDNews.Repo {
    public interface ICrawlerRepo {
        Task<List<Newsinfo>> GetNewsAsync (SiteInfo siteInfo);
    }
}