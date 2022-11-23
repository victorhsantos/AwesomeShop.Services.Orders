using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using AwesomeShop.Services.Orders.Core.Entites;
using AwesomeShop.Services.Orders.Core.Repositories;

namespace AwesomeShop.Services.Orders.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public OrderRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<Order>("orders");
        }

        public async Task AddAsync(Order order) =>        
            await _collection.InsertOneAsync(order);
        
        public async Task<Order> GetByIdAsync(Guid id) =>        
            await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        
        public async Task UpdateAsync(Order order) =>      
            await _collection.ReplaceOneAsync(c => c.Id == order.Id, order);
        
    }
}
