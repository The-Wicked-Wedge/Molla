using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Domain.Entities
{
    public class SocialLink
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconSource { get; set; }
        public string Link { get; set; }
    }
}
