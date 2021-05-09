 using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace QuoteRetriever.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
  public class QuotesController : ControllerBase
  {
    private readonly IQuoteService _quoteService;
    private readonly IGenericRepository<Service> _serviceRepository;

    public QuotesController(IQuoteService quoteService, IGenericRepository<Service> serviceRepository)
    {
      _quoteService = quoteService;
      _serviceRepository = serviceRepository;
    }

    [HttpGet("{weight}")]
    public async Task<ActionResult> GetQutoesByWeight([FromRoute]int weight)
    {
        var quotes = await this._quoteService.GetQuotes(weight);

        if(weight==0)
        return BadRequest();

        if(quotes==null)
        return NotFound();
        
        return Ok(quotes);

        

    }

    [HttpGet()]
    public async Task<ActionResult> GetQutoes()
    {
        var quotes = await this._quoteService.GetQuotes(10);

        return Ok(quotes);

    }

    [HttpGet("services")]
    public async Task<ActionResult> GetServices()
    {
        var services = await this._serviceRepository.ListAllAsync();

        return Ok(services);

    }


  }
}