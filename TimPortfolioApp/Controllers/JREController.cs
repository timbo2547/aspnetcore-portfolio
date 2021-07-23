using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimPortfolioApp.Models;
using TimPortfolioApp.Utilities;

namespace TimPortfolioApp.Controllers
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
