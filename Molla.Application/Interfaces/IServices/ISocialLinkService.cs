using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IServices
{
    public interface ISocialLinkService
    {
        Task<bool> CreateSocialLink(SocialLinkDTO socialLinkDTO);
        Task<bool> UpdateSocialLink(SocialLinkDTO socialLinkDTO);
        Task<ICollection<SocialLinkDTO>> GetAllSocialLinks();
        Task<SocialLinkDTO> GetByIdAsync(Guid Id);
        Task<SocialLinkDTO> GetByIdAsNoTrackingAsync(Guid Id);
        Task<bool> DeleteSocialLinkByIdAsync(Guid Id);
    }
}
