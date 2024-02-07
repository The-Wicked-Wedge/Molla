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
        Task<Baner> GetByIdAsync(Guid id);

        Task<Baner> GetByIdNoTrackingAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<Baner>> GetAllAsync();
        Task<bool> Create(Baner baner);
        bool Update(Baner baner);
        bool Delete(Baner model);
        #endregion
    }
}
