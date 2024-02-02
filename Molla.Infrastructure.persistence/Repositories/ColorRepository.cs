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
    public class ColorRepository(ApplicationDbContext context) : GenericeRepository<Color>(context), IColorRepository
    {
        public async Task<Color> GetByIdAsync(Guid id)
        {
            return await _context.Colors.FirstOrDefaultAsync(p=> p.ID == id) ;
        }
    }
}
