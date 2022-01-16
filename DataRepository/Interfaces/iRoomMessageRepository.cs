using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataRepository.Interfaces
{
    public interface iRoomMessageRepository
    {
        bool Add(RoomMessage message);
        bool Update(RoomMessage message);
        bool Remove(string roomid);
        RoomMessage GetMessage(string roomid, string messageid);
        IEnumerable<RoomMessage> GetMessages(string roomid);
    }
}
