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
        string Add(RoomMessage message);
        string Update(RoomMessage message);
        bool Remove(string roomid);
        RoomMessage GetMessage(string roomid, string messageid);
        IEnumerable<RoomMessage> GetMessages(string roomid);
    }
}
