using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MarketComparingWebApp.Startup))]

namespace MarketComparingWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute( //
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
            configuration.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore//
        };
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("application/json"));

            app.UseWebApi(configuration);


        }

        //public static void Register(HttpConfiguration config)
        //{
        //    //// Web API configuration and services

        //    //// Web API routes
        //    //config.MapHttpAttributeRoutes();

        //    //config.Routes.MapHttpRoute(
        //    //    name: "DefaultApi",
        //    //    routeTemplate: "api/{controller}/{id}",
        //    //    defaults: new { id = RouteParameter.Optional }
        //    //);

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );


        //    //****//
        //    config.Formatters.Remove(config.Formatters.XmlFormatter);
        //    config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
        //        = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        //    config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
        //        new MediaTypeHeaderValue("application/json"));
        //    //****//
        //}
    }
}