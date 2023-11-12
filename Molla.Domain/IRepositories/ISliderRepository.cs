using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface ISliderRepository:IDisposable
    {
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<Slider> GetByIDAsync(Guid id);
        Task<bool> CreateAsync(Slider model);
        Task<bool> UpdateByIDAsync(Slider model);
        Task<bool> DeleteByIDAsync(Guid id);
        Task Save();


    }
}
