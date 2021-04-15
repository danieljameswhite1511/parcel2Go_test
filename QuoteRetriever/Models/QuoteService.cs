using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteRetriever.Models
{
    public class QuoteService
    {
        public string CourierName { get; set; }
        public string CourierSlug { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string CollectionType { get; set; }
        public string DeliveryType { get; set; }
        public string ShortDescriptions { get; set; }
        public string Overview { get; set; }
        public string Features { get; set; }
    }
}
