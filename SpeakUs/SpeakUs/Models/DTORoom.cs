using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakUs.Models
{
    public class DTORoom
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string CreatorId { get; set; }
        public string RoomStatus { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}