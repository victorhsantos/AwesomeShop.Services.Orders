using AwesomeShop.Services.Orders.Core.Repositories;
using AwesomeShop.Services.Orders.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AwesomeShop.Services.Orders.Api.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
