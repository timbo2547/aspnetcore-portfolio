using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TimPortfolioApp.Controllers
{
    public class CurriculumVitaeController : Controller
    {
        //[HttpGet("{id}")]
        //[Route("Stream")]
        public IActionResult Index()
        {
            string filePath = "~/docs/cv.pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=cv.pdf");
            return File(filePath, "application/pdf");
        }
    }
}
