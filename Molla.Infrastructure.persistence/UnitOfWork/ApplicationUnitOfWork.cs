using Molla.Application.Interfaces;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.UnitOfWork
{
    public class ApplicationUnitOfWork(ApplicationDbContext dbContext) : IApplicationUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
