using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs
{
    public class SocialLinkDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public string IconSource { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
