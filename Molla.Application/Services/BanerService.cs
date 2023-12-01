using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.IServices;
using Molla.Domain.IRepositories;


namespace Molla.Application.Services
{
    public class BanerService : IBanerService
    {
        private readonly IBanerRepository banerRepository;

        public BanerService(IBanerRepository banerRepository)
        {
            this.banerRepository = banerRepository;
        }

        public async Task<bool> CreateAsync(BanerDTO banerDTO)
        {
            banerDTO.CreateDate = DateTime.Now;

            return await banerRepository.CreateAsync(banerDTO.ConvertBanerDTOToBaner());
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await banerRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<BanerDTO>> GetAllAsync()
        {
            return (await banerRepository.GetAllAsync()).Select(b => b.ConvertBanerToBanerDTO());
            
        }

        public async Task<BanerDTO> GetByIdAsync(Guid id)
        {
            return (await banerRepository.GetByIdAsync(id)).ConvertBanerToBanerDTO();
        }

        public async Task<bool> UpdateAsync(BanerDTO BanerDTO)
        {
            BanerDTO.UpdateDate = DateTime.Now;

            return await banerRepository.UpdateAsync(BanerDTO.ConvertBanerDTOToBaner());
        }
    }
}
