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
        private readonly IApplicationUnitOfWork _uow;
        public BanerService(IBanerRepository banerRepository, IApplicationUnitOfWork uow)
        {
            _banerRepository = banerRepository;
            _uow = uow;
        }
        public async Task<bool> CreateAsync(BanerDTO banerDTO)
        {

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
            BanerDTO baner  = await  GetByIdAsync(id);
            if(baner != null)
            {
                bool resualt = _banerRepository.Delete(baner.ConvertBanerDTOToBaner());
                if (resualt)
                {
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

        public async Task<bool> UpdateAsync(BanerDTO BanerDTO)
        {

            BanerDTO baner = await GetByIdAsync(BanerDTO.ID);
            if(baner != null)
            {
                BanerDTO.UpdateDate = DateTime.Now;
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
