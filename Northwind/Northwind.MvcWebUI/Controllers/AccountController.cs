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
        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                user.Id,
                user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                new string[] { "Admin,User" },
                false, user.FirstName, user.LastName);

                return "user is authenticated";
            }

            return "user is not authenticated";

        }
    }
}