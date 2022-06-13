using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsScraper.Scraping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        [HttpGet]

        [Route("scrapetls")]

        public List<NewsPost> ScrapeTLS()
        {
            return TLSScraper.Scrape();
        }
    }
}
