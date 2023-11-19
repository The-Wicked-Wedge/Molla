using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities
{
    public class Baner : BaseEntity
    {
        [Display(Name = "Image Source")]
        [Required(ErrorMessage ="Image Can't Be Null")]
        public string ImageSource { get; set; }

        [Display(Name ="Title")]
        [Required(ErrorMessage ="Baner Can't Have Null Title")]
        public string Title { get; set; }                   //Also Refer As Name

        [Display(Name ="Description")]
        public string? BanerDescription { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date Is Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End slider")]
        [Required(ErrorMessage = "End Date Is Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }


    }


}
