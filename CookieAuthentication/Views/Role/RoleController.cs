using CookieAuthentication.DataAccess.Entities;
using CookieAuthentication.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CookieAuthentication.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly IAccountLogic _accountLogic;

        public RoleController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleAdd(Role role)
        {
            var _isCreate = _accountLogic.CreateRole(role);
            return View();
        }
    }
}