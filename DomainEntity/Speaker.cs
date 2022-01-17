using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class Speaker
    {
        public string SpeakerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerStatus { get; set; }

        public List<Speaker> Mates { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
