using System;
using System.Threading.Tasks;
using AwesomeShop.Services.Orders.Core.Entites;

namespace AwesomeShop.Services.Orders.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);

    }
}
