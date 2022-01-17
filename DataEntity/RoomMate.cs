using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossover.Status;

namespace DataEntity
{
    public class RoomMate:Base
    {
        public string RoomId { get; set; }
        public string RoomMateId { get; set; }
        public string Status { get; set; }
    }
}
