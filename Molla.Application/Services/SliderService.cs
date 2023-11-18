using Microsoft.AspNetCore.Http;
using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.IServices;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        public SliderService(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        public async Task<bool> CreateAsync(SliderDTO model)
        {
            var imageName =  Guid.NewGuid().ToString() + Path.GetExtension(model.ImageSource);

            model.ImageFile.AddImageToServer(imageName,model.ImageSource,270,270);
            Slider reverseDTO = model.ReverseDTO();
            bool result = await _sliderRepository.CreateAsync(reverseDTO);

            return result; 
        }
        public async Task<bool> DeleteByIDAsync(Guid id)
        {
            bool result = await _sliderRepository.DeleteByIDAsync(id);
            return result;
        }

        public async Task<IEnumerable<SliderDTO>> GetAllAsync()
        {
            IEnumerable<Slider> res = await _sliderRepository.GetAllAsync();
            IEnumerable<SliderDTO> toDTO = res.Select(s=>s.ConvertToDTO()).ToList();
            return toDTO;
        }

        public async Task<SliderDTO> GetByIDAsync(Guid id)
        {
            Slider x = await _sliderRepository.GetByIDAsync(id);
            SliderDTO res = x.ConvertToDTO();
            return res;
        }

        public async Task<bool> IsAnyActiveSlider()
        {
            bool x = await _sliderRepository.IsAnyActiveSlider();
            return x;
        }

        public async Task<bool> UpdateByIDAsync(SliderDTO model)
        {
            Slider reverseDTO = model.ReverseDTO();
            bool result = await _sliderRepository.UpdateByIDAsync(reverseDTO);
            return result;
        }
    }
}
