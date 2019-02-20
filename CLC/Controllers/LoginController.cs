using CLC.Models;
using CLC.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            SecurityService service = new SecurityService();

            bool result = service.login(user);

            if (result)
            {
                Session["principal"] = true;
                return View("Home");
            } else
            {
                return View("Login");
            }
        }
    }
}