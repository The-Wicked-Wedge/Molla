using Molla.Application.DTOs;
using Molla.Application.Extensions;
using Molla.Application.Interfaces.IServices;
using Molla.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Services
{
    public class OrderService : IOrderService
    {
        public OrderService(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public IOrderRepository OrderRepository { get; set; }

        public async Task<bool> AddToOrders(OrderDTO orderDTO)
        {
            return await OrderRepository.Create(orderDTO.CovertToModel());
        }

        public async Task<float> AllPurchases()
        {
            var all = await OrderRepository.GetAllAsync();
            float total = 0;
            foreach (var item in all)
            {
                if (item.Completed)
                {
                    total += item.Price;
                }
            }
            return total;
        }

        public async Task<float> AllPurchasesByUser(string UserId)
        {
            var all = (await OrderRepository.GetAllAsync()).Where(i => i.UserId == UserId).ToList();
            float total = 0;
            foreach (var item in all)
            {
                if (item.Completed)
                    total += item.Price;
            }
            return total;
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var all = await OrderRepository.GetAllAsync();
            var allInDTO = new List<OrderDTO>();
            foreach (var item in all)
            {
                allInDTO.Add(item.CovertToDTO());
            }
            return allInDTO;
        }

        public async Task<OrderDTO> GetByIdAsync(int Id)
        {
            return (await OrderRepository.GetByIDAsync(Id)).CovertToDTO();
        }

        public async Task<bool> RemoveFromOrders(int Id)
        {
            return OrderRepository.Delete(await OrderRepository.GetByIDAsync(Id));
        }
    }
}
