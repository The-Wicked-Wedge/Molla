using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IServices
{
    public interface IBanerService
    {
        Task<IEnumerable<BanerDTO>> GetAllAsync();
        Task<BanerDTO> GetByIdAsync(Guid id);
        Task<BanerDTO> GetByIdNoTrackingAsync(Guid id);

        Task<bool> CreateAsync(BanerDTO banerDTO);
        Task<bool> UpdateAsync(BanerDTO BanerDTO);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
