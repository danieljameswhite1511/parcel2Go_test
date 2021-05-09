using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Quotes.Dtos
{
    public class QuoteRequestAddress
    {
        public QuoteRequestAddress()
        {
            Country = "GBR";
        }
        public string Country { get; set; }
    }
}
