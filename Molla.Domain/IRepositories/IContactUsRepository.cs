using Molla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.IRepositories
{
    public interface IContactUsRepository
    {
        Task<ContactUs> GetByIdAsync(Guid id);

        #region Generice Repository
        Task<IEnumerable<ContactUs>> GetAllAsync();
        Task<bool> Create(ContactUs baner);
        bool Update(ContactUs baner);
        bool Delete(ContactUs model);
        #endregion
    }
}
