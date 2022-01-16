using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossover.Status;

namespace DataEntity
{
    public class Speaker:Base
    {
        public string UserId { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }
    }
}
