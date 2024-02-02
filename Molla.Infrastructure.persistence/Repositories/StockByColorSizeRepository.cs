using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities.product;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class StockByColorSizeRepository(ApplicationDbContext context) :
        GenericeRepository<StockByColorSize>(context), IStockByColorSizeRepository
    {
        public async Task<StockByColorSize> GetByIdAsync(Guid id)
        {
            return await _context.StockByColorSizes.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
