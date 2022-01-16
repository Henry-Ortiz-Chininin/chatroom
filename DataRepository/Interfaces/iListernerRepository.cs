using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataRepository.Interfaces
{
    public interface iListernerRepository
    {
        bool Add(string speakerId, string listenerId);
        bool Remove(string speakerId, string listenerId);
        IEnumerable<Listener> GetListeners(string speakerId);
    }
}
