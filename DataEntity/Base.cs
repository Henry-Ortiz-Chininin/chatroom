using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class Base
    {
        public string GetID()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
    }
}
