using Molla.Domain.Entities.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> Create(Product model);
        bool Update(Product model);
        bool Delete(Product model);
        #endregion
    }
}
