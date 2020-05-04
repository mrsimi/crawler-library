using System;
using System.IO;
using CrawlDNews.Models;
using CrawlDNews.Repo;
using Newtonsoft.Json;

namespace Console.Samples {
    class Program {
        static async System.Threading.Tasks.Task Main (string[] args) {
            ICrawlerRepo crawlerRepo = new CrawlerRepo ();

            var siteInfo = new SiteInfo {
               Url ="https://punchng.com/topics/latest-news/",
                    NewsSectionClass = ".items.col-sm-12",
                    TitleClass = ".seg-title",
                    SummaryClass = ".seg-summary",
                    DateClass = ".seg-time",
                    LinkClass = "a"
            };

            var result = await crawlerRepo.GetNewsAsync (siteInfo);

            var jsonResult = JsonConvert.SerializeObject(result, new JsonSerializerSettings(){
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });

            File.WriteAllText("result.json",jsonResult);
            System.Console.WriteLine ("Hello World!");
        }
    }
}