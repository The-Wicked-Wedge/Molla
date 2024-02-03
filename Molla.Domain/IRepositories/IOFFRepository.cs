using Molla.Domain.Entities;
using Molla.Domain.Entities.AdminDashBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IOFFRepository
    {
        Task<IEnumerable<OFFModel>> GetAllAsync();
        Task<bool> Create(OFFModel model);
        bool Delete(OFFModel model);

        Task<IEnumerable<OFFModel>> GetAllTicketsForUser(string Id);
    }
}
