using Molla.Application.Extensions;
using Molla.Application.Interfaces.IPoviders;

namespace Molla.Infrastructure.SMSProvider
{
    public class SMSProvider : ISMSProvider
    {
        public Task<Result> SendAsync(string receiver, string text)
        {
            throw new NotImplementedException();
        }
    }
}
