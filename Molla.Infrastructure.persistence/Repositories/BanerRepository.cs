using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Molla.Application.Interfaces;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class BanerRepository(ApplicationDbContext context, IApplicationUnitOfWork uow) : IBanerRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IApplicationUnitOfWork _uow = uow;

        public async Task<bool> CreateAsync(Baner baner)
        {
            await _context.AddAsync(baner);
            return await _uow.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            _context.Remove(await GetByIdAsync(id));
            return await _uow.SaveChangesAsync();
        }

        public async Task<IEnumerable<Baner>> GetAllAsync()
        {
            return await _context.Baners.ToListAsync();
        }

        public async Task<Baner> GetByIdAsync(Guid id)
        {
            return await _context.Baners.FirstOrDefaultAsync(b => b.ID == id);
        }


        public async Task<bool> UpdateAsync(Baner baner)
        {
            _context.Update(baner);
            return await _uow.SaveChangesAsync();
        }
    }
}
