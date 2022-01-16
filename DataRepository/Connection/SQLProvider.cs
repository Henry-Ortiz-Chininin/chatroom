using System;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Net.Security;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DataRepository.Connection
{
    public class SQLProvider
    {
        static string ConnectionHandle=string.Empty;

        static SQLProvider()
        {
            ConnectionHandle = "Connection";
        }

        private static string m_strConnectionString = string.Empty;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(m_strConnectionString))
                {
                    m_strConnectionString = ConfigurationManager.ConnectionStrings[ConnectionHandle].ConnectionString;
                }

                return m_strConnectionString;
            }

            set
            {
                m_strConnectionString = value;
            }
        }
        

        public static SqlDataReader ReaderFromProc(string strStoreProc, IEnumerable<SqlParameter>sqlParams)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = strStoreProc;
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach(SqlParameter param in sqlParams)
            {
                command.Parameters.Add(param);
            }

            connection.Open();
            return command.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                       
        }

        public static void ExecuteProc(string strStoreProc, IEnumerable<SqlParameter> sqlParams)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = strStoreProc;
                command.CommandType = System.Data.CommandType.StoredProcedure;

                foreach (SqlParameter param in sqlParams)
                {
                    command.Parameters.Add(param);
                }

                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public static string GetText(SqlDataReader reader, string fieldName)
        {
            string fieldValue = "";
            for(int id=0;id< reader.FieldCount;id++)
            {
                if(reader.GetName(id).ToString()==fieldName && !reader.IsDBNull(id))
                {
                    fieldValue =reader.GetString(id);
                }
            }
            return fieldValue;
        }

        public static string GetGUID(SqlDataReader reader, string fieldName)
        {
            string fieldValue = "";
            for (int id = 0; id < reader.FieldCount; id++)
            {
                if (reader.GetName(id).ToString() == fieldName && !reader.IsDBNull(id))
                {
                    fieldValue = reader.GetGuid(id).ToString().ToUpper();
                }
            }
            return fieldValue;
        }

        public static string GetDateTime(SqlDataReader reader, string fieldName)
        {
            string fieldValue = "";
            for (int id = 0; id < reader.FieldCount; id++)
            {
                if (reader.GetName(id).ToString() == fieldName && !reader.IsDBNull(id))
                {
                    fieldValue = reader.GetDateTime(id).ToString();
                }
            }
            return fieldValue;
        }

        public static int? GetInt(SqlDataReader reader, string fieldName)
        {
            int? fieldValue = null;
            for (int id = 0; id < reader.FieldCount; id++)
            {
                if (reader.GetName(id).ToString() == fieldName && !reader.IsDBNull(id))
                {
                    fieldValue = reader.GetInt32(id);
                }
            }
            return fieldValue;

        }

        public static double? GetDouble(SqlDataReader reader, string fieldName)
        {
            double? fieldValue = null;
            for (int id = 0; id < reader.FieldCount; id++)
            {
                if (reader.GetName(id).ToString() == fieldName && !reader.IsDBNull(id))
                {
                    fieldValue = reader.GetDouble(id);
                }
            }
            return fieldValue;

        }
    }
}
