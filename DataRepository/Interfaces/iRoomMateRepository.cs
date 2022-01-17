using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataRepository.Interfaces
{
    public interface iRoomMateRepository
    {
        bool Add(RoomMate mate);
        bool Update(RoomMate mate);
        bool Remove(string roomid, string mateid);
        IEnumerable<RoomMate> GetRoomsByMate(string mateId);
        IEnumerable<RoomMate> GetMatesByRoom(string roomId);
    }
}
