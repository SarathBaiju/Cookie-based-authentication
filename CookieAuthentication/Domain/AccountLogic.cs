using CookieAuthentication.DataAccess.Entities;
using CookieAuthentication.DataAccess.Repository;
using CookieAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieAuthentication.Domain
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IRepository _repository;

        public AccountLogic(IRepository repository)
        {
            _repository = repository;
        }

        public bool CreateRole(Role role)
        {
            role.CreatedBy = 1;
            role.CreatedOn = DateTime.UtcNow;
            return _repository.CreateRole(role);
        }

        public bool CreateUser(User user)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.CreatedBy = 1;
            return _repository.CreateUser(user);
        }

        public string GetHighestRole(List<int> roles)
        {
            int maxVal =0;
            if (roles.Count != 0)
            {
                maxVal = roles.Max();
            }
            string role = EnumTypes.Roles.User.ToString();

            switch (maxVal)
            {
                case (int)EnumTypes.Roles.Admin:
                    role = EnumTypes.Roles.Admin.ToString();
                    break;

                default:

                    break;
            }
            return role;
        }

        public List<int> GetRolesByUserId(int userId)
        {
            return _repository.GetRolesByUserId(userId);
        }

        public int GetUserIdByName(string userName)
        {
            var user = _repository.GetUserByName(userName);
            if (user == null) return 0;
            else return user.UserId;
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = _repository.GetUser(userName, password);
            if (user != null) return true;
            else return false;
        }
    }
}
