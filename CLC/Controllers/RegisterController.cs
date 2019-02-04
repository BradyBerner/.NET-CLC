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
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            SecurityService service = new SecurityService();

            bool result = service.register(user);

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