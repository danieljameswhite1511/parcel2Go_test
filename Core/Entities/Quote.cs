using System;
using System.Collections.Generic;

namespace Core.Entities
{
  public class Quote
    {
        public decimal Discount { get; set; }
        public Service Service { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceExVat { get; set; }
        public decimal TotalVat { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VatRate { get; set; }
        public DateTime Collection { get; set; }
        public DateTime CutOff { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }

        public List<AvailableExtra> AvailableExtras { get; set; }

        public Links Links { get; set; }

        public List<Quote> Quotes { get; set; }
    }
}
