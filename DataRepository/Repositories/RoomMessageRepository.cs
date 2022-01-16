using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class RoomMessageRepository : iRoomMessageRepository
    {
        public bool Add(RoomMessage message)
        {
            throw new NotImplementedException();
        }

        public RoomMessage GetMessage(string roomid, string messageid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoomMessage> GetMessages(string roomid)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string roomid)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoomMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
