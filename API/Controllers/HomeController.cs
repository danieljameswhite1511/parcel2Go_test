using Core.ViewModels;
using Infrastructure.Services.Quotes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace QuoteRetriever.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IQuoteService _quoteService;

    public HomeController(ILogger<HomeController> logger, IQuoteService quoteService)
    {
      _quoteService = quoteService;
      _logger = logger;
    }

    public IActionResult Index()
    {
      
      return View(_quoteService.GetQuotes(50));
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
