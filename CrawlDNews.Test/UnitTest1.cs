using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrawlDNews.Models;
using CrawlDNews.Repo;
using Moq;
using Xunit;

namespace CrawlDNews.Test {
    public class UnitTest1 {
        private Mock<ICrawlerRepo> repo;
        private Crawler crawler;
        public UnitTest1 () {
            repo = new Mock<ICrawlerRepo> ();
            crawler = new Crawler (repo.Object);
        }

        [Fact]
        public async void CrawlerReturnsListofNews () {
            var result = new List<Newsinfo> {
                new Newsinfo { Title = "title-1" },
                new Newsinfo { Title = "title-2" },
            };

            var site = new SiteInfo {
                Url = "url",
                NewsSectionClass = "newsection",
                TitleClass = "title",
                SummaryClass = "summary",
                DateClass = "date",
                LinkClass = "link"
            };

            repo.Setup (m => m.GetNewsAsync (site))
                .Returns (Task.FromResult (result));

            var news = await crawler.GetNewsResult (site);

            repo.Verify (repo => repo.GetNewsAsync (site));
            Assert.Equal (result, news);
        }

        [Fact]
        public async void CrawlerReturnsNull_ifSiteinfoNull () {
            SiteInfo site = null;

            var news = await crawler.GetNewsResult (site);

            repo.Verify (repo => repo.GetNewsAsync (site), Times.Never ());
            Assert.Null (news);

        }
    }
}