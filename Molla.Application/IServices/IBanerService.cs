using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.IServices
{
    internal interface IBanerService
    {
        Task<IEnumerable<BanerDTO>> GetAllAsync();
        Task<BanerDTO> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(BanerDTO banerDTO);
        Task<bool> UpdateByIdAsync(BanerDTO BanerDTO);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
