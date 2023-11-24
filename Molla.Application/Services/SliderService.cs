using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IPhotoService _photoService;
        private readonly ISliderRepository _sliderRepository;
        public SliderService(ISliderRepository sliderRepository, IPhotoService photoService)
        {
            this._sliderRepository = sliderRepository;
            this._photoService = photoService;
        }
        public async Task<bool> CreateAsync(SliderDTO model)
        {

            var addPhoto = await _photoService.AddPhotoAsync(model.ImageFile);
            string Source = addPhoto.Uri.ToString();

            model.ImageSource = Source;
            Slider reverseDTO = model.ReverseDTO();
            bool result = await _sliderRepository.CreateAsync(reverseDTO);
            return result;
        }
        public async Task<bool> DeleteByIDAsync(Guid id)
        {
            var x = await GetByIDAsync(id);
            bool result = await _sliderRepository.DeleteByIDAsync(id);
            
            if (result)
            {
                await _photoService.DeletePhotoAsync(x.ImageSource);
            }
            return result;
        }

        public async Task<IEnumerable<SliderDTO>> GetAllAsync()
        {
            IEnumerable<Slider> res = await _sliderRepository.GetAllAsync();
            IEnumerable<SliderDTO> toDTO = res.Select(s => s.ConvertToDTO()).ToList();
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
            if(model.ImageFile != null)
            {
                var addNewPhoto = await _photoService.AddPhotoAsync(model.ImageFile);
                model.ImageSource =  addNewPhoto.Uri.ToString();
                await _photoService.DeletePhotoAsync(model.ImageSource);           
            }
            Slider reverseDTO = model.ReverseDTO();
            bool result = await _sliderRepository.UpdateByIDAsync(reverseDTO);
            return result;
        }
    }
}
