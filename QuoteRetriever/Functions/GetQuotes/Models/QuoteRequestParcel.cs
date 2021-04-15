using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteRetriever.Functions.GetQuotes.Models
{
    public class QuoteRequestParcel
    {
        public QuoteRequestParcel(decimal weight)
        {
            Weight = weight;
            Length = 10m;
            Width = 10m;
            Height = 10m;
        }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
    }
}
