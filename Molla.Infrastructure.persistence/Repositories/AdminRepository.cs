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
    public class AdminRepository(ApplicationDbContext context) : GenericeRepository<User>(context),IAdminRepository
    {
        public async Task<ICollection<User>> GetAllEmailConfirmedUsers()
        {
            var all = await GetAllAsync();
            return all.Where(u => u.EmailConfirmed).ToList();

        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return (ICollection<User>)await GetAllAsync();
        }

        public async Task<User> GetUserById(string Id)
        {
            return await GetUserById(Id);
        }
    }
}
