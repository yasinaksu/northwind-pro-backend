using Core.CrossCuttingConcerns.Security.Web;
using Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string userName="yasinaksu", string password="12345")
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                var userRoles = _userService.GetRolesByUser(user).Select(x => x.RoleName).ToArray();
                    AuthenticationHelper.CreateAuthCookie(
                    user.Id,
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    userRoles,
                    false, user.FirstName, user.LastName);

                return "user is authenticated";
            }

            return "user is not authenticated";

        }
    }
}