using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Molla.Application.Interfaces;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class BanerRepository(ApplicationDbContext context) : 
        GenericeRepository<Baner>(context), IBanerRepository
    { 
        public async Task<Baner> GetByIdAsync(Guid id)
        {
            return await _context.Baners.FirstOrDefaultAsync(b => b.ID == id);
        }

    }
}
