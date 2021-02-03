using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RadixTest.Domain.Connectors;
using RadixTest.Domain.Handlers;
using RadixTest.Domain.Interfaces;
using RadixTest.Domain.Services;
using RadixTest.Infra.Context;
using RadixTest.Infra.Repositories;
using System.Reflection;

namespace RadixTest.API
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            RegisterDomainServices(services);
            RegisterRepositories(services);
            RegisterHandlers(services);
        }

        private static void RegisterHandlers(IServiceCollection services)
        {
            services.AddTransient<EventWsHandler>();
            services.AddTransient<EventHandler>();
            services.AddTransient<SensorHandler>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ISensorService, SensorService>();
        }

        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddSingleton<ConnectionManager>();

            foreach (var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(WebSocketHandler))
                {
                    services.AddSingleton(type);
                }
            }

            return services;
        }

        public static IApplicationBuilder MapWebSocketManager(this IApplicationBuilder app,
                                                        PathString path,
                                                        WebSocketHandler handler)
        {
            return app.Map(path, (_app) => _app.UseMiddleware<WebSocketManagerMiddleware>(handler));
        }
    }
}
