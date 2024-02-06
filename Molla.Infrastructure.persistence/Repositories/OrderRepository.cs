using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class OrderRepository(ApplicationDbContext context) : GenericeRepository<Order>(context), IOrderRepository
    {
        public async Task<Order> GetByIDAsync(int id)
        {
            return await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

    }
}
