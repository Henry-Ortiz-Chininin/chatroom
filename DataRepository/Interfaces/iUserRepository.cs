using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity;

namespace DataRepository.Interfaces
{
    public interface iUserRepository
    {
        string Add(User user);
        string Update(User user);
        User Authenticate(string username, string password);
        bool existUser(string username);
        bool Remove(string userId);
        User GetUser(string UserId);
        List<User> GetUsers();
    }
}
