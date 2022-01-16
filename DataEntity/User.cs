using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossover.Status;

namespace DataEntity
{
    public class User:Base
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
