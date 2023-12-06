using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IBanerRepository
    {

        Task<IEnumerable<Baner>> GetAllAsync();
        Task<Baner> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(Baner baner);
        Task<bool> UpdateAsync(Baner baner);
        Task<bool> DeleteByIdAsync(Guid id);
        
    }
}
