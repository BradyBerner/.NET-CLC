using CLC.Models;
using CLC.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (!ModelState.IsValid) {
                return View("Register");
            }

            SecurityService service = new SecurityService();

            bool result = service.register(user);

            if (result)
            {
                return View("Login");
            } else
            {
                return View("Register");
            }
        }
    }
}