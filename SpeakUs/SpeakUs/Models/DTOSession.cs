using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainSpeakUs;

namespace SpeakUs.Models
{
    public class DTOSession
    {
        public string SessionId { get; set; }
        public string SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerStatus { get; set; }
        public List<DTORoom> Rooms { get; set; }
        public List<DTOMate> Mates { get; set; }
        public List<DTOMessage> Messages { get; set; }

        public string NewRoomName { get; set; }
        public string NewMateUser { get; set; }
        public string NewMessage { get; set; }
        public string NewCurrentRoomId { get; set; }
        public string CurrentRoomId { get; set; }
        public string RemoveRoomId { get; set; }
        public string RemoveMateId { get; set; }

        public string CurrentAction { get; set; }
    }
}