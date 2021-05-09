
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Services.Quotes
{
    public interface IQuoteService
    {
        Task<List<Quote>> GetQuotes(decimal? weight);
    }
}
