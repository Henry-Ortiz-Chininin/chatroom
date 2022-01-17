using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class Message
    {
        public string IdMessage { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatorId { get; set; }

    }
}
