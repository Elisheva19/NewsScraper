using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsScraper.Scraping
{
   public static class TLSScraper
    {
        public static List<NewsPost> Scrape ()
        {
            var html = GetNewsHtml();
            return ParseNewsHtml(html);

        }
         private static List<NewsPost> ParseNewsHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".post");
            var items = new List<NewsPost>();

            foreach( var div in resultDivs)
            {
                var post = new NewsPost();
                var title = div.QuerySelector("h2");
                if (title == null)
                {
                    continue;
                }
                if (title!= null)
                {
                    post.Title = title.TextContent;
                }
                var link = div.QuerySelector("a");
                if (link == null)
                {
                    continue;
                }
                if (link != null)
                {
                    post.Link = $"{link.Attributes["href"].Value}";

                }
                var imagetag = div.QuerySelector(".fancybox");
                if (imagetag == null)
                {
                    continue;
                }
                if (imagetag != null)
                {
                    post.ImageUrl = $"{imagetag.Attributes["href"].Value}";
                }
                var textblurb = div.QuerySelector("p");
                if (textblurb == null)
                {
                    continue;
                }
                if (textblurb != null)
                {
                    post.TextBlurb = textblurb.TextContent;
                }
                var comments = div.QuerySelector(".backtotop");
                if (comments == null)
                {
                    continue;
                }
                if (comments != null)
                {
                    post.CommentsAmount = comments.TextContent;
                }

                var submitcomment = div.QuerySelector(".backtotop > a");
                if (submitcomment == null)
                {
                    continue;
                }
                if (submitcomment != null)
                {
                    post.SubmitComment = $"{submitcomment.Attributes["href"].Value}";
                }


                items.Add(post);
            }

            return items;
        }
        private static string GetNewsHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };

            using var client = new HttpClient(handler);
            var url = $"https://www.thelakewoodscoop.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
   
}

