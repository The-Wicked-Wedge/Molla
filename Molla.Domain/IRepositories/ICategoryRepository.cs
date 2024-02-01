using Molla.Domain.Entities.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<Category>> GetAllAsync();
        Task<bool> Create(Category model);
        bool Update(Category model);
        bool Delete(Category model);
        #endregion
    }
}
