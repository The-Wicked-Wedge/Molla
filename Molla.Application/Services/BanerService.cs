using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.IServices;
using Molla.Domain.IRepositories;

namespace Molla.Application.Services
{
    public class BanerService(IBanerRepository banerRepository) : IBanerService
    {
        private readonly IBanerRepository _banerRepository = banerRepository;
        public async Task<bool> CreateAsync(BanerDTO banerDTO)
        {

            banerDTO.CreateDate = DateTime.Now;

            return await banerRepository.CreateAsync(banerDTO.ConvertBanerDTOToBaner());

        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await _banerRepository.DeleteByIdAsync(id);
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
 
            BanerDTO.UpdateDate = DateTime.Now;

            return await banerRepository.UpdateAsync(BanerDTO.ConvertBanerDTOToBaner());
  
        }
    }
}
