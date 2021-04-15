using QuoteRetriever.Models;
using System.Collections.Generic;

namespace QuoteRetriever.Functions.GetQuotes
{
    public interface IQuoteRetriever
    {
        List<Quote> GetQuotes(int weight);
    }
}
