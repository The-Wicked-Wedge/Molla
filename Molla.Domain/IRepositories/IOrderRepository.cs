using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIDAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<bool> Create(Order model);
        bool Delete(Order model);
    }
}
