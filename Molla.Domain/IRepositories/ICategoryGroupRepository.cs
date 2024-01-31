using Molla.Domain.Entities;
using Molla.Domain.Entities.category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface ICategoryGroupRepository
    {
        Task<CategoryGroup> GetByIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<CategoryGroup>> GetAllAsync();
        Task<bool> Create(CategoryGroup model);
        bool Update(CategoryGroup model);
        bool Delete(CategoryGroup model);
        #endregion
    }
}
