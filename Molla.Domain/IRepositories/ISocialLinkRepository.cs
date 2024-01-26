using Molla.Domain.Entities;


namespace Molla.Domain.IRepositories
{
    public interface ISocialLinkRepository
    {

        Task<SocialLink?> GetByIdAsync(Guid Id);
        Task<SocialLink?> GetByIdAsNoTrackingAsync(Guid Id);

        #region Generice Repository
        Task<IEnumerable<SocialLink>> GetAllAsync();
        Task<bool> Create(SocialLink model);
        bool Update(SocialLink model);
        bool Delete(SocialLink model);
        #endregion

    }
}
