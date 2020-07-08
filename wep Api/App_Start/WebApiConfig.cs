using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace wep_Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type","json","application/json"));

            config.Formatters.JsonFormatter.Indent = true;


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
          name: "RPC",
          routeTemplate: "{controller}/{action}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

        }
    }
}
