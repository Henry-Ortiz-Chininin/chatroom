using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;
using DataRepository.Repositories;

namespace DomainSpeakUs.Aggregates
{
    public class RoomMessage
    {
        public string IdMessage { get; set; }
        public string IdRoom { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreatorId { get; set; }
        public Speaker Creator { get; set; }

        public RoomMessage()
        {

        }
        public RoomMessage(string IdRoom, string IdMessage)
        {
            iRoomMessageRepository iRoomMessage = new RoomMessageRepository();
            DataEntity.RoomMessage message = iRoomMessage.GetMessage(IdRoom, IdMessage);
            this.IdMessage = IdMessage;
            this.IdRoom = IdRoom;
            this.Content = message.Message;
            this.CreationTime = message.CreationTime;
            this.CreatorId = message.SpeakerId;
            this.Creator = new Speaker(this.CreatorId);
        }

    }
}
