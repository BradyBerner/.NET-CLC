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
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            SecurityService service = new SecurityService();

            bool result = service.login(user);

            if (result)
            {
                return View();
            } else
            {
                return View();
            }
        }
    }
}