using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using InfyInsight.business;
using InfyInsight.business.contract;
using Microsoft.Practices.Unity;

namespace InfyInsight.api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            //Dependencies
            container.RegisterType<IProductManager, ProductManager>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
