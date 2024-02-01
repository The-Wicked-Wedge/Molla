using Microsoft.EntityFrameworkCore;
using Molla.Domain.Common;
using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Common
{
    public class GenericeRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext _context;
        public GenericeRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Create(TEntity entity)
        {
            var x = await _context.Set<TEntity>().AddAsync(entity);
            if (x.State == EntityState.Added)
            {
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            List<TEntity> model = await _context.Set<TEntity>().ToListAsync();
            return model;
        }
        public bool Delete(TEntity model)
        {
            var x = _context.Remove(model);
            if (x.State == EntityState.Deleted)
            {
                return true;
            }
            return false;
        }
        public bool Update(TEntity model)
        {
            var x = _context.Update(model);
            if (x.State == EntityState.Modified)
            {
                return true;
            }
            return false;
        }

    }
}
