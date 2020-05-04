using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlDNews.Models;
using CrawlDNews.Repo;

namespace CrawlDNews {
    public class Crawler {
        public Crawler (ICrawlerRepo _repo) {
            repo = _repo;
        }
        private ICrawlerRepo repo;

        public async Task<List<Newsinfo>> GetNewsResult (SiteInfo site) {
            if (site == null) {
                return null;
            }
            return await repo.GetNewsAsync (site);
        }
    }
}