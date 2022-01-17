using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;
using DataRepository.Repositories;


namespace DomainEntitySpeakUs.Aggregates
{
    public class Room
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string CreatorId { get; set; }
        public string RoomStatus { get; set; }

        public DateTime LastUpdate { get; set; }

        public Room() {
        }

        public Room(string RoomId)
        {
            iRoomRepository iRoom = new RoomRepository();
            DataEntity.Room room = iRoom.GetRoom(RoomId);
            this.RoomId = RoomId;
            this.RoomName = room.RoomName;
            this.CreatorId = room.CreatorId;
            this.RoomStatus = room.Status;
            this.LastUpdate = room.LastUpdate;
        }

        public List<Speaker> Mates ()
        {
            List<Speaker> result = new List<Speaker>();

            iRoomMateRepository iMate = new RoomMateRepository();

            foreach (RoomMate mate in iMate.GetMatesByRoom(this.RoomId))
            {
                result.Add(new Speaker(mate.RoomMateId));
            }
            return result;
        }

        public List<Message> Messages { get; set; }

    }
}
