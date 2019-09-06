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
        public static void UseGenericController(this IServiceCollection services, Type controllerType)
        {
            services.
                AddMvc(o => o.Conventions.Add(new RouteConvention())).
                ConfigureApplicationPartManager(m => m.FeatureProviders.Add(new FeatureProvider {
                    ControllerType = controllerType,
                    Assembly = controllerType.Assembly,
                }));
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AutoRouteAttribute : Attribute
    {
        public string Route { get; set; }

        public AutoRouteAttribute(string route)
        {
            Route = route;
        }
    }

    public class FeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public Type ControllerType { get; set; }
        public Assembly Assembly { get; set; }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var type in Assembly.GetExportedTypes())
            {
                if (type.GetCustomAttributes<AutoRouteAttribute>().Any())
                {
                    var typeInfo = this.ControllerType.MakeGenericType(type).GetTypeInfo();
                    feature.Controllers.Add(typeInfo);
                }
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
            var customNameAttribute = genericType.GetCustomAttribute<AutoRouteAttribute>();

            if (customNameAttribute?.Route == null)
            {
                controller.ControllerName = genericType.Name;
                return;
            }

            controller.Selectors.Add(new SelectorModel
            {
                AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route)),
            });
        }
    }
}
