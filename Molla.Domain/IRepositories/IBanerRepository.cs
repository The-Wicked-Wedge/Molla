using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IBanerRepository : IDisposable
    {
        Task<IEnumerable<Baner>> GetAllAsync();
        Task<Baner> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Baner baner);
        Task<bool> SaveAsync();
        bool Save();
        Task<bool> UpdateByIdAsync(Baner baner);
        Task<bool> DeleteByIdAsync(Guid id);
        
    }
}
