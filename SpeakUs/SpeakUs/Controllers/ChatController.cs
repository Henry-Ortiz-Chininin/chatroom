using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeakUs.Models;
using Crossover.Status;
using System.Threading.Tasks;

namespace SpeakUs.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index(string SessionId)
        {
            if (string.IsNullOrEmpty(SessionId))
                return RedirectToAction("Login", "Home");

            Models.DTOSession session = Build(SessionId);            

            return View(session);
        }

        public ActionResult Logout(string SessionId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DTOSession session)
        {
            if(session.CurrentAction=="Add Room")
                DomainSpeakUs.Repository.Room.Add(session.SessionId, session.NewRoomName);

            if (session.CurrentAction == "Add Mate")
                DomainSpeakUs.Repository.Speaker.AddSpeakerToRoom(session.CurrentRoomId, session.NewMateUser);

            if (session.CurrentAction == "Open Room")
            {
                if( !string.IsNullOrEmpty(session.NewCurrentRoomId))
                    DomainSpeakUs.Repository.Room.SetStatusRoom(session.NewCurrentRoomId, session.SpeakerId);
            }

            if (session.CurrentAction == "Add Message")
            {
                if(session.NewMessage.StartsWith("/stock="))
                {
                    ProcessCommand(session);
                }
                else
                {
                    DomainSpeakUs.Repository.Speaker.AddMessage(session.CurrentRoomId, session.SpeakerId, session.NewMessage);

                }

            }

            if (session.CurrentAction == "Remove Mate")
                DomainSpeakUs.Repository.Speaker.RemoveSpeaker(session.CurrentRoomId, session.RemoveMateId);

            session = Build(session.SessionId); 
            
            return View(session);
        }

        public void ProcessCommand(DTOSession session)
        {
            string BootId = System.Configuration.ConfigurationManager.AppSettings["BotId"].ToString();
            DomainSpeakUs.Repository.Speaker.AddBootMessage(session.CurrentRoomId, BootId, session.NewMessage);

        }
        private DTOSession Build(string SessionId)
        {
            DomainSpeakUs.Aggregates.Speaker speaker = new DomainSpeakUs.Aggregates.Speaker(SessionId);
            Models.DTOSession session = new Models.DTOSession();
            session.SessionId = SessionId;
            session.SpeakerId = speaker.SpeakerId;
            session.SpeakerName = speaker.SpeakerName;
            session.SpeakerStatus = speaker.SpeakerStatus;
            session.CurrentRoomId = speaker.CurrentRoomId;
            session.Rooms = new List<Models.DTORoom>();
            session.Mates = new List<Models.DTOMate>();
            session.Messages = new List<DTOMessage>();

            foreach (DomainSpeakUs.Aggregates.Room room in speaker.Rooms())
            {
                Models.DTORoom item = new Models.DTORoom();
                item.CreatorId = room.CreatorId;
                item.LastUpdate = room.LastUpdate;
                item.RoomId = room.RoomId;
                item.RoomName = room.RoomName;
                item.RoomStatus = room.RoomStatus;
                

                if(room.RoomId== session.CurrentRoomId)
                {
                    foreach (DomainSpeakUs.Aggregates.RoomMessage message in room.Messages().OrderBy(m=>m.CreationTime))
                    {
                        Models.DTOMessage roomMessage = new Models.DTOMessage();
                        roomMessage.IdRoom = message.IdRoom;
                        roomMessage.CreatorId = message.CreatorId;
                        roomMessage.CreatorName = message.Creator.SpeakerName;
                        roomMessage.CreationTime = message.CreationTime;
                        roomMessage.Content = message.Content;

                        session.Messages.Add(roomMessage);
                    }

                    foreach (DomainSpeakUs.Aggregates.Speaker mate in room.Mates())
                    {
                        Models.DTOMate roomMate = new Models.DTOMate();
                        roomMate.SpeakerId = mate.SpeakerId;
                        roomMate.SpeakerName = mate.SpeakerName;
                        roomMate.SpeakerStatus = mate.SpeakerStatus;

                        session.Mates.Add(roomMate);
                    }

                }

                session.Rooms.Add(item);
            }

            foreach (DomainSpeakUs.Aggregates.Speaker mate in speaker.Mates())
            {
                if(session.Mates.Find(m=>m.SpeakerId==mate.SpeakerId)==null )
                {
                    Models.DTOMate item = new Models.DTOMate();
                    item.SpeakerId = mate.SpeakerId;
                    item.SpeakerName = mate.SpeakerName;
                    item.SpeakerStatus = mate.SpeakerStatus;

                    session.Mates.Add(item);
                }

            }

            return session;
        }
    
    
    }
}