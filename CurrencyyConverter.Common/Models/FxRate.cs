using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyyConverter.Infrastructure.Models
{
    public class FxRate
    {
        public int FxRateId { get; set; }
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
