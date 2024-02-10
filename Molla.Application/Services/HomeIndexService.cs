using Molla.Application.DTOs.SiteSide;
using Molla.Application.Extensions;

using Molla.Application.Interfaces.IServices;
using Molla.Domain.Entities;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
    public class HomeIndexService : IHomeIndexService
    {

        private readonly ISliderService _sliderService;

        public HomeIndexService(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<HomeIndexDTO> GetHomeAsync()
        {
             HomeIndexDTO homeIndexDTO = new HomeIndexDTO();

            homeIndexDTO.Slider = await _sliderService.GetHomeSliderAsync();

            return homeIndexDTO;
        }

    }
}
