﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Delete
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TrustRoute",
                url: "Trust",
                defaults: new
                {
                    controller = "Home",
                    action = "TrustView"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    location = UrlParameter.Optional,
                    trustType = UrlParameter.Optional
                }
            );
        }
        
    }
}
