using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository;
using DataRepository.Connection;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class RoomRepository : iRoomRepository
    {
        public string Add(Room room)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", room.Id));
            parameters.Add(new SqlParameter("RoomName", room.RoomName));
            parameters.Add(new SqlParameter("CreatorId", room.CreatorId));
            parameters.Add(new SqlParameter("Status", room.Status));

            SQLProvider.ExecuteProc("usp_Room_Add", parameters);

            return room.Id;
        }

        public Room GetRoom(string roomId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", roomId));

            Room room = null;

            using (SqlConnection connection = SQLProvider.GetConnection())
            {
                SqlDataReader reader = SQLProvider.ReaderFromProc(connection, "usp_Room_Get", parameters);
                while (reader.HasRows && reader.Read())
                {
                    room = new Room();

                    room.Id = SQLProvider.GetGUID(reader, "Id");
                    room.RoomName = SQLProvider.GetText(reader, "RoomName");
                    room.CreatorId = SQLProvider.GetGUID(reader, "CreatorId");
                    room.Status = SQLProvider.GetText(reader, "Status");
                }
                reader.Close();
            }

            return room;
        }

        public IEnumerable<Room> GetRooms(string mateId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            List<Room> roomList = new List<Room>();

            using (SqlConnection connection = SQLProvider.GetConnection())
            {
                SqlDataReader reader = SQLProvider.ReaderFromProc(connection, "usp_Room_List", parameters);
                while (reader.HasRows && reader.Read())
                {
                    Room room = new Room();

                    room.Id = SQLProvider.GetGUID(reader, "Id");
                    room.RoomName = SQLProvider.GetText(reader, "RoomName");
                    room.CreatorId = SQLProvider.GetGUID(reader, "CreatorId");
                    room.Status = SQLProvider.GetText(reader, "Status");

                    roomList.Add(room);
                }
                reader.Close();
            }

            return roomList;
        }

        public bool Remove(string roomId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", roomId));

            SQLProvider.ExecuteProc("usp_Room_Delete", parameters);

            return true;
        }

        public string Update(Room room)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", room.Id));
            parameters.Add(new SqlParameter("RoomName", room.RoomName));
            parameters.Add(new SqlParameter("CreatorId", room.CreatorId));
            parameters.Add(new SqlParameter("Status", room.Status));

            SQLProvider.ExecuteProc("usp_Room_Update", parameters);

            return room.Id;
        }
    }
}
