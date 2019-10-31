
using CookieAuthentication.DataAccess.Entities;
using CookieAuthentication.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CookieAuthentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountLogic _accountLogic;
 
        public AccountController(IConfiguration configuration, IAccountLogic accountLogic)
        {
            this._configuration = configuration;
            _accountLogic = accountLogic;
        }

        #region Public Methods
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return View("Error");
            }
            var isRegisteredUser = ValidateUser(userName, password);

            if (isRegisteredUser)
            {
                bool isAuthenticated = false;
                ClaimsIdentity identity = null;

                int userId = _accountLogic.GetUserIdByName(userName);
                List<int> roles = _accountLogic.GetRolesByUserId(userId);

                string highestRole = GetHighestRole(roles);
                //var userName = configuration
               
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,userName),new Claim(ClaimTypes.Role,highestRole) }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticated = true;
               
                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View("Error");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            var isCreate = _accountLogic.CreateUser(user);
            return View();
        }
       
        #endregion

        #region Private Methods
        private string GetRoleByClientId(string clientId)
        {
            string role = "User";
            if (clientId == "sarath")
            {
                role = "Admin";
            }
            return role;
        }
        private bool ValidateUser(string userName, string password)
        {
            return _accountLogic.ValidateUser(userName, password);
        }

        private string GetHighestRole(List<int> roles)
        {
            return _accountLogic.GetHighestRole(roles);
        }
        #endregion


    }
}