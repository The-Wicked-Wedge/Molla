using Molla.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Interfaces.IPoviders
{
    public interface ISMSProvider
    {
        Task<Result> SendAsync(string receiver, string text);
    }
}
