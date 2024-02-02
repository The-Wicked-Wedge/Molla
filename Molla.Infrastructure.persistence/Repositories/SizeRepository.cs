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
    public class SizeRepository(ApplicationDbContext context) : GenericeRepository<Size>(context), ISizeRepository
    {
        public async Task<Size> GetByIdAsync(Guid id)
        {
            return await _context.Sizes.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
