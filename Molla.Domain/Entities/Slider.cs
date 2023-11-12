﻿using Molla.Domain.Common;
using Molla.Domain.Enums;
using Molla.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Molla.Domain.Entities
{
    public class Slider:BaseEntity
    {

        public required string ImageSource { get; set; }
        [Display(Name = "Start slider")]
        [Required(ErrorMessage = "please enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End slider")]
        [Required(ErrorMessage = "please enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:MM AM/PM}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "make it main slide of slider")]
        [Required(ErrorMessage = "please enter {0}")]
        public bool IsActive { get; set; }

        [Display(Name = "Title")]
        [MaxLength(70, ErrorMessage = "BloggerName must be 10 characters or less"), MinLength(5)]
        [Required(ErrorMessage = "please enter {0}")]
        public required string Title { get; set; }

        [Display(Name = "Short description")]
        [DataType(DataType.MultilineText)]
        [MaxLength(150, ErrorMessage = "BloggerName must be 10 characters or less"), MinLength(10)]
        [Required(ErrorMessage = "please enter {0}")]
        public required string Description { get; set; }

        [Display(Name = "Tags")]
        [Required(ErrorMessage = "please enter {0}")]
        public required string Tag { get; set; }

        [Display(Name = "Link to")]
        [Required(ErrorMessage = "please enter {0}")]
        [Url(ErrorMessage ="Enter valid URL")]
        public string? Link { get; set; }

    }
}
