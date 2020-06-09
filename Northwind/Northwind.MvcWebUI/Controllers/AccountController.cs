using Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(
                1,
                "yasinaksu",
                "yasinaksu88gmail.com",
                DateTime.Now.AddDays(15),
                new string[] { "Admin,User" },
                false, "Yasin", "Aksu");

            return "user is authenticated";
        }
    }
}