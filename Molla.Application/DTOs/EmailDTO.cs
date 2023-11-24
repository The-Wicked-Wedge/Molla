using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs
{
    public class EmailDTO
    {
        public string Subject { get; set; } = "No Subject";
        public string Reciever { get; set; }
        public string Body { get; set; } = "Emty";
    }
}
