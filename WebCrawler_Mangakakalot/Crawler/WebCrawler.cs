using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebCrawler_Mangakakalot.Models;

namespace WebCrawler_Mangakakalot.Crawler
{
    public class WebCrawler
    {
        public async Task<List<Popular>> startCrawler()
        {
            //Default code architecture to load any html page
            var url = "https://mangakakalot.com";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //List to hold elements collected
            List<Popular> pops = new List<Popular>();

            //Variable to hold information from specified URL
            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("xem-nhieu-item")).ToList();

            //Loop to collect each apparition of specified div
            foreach(var div in divs)
            {
                Popular pop = new Popular
                {
                    Title = div.Descendants("a").FirstOrDefault().ChildAttributes("Title").FirstOrDefault().Value,
                    Link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value
                };
                pops.Add(pop);
            }

            return pops;
        }
    }
}
