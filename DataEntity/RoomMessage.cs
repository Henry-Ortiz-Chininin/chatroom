using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public class RoomMessage:Base
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string SpeakerId { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }
        public string ReferenceId { get; set; }
    }
}
