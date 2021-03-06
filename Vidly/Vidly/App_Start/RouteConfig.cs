﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //     url: "movies/released/{year}/{month}",
            //     defaults: new { controller = "Movies", action = "ByReleasedDate", year = "3217", month = "11"},
            //     constraints: new { year = @"\d{4}", month = @"\d{2}"}
            //     );

            routes.MapRoute(
                name: "NewMovie",
                url: "movies/new",
                defaults: new { controller = "Movies", action = "New" }
                );

            routes.MapRoute(
                name: "MovieDetails",
                url: "movies/{id}",
                defaults: new { controller = "Movies", action = "View" }
                );

            routes.MapRoute(
                name: "NewCustomer",
                url: "customers/new",
                defaults: new { controller = "Customers", action = "New" }
                );

            routes.MapRoute(
                name: "EditCustomer",
                url: "customers/edit/{id}",
                defaults: new { controller = "customers", action = "Edit" }
                );

            routes.MapRoute(
                name: "CustomerDetails",
                url: "customers/{id}",
                defaults: new { controller = "Customers", action = "View" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
