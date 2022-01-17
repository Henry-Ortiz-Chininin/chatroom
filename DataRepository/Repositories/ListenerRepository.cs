using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Connection;
using DataRepository.Interfaces;

namespace DataRepository.Repositories
{
    public class ListenerRepository : iListernerRepository
    {
        public bool Add(string speakerId, string listenerId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("SpeakerId", speakerId));
            parameters.Add(new SqlParameter("ListenerId", listenerId));

            SQLProvider.ExecuteProc("usp_Listener_Add", parameters);

            return true;
        }

        public IEnumerable<Listener> GetListeners(string speakerId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("SpeakerId", speakerId));

            List<Listener> listeners = new List<Listener>();

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_Listener_List", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    Listener listener = new Listener();

                    listener.ListenerId = SQLProvider.GetGUID(reader, "ListenerId");
                    listener.SpeakerId = SQLProvider.GetGUID(reader, "SpeakerId");

                    listeners.Add(listener);
                }
            }
            return listeners;
        }

        public bool Remove(string speakerId, string listenerId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("SpeakerId", speakerId));
            parameters.Add(new SqlParameter("ListenerId", listenerId));

            SQLProvider.ExecuteProc("usp_Listener_Delete", parameters);

            return true;
        }
    }
}
