using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuoteRetriever.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteRetriever.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var quotes = new QuoteRetriever.Functions.GetQuotes.QuoteRetriever("public-api", "ea3008fec7784ee29bd2aa1e00c0d3c9:TechTest", "parcel2go-technical-test", "https://sandbox.parcel2go.com/auth/connect/token", "https://sandbox.parcel2go.com/api/quotes");
            return View(quotes.GetQuotes(5));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
