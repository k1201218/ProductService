using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Harjoitus4.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Harjoitus4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
            // New code:
            builder.Namespace = "ProductService";
            builder.EntityType<Product>()
                .Action("Rate")
                .Parameter<int>("Rating");

            // New code:
            builder.Namespace = "ProductService";
            builder.EntityType<Product>().Collection
                .Function("MostExpensive")
                .Returns<double>();

            // New code:
            builder.Function("GetSalesTaxRate")
                .Returns<double>()
                .Parameter<int>("PostalCode");
        }
    }
}
