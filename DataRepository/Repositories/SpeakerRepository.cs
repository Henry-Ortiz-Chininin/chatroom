﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;
using System.Data.SqlClient;
using DataRepository.Connection;
using Crossover.Status;

namespace DataRepository.Repositories
{
    public class SpeakerRepository : iSpeakerRepository
    {
        public bool Add(Speaker speaker)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UseId", speaker.UserId));
            parameters.Add(new SqlParameter("Name", speaker.Name));
            parameters.Add(new SqlParameter("Status", speaker.Status));

            SQLProvider.ExecuteProc("usp_Speaker_Add", parameters);

            return true;
        }

        public Speaker GetSpeaker(string speakerId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UserId", speakerId));

            Speaker speaker = null;

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_Speaker_Get", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    speaker = new Speaker();

                    speaker.UserId = SQLProvider.GetGUID(reader, "Id");
                    speaker.Name = SQLProvider.GetText(reader, "UserName");
                    speaker.Status = SQLProvider.GetText(reader, "Status");                    
                }
            }
            return speaker;
        }

        public bool Remove(string speakerId)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("UserId", speakerId));

                SQLProvider.ExecuteProc("usp_Speaker_Delete", parameters);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Speaker> GetSpeakers()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            List<Speaker> speakerList = new List<Speaker>();

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_Speaker_List", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    Speaker speaker = new Speaker();

                    speaker.UserId = SQLProvider.GetGUID(reader, "UserId");
                    speaker.Name = SQLProvider.GetText(reader, "Name");
                    speaker.Status= SQLProvider.GetText(reader, "Status");

                    speakerList.Add(speaker);
                }

            }
            return speakerList;
        }

        public bool Update(Speaker speaker)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UserId", speaker.UserId));
            parameters.Add(new SqlParameter("Name", speaker.Name));
            parameters.Add(new SqlParameter("Status", speaker.Status));

            SQLProvider.ExecuteProc("usp_Speaker_Update", parameters);

            return true;
        }
    }
}
