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
    public class CategoryRepository(ApplicationDbContext context) :
        GenericeRepository<Category>(context), ICategoryRepository
    {
        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
