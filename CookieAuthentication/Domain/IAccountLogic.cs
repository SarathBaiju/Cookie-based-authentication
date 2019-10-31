using CookieAuthentication.DataAccess.Entities;
using System.Collections.Generic;

namespace CookieAuthentication.Domain
{
    public interface IAccountLogic
    {
        bool CreateUser(User user);
        bool CreateRole(Role user);
        bool ValidateUser(string userName, string password);
        int GetUserIdByName(string userName);
        List<int> GetRolesByUserId(int userId);
        string GetHighestRole(List<int> roles);
    }
}
