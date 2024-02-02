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
    public class ProductRepository(ApplicationDbContext context) : GenericeRepository<Product>(context), IProductRepository
    {
        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id)
        {
            return  _context.Products.Where(p=> p.CategoryId == id).ToList(); 
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
