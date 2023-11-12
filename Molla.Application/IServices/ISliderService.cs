using Molla.Application.DTOs;
using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.IServices
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderDTO>> GetAllAsync();
        Task<SliderDTO> GetByIDAsync(Guid id);
        Task<bool> CreateAsync(SliderDTO model);
        Task<bool> UpdateByIDAsync(SliderDTO model);
        Task<bool> DeleteByIDAsync(Guid id);
    }
}
