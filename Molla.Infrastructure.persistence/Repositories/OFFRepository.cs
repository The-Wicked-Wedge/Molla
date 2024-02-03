using Molla.Domain.Entities;
using Molla.Domain.Entities.AdminDashBoard;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class OFFRepository(ApplicationDbContext context) : GenericeRepository<OFFModel>(context), IOFFRepository
    {
        public async Task<IEnumerable<OFFModel>> GetAllTicketsForUser(string Id)
        {
            var allTickets = await GetAllAsync();
            return allTickets.Where(t => t.UserId == Id).ToList();
        }
    }
}
