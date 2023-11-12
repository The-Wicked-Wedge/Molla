using Microsoft.EntityFrameworkCore;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using Molla.Infrastructure.persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Infrastructure.persistence.Repositories
{
    public class SliderRepository : ISliderRepository
    {
        private readonly ApplicationDbContext _context;
        public SliderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            List<Slider> allSlider = await _context.Sliders.ToListAsync();
            return allSlider;
        }
        public async Task<Slider> GetByIDAsync(Guid id)
        {
            Slider sliderById = await _context.Sliders.FirstOrDefaultAsync(x => x.ID == id);
            return sliderById;
        }
        public async Task<bool> CreateAsync(Slider model)
        {
            try
            {
                Slider NewSlider = new Slider
                {
                    Description = model.Description,
                    ImageSource = model.ImageSource,
                    Tag = model.Tag,
                    Title = model.Title,
                    IsActive = model.IsActive,
                    EndDate = model.EndDate,
                    Link = model.Link,
                    CreateDate = DateTime.Now,
                    StartDate = model.StartDate,
                };
                await _context.Sliders.AddAsync(NewSlider);
                await Save();
                return true;
                
            }
            catch
            {
                throw new Exception("Somthin is wrong Check Your Information and try again");
            }
        }

        public async Task<bool> DeleteByIDAsync(Guid id)
        {
            Slider sliderById = await GetByIDAsync(id);
            if(sliderById != null)
            {
                _context.Sliders.Remove(sliderById);
                await Save();
                return true;
            }
            return false;
        }



        public async Task<bool> UpdateByIDAsync(Slider model)
        {
            var getSliderById = await GetByIDAsync(model.ID);
            if(getSliderById != null)
            {
                getSliderById.Link = model.Link;
                getSliderById.Title = model.Title;
                getSliderById.IsActive = model.IsActive;
                getSliderById.EndDate = model.EndDate;
                getSliderById.StartDate = model.StartDate;
                getSliderById.Description = model.Description;
                getSliderById.Tag = model.Tag;
                getSliderById.UpdateDate = DateTime.Now;
                
                await Save();
                return true;
            }
            return false;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
             _context.DisposeAsync();
        }
    }
}
