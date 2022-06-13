using System;

namespace NewsScraper.Scraping
{
    public class NewsPost

    {
        public string Title { get; set; }
        public string Link { get; set; }
       public string   ImageUrl {get;set;}
       public string TextBlurb { get; set; }
       public string CommentsAmount { get; set; }

        public string SubmitComment { get; set; }
    }
}


