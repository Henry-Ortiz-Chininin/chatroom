using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class RoomRepository : iRoomRepository
    {
        public string Add(Room room)
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(string roomId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetRooms(string mateId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string roomId)
        {
            throw new NotImplementedException();
        }

        public string Update(Room room)
        {
            throw new NotImplementedException();
        }
    }
}
