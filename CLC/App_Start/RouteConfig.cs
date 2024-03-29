﻿using System.Web.Mvc;
using System.Web.Routing;

namespace CLC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "{Home}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "{Login}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "{Register}",
                defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Minesweeper",
                url: "{Minesweeper}",
                defaults: new { controller = "Minesweeper", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
