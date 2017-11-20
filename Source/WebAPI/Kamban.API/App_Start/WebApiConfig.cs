using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Web.Http.Cors;

namespace Kamban.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            //config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "GroupsRouting",
                routeTemplate: "api/trusts/{userName}/groups/{groupName}",
                defaults: new { controller = "groups", groupName = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TrustRouting",
                routeTemplate: "api/trusts/{userName}",
                defaults: new { controller = "trusts", userName = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
