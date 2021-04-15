using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteRetriever.Models
{
    public class Quote
    {
        public decimal Discount { get; set; }
        public QuoteService Service { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceExVat { get; set; }
        public decimal TotalVat { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public DateTime Collection { get; set; }
        public DateTime CutOff { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
    }

    public class Result
    {
        public List<Quote> Quotes { get; set; }
    }
}
