using Molla.Application.DTOs;
using Molla.Application.DTOs.SiteSide;

namespace Molla.Application.Interfaces.IServices
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderDTO>> GetAllAsync();
        Task<bool> IsAnyActiveSlider();
        Task<SliderDTO> GetByIDAsync(Guid id);

        Task<IEnumerable<HomeSliderDTO>> GetHomeSliderAsync();
        Task<bool> CreateAsync(SliderDTO model);
        Task<bool> UpdateByIDAsync(SliderDTO model);
        Task<bool> DeleteByIDAsync(Guid id);
    }
}
