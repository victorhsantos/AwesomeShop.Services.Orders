using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Bson;
using AwesomeShop.Services.Orders.Infrastructure.Persistence;

namespace AwesomeShop.Services.Orders.Api.Configurations
{
    public static class MongoDbConfiguration
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            services.AddSingleton(s =>
            {
                var configuration = s.GetService<IConfiguration>();
                var options = new MongoDbOptions();
                configuration.GetSection("Mongo").Bind(options);
                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddTransient(sp =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();
                return mongoClient.GetDatabase(options.Database);
            });

            return services;
        }
    }
}
