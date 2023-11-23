using Molla.Application.DTOs;
using Molla.Application.IServices;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await banerRepository.CreateAsync()
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BanerDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BanerDTO> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateByIdAsync(BanerDTO BanerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
