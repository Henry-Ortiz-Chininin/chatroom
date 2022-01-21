using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainSpeakUs.Repository
{
    public static class Speaker
    {
        public static bool AddSpeakerToRoom(string RoomId, string MateUser)
        {
            string MateId = DataRepository.Repositories.UserRepository.GetUserByName(MateUser);
            if (MateId == string.Empty)
                return false;

            DataEntity.RoomMate roomMate = new DataEntity.RoomMate();
            roomMate.RoomId = RoomId;
            roomMate.RoomMateId = MateId;
            roomMate.Status = Crossover.Status.RoomMateStatus.CONNECTED;

            new DataRepository.Repositories.RoomMateRepository().Add(roomMate);

            return true;
        }

        public static bool AddMessage(string RoomId, string SpeakerId, string SpeakerMessage)
        {
            DataEntity.RoomMessage message = new DataEntity.RoomMessage();
            message.Id = message.GetID();
            message.CreationTime = DateTime.Now;
            message.RoomId = RoomId;
            message.SpeakerId = SpeakerId;
            message.Message = SpeakerMessage;
            new DataRepository.Repositories.RoomMessageRepository().Add(message);

            return true;
        }

        public static bool RemoveSpeaker(string RoomId, string SpeakerId)
        {
            new DataRepository.Repositories.RoomMateRepository().Remove(RoomId, SpeakerId);

            return true;
        }

        public static bool AddBootMessage(string RoomId, string SpeakerId, string SpeakerMessage)
        {
            string SpeakerCommand = SpeakerMessage.ToLower().Replace("/stock=","");
            string CSVContent = ExternalSource.Stooq.Repository.DownloadFile(SpeakerCommand);
            DataEntity.Stooq stooq = ExternalSource.Stooq.Repository.GetStooq(CSVContent);

            DataEntity.RoomMessage message = new DataEntity.RoomMessage();
            message.Id = message.GetID();
            message.CreationTime = DateTime.Now;
            message.RoomId = RoomId;
            message.SpeakerId = SpeakerId;
            message.Message = stooq.ToString();
            new DataRepository.Repositories.RoomMessageRepository().Add(message);

            return true;
        }

    }
}
