using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Connection;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class RoomMessageRepository : iRoomMessageRepository
    {
        public string Add(RoomMessage message)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", message.Id));
            parameters.Add(new SqlParameter("RoomId", message.RoomId));
            parameters.Add(new SqlParameter("SpeakerId", message.SpeakerId));
            parameters.Add(new SqlParameter("Message", message.Message));
            parameters.Add(new SqlParameter("ReferenceId", message.ReferenceId));

            SQLProvider.ExecuteProc("usp_RoomMessage_Add", parameters);

            return message.Id;
        }

        public RoomMessage GetMessage(string roomid, string messageid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomId", roomid));
            parameters.Add(new SqlParameter("Id", messageid));

            RoomMessage message = null;

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_RoomMessage_Get", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    message = new RoomMessage();

                    message.Id = SQLProvider.GetGUID(reader, "Id");
                    message.RoomId = SQLProvider.GetText(reader, "RoomId");
                    message.SpeakerId = SQLProvider.GetText(reader, "SpeakerId");
                    message.CreationTime = SQLProvider.GetDateTime(reader, "CreationTime");
                    message.Message = SQLProvider.GetText(reader, "Message");
                    message.ReferenceId = SQLProvider.GetText(reader, "ReferenceId");
                }
            }
            return message;
        }

        public IEnumerable<RoomMessage> GetMessages(string roomid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomId", roomid));

            List<RoomMessage> messageList = new List<RoomMessage>();

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_RoomMessage_List", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    RoomMessage message = new RoomMessage();

                    message.Id = SQLProvider.GetGUID(reader, "Id");
                    message.RoomId = SQLProvider.GetText(reader, "RoomId");
                    message.SpeakerId = SQLProvider.GetText(reader, "SpeakerId");
                    message.CreationTime = SQLProvider.GetDateTime(reader, "CreationTime");
                    message.Message = SQLProvider.GetText(reader, "Message");
                    message.ReferenceId = SQLProvider.GetText(reader, "ReferenceId");

                    messageList.Add(message);
                }
            }
            return messageList;
        }

        public bool Remove(string roomid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", roomid));

            SQLProvider.ExecuteProc("usp_RoomMessage_Delete", parameters);

            return true;
        }

        public string Update(RoomMessage message)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", message.Id));
            parameters.Add(new SqlParameter("RoomId", message.RoomId));
            parameters.Add(new SqlParameter("Message", message.Message));

            SQLProvider.ExecuteProc("usp_RoomMessage_Update", parameters);

            return message.Id;
        }
    }
}
