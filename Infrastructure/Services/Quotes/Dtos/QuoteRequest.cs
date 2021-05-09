using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services.Quotes.Dtos
{
    public class QuoteRequest
    {
        public QuoteRequest(decimal? weight)
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
