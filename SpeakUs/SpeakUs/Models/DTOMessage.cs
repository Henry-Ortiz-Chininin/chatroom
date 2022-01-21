using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakUs.Models
{
    public class DTOMessage
    {
        public string IdMessage { get; set; }
        public string IdRoom { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
    }
}