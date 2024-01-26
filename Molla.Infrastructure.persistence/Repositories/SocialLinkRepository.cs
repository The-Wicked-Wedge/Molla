using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;



namespace Molla.Infrastructure.persistence.Repositories
{
    public class SocialLinkRepository(ApplicationDbContext context) 
        : GenericeRepository<SocialLink>(context), ISocialLinkRepository
    {
        
        public async Task<SocialLink?> GetByIdAsNoTrackingAsync(Guid Id)
        {
            return await context.SocialLinks.AsNoTracking().FirstOrDefaultAsync(s => s.ID == Id);
        }

        public async Task<SocialLink?> GetByIdAsync(Guid Id)
        {
            return await context.SocialLinks.FirstOrDefaultAsync(s => s.ID == Id);
        }
    }
}
