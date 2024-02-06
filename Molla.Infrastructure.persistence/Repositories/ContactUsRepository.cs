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
    public class ContactUsRepository(ApplicationDbContext context) : GenericeRepository<ContactUs>(context), IContactUsRepository
    {
        public async Task<ContactUs> GetByIdAsync(Guid id)
        {
            return await _context.ContactUs.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
