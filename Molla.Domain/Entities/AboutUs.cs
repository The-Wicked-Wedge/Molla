using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities
{
    public class AboutUs : BaseEntity,IEntity
    {
        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string CoWorkers { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }

    }

}
