using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.Interfaces;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.IRepositories;

namespace Molla.Application.Services
{
    public class BanerService : IBanerService
    {
        private readonly IBanerRepository _banerRepository;
        private readonly IPhotoService _photoService;
        private readonly IApplicationUnitOfWork _uow;
        public BanerService(IBanerRepository banerRepository, IApplicationUnitOfWork uow,IPhotoService photoService)
        {
            _banerRepository = banerRepository;
            _uow = uow;
            _photoService = photoService;
        }
        public async Task<bool> CreateAsync(BanerDTO banerDTO)
        {
            banerDTO.CreateDate = DateTime.Now;
            banerDTO.UpdateDate = banerDTO.CreateDate;
            var resualt = await _banerRepository.Create(banerDTO.ConvertBanerDTOToBaner());
            if (resualt)
            {
                return await _uow.SaveChangesAsync();
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            BanerDTO baner  = await  GetByIdNoTrackingAsync(id);
            if(baner != null)
            {
                bool resualt = _banerRepository.Delete(baner.ConvertBanerDTOToBaner());
                if (resualt)
                {
                    await _photoService.DeletePhotoAsync(baner.ImageSource);
                    return await _uow.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
        public async Task<IEnumerable<BanerDTO>> GetAllAsync()
        {
            return (await _banerRepository.GetAllAsync()).Select(b => b.ConvertBanerToBanerDTO());
            
        }
        public async Task<BanerDTO> GetByIdAsync(Guid id)
        {
            return (await _banerRepository.GetByIdAsync(id)).ConvertBanerToBanerDTO();
        }
        public async Task<BanerDTO> GetByIdNoTrackingAsync(Guid id)
        {
            return (await _banerRepository.GetByIdNoTrackingAsync(id)).ConvertBanerToBanerDTO();
        }
        public async Task<bool> UpdateAsync(BanerDTO BanerDTO)
        {

            BanerDTO baner = await GetByIdNoTrackingAsync(BanerDTO.ID);
            if(baner != null)
            {
                BanerDTO.UpdateDate = DateTime.Now;
                if(BanerDTO.ImageSource == null) BanerDTO.ImageSource = baner.ImageSource;
                bool resualt = _banerRepository.Update(BanerDTO.ConvertBanerDTOToBaner());
                if (resualt)
                {
                    return await _uow.SaveChangesAsync();
                }
                return false;
            }
            return false;
        }
    }
}
