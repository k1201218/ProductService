using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Harjoitus3.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Harjoitus3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            builder.EntitySet<Supplier>("Suppliers");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
