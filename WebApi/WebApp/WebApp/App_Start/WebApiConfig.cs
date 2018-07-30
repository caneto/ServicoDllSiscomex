using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            config.Routes.MapHttpRoute(
               name: "ControllerOnly",
               routeTemplate: "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                           name: "ControllerAndId",
                           routeTemplate: "api/{controller}/{id}",
                           defaults: null,
                           constraints: new { id = @"^\d+$" } // Only integers 
                       );

            // Rotas da API da Web
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
