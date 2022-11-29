using AwesomeShop.Services.Orders.Infrastructure.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace AwesomeShop.Services.Orders.Api.Configurations
{
    public static class MessageBusConfiguration
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            var connectionFactory = new ConnectionFactory {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("order-service-producer");

            services.AddSingleton(new ProducerConnection(connection));
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();

            return services;
        }
    }
}
