using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface ISliderRepository
    {
        Task<Slider> GetByIDAsync(Guid id);
        Task<bool> IsAnyActiveSlider();

        #region Generice Repository
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<bool> Create(Slider model);
        bool Update(Slider model);
        bool Delete(Slider model);
        #endregion
    }
}
