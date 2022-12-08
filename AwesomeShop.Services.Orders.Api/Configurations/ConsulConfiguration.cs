using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AwesomeShop.Services.Orders.Api.Configurations
{
    public static class ConsulConfiguration
    {
        public static IServiceCollection AddConsulCfg(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consul =>
            {
                var addres = configuration.GetValue<string>("Consul:Host");
                consul.Address = new System.Uri(addres);
            }));

            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            var registration = new AgentServiceRegistration
            {
                ID = "order-service",
                Name = "OrderServices",
                Address = "localhost",
                Port = 5003
            };

            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            System.Console.WriteLine("Service registred in Consul");

            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                System.Console.WriteLine("Service deregistred in Consul");
            });

            return app;
        }
    }
}
