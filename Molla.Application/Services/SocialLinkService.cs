using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.Interfaces;
using Molla.Application.Interfaces.IServices;
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
        private readonly IApplicationUnitOfWork _uow;


        public SocialLinkService(ISocialLinkRepository socialLinkRepository , IApplicationUnitOfWork unitOfWork)
        {
            this.socialLinkRepository = socialLinkRepository;
            _uow = unitOfWork;
        }

        public async Task<bool> CreateSocialLink(SocialLinkDTO socialLinkDTO)
        {
            return await socialLinkRepository.Create(socialLinkDTO.ConvertToModel());
        }

        public async Task<bool> DeleteSocialLinkByIdAsync(SocialLinkDTO model)
        {
            bool resualt = socialLinkRepository.Delete(model.ConvertToModel());
            if(resualt)
                return await _uow.SaveChangesAsync();
            return false;
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

        public async Task<SocialLinkDTO> GetByIdAsNoTrackingAsync(Guid Id)
        {
            return (await socialLinkRepository.GetByIdAsNoTrackingAsync(Id)).ConvertToDTO();
        }

        public async Task<SocialLinkDTO> GetByIdAsync(Guid Id)
        {
            return (await socialLinkRepository.GetByIdAsync(Id)).ConvertToDTO();
        }

        public bool UpdateSocialLink(SocialLinkDTO socialLinkDTO)
        {
            return  socialLinkRepository.Update(socialLinkDTO.ConvertToModel());
        }
    }
}
