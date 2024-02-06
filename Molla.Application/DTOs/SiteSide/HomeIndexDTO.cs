using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs.SiteSide
{
    public class HomeIndexDTO
    {
        public IEnumerable<HomeSliderDTO> Slider { get; set; }
    }
}
