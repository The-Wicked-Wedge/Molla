using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class BanerRepository : IBanerRepository
    {
        private readonly ApplicationDbContext _context;
        public BanerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Baner baner)
        {
            await _context.AddAsync(baner);
            return await SaveAsync();
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            _context.Remove(await GetByIdAsync(id));
            return await SaveAsync();
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public async Task<IEnumerable<Baner>> GetAllAsync()
        {
            return await _context.Baners.ToListAsync();
        }

        public async Task<Baner> GetByIdAsync(Guid id)
        {
            return await _context.Baners.FirstOrDefaultAsync(b => b.ID == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Baner baner)
        {
            _context.Update(baner);
            return await SaveAsync();
        }
    }
}
