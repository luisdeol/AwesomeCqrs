using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeCqrs
{
    public static class LibraryExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly) {
            services
                .AddTransient<IMediator, AwesomeMediator>()
                .AddHandlers(assembly);

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services, Type type) {
            services
                .AddTransient<IMediator, AwesomeMediator>()
                .AddHandlers(type);

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services, Assembly assembly) {
            services.Scan(t => 
                t.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(t => 
                t.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services, Type type) {
            var assembly = type.Assembly;

            services.AddHandlers(assembly);

            return services;
        }
    }
}