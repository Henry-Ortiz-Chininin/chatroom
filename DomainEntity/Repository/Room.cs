using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crossover.Status;

namespace DomainSpeakUs.Repository
{
    public static class Room
    {
        public static string Add(string CreatorId, string roomName)
        {
            DataEntity.Room room = new DataEntity.Room();
            room.Id = room.GetID();
            room.CreatorId = CreatorId;
            room.RoomName = roomName;
            room.Status = RoomStatus.OPEN;
            new DataRepository.Repositories.RoomRepository().Add(room);

            DataEntity.RoomMate roomMate = new DataEntity.RoomMate();
            roomMate.RoomId = room.Id;
            roomMate.RoomMateId = CreatorId;
            roomMate.Status = RoomMateStatus.HIDDEN;

            new DataRepository.Repositories.RoomMateRepository().Add(roomMate);

            //ADD BOOT
            string BootId = System.Configuration.ConfigurationManager.AppSettings["BotId"].ToString();
            roomMate.RoomMateId = BootId;
            new DataRepository.Repositories.RoomMateRepository().Add(roomMate);

            return room.Id;
        }

        public static bool SetStatusRoom(string RoomId, string SpeakerId)
        {
            DataRepository.Interfaces.iSpeakerRepository iSpeakerRepository = new DataRepository.Repositories.SpeakerRepository();
            DataEntity.Speaker speaker = iSpeakerRepository.GetSpeaker(SpeakerId);
            speaker.CurrentRoomId = RoomId;

            iSpeakerRepository.Update(speaker);

            return true;
        }



    }
}
