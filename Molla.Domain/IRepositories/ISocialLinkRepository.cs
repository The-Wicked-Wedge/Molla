using Molla.Domain.Entities;


namespace Molla.Domain.IRepositories
{
    public interface ISocialLinkRepository
    {
        Task<SocialLink> GetByIdAsync(Guid Id);
        Task<SocialLink> GetByIdAsNoTrackingAsync(Guid Id);
        Task<ICollection<SocialLink>> GetAllAsync();
        Task<bool> SaveAsync();
        Task<bool> CreateAsync(SocialLink socialLink);
        Task<bool> DeleteByIdAsync(Guid Id);
        Task<bool> UpdateAsync(SocialLink socialLink);
    }
}
