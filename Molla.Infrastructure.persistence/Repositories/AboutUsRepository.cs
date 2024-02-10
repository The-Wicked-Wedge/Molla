using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class AboutUsRepository(ApplicationDbContext context) : GenericeRepository<AboutUs>(context), IAboutUsRepository
    {
        public async Task<AboutUs> GetAboutUsAsync()
        {
            return await _context.AboutUs.FirstOrDefaultAsync();
        }
    }
}
