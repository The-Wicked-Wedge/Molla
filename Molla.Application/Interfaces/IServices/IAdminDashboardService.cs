using Molla.Application.DTOs;
using Molla.Application.DTOs.AdminDashBoard;
using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IServices
{
    public interface IAdminDashboardService
    {
        Task<IEnumerable<AdminDashBoardUserDTO>> GetAllUsers();
        Task<AdminDashBoardUserDTO> GetUserById(string Id);
        Task<bool> AddTicket(int OFFPercentage,string UserId);
        Task<IEnumerable<AdminDashBoardUserDTO>> ConfirmedEmailUsers();
        Task<IEnumerable<OrderDTO>> GetAllOrdersSummary();
    }
}
