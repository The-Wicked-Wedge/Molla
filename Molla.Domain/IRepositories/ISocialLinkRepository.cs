using Molla.Domain.Entities;


namespace Molla.Domain.IRepositories
{
    public interface ISocialLinkRepository
    {
        Task<SocialLink> GetByIdAsync(int Id);
        Task<SocialLink> GetByIdAsNoTrackingAsync(int Id);
        Task<ICollection<SocialLink>> GetAllAsync();
        Task<bool> SaveAsync();
        Task<bool> CreateAsync(SocialLink socialLink);
        Task<bool> DeleteByIdAsync(int Id);
        Task<bool> UpdateAsync(SocialLink socialLink);
    }
}
