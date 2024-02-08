using Microsoft.EntityFrameworkCore.Storage;
using Molla.Application.DTOs;
using Molla.Application.DTOs.AdminDashBoard;
using Molla.Application.Extensions;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.Entities.product;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
    public class AdminDashBoardService : IAdminDashboardService
    {
        private readonly IOFFRepository oFFRepository;
        private readonly IUserAccountService userAccountService;
        private readonly IAdminRepository adminRepository;
        private readonly IOrderRepository orderRepository;

        public AdminDashBoardService(IOFFRepository _OFFRepository,IUserAccountService _userAccountService 
                                        ,IAdminRepository adminRepository
                                        ,IOrderRepository orderRepository)
        {
            oFFRepository = _OFFRepository;
            userAccountService = _userAccountService;
            this.adminRepository = adminRepository;
            this.orderRepository = orderRepository;
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

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersSummary()
        {
            var all = await orderRepository.GetAllAsync();
            var allInDTO = new List<OrderDTO>();
            foreach (var item in all)
            {
                allInDTO.Add(item.CovertToDTO());
            }
            return allInDTO;
        }

        
    }
}
