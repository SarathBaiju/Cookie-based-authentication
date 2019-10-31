using CookieAuthentication.DataAccess.Entities;
using System.Collections.Generic;

namespace CookieAuthentication.DataAccess.Repository
{
    public interface IRepository
    {
        bool CreateUser(User user);
        bool CreateRole(Role role);
        User GetUser(string userName, string password);
        User GetUserByName(string userName);
        List<int> GetRolesByUserId(int userId);
    }
}
