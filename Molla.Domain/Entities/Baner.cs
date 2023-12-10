using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities
{
    public class Baner : BaseEntity,IEntity
    {
        public string ImageSource { get; set; }
        public string Title { get; set; }                   //Also Refer As Name
        public string? BanerDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
