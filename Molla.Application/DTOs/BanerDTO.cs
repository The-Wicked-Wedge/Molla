using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs
{
    public class BanerDTO
    {
        [Key]
        public Guid ID { get; set; }
        [Display(Name = "Create date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Update date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}")]
        public DateTime? UpdateDate { get; set; }
        public string ImageSource { get; set; }

        [Display(Name = "نمایش از تاریخ و ساعت")]
        [Required(ErrorMessage = "please enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "تا تاریخ و ساعت")]
        [Required(ErrorMessage = "please enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "Baner Can't Have Null Title")]
        public string Title { get; set; }                    

        [Display(Name = "توضیحات")]
        public string? BanerDescription { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? Error { get; set; }
    }
}
