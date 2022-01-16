using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class ListenerRepository : iListernerRepository
    {
        public bool Add(string speakerId, string listenerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Listener> GetListeners(string speakerId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string speakerId, string listenerId)
        {
            throw new NotImplementedException();
        }
    }
}
