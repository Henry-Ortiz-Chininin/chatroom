using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataRepository.Interfaces
{
    public interface iRoomRepository
    {
        string Add(Room room);
        string Update(Room room);
        bool Remove(string roomId);
        Room GetRoom(string roomId);
        IEnumerable<Room> GetRooms(string mateId);
    }
}
