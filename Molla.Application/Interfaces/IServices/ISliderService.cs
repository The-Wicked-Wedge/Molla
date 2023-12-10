using Molla.Application.DTOs;

namespace Molla.Application.Interfaces.IServices
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderDTO>> GetAllAsync();
        Task<bool> IsAnyActiveSlider();
        Task<SliderDTO> GetByIDAsync(Guid id);
        Task<bool> CreateAsync(SliderDTO model);
        Task<bool> UpdateByIDAsync(SliderDTO model);
        Task<bool> DeleteByIDAsync(Guid id);
    }
}
