using Molla.Domain.Entities;
using Molla.Domain.Entities.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IColorRepository
    {
        Task<Color> GetByIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<Color>> GetAllAsync();
        Task<bool> Create(Color model);
        bool Update(Color model);
        bool Delete(Color model);
        #endregion
    }
}
