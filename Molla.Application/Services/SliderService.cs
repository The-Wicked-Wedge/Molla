using Microsoft.EntityFrameworkCore;
using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.Interfaces;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;

namespace Molla.Application.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IPhotoService _photoService;
        private readonly IApplicationUnitOfWork _uow;

        public SliderService(ISliderRepository sliderRepository,
            IPhotoService photoService,
            IApplicationUnitOfWork applicationUnitOfWork)
        {
            _photoService = photoService;
            _sliderRepository = sliderRepository;
            _uow = applicationUnitOfWork;
        }


        public async Task<bool> CreateAsync(SliderDTO model)
        {

            var addPhoto = await _photoService.AddPhotoAsync(model.ImageFile);
            model.ImageSource = addPhoto.Uri.ToString();
            IEnumerable<SliderDTO> slidersLists = await GetAllAsync();

            if (slidersLists.Count() < 5 && model.ImageSource != null && model.StartDate < model.EndDate)
            {

                var x = await IsAnyActiveSlider();
                if (x && model.IsActive == true)
                {
                    model.IsActive = false;
                    Slider reverseDTO = model.ReverseDTO();
                    bool result = await _sliderRepository.Create(reverseDTO);
                    if (result)
                    {
                        return await _uow.SaveChangesAsync();
                    }
                    else
                    {
                        await _photoService.DeletePhotoAsync(model.ImageSource);
                        return false;
                    }
                }
                else
                {
                    Slider reverseDTO = model.ReverseDTO();
                    bool result = await _sliderRepository.Create(reverseDTO);
                    if (result)
                    {
                        return await _uow.SaveChangesAsync();
                    }
                    else
                    {
                        await _photoService.DeletePhotoAsync(model.ImageSource);
                        return false;
                    }
                }

            }
            return false;
        }
        public async Task<bool> DeleteByIDAsync(Guid id)
        {
            SliderDTO x = await GetByIDAsync(id);
            if (x != null)
            {
                var resault = _sliderRepository.Delete(x.ReverseDTO());
                if (resault)
                {
                    await _photoService.DeletePhotoAsync(x.ImageSource);
                    return await _uow.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            return false;

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
            if (model.ImageFile != null)
            {
                var addNewPhoto = await _photoService.AddPhotoAsync(model.ImageFile);
                model.ImageSource = addNewPhoto.Uri.ToString();
                await _photoService.DeletePhotoAsync(model.ImageSource);
            }
            Slider reverseDTO = model.ReverseDTO();
            if (reverseDTO != null)
            {
                bool result = _sliderRepository.Update(reverseDTO);
                if (result)
                {
                    return await _uow.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
