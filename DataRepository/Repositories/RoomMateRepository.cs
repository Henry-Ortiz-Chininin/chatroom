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
    public class RoomMateRepository : iRoomMateRepository
    {
        public bool Add(RoomMate mate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomId", mate.RoomId));
            parameters.Add(new SqlParameter("RoomMateId", mate.RoomMateId));
            parameters.Add(new SqlParameter("Status", mate.Status));

            SQLProvider.ExecuteProc("usp_RoomMate_Add", parameters);

            return true;
        }

        public IEnumerable<RoomMate> GetMatesByRoom(string roomId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomId", roomId));

            List<RoomMate> roomList = new List<RoomMate>();

            using (SqlConnection connection = SQLProvider.GetConnection())
            {
                SqlDataReader reader = SQLProvider.ReaderFromProc(connection, "usp_RoomMateByRoom_List", parameters);
                while (reader.HasRows && reader.Read())
                {
                    RoomMate mate = new RoomMate();

                    mate.RoomId = SQLProvider.GetGUID(reader, "RoomId");
                    mate.RoomMateId = SQLProvider.GetGUID(reader, "RoomMateId");
                    mate.Status = SQLProvider.GetText(reader, "Status");

                    roomList.Add(mate);
                }
                reader.Close();
            }

            return roomList;
        }

        public IEnumerable<string> GetRoomsByMate(string mateId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomMateId", mateId));

            List<string> roomList = new List<string>();

            using (SqlConnection connection = SQLProvider.GetConnection())
            {
                SqlDataReader reader = SQLProvider.ReaderFromProc(connection, "usp_RoomMateByMate_List", parameters);
                while (reader.HasRows && reader.Read())
                {
                    roomList.Add(SQLProvider.GetGUID(reader, "RoomId"));
                }
                reader.Close();
            }

            return roomList;
        }

        public bool Remove(string roomid, string mateid)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomId", roomid));
            parameters.Add(new SqlParameter("RoomMateId", mateid));

            SQLProvider.ExecuteProc("usp_RoomMate_Delete", parameters);

            return true;
        }

        public bool Update(RoomMate mate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("RoomId", mate.RoomId));
            parameters.Add(new SqlParameter("RoomMateId", mate.RoomMateId));
            parameters.Add(new SqlParameter("Status", mate.Status));

            SQLProvider.ExecuteProc("usp_RoomMate_Update", parameters);

            return true;
        }
    }
}
