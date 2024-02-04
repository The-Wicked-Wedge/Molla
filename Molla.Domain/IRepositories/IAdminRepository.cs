using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IAdminRepository
    {
        public Task<ICollection<User>> GetAllUsers();
        public Task<ICollection<User>> GetAllEmailConfirmedUsers();
        public Task<User> GetUserById(string Id);
        
    }
}
