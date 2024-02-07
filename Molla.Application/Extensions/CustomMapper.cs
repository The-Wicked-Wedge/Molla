using Molla.Application.DTOs;
using Molla.Application.DTOs.AdminDashBoard;
using Molla.Application.DTOs.SiteSide;
using Molla.Application.Services;
using Molla.Domain.Entities;
using Molla.Domain.Entities.category;

namespace Molla.Application.Extensions
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
                Events = model.Events
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
                Events = model.Events
            };
        }

        public static HomeSliderDTO ToHomeSlider(this Slider model)
        {
            return new HomeSliderDTO() 
            { 
                ImageSource = model.ImageSource,
                Description = model.Description,
                Link = model.Link,
                Title = model.Title,
                Tag = model.Tag
            
            };
        }
        public static BanerDTO ConvertBanerToBanerDTO(this Baner baner)
        {
            return new BanerDTO
            {
                ID = baner.ID,
                BanerDescription = baner.BanerDescription,
                CreateDate = baner.CreateDate,
                EndDate = baner.EndDate,
                ImageSource = baner.ImageSource,
                StartDate = baner.StartDate,
                Title = baner.Title
            };
        }
        public static Baner ConvertBanerDTOToBaner(this BanerDTO baner)
        {
            return new Baner
            {
                ID = baner.ID,
                BanerDescription = baner.BanerDescription,
                CreateDate = baner.CreateDate,
                EndDate = baner.EndDate,
                ImageSource = baner.ImageSource,
                StartDate = baner.StartDate,
                Title = baner.Title,
                UpdateDate = baner.UpdateDate
            };
        }
        public static SocialLinkDTO ConvertToDTO(this SocialLink socialLink)
        {
            return new SocialLinkDTO()
            {
                ID = socialLink.ID,
                Name = socialLink.Name,
                Link = socialLink.Link,
                IconSource = socialLink.IconSource
            };
        }
        public static SocialLink ConvertToModel(this SocialLinkDTO socialLinkDTO)
        {
            return new SocialLink()
            {
                ID = socialLinkDTO.ID,
                Name = socialLinkDTO.Name,
                IconSource = socialLinkDTO.IconSource,
                Link = socialLinkDTO.Link
            };
        }

        public static AdminDashBoardUserDTO ConvertToDTO(this User user)
        {
            return new AdminDashBoardUserDTO()
            {
                Email = user.Email,
                Id = user.Id,
                NumberOFPurchases = 0,
                Phone = user.PhoneNumber,
                PurchasedValue = 0,
                UserName = user.UserName
            };
        }

        public static OrderDTO CovertToDTO(this Order order)
        {
            return new OrderDTO()
            {
                Id = order.Id,
                ProductId = order.ProductId,
                UserId = order.UserId,
                Price = order.Price,
                Completed = order.Completed
            };
        }
        public static Order CovertToModel(this OrderDTO orderDTO)
        {
            return new Order()
            {
                Id = orderDTO.Id,
                ProductId = orderDTO.ProductId,
                UserId = orderDTO.UserId,
                Price = orderDTO.Price,
                Completed = orderDTO.Completed
            };
        }
        public static AdminCategoryGroupDTO ConvertToDTO(this CategoryGroup categoryGroup)
        {
            return new AdminCategoryGroupDTO()
            {
                id = categoryGroup.ID,
                name = categoryGroup.Name
            };
        }
		public static CategoryGroup ConvertToModel(this AdminCategoryGroupDTO adminCategoryGroupDTO)
        {
            return new CategoryGroup()
            {
                ID = adminCategoryGroupDTO.id,
                Name = adminCategoryGroupDTO.name
            };
        }
	}
}
