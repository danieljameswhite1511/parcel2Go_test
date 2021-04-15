using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteRetriever.Functions.GetQuotes.Models
{
    public class QuoteRequest
    {
        public QuoteRequest(decimal weight)
        {
            CollectionAddress = new QuoteRequestAddress();
            DeliveryAddress = new QuoteRequestAddress();
            Parcels = new[] { new QuoteRequestParcel(weight) };
        }

        public QuoteRequestAddress CollectionAddress { get; set; }
        public QuoteRequestAddress DeliveryAddress { get; set; }
        public QuoteRequestParcel[] Parcels { get; set; }
    }
}
