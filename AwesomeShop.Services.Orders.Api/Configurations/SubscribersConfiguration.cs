using AwesomeShop.Services.Orders.Application.Subscribers;
using AwesomeShop.Services.Orders.Infrastructure.MessageBus;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeShop.Services.Orders.Api.Configurations
{
    public static class SubscribersConfiguration
    {
        public static IServiceCollection AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<PaymentAcceptedSubscriber>();
            return services;
        }
    }
}
