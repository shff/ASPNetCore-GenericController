using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace SHF.GenericController
{
    public static class ServiceCollectionExtensions
    {
        public static void UseGenericController(this IServiceCollection services)
        {
            services
                .AddMvc(o => o.Conventions.Add(new RouteConvention()))
                .ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new FeatureProvider()));
        }
    }

    public class FeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var classes = Assembly.GetEntryAssembly().DefinedTypes;

            var models = classes.Where(a => a.GetCustomAttributes<RouteAttribute>().Any());
            var controller = classes.Single(a => a.IsClass && a.IsPublic &&
                a.ContainsGenericParameters && (a.Name.Contains("Controller")
                    || a.IsDefined(typeof(ControllerAttribute))));

            foreach (var model in models)
            {
                var typeInfo = controller.MakeGenericType(model).GetTypeInfo();
                feature.Controllers.Add(typeInfo);
            }
        }
    }

    public class RouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerType.IsGenericType)
                return;

            var genericType = controller.ControllerType.GenericTypeArguments[0];
            var attribute = genericType.GetCustomAttribute<RouteAttribute>();

            if (attribute?.Template == null)
            {
                controller.ControllerName = genericType.Name;
                return;
            }

            controller.Selectors.Add(new SelectorModel
            {
                AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(attribute.Template)),
            });
        }
    }
}
