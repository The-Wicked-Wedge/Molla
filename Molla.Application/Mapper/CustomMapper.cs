using Molla.Application.DTOs;
using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Mapper
{
    public static class CustomMapper
    {
        public static SliderDTO ConvertToDTO(this Slider model)
        {
            return new SliderDTO
            {
                CreateDate = model.CreateDate,
                Description = model.Description,
                ImageSource = model.ImageSource,
                Tag = model.Tag,
                Title = model.Title,
                EndDate = model.EndDate,
                ID = model.ID,
                IsActive = model.IsActive,
                Link = model.Link,
                StartDate = model.StartDate,
            };
        }
        public static Slider ReverseDTO(this SliderDTO model) 
        {
            return new Slider
            {
                CreateDate = model.CreateDate,
                Description = model.Description,
                ImageSource = model.ImageSource,
                Tag = model.Tag,
                Title = model.Title,
                EndDate = model.EndDate,
                ID = model.ID,
                IsActive = model.IsActive,
                Link = model.Link,
                StartDate = model.StartDate,
                UpdateDate = model.UpdateDate,
            };
        }

    }
}
