using Molla.Application.DTOs.SiteSide;
using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Molla.Application.DTOs.AdminDashBoard;

namespace Molla.Application.Interfaces.IServices
{
	public interface ICategoryGroupService
	{
		Task<IEnumerable<AdminCategoryGroupDTO>> GetAllAsync();
		Task<AdminCategoryGroupDTO> GetByIDAsync(Guid id);
		Task<bool> Create(AdminCategoryGroupDTO model);
		Task<bool> Update(AdminCategoryGroupDTO model);
		Task<bool> DeleteByID(Guid id);
	}
}
