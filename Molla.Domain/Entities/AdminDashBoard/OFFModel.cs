using Molla.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities.AdminDashBoard
{
    public class OFFModel : IEntity
    {
        public int Id { get; set; }
        public int OFFPercentage { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
    }
}
