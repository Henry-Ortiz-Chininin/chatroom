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
    public class Speaker
    {
        iSpeakerRepository iSpeaker = new SpeakerRepository();
        iUserRepository iUser = new UserRepository();

        public string SpeakerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerStatus { get; set; }

        public Speaker()
        {

        }

        public Speaker(string SpeakerId)
        {
            DataEntity.Speaker speaker =  iSpeaker.GetSpeaker(SpeakerId);
            DataEntity.User user = iUser.GetUser(SpeakerId);
            this.SpeakerId = SpeakerId;
            this.SpeakerName = speaker.Name;
            this.SpeakerStatus = speaker.Status;
            this.Username = user.UserName;
            this.Password = user.Password;
        }

        public List<Speaker> Mates()
        {
            List<Speaker> result = new List<Speaker>();

            iListernerRepository iListener = new ListenerRepository();
            foreach(Listener listener in iListener.GetListeners(this.SpeakerId))
            {
                result.Add(new Speaker(listener.ListenerId));
            }
            return result;
        }
        public List<Room> Rooms()
        {
            List<Room> result = new List<Room>();
            iRoomMateRepository iRoom = new RoomMateRepository();
            foreach (DataEntity.RoomMate room in iRoom.GetRoomsByMate(this.SpeakerId))
            {
                result.Add(new Room(room.RoomId));
            }

            return result;
        }
    }
}
