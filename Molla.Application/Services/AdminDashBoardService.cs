using Molla.Application.DTOs.AdminDashBoard;
using Molla.Application.Extensions;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
    public class AdminDashBoardService : IAdminDashboardService
    {
        private readonly IOFFRepository oFFRepository;
        private readonly IUserAccountService userAccountService;
        private readonly IAdminRepository adminRepository;

        public AdminDashBoardService(IOFFRepository _OFFRepository,IUserAccountService _userAccountService ,IAdminRepository adminRepository)
        {
            oFFRepository = _OFFRepository;
            userAccountService = _userAccountService;
            this.adminRepository = adminRepository;
        }
        public Task<bool> AddTicket(int OFFPercentage,string UserID)
        {
            return oFFRepository.Create(new Domain.Entities.AdminDashBoard.OFFModel() { OFFPercentage = OFFPercentage, UserId = UserID });
        }

        public async Task<IEnumerable<AdminDashBoardUserDTO>> ConfirmedEmailUsers()
        {
            var allConfirmedUsers = await adminRepository.GetAllEmailConfirmedUsers();
            var allInDTO =new  List<AdminDashBoardUserDTO>();
            foreach (var item in allConfirmedUsers)
            {
                allInDTO.Add(item.ConvertToDTO());
            }
            return allInDTO;
        }
        public async Task<IEnumerable<AdminDashBoardUserDTO>> GetAllUsers()
        {
            var allConfirmedUsers = await adminRepository.GetAllUsers();
            var allInDTO = new List<AdminDashBoardUserDTO>();
            foreach (var item in allConfirmedUsers)
            {
                allInDTO.Add(item.ConvertToDTO());
            }
            return allInDTO;
        }
        public async Task<AdminDashBoardUserDTO> GetUserById(string Id)
        {
            return (await adminRepository.GetUserById(Id)).ConvertToDTO();
        }
    }
}
