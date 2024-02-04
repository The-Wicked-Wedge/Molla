using Molla.Domain.Entities.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IStockByColorSizeRepository
    {
        Task<StockByColorSize> GetByIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<StockByColorSize>> GetAllAsync();
        Task<bool> Create(StockByColorSize model);
        bool Update(StockByColorSize model);
        bool Delete(StockByColorSize model);
        #endregion
    }
}
