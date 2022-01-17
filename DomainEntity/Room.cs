using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntity
{
    public class Room
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string CreatorId { get; set; }
        public string RoomStatus { get; set; }
        public List<Speaker> Mates { get; set; }
        public List<Message> Messages { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
