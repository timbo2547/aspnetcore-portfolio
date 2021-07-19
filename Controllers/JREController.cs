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
using AspNetCorePostgreSQLDockerApp.Utilities;

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
            var jreShows = JreShowService.GetShows();
            return View(jreShows);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
