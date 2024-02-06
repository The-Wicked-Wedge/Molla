using Molla.Application.DTOs.SiteSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IServices
{
    public interface IHomeIndexService
    {
        Task<HomeIndexDTO> GetHomeAsync();
    }
}
