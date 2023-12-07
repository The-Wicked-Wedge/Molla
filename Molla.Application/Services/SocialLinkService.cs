using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.IServices;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
    public class SocialLinkService : ISocialLinkService
    {
        private readonly ISocialLinkRepository socialLinkRepository;
        public SocialLinkService(ISocialLinkRepository socialLinkRepository)
        {
            this.socialLinkRepository = socialLinkRepository;
        }

        public async Task<bool> CreateSocialLink(SocialLinkDTO socialLinkDTO)
        {
            return await socialLinkRepository.CreateAsync(socialLinkDTO.ConvertToModel());
        }

        public async Task<bool> DeleteSocialLinkByIdAsync(int Id)
        {
            return await socialLinkRepository.DeleteByIdAsync(Id);
        }

        public async Task<ICollection<SocialLinkDTO>> GetAllSocialLinks()
        {
            var allSLs = await socialLinkRepository.GetAllAsync();
            var allSlDTOs = new List<SocialLinkDTO>();

            foreach (var item in allSLs)
            {
                allSlDTOs.Add(item.ConvertToDTO());    
            }

            return allSlDTOs;
        }

        public async Task<SocialLinkDTO> GetByIdAsNoTrackingAsync(int Id)
        {
            return (await socialLinkRepository.GetByIdAsNoTrackingAsync(Id)).ConvertToDTO();
        }

        public async Task<SocialLinkDTO> GetByIdAsync(int Id)
        {
            return (await socialLinkRepository.GetByIdAsync(Id)).ConvertToDTO();
        }

        public async Task<bool> UpdateSocialLink(SocialLinkDTO socialLinkDTO)
        {
            return await socialLinkRepository.UpdateAsync(socialLinkDTO.ConvertToModel());
        }
    }
}
