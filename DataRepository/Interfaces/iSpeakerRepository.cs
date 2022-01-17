using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataRepository.Interfaces
{
    public interface iSpeakerRepository
    {
        string Add(Speaker speaker);
        string Update(Speaker speaker);
        bool Remove(string speakerId);
        Speaker GetSpeaker(string speakerId);
        List<Speaker> GetSpeakers();
    }
}
