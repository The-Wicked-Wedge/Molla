using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;



namespace Molla.Infrastructure.persistence.Repositories
{
    public class SocialLinkRepository : ISocialLinkRepository
    {
        private readonly ApplicationDbContext context;

        public SocialLinkRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(SocialLink socialLink)
        {
            await context.SocialLinks.AddAsync(socialLink);
            return await SaveAsync();
        }

        public async Task<bool> DeleteByIdAsync(Guid Id)
        {
            context.SocialLinks.Remove(await GetByIdAsync(Id));
            return await SaveAsync();
        }

        public async Task<ICollection<SocialLink>> GetAllAsync()
        {
            return await context.SocialLinks.ToListAsync();
        }

        public async Task<SocialLink> GetByIdAsNoTrackingAsync(Guid Id)
        {
            return await context.SocialLinks.AsNoTracking().FirstOrDefaultAsync(s => s.ID == Id);
        }

        public async Task<SocialLink> GetByIdAsync(Guid Id)
        {
            return await context.SocialLinks.FirstOrDefaultAsync(s => s.ID == Id);
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(SocialLink socialLink)
        {
            context.SocialLinks.Update(socialLink);
            return await SaveAsync();
        }
    }
}
