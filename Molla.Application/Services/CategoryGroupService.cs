using Molla.Application.DTOs.AdminDashBoard;
using Molla.Application.Extensions;
using Molla.Application.Interfaces;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.Entities.category;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
	public class CategoryGroupService : ICategoryGroupService
	{
		private readonly ICategoryGroupRepository _categoryGroupRepository;
		private readonly IApplicationUnitOfWork _uow;
		public CategoryGroupService(ICategoryGroupRepository categoryGroupRepository, IApplicationUnitOfWork uow)
        {
			_categoryGroupRepository = categoryGroupRepository;
			_uow = uow;
		}
		public async Task<IEnumerable<AdminCategoryGroupDTO>> GetAllAsync()
		{
			return (await _categoryGroupRepository.GetAllAsync()).Select(o => o.ConvertToDTO());
		}
		public async Task<bool> Create(AdminCategoryGroupDTO model)
		{
			if (model != null)
			{
				CategoryGroup categoryGroup = model.ConvertToModel();
				bool res = await _categoryGroupRepository.Create(categoryGroup);
				if (res)
				{
					return await _uow.SaveChangesAsync();
				}
			}
			return false;
		}
		public async Task<bool> DeleteByID(Guid id)
		{
			CategoryGroup categoryGroup = await _categoryGroupRepository.GetByIdAsync(id);
			if (categoryGroup != null)
			{
				bool res = _categoryGroupRepository.Delete(categoryGroup);
				if (res)
				{
					return await _uow.SaveChangesAsync();
				}
			}
			return false;
		}
		public async Task<AdminCategoryGroupDTO> GetByIDAsync(Guid id)
		{
			CategoryGroup categoryGroup = await _categoryGroupRepository.GetByIdAsync(id);
			AdminCategoryGroupDTO res = categoryGroup.ConvertToDTO();
			return res;
		}
		public async Task<bool> Update(AdminCategoryGroupDTO model)
		{
			if (model != null)
			{
				CategoryGroup categoryGroup = model.ConvertToModel();
				categoryGroup.UpdateDate = DateTime.Now;
				bool res = _categoryGroupRepository.Update(categoryGroup);
				if (res)
				{
					return await _uow.SaveChangesAsync();
				}
			}
			return false;
		}
	}
}
