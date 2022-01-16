using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;
using DataRepository.Interfaces;
using System.Data.SqlClient;
using DataRepository.Connection;

namespace DataRepository.Repositories
{
    public class UserRepository : iUserRepository
    {
        public string Add(User user)
        {   
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id",user.Id));
            parameters.Add(new SqlParameter("UserName",user.UserName));
            parameters.Add(new SqlParameter("Password",user.Password));

            SQLProvider.ExecuteProc("usp_User_Add", parameters);

            return user.Id;
        }

        public User Authenticate(string username, string password)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UserName", username));
            parameters.Add(new SqlParameter("Password", password));
            
            User user = null;

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_User_Authenticate", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    user = new User();

                    user.Id = SQLProvider.GetGUID(reader,"Id");
                    user.UserName = SQLProvider.GetText(reader,"UserName");
                    user.Password = SQLProvider.GetText(reader,"Password");
                }

            }
            return user;
        }

        public bool Remove(string userId)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Id", userId));

                SQLProvider.ExecuteProc("usp_User_Delete", parameters);

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool existUser(string username)
        {
            bool result = false;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("UserName", username));

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_User_Validate", parameters))
            {
                result = reader.HasRows;
            }
            return result;
        }

        public User GetUser(string UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", UserId));

            User user = null;

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_User_Get", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    user = new User();

                    user.Id = SQLProvider.GetGUID(reader, "Id");
                    user.UserName = SQLProvider.GetText(reader, "UserName");
                    user.Password = SQLProvider.GetText(reader, "Password");
                }

            }
            return user;
        }

        public string Update(User user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", user.Id));
            parameters.Add(new SqlParameter("UserName", user.UserName));
            parameters.Add(new SqlParameter("Password", user.Password));

            SQLProvider.ExecuteProc("usp_User_Update", parameters);

            return user.Id;
        }

        public List<User> GetUsers()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            List<User> userList = new List<User>();

            using (SqlDataReader reader = SQLProvider.ReaderFromProc("usp_User_List", parameters))
            {
                while (reader.HasRows && reader.Read())
                {
                    User user = new User();

                    user.Id = SQLProvider.GetGUID(reader, "Id");
                    user.UserName = SQLProvider.GetText(reader, "UserName");
                    user.Password = SQLProvider.GetText(reader, "Password");

                    userList.Add(user);
                }

            }
            return userList;
        }
    }
}
