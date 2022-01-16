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
        bool Add(Speaker speaker);
        bool Update(Speaker speaker);
        bool Remove(string speakerId);
        Speaker GetSpeaker(string speakerId);
        List<Speaker> GetSpeakers();
    }
}
