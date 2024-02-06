using Molla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<OrderDTO> GetByIdAsync(int Id);
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<bool> AddToOrders(OrderDTO orderDTO);
        Task<bool> RemoveFromOrders(int Id);
        Task<float> AllPurchases();
        Task<float> AllPurchasesByUser(string UserId);
    }
}
