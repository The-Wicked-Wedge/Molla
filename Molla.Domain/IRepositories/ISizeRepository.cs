using Molla.Domain.Entities.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface ISizeRepository
    {
        Task<Size> GetByIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<Size>> GetAllAsync();
        Task<bool> Create(Size model);
        bool Update(Size model);
        bool Delete(Size model);
        #endregion
    }
}
