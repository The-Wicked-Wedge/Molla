using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IAboutUsRepository
    {
        Task<AboutUs> GetAboutUsAsync();

        #region Generice Repository
        
        Task<bool> Create(AboutUs baner);
        bool Update(AboutUs baner);
        bool Delete(AboutUs model);
        #endregion
    }
}
