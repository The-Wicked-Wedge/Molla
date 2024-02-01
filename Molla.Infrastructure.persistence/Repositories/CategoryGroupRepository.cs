using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities.category;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class CategoryGroupRepository(ApplicationDbContext context) :
        GenericeRepository<CategoryGroup>(context), ICategoryGroupRepository
    {

        public async Task<CategoryGroup> GetByIdAsync(Guid id)
        {
            return await _context.CategoryGroups.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
