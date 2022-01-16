using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class RoomMateRepository : iRoomMateRepository
    {
        public bool Add(RoomMate mate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomMate> GetRoomMates(string roomid)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string roomid, string mateid)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoomMate mate)
        {
            throw new NotImplementedException();
        }
    }
}
