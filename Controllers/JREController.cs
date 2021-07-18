using AspNetCorePostgreSQLDockerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AspNetCorePostgreSQLDockerApp.Controllers
{
    public class JREController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public JREController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var showUrl = "https://spotifeed.timdorr.com/4rOoJ6Egrf8K2IrywzwOMk";
            var doc = XDocument.Load(showUrl);
            var root = doc.Root;
            var res = root.
                Element("channel").
                Elements("item").
                Select(x => new JreShow { 
                    Description = (string)x.Element("description"),
                    Title = (string)x.Element("title"),
                    ImageUrl = (string)x.Element("{http://www.itunes.com/dtds/podcast-1.0.dtd}image").Attribute("href"),
                    Url = (string)x.Element("link"),
                }).ToList();

             return View(res);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
