using Molla.Domain.Entities.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IGalleryRepository
    {
        Task<Gallery> GetByIdAsync(Guid id);
        Task<Gallery> GetOriginImageByProductIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<Gallery>> GetAllAsync();
        Task<bool> Create(Gallery model);
        bool Update(Gallery model);
        bool Delete(Gallery model);
        #endregion
    }
}
