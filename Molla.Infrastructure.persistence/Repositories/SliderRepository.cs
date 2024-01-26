using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;


namespace Molla.Infrastructure.persistence.Repositories;
public class SliderRepository(ApplicationDbContext context) : GenericeRepository<Slider>(context), ISliderRepository
{
    public async Task<Slider> GetByIDAsync(Guid id)
    {
        Slider sliderById = await _context.Sliders.FirstOrDefaultAsync(x => x.ID == id);
        return sliderById;
    }
    public async Task<bool> IsAnyActiveSlider()
    {
        IEnumerable<Slider> allSliders = await GetAllAsync();
        bool isAnyActiveSlider = allSliders.Select(x => x.IsActive == true).Any();
        return isAnyActiveSlider;
    }
}

