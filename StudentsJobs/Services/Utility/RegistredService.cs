using System;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;

namespace StudentsJobs.Services.Utility
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            var serviceType = typeof(IServiceScope);

            var serviceTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => serviceType.IsAssignableFrom(x) && !x.IsAbstract);

            foreach (var type in serviceTypes)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(x => x != serviceType);

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"Service type {type.Name} must implement an interface other than {serviceType.Name}.");
                }

                services.AddScoped(interfaceType, type);
            }
        }
    }
}
