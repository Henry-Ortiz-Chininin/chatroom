using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class Stooq
    {
        public string Symbol { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Close { get; set; }
        public decimal Volumen { get; set; }

        public override string ToString()
        {
            return $"{Symbol.ToUpper()} quote is {Close:c}";
        }

    }
}
