using CookieAuthentication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieAuthentication.DataAccess.Repository
{
    public class SqlRepository : IRepository
    {
        private readonly AccountDbContext _accountDbContext;
        public SqlRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public bool CreateRole(Role role)
        {
            try
            {
                _accountDbContext.Roles.Add(role);
                _accountDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

        public bool CreateUser(User user)
        {
            try
            {
                _accountDbContext.Users.Add(user);
                _accountDbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                return false;
            }     
        }

        public List<int> GetRolesByUserId(int userId)
        {
            try
            {
               return _accountDbContext.UserRoles.Where(UserRole => UserRole.UserId == userId).Select(u => u.RoleId).ToList<int>();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public User GetUser(string userName, string password)
        {
            try
            {
               User userData = _accountDbContext.Users.Where(user => user.UserName == userName && user.Password== password).FirstOrDefault();
                
                return userData;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }

        public User GetUserByName(string userName)
        {
            try
            {
                return _accountDbContext.Users.Where(user => user.UserName.Equals(userName)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}
