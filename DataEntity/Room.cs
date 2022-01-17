using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossover.Status;

namespace DataEntity
{
    public class Room:Base
    {
        public string Id { get; set; }
        public string CreatorId { get; set; }
        public string RoomName { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdate { get; private set; }

    }
}
