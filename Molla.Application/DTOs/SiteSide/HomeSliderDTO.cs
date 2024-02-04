using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs.SiteSide
{
    public class HomeSliderDTO
    {
        public required string ImageSource { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? Link { get; set; }

        public string? Tag { get; set; }

    }
}
