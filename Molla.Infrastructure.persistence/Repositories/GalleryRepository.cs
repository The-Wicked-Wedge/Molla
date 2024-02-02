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
    public class GalleryRepository(ApplicationDbContext context) : GenericeRepository<Gallery>(context), IGalleryRepository
    {
        public async Task<Gallery> GetByIdAsync(Guid id)
        {
            return await _context.Galleries.FirstOrDefaultAsync(p => p.ID == id);
        }
        public async Task<Gallery> GetOriginImageByProductIdAsync(Guid id)
        {
            return await _context.Galleries.FirstOrDefaultAsync(p => p.ProductId == id && p.IsOriginImage == true);
        }
    }
}
