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
        Task<SocialLinkDTO> GetByIdAsync(int Id);
        Task<SocialLinkDTO> GetByIdAsNoTrackingAsync(int Id);
        Task<bool> DeleteSocialLinkByIdAsync(int Id);
    }
}
