using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Wep.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //var corse = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            //config.EnableCors(corse);

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", "application/json"));

            config.Formatters.JsonFormatter.Indent = true;

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //config.Formatters.XmlFormatter.UseXmlSerializer = true;



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           

            config.Routes.MapHttpRoute(
              name: "Rpc",
              routeTemplate: "{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
        }
    }
}
