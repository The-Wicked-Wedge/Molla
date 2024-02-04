using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.Extensions
{
    public static class OFFTicketGenerator
    {
        public static int GenerateOFFTicket(int lowest , int highest)
        {
            return new Random().Next(lowest, highest + 1);
        }
    }
}
